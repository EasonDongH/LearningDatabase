using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using ArcFace.DAL;
using ArcFace.Models;
using ArcFace.Base;

namespace ArcFace.BLL
{
    public enum DataBaseTable
    {
        face_sample, face_blacklist
    }

    public class ReplaceSampleDataControl<T> where T : IReplaceSampleDataModel, new()
    {
        /// <summary>
        /// 需要升级到该版本
        /// </summary>
        public const decimal sampleDataVer = 2.0M;
        /// <summary>
        /// 每次从数据库读取的数据量
        /// 其sampleface字段大小约20k，量内存大小取值
        /// </summary>
        private const int numberForPerQuery = 50;
        /// <summary>
        /// 当队列中数据量降低到该值时进行数据读取
        /// 所以内存中最大时可能存有(numberForPerQuery + numberWhenNeedRead)个数据
        /// </summary>
        private const int numberWhenNeedRead = 10;
        /// <summary>
        /// 每达到该值即进行一次数据更新，减少数据库连接次数
        /// 其在保存sampleface字段（保存以在界面展示）的同时，需要再保存大约1k的sampledata字段
        /// </summary>
        private const int numberForPerUpdate = 100;
        /// <summary>
        /// 需要处理的总数据量
        /// </summary>
        private int totalSize = 0;
        public int TotalSize { get { return totalSize; } }
        /// <summary>
        /// 已处理完成的数据量
        /// </summary>
        private int successProcessedSize = 0;
        /// <summary>
        /// 处理失败的数据量
        /// </summary>
        private int failProcessedSize = 0;
        /// <summary>
        ///  存放处理失败的图像数据信息
        /// </summary>
        private List<ImageFaceDataModel> failProcessedImgList = new List<ImageFaceDataModel>();
        /// <summary>
        /// 线程安全的队列
        /// ReadData()写，ProcessData()读
        /// </summary>
        ConcurrentQueue<T> waitForProcessQueue = new ConcurrentQueue<T>();
        /// <summary>
        /// ProcessData()写，WriteData()读
        /// </summary>
        ConcurrentQueue<T> waitForWriteQueue = new ConcurrentQueue<T>();
        /// <summary>
        /// 单张图像开始处理之前要做的事
        /// 展示当前处理图像
        /// </summary>
        private Action<byte[]> BeforeProcess = null;
        /// <summary>
        /// 单张处理完成后要做的事
        /// 更新当前已处理完成的数据量，展示当前图像处理时间
        /// </summary>
        private Action<int, double> AfterProcess = null;
        /// <summary>
        /// 任务全部结束后要做的事
        /// </summary>
        private Action<int> EndProcess = null;
        /// <summary>
        /// 特殊情况的处理
        /// 人脸数不等于1时的处理方式
        /// </summary>
        private Action<int, T> HandleSpecialCase = null;
        /// <summary>
        /// 发生错误时要做的事
        /// </summary>
        private Action<Exception> HandleError = null;
        /// <summary>
        /// 取消标记
        /// </summary>
        CancellationTokenSource cancelTokenSource = null;

        private IRelpaceSampleDataDAL _dal = null;

        private PagingQueryControl<T> pagingQuery = null;

        public ReplaceSampleDataControl(DataBaseTable tableName, Action<byte[]> beforeProcess, Action<int, double> afterProcess, Action<int> endProcess, Action<int, T> handleSpecialCase, Action<Exception> handleError, CancellationTokenSource cancelTokenSource)
        {
            this.BeforeProcess = beforeProcess;
            this.AfterProcess = afterProcess;
            this.EndProcess = endProcess;
            this.HandleSpecialCase = handleSpecialCase;
            this.HandleError = handleError;
            this.cancelTokenSource = cancelTokenSource;

            // 简单工厂：创建DAL
            switch (tableName)
            {
                case DataBaseTable.face_sample:
                    this._dal = new FaceSampleDAL();
                    break;
                default:
                    throw new Exception("DAL创建失败！");
            }

            try
            {
                this.totalSize = this._dal.GetNeedUpdateAmount(sampleDataVer);
            }
            catch (Exception ex)
            {
                this.HandleError(ex);
            }
            this.pagingQuery = new PagingQueryControl<T>(this.totalSize, numberForPerQuery, GetPagingData);
        }

        private IEnumerable<T> GetPagingData(int startIndex, int num)
        {
            return this._dal.GetPagingData<T>(startIndex, num, sampleDataVer);
        }

