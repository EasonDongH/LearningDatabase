using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Reflection;
using log4net;

namespace ArcSoft.Face2._2
{
    public class FaceControl:IDisposable
    {
        private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private const string APPId = "TLGv6eAQ3ihsBwFwzM9SdtgzS5HLUuL8vfTGGr72wv2";
        private const string SDKKey = "5GSobsVbGYosjxGEWLjUM9g1nW7roZT1D36QEhneQLkL";
        /// <summary>
        /// 用于数值化表示的最小人脸尺寸，该尺寸代表人脸尺寸相对于图片长边的占比
        /// video 模式有效值范围[2,16], Image模式有效值范围[2,32] 推荐值为 16
        /// IMAGE 模式取值范围[2,32]，推荐值为30
        /// </summary>
        private const int nScale = 30;
        private const int nMaxFaceNum = 50;
        private IntPtr hEngine = IntPtr.Zero;
        private bool disposed = false;

        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <param name="hEngine">返回引擎handle</param>
        /// <returns></returns>
        private AsfEnums.ResultCode InitAsfSDK(out IntPtr hEngine, uint detectMode)
        {
            AsfEnums.ResultCode res = (AsfEnums.ResultCode)AsfFunctions.ASFInitEngine(detectMode, Convert.ToInt32(AsfEnums.ArcSoftFace_OrientPriority.ASF_OP_0_ONLY), nScale, nMaxFaceNum, AsfConstants.AsfFaceFunction.ASF_FACE_DETECT | AsfConstants.AsfFaceFunction.ASF_FACE_RECOGNITION | AsfConstants.AsfFaceFunction.ASF_FACE_AGE | AsfConstants.AsfFaceFunction.ASF_FACE_GENDER | AsfConstants.AsfFaceFunction.ASF_FACE_3DANGLE, out hEngine);
            return res;
        }

        /// <summary>
        /// 销毁引擎
        /// </summary>
        /// <param name="hEngine">引擎handle</param>
        /// <returns></returns>
        private AsfEnums.ResultCode UnInitAsfSDK()
        {
            AsfEnums.ResultCode res = (AsfEnums.ResultCode)AsfFunctions.ASFUninitEngine(this.hEngine);
            return res;
        }

        /// <summary>
        /// 激活人脸sdk(激活一次即可)
        /// </summary>
        static FaceControl()
        {
            AsfEnums.ResultCode res = (AsfEnums.ResultCode)AsfFunctions.ASFActivation(APPId, SDKKey);
            //if (res != AsfEnums.ResultCode.MOK)
            //    throw new Exception(res.ToString());
        }

        /// <summary>
        /// 初始化人脸识别控制模块
        /// </summary>
        /// <param name="detectMode">默认图像模式</param>
        public FaceControl(AsfEnums.AsfFaceDetectMode detectMode = AsfEnums.AsfFaceDetectMode.ASF_DETECT_MODE_IMAGE)
        {
            AsfEnums.ResultCode res = InitAsfSDK(out this.hEngine, detectMode == AsfEnums.AsfFaceDetectMode.ASF_DETECT_MODE_IMAGE ? AsfConstants.AsfFaceDetectMode.ASF_DETECT_MODE_IMAGE : AsfConstants.AsfFaceDetectMode.ASF_DETECT_MODE_VIDEO);
            if (res != AsfEnums.ResultCode.MOK)
                throw new Exception(res.ToString());
        }

        /// <summary>
        /// 获取图像中检测人脸信息ASF_MultiFaceInfo
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="detectedFaces"></param>
        /// <returns></returns>
        public AsfEnums.ResultCode GetDetectedFaceInfo(Bitmap bmp, ref AsfStruct.ASF_MultiFaceInfo detectedFaces)
        {
            ImageDataModel image = null;
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            try
            {
                detectedFaces = new AsfStruct.ASF_MultiFaceInfo();
                image = ImageDataConverter.ConvertToImageData(bmp);
                res = (AsfEnums.ResultCode)AsfFunctions.ASFDetectFaces(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref detectedFaces);
            }
            catch (Exception ex)
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            finally
            {
                if (image != null)
                    image.Dispose();
            }
            return res;
        }

