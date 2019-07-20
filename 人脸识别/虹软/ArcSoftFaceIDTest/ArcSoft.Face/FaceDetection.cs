using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ArcSoft.Face
{
    public class FaceDetection
    {
        private IntPtr hEngine;
        private Bitmap image1;
        private Bitmap image2;
        BitmapImage bitmapImage;

        /// <summary>
        /// 人脸检测
        /// </summary>
        /// <param name="hEngine"></param>
        /// <param name="image"></param>
        public FaceDetection(IntPtr hEngine)
        {
            this.hEngine = hEngine;
        }

        /// <summary>
        /// 人脸检测
        /// </summary>
        /// <param name="hEngine"></param>
        /// <param name="image"></param>
        public FaceDetection(IntPtr hEngine, Bitmap image)
        {
            this.hEngine = hEngine;
            this.image1 = image;
        }

        /// <summary>
        /// 人脸检测
        /// </summary>
        /// <param name="hEngine"></param>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        public FaceDetection(IntPtr hEngine, Bitmap image1, Bitmap image2)
        {
            this.hEngine = hEngine;
            this.image1 = image1;
            this.image2 = image2;
        }

        /// <summary>
        /// 获取人脸检测的结果
        /// </summary>
        /// <returns></returns>
        public MultiFaceInfo DetectFaces()
        {
            bitmapImage = new BitmapImage(image1);
            bitmapImage.ParseImage();
            MultiFaceInfo faceInfo = new MultiFaceInfo();
            try
            {
                ResultCode result = (ResultCode)ASFAPI.ASFDetectFaces(hEngine, bitmapImage.Width, bitmapImage.Height, bitmapImage.Format, bitmapImage.ImageData, ref faceInfo);
                if (result == ResultCode.MOK)
                {
                    return faceInfo;
                }
                else
                {
                    throw new Exception(result.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SingleFaceInfo GetRect(Bitmap image)
        {
            SingleFaceInfo info = new SingleFaceInfo();
            try
            {
                BitmapImage bitmapImage = null;
                var multiFaceInfo = DetectFaces(image, out bitmapImage);

                if (multiFaceInfo.faceNum > 0)
                {
                    info = new SingleFaceInfo();
                    Mrect mrect = new Mrect();
                    int[] orientArray = new int[multiFaceInfo.faceNum];
                    Marshal.Copy(multiFaceInfo.faceOrient, orientArray, 0, orientArray.Length);
                    info.faceOrient = orientArray[0];

                    byte[] byteArray = new byte[4 * 4];
                    Marshal.Copy(multiFaceInfo.faceRect, byteArray, 0, byteArray.Length);
                    int size = Marshal.SizeOf(mrect);
                    IntPtr buffer = Marshal.AllocHGlobal(size);
                    try
                    {
                        Marshal.Copy(byteArray, 0, buffer, size);
                        mrect = (Mrect)Marshal.PtrToStructure(buffer, typeof(Mrect));
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(buffer);
                    }
                    info.faceRect = mrect;

                }
                else
                {
                    info.faceOrient = -1;
                }
              
            }
            catch (Exception ex)
            {

            }
            return info;
        }

        /// <summary>
        /// 获取单人脸信息
        /// </summary>
        /// <param name="image"></param>
        /// <param name="minFaceSize"></param>
        /// <returns></returns>
        public SingleFaceInfo GetRect(Bitmap image, int minFaceSize)
        {
            SingleFaceInfo info = new SingleFaceInfo();
            try
            {
                BitmapImage bitmapImage = null;
                MultiFaceInfo multiFaceInfo = DetectFaces(image, out bitmapImage);

                if (multiFaceInfo.faceNum > 0)
                {
                    info = new SingleFaceInfo();
                    Mrect mrect = new Mrect();
                    int[] orientArray = new int[multiFaceInfo.faceNum];
                    Marshal.Copy(multiFaceInfo.faceOrient, orientArray, 0, orientArray.Length);
                    info.faceOrient = orientArray[0];

                    byte[] byteArray = new byte[4 * 4];
                    Marshal.Copy(multiFaceInfo.faceRect, byteArray, 0, byteArray.Length);
                    int size = Marshal.SizeOf(mrect);
                    IntPtr buffer = Marshal.AllocHGlobal(size);
                    try
                    {
                        Marshal.Copy(byteArray, 0, buffer, size);
                        mrect = (Mrect)Marshal.PtrToStructure(buffer, typeof(Mrect));
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(buffer);
                    }
                    info.faceRect = mrect;

                }
                else
                {
                    info.faceOrient = -1;
                }

            }
            catch (Exception ex)
            {

            }
            return info;
        }

        /// <summary>
        /// 获取活体检测信息
        /// </summary>
        /// <returns></returns>
        public int GetLivenessInfo()
        {
            int isLive = -1;
            try
            {
                var faceinfo = DetectFaces();
                ASFAPI.ASFProcess(hEngine, bitmapImage.Width, bitmapImage.Height, bitmapImage.Format, bitmapImage.ImageData, ref faceinfo, (int)(EngineMode.ASF_LIVENESS));
                LivenessInfo info = new LivenessInfo();
                ASFAPI.ASFGetLivenessScore(hEngine, ref info);
                int[] infoArray = new int[info.num];
                Marshal.Copy(info.isLive, infoArray, 0, infoArray.Length);
                isLive = infoArray[0];
            }
            catch (Exception ex)
            {

            }
            return isLive;
        }

        /// <summary>
        /// 获取人脸的数量
        /// </summary>
        /// <returns></returns>
        public int FindFaceNum()
        {

            MultiFaceInfo faceInfo = DetectFaces();
            return faceInfo.faceNum;

        }

        /// <summary>
        /// 获取年龄信息
        /// </summary>
        /// <returns></returns>
        public int GetAge()
        {
            var faceinfo = DetectFaces();
            ASFAPI.ASFProcess(hEngine, bitmapImage.Width, bitmapImage.Height, bitmapImage.Format, bitmapImage.ImageData, ref faceinfo, (int)(EngineMode.ASF_AGE));
            AgeInfo age = new AgeInfo();
            ASFAPI.ASFGetAge(hEngine, ref age);
            int[] ageArray = new int[age.num];
            Marshal.Copy(age.ageArray, ageArray, 0, ageArray.Length);
            return ageArray[0];
        }

        /// <summary>
        /// 获取性别信息
        /// </summary>
        /// <returns></returns>
        public string GetGender()
        {
            var faceinfo = DetectFaces();
            ASFAPI.ASFProcess(hEngine, bitmapImage.Width, bitmapImage.Height, bitmapImage.Format, bitmapImage.ImageData, ref faceinfo, (int)(EngineMode.ASF_GENDER));
            GenderInfo gender = new GenderInfo();
            ASFAPI.ASFGetGender(hEngine, ref gender);
            int[] genderArray = new int[gender.num];
            Marshal.Copy(gender.genderArray, genderArray, 0, genderArray.Length);
            switch (genderArray[0])
            {
                case 0:
                    return "男";
                case 1:
                    return "女";
                default:
                    return "未知";
            }
        }

        /// <summary>
        /// 获取人脸特征
        /// </summary>
        /// <returns></returns>
        public byte[] GetFaceFeature(Bitmap image)
        {
            try
            {
                BitmapImage bitmapImage = null;
                var multiFaceInfo = DetectFaces(image, out bitmapImage);

                if (multiFaceInfo.faceNum > 0)
                {
                    SingleFaceInfo info = new SingleFaceInfo();
                    Mrect mrect = new Mrect();
                    int[] orientArray = new int[multiFaceInfo.faceNum];
                    Marshal.Copy(multiFaceInfo.faceOrient, orientArray, 0, orientArray.Length);
                    info.faceOrient = orientArray[0];

                    byte[] byteArray = new byte[4 * 4];
                    Marshal.Copy(multiFaceInfo.faceRect, byteArray, 0, byteArray.Length);
                    int size = Marshal.SizeOf(mrect);
                    IntPtr buffer = Marshal.AllocHGlobal(size);
                    try
                    {
                        Marshal.Copy(byteArray, 0, buffer, size);
                        mrect = (Mrect)Marshal.PtrToStructure(buffer, typeof(Mrect));
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(buffer);
                    }
                    info.faceRect = mrect;

                    FaceFeature feature = new FaceFeature();
                    IntPtr ptr1 = Marshal.AllocHGlobal(Marshal.SizeOf(info));
                    Marshal.StructureToPtr(info, ptr1, false);

                    var result = ASFAPI.ASFFaceFeatureExtract(hEngine, bitmapImage.Width, bitmapImage.Height, bitmapImage.Format, bitmapImage.ImageData, ptr1, ref feature);
                    Marshal.FreeHGlobal(ptr1);
                    byte[] data = new byte[1032];
                    Marshal.Copy(feature.feature, data, 0, 1032);
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取人脸检测结果
        /// </summary>
        /// <param name="image"></param>
        /// <param name="bitmapImage"></param>
        /// <returns></returns>
        public MultiFaceInfo DetectFaces(Bitmap image, out BitmapImage bitmapImage)
        {
            bitmapImage = new BitmapImage(image);
            bitmapImage.ParseImage();
            MultiFaceInfo faceInfo = new MultiFaceInfo();
            try
            {
                ResultCode result = (ResultCode)ASFAPI.ASFDetectFaces(hEngine, bitmapImage.Width, bitmapImage.Height, bitmapImage.Format, bitmapImage.ImageData, ref faceInfo);
                if (result == ResultCode.MOK)
                {
                    return faceInfo;
                }
                else
                {
                    throw new Exception(result.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 人脸对比
        /// </summary>
        /// <returns></returns>
        public float Compare()
        {
            float similar = -1;

            try
            {
                byte[] data1 = GetFaceFeature(image1);
                byte[] data2 = GetFaceFeature(image2);
                if (data1 != null && data2 != null)
                {
                    FaceFeature feature1 = new FaceFeature();
                    FaceFeature feature2 = new FaceFeature();
                    IntPtr ptr1 = Marshal.AllocHGlobal(data1.Length);
                    IntPtr ptr2 = Marshal.AllocHGlobal(data2.Length);
                    Marshal.Copy(data1, 0, ptr1, data1.Length);
                    Marshal.Copy(data2, 0, ptr2, data2.Length);
                    feature1.feature = ptr1;
                    feature1.featureSize = 1032;
                    feature2.feature = ptr2;
                    feature2.featureSize = 1032;
                    similar = 0.0f;
                    ASFAPI.ASFFaceFeatureCompare(hEngine, ref feature1, ref feature2, ref similar);
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return (float)similar;
        }

        /// <summary>
        /// 人脸比对
        /// </summary>
        /// <param name="data1">第一张人脸数据</param>
        /// <param name="data2">第二张人脸数据</param>
        /// <returns></returns>
        public float Compare(byte[] data1, byte[] data2)
        {
            FaceFeature feature1 = new FaceFeature();
            FaceFeature feature2 = new FaceFeature();
            IntPtr ptr1 = Marshal.AllocHGlobal(data1.Length);
            IntPtr ptr2 = Marshal.AllocHGlobal(data2.Length);
            Marshal.Copy(data1, 0, ptr1, data1.Length);
            Marshal.Copy(data2, 0, ptr2, data2.Length);
            feature1.feature = ptr1;
            feature1.featureSize = 1032;
            feature2.feature = ptr2;
            feature2.featureSize = 1032;
            float similar = 0.0f;
            ASFAPI.ASFFaceFeatureCompare(hEngine, ref feature1, ref feature2, ref similar);
            return similar;
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void DisposeResource()
        {
            if (hEngine != null)
            {
                Marshal.FreeHGlobal(hEngine);
            }

        }

        public void SetImage1(Bitmap image1)
        {
            this.image1 = image1;
        }
    }
}