        public void StartProcessData()
        {
            Task.Factory.StartNew(() =>
            {
                ReadData();
                Thread.Sleep(100);
                ProcessData();
            });
        }

        private void ReadData()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                try
                {
                    // 如果未取消线程，则继续运行
                    while (!this.cancelTokenSource.IsCancellationRequested)
                    {
                        // 数据库没有数据需要读取，线程终止
                        if (this.pagingQuery.HasDataWaitForRead == false)
                            break;
                        if (this.waitForProcessQueue.Count() >= numberWhenNeedRead)
                            continue;
                        List<T> models = this.pagingQuery.GetNextPagingData();
                        foreach (var model in models)
                        {
                            this.waitForProcessQueue.Enqueue(model);
                        }
                    }
                }
                catch (Exception ex)
                {

                    this.HandleError(ex);
                }

            }, this.cancelTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        private void ProcessData()
        {
            DateTime start, end;
            AsfFaceControl faceControl = new AsfFaceControl();

            Task task = Task.Factory.StartNew(() =>
            {
                try
                {
                    //如果未取消线程，则继续运行
                    while (!this.cancelTokenSource.IsCancellationRequested)
                    {
                        // 没有数据等待处理且数据库没有数据等待读取，线程终止
                        if (this.waitForProcessQueue.Count == 0 && this.pagingQuery.HasDataWaitForRead == false)
                        {
                            break;
                        }
                        T model = default(T);
                        if (this.waitForProcessQueue.TryDequeue(out model) == false || model == null)
                            continue;

                        // 将当前图像刷至UI
                        this.BeforeProcess(model.FaceImage);
                        //Task.Factory.StartNew(() => { this.BeforeProcess(model.sampleface); });
                        start = DateTime.Now;

                        ImageFaceDataModel imgFace = new ImageFaceDataModel();
                        faceControl.GetFaceDatas(ImageHelper.BytesToBitmap(model.FaceImage), ref imgFace);
                        // 图像有多个人脸或没有人脸时
                        if (imgFace.FaceNumer != 1)
                        {
                            this.failProcessedSize += 1;
                            this.HandleSpecialCase(this.failProcessedSize, model);
                            //Task.Factory.StartNew(() => { this.HandleSpecialCase(this.failProcessedSize, model); });
                            imgFace.Id = model.Id;
                            this.failProcessedImgList.Add(imgFace);
                            continue;
                        }

                        model.FaceFeature = imgFace.FaceDatas[0].FaceFeature;
                        //model.sampledataver = ReplaceSampleDataControl.sampleDataVer;

                        this.successProcessedSize += 1;
                        this.waitForWriteQueue.Enqueue(model);

                        end = DateTime.Now;
                        double time = end.Subtract(start).TotalMilliseconds;
                        if (successProcessedSize > 43)
                        {
                            Console.WriteLine(failProcessedSize);
                        }
                        this.AfterProcess(this.successProcessedSize, time);

                        // 更新数据库
                        WriteDataSync(false);
                    }
                }
                catch (Exception ex)
                {
                    this.HandleError(ex);
                }
            }, this.cancelTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            task.ContinueWith(t =>
            {
                try
                {
                    WriteDataSync(true);
                    this.EndProcess(this.successProcessedSize);
                }
                catch (Exception ex)
                {
                    this.HandleError(ex);
                }
                
            });
        }

        /// <summary>
        /// 同步写数据库
        /// </summary>
        /// <param name="isEnd">true：将队列中所有数据写入；false：在有大于等于指定数量的数据后进行写入</param>
        private void WriteDataSync(bool isEnd)
        {
            if (isEnd == false && this.waitForWriteQueue.Count < numberForPerUpdate)
                return;
            try
            {
                T model = default(T);
                List<T> models = new List<T>();
                while (this.waitForWriteQueue.Count > 0)
                {
                    if (this.waitForWriteQueue.TryDequeue(out model))
                    {
                        models.Add(model);
                    }
                }
                int update_Result = this._dal.Update<T>(models);
                if (update_Result != models.Count)
                {
                    throw new Exception(string.Format("更新数据失败！应更新：{0}，实际更新：{1}。", models.Count, update_Result));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ImageFaceDataModel GetImgFaceDataById(string id)
        {
            return this.failProcessedImgList.Find(img => img.Id == id);
        }

        public bool UpdateSingleData(string id, byte[] feature)
        {
            T model = new T();
            model.Id = id;
            model.FaceFeature = feature;
            int update_Result = this._dal.Update<T>(model);
            return update_Result > 0;
        }
    }
}