        public AsfEnums.ResultCode GetDetectedFaceInfo(byte[] imageData, ref AsfStruct.ASF_MultiFaceInfo detectedFaces)
        {
            Bitmap bmp = null;
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            try
            {
                bmp = ImageHelper.BytesToBitmap(imageData);
                res = GetDetectedFaceInfo(bmp, ref detectedFaces);
            }
            catch (Exception ex)
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            finally
            {
                if (bmp != null)
                    bmp.Dispose();
            }
            return res;
        }

        public AsfEnums.ResultCode GetDetectedFaceInfo(Bitmap bmp, ref MultiFaceModel multiFaceModel)
        {
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            try
            {
                AsfStruct.ASF_MultiFaceInfo detectedFaces = new AsfStruct.ASF_MultiFaceInfo();
                res = GetDetectedFaceInfo(bmp, ref detectedFaces);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;
                multiFaceModel = new MultiFaceModel(detectedFaces);
            }
            catch (Exception ex)
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            finally
            {

            }
            return res;
        }

        /// <summary>
        /// 根据原始图像，提取图像中的所有人脸图像，及每个人脸对应的特征
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="faceData"></param>
        /// <returns></returns>
        public AsfEnums.ResultCode GetDetectedFaceInfo(Bitmap sourceImage, ref ImageFaceDataModel faceData)
        {
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            ImageDataModel image = null;
            AsfStruct.ASF_FaceFeature faceFeature = new AsfStruct.ASF_FaceFeature();
            if (faceData == null)
                faceData = new ImageFaceDataModel();
            try
            {
                image = ImageDataConverter.ConvertToImageData(sourceImage);
                AsfStruct.ASF_MultiFaceInfo detectedFaces = new AsfStruct.ASF_MultiFaceInfo();
                res = (AsfEnums.ResultCode)AsfFunctions.ASFDetectFaces(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref detectedFaces);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;

                faceData.SourceImage = sourceImage;
                faceData.FaceDatas = new List<FaceData>();
                MultiFaceModel multiFace = new MultiFaceModel(detectedFaces);
                for (int i = 0; i < detectedFaces.faceNum; ++i)
                {
                    AsfStruct.ASF_SingleFaceInfo singleFaceInfo = multiFace.FaceInfoList[i];
                    if (image == null)
                        image = ImageDataConverter.ConvertToImageData(sourceImage);
                    res = (AsfEnums.ResultCode)AsfFunctions.ASFFaceFeatureExtract(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref singleFaceInfo, ref faceFeature);
                    if (res != AsfEnums.ResultCode.MOK)
                        continue;
                    byte[] featureData = new byte[faceFeature.featureSize];
                    Marshal.Copy(faceFeature.feature, featureData, 0, featureData.Length);
                    faceData.FaceDatas.Add(new FaceData()
                    {
                        Rect = singleFaceInfo.faceRect.GetRectangle(),
                        Face = ImageHelper.GetRectangleImage(sourceImage, singleFaceInfo.faceRect.GetRectangle()),
                        FaceFeature = featureData
                    });
                }
            }
            catch (Exception ex)
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            finally
            {
                if (image != null)
                    image.Dispose();
                //if (faceFeature.feature != IntPtr.Zero)
                //    Marshal.FreeCoTaskMem(faceFeature.feature);
            }
            return res;
        }

