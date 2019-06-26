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
    public class ReplaceSampleDataControl
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
        ConcurrentQueue<FaceSampleModel> waitForProcessQueue = new ConcurrentQueue<FaceSampleModel>();
        /// <summary>
        /// ProcessData()写，WriteData()读
        /// </summary>
        ConcurrentQueue<FaceSampleModel> waitForWriteQueue = new ConcurrentQueue<FaceSampleModel>();
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
        private Action<int, FaceSampleModel> HandleSpecialCase = null;
        /// <summary>
        /// 发生错误时要做的事
        /// </summary>
        private Action<Exception> HandleError = null;
        /// <summary>
        /// 取消标记
        /// </summary>
        CancellationTokenSource cancelTokenSource = null;

        private FaceSampleDAL objFaceSampleDAL = new FaceSampleDAL();

        private PagingQueryControl<FaceSampleModel> pagingQuery = null;

        public ReplaceSampleDataControl(Action<byte[]> beforeProcess, Action<int, double> afterProcess, Action<int> endProcess, Action<int, FaceSampleModel> handleSpecialCase, Action<Exception> handleError, CancellationTokenSource cancelTokenSource)
        {
            this.BeforeProcess = beforeProcess;
            this.AfterProcess = afterProcess;
            this.EndProcess = endProcess;
            this.HandleSpecialCase = handleSpecialCase;
            this.HandleError = handleError;
            this.cancelTokenSource = cancelTokenSource;

            try
            {
                this.totalSize = this.objFaceSampleDAL.GetNeedUpdateAmount(sampleDataVer);
            }
            catch (Exception ex)
            {
                this.HandleError(ex);
            }
            this.pagingQuery = new PagingQueryControl<FaceSampleModel>(this.totalSize, numberForPerQuery, this.objFaceSampleDAL.GetPagingData);
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
            try
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    // 如果未取消线程，则继续运行
                    while (!this.cancelTokenSource.IsCancellationRequested)
                    {
                        // 数据库没有数据需要读取，线程终止
                        if (this.pagingQuery.HasDataWaitForRead == false)
                            break;
                        if (this.waitForProcessQueue.Count() >= numberWhenNeedRead)
                            continue;
                        List<FaceSampleModel> models = this.pagingQuery.GetNextPagingData();
                        foreach (var model in models)
                        {
                            this.waitForProcessQueue.Enqueue(model);
                        }
                    }
                }, this.cancelTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
            catch (Exception ex)
            {
                this.HandleError(ex);
            }
        }

        private void ProcessData()
        {
            DateTime start, end;
            AsfFaceControl faceControl = new AsfFaceControl();
            try
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    //如果未取消线程，则继续运行
                    while (!this.cancelTokenSource.IsCancellationRequested)
                    {
                        // 没有数据等待处理且数据库没有数据等待读取，线程终止
                        if (this.waitForProcessQueue.Count == 0 && this.pagingQuery.HasDataWaitForRead == false)
                        {
                            this.EndProcess(this.successProcessedSize);
                            break;
                        }
                        FaceSampleModel model = null;
                        if (this.waitForProcessQueue.TryDequeue(out model) == false || model == null)
                            continue;

                        // 将当前图像刷至UI
                        this.BeforeProcess(model.sampleface);
                        //Task.Factory.StartNew(() => { this.BeforeProcess(model.sampleface); });
                        start = DateTime.Now;

                        ImageFaceDataModel imgFace = new ImageFaceDataModel();
                        faceControl.GetFaceDatas(ImageHelper.BytesToBitmap(model.sampleface), ref imgFace);
                        // 图像有多个人脸或没有人脸时
                        if (imgFace.FaceNumer != 1)
                        {
                            this.failProcessedSize += 1;
                            this.HandleSpecialCase(this.failProcessedSize, model);
                            //Task.Factory.StartNew(() => { this.HandleSpecialCase(this.failProcessedSize, model); });
                            imgFace.Id = model.id;
                            this.failProcessedImgList.Add(imgFace);
                            continue;
                        }

                        model.sampledata = imgFace.FaceDatas[0].FaceFeature;
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
                }, this.cancelTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

                task.ContinueWith(t =>
                {
                    WriteDataSync(true);
                });
            }
            catch (Exception ex)
            {
                this.HandleError(ex);
            }
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
                FaceSampleModel model = null;
                List<FaceSampleModel> models = new List<FaceSampleModel>();
                while (this.waitForWriteQueue.Count > 0)
                {
                    if (this.waitForWriteQueue.TryDequeue(out model))
                    {
                        models.Add(model);
                    }
                }
                int update_Result = this.objFaceSampleDAL.Update(models);
                if (update_Result != models.Count)
                {
                    throw new Exception(string.Format("更新数据失败！应更新：{0}，实际更新：{1}。", models.Count, update_Result));
                }
            }
            catch (Exception ex)
            {
                this.HandleError(ex);
            }
        }

        public ImageFaceDataModel GetImgFaceDataById(string id)
        {
            return this.failProcessedImgList.Find(img => img.Id == id);
        }

        public bool UpdateSingleData(string id, byte[] feature)
        {
            FaceSampleModel model = new FaceSampleModel();
            model.id = id;
            model.sampledata = feature;
            int update_Result = this.objFaceSampleDAL.Update(model);
            return update_Result > 0;
        }
    }
}