        /// <summary>
        /// 根据单人脸信息，获取该人脸的特征值
        /// </summary>
        /// <param name="faceBmp"></param>
        /// <param name="singleFace"></param>
        /// <param name="feature"></param>
        /// <returns></returns>
        public AsfEnums.ResultCode GetSingleFaceFeature(Bitmap faceBmp, AsfStruct.ASF_SingleFaceInfo singleFace, out byte[] feature)
        {
            feature = new byte[1];
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            ImageDataModel image = null;
            AsfStruct.ASF_FaceFeature faceFeature = new AsfStruct.ASF_FaceFeature();
            try
            {
                res = (AsfEnums.ResultCode)AsfFunctions.ASFFaceFeatureExtract(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref singleFace, ref faceFeature);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;
                feature = new byte[faceFeature.featureSize];
                Marshal.Copy(faceFeature.feature, feature, 0, feature.Length);
            }
            catch (Exception ex)
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            finally
            {
                if (image != null)
                    image.Dispose();
            }
            return res;
        }

        /// <summary>
        /// 获取图像中第一个人脸的特征信息
        /// 如果图像中没有人脸或有多个人脸，则不会返回MOK
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="faceFeature"></param>
        /// <returns></returns>
        private AsfEnums.ResultCode GetFirstFaceFeature(byte[] imageData, out AsfStruct.ASF_FaceFeature faceFeature)
        {
            faceFeature = new AsfStruct.ASF_FaceFeature();
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            AsfStruct.ASF_MultiFaceInfo detectedFaces = new AsfStruct.ASF_MultiFaceInfo();
            Bitmap bmp = null;
            ImageDataModel image = null;
            try
            {
                bmp = ImageHelper.BytesToBitmap(imageData);
                image = ImageDataConverter.ConvertToImageData(bmp);
                res = (AsfEnums.ResultCode)AsfFunctions.ASFDetectFaces(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref detectedFaces);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;

                if (detectedFaces.faceNum == 0)
                    return AsfEnums.ResultCode.ERROR_NOFACE;
                if (detectedFaces.faceNum > 1)
                    return AsfEnums.ResultCode.ERROR_MULTIFACES;

                AsfStruct.ASF_FaceFeature featureout = new AsfStruct.ASF_FaceFeature();
                MultiFaceModel faceModel = new MultiFaceModel(detectedFaces);
                AsfStruct.ASF_SingleFaceInfo faceInfo = faceModel.FaceInfoList[0];
                res = (AsfEnums.ResultCode)AsfFunctions.ASFFaceFeatureExtract(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref faceInfo, ref featureout);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;
                faceFeature.feature = Marshal.AllocCoTaskMem(featureout.featureSize);
                faceFeature.featureSize = featureout.featureSize;
                CommonMethod.CopyMemory(faceFeature.feature, featureout.feature, featureout.featureSize);
            }
            catch (Exception ex)
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            finally
            {
                if (bmp != null)
                    bmp.Dispose();
                if (image != null)
                    image.Dispose();
            }
            return res;
        }

        private AsfEnums.ResultCode GetFirstFaceFeature(Bitmap bmp, out AsfStruct.ASF_FaceFeature faceFeature)
        {
            faceFeature = new AsfStruct.ASF_FaceFeature();
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            try
            {
                byte[] imageData = ImageHelper.ImageToBytes(bmp, ImageFormat.Jpeg);
                res = GetFirstFaceFeature(imageData, out faceFeature);
            }
            catch (Exception ex) 
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            return res;
        }

        /// <summary>
        /// 人脸比对（比对的两张图片必须只有1张人脸）
        /// </summary>
        /// <param name="hEngine">引擎handle</param>
        /// <param name="imageData1">图片1</param>
        /// <param name="imageData2">图片2</param>
        /// <param name="similscore">返回相似度</param>
        /// <returns></returns>
        public AsfEnums.ResultCode FaceMatching(byte[] imageData1, byte[] imageData2, out float similscore)
        {
            similscore = 0;
            AsfEnums.ResultCode res = new AsfEnums.ResultCode();
            try
            {
                AsfStruct.ASF_FaceFeature faceFeature1 = new AsfStruct.ASF_FaceFeature();
                AsfStruct.ASF_FaceFeature faceFeature2 = new AsfStruct.ASF_FaceFeature();

                res = GetFirstFaceFeature(imageData1, out faceFeature1);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;

                res = GetFirstFaceFeature(imageData2, out faceFeature2);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;
                res = (AsfEnums.ResultCode)AsfFunctions.ASFFaceFeatureCompare(hEngine, ref faceFeature1, ref faceFeature2, ref similscore);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;
                return 0;
            }
            catch (Exception ex)
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            return res;
        }

        /// <summary>
        /// 根据特征值数组来进行人脸匹配
        /// </summary>
        /// <param name="feature1"></param>
        /// <param name="simileScore"></param>
        /// <returns></returns>
        public AsfEnums.ResultCode FaceMatchingByFeature(byte[] feature1, byte[] feature2,out float simileScore)
        {
            simileScore = 0;
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            try
            {
                AsfStruct.ASF_FaceFeature faceFeature1 = AsfStruct.ASF_FaceFeature.ToFaceFeature(feature1);
                AsfStruct.ASF_FaceFeature faceFeature2 = AsfStruct.ASF_FaceFeature.ToFaceFeature(feature2);
                res = (AsfEnums.ResultCode)AsfFunctions.ASFFaceFeatureCompare(hEngine, ref faceFeature1, ref faceFeature2, ref simileScore);
            }
            catch (Exception ex)
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            return res;
        }

        /// <summary>
        /// 解析人脸，一次得出所有人脸相关信息
        /// </summary>
        /// <param name="imgData"></param>
        /// <param name="ageInfo"></param>
        /// <param name="genderInfo"></param>
        /// <param name="face3dAngle"></param>
        /// <returns></returns>
        public AsfEnums.ResultCode AnalysisFace(byte[] imgData, ref AsfStruct.ASF_AgeInfo ageInfo, ref AsfStruct.ASF_GenderInfo genderInfo, ref AsfStruct.ASF_Face3DAngle face3dAngle)
        {
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            AsfStruct.ASF_MultiFaceInfo detectedFaces = new AsfStruct.ASF_MultiFaceInfo();
            Bitmap bmp = null;
            ImageDataModel image = null;
            uint combinedMask = AsfConstants.AsfFaceFunction.ASF_FACE_AGE | AsfConstants.AsfFaceFunction.ASF_FACE_GENDER | AsfConstants.AsfFaceFunction.ASF_FACE_3DANGLE;
            try
            {
                bmp = ImageHelper.BytesToBitmap(imgData);
                image = ImageDataConverter.ConvertToImageData(bmp);
                res = (AsfEnums.ResultCode)AsfFunctions.ASFDetectFaces(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref detectedFaces);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;
                if (detectedFaces.faceNum == 0)
                    return AsfEnums.ResultCode.ERROR_NOFACE;
                res = (AsfEnums.ResultCode)AsfFunctions.ASFProcess(this.hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref detectedFaces, combinedMask);
                if (res != AsfEnums.ResultCode.MOK)
                    return res;
                res = (AsfEnums.ResultCode)AsfFunctions.ASFGetAge(this.hEngine, ref ageInfo);
                res = (AsfEnums.ResultCode)AsfFunctions.ASFGetGender(this.hEngine, ref genderInfo);
                res = (AsfEnums.ResultCode)AsfFunctions.ASFGetFace3DAngle(this.hEngine, ref face3dAngle);
            }
            catch (Exception ex)
            {
                res = AsfEnums.ResultCode.ERROR_UNKNOWN;
                _log.Error(ex);
            }
            return res;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                if (disposing)
                {
                    UnInitAsfSDK();
                }
                // Note disposing has been done.
                disposed = true;
            }
        }

        ~FaceControl()
        {
            Dispose(false);
        }
    }
}
