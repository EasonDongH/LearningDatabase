using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using ArcFace.Base;
using ArcFace.DAL;
using ArcFace.Models;

namespace ArcFace.Face
{
    public class AsfFaceControl
    {
        private const string APPId = "TLGv6eAQ3ihsBwFwzM9SdtgzS5HLUuL8vfTGGr72wv2";
        private const string SDKKey = "5GSobsVbGYosjxGEWLjUM9g1nW7roZT1D36QEhneQLkL";
        /// <summary>
        /// 用于数值化表示的最小人脸尺寸，该尺寸代表人脸尺寸相对于图片长边的占比
        /// video 模式有效值范围[2,16], Image模式有效值范围[2,32] 推荐值为 16
        /// </summary>
        private const int nScale = 16;
        private const int nMaxFaceNum = 50;
        private IntPtr hEngine = IntPtr.Zero;

        static AsfFaceControl()
        {
            //激活程序(激活一次即可)
            AsfFunctions.ASFActivation(APPId, SDKKey);
        }

        public AsfFaceControl()
        {
            int res = InitAsfSDK(out this.hEngine);;
            if (res != 0)
                throw new Exception(GetCodeString(res));
        }

        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <param name="hEngine">返回引擎handle</param>
        /// <returns></returns>
        public int InitAsfSDK(out IntPtr hEngine)
        {
            int res = 0;
            res = AsfFunctions.ASFInitEngine(AsfConstants.AsfFaceDetectMode.ASF_DETECT_MODE_IMAGE, Convert.ToInt32(AsfEnums.ArcSoftFace_OrientPriority.ASF_OP_0_ONLY), nScale, nMaxFaceNum, AsfConstants.AsfFaceFunction.ASF_FACE_DETECT | AsfConstants.AsfFaceFunction.ASF_FACE_RECOGNITION | AsfConstants.AsfFaceFunction.ASF_FACE_AGE | AsfConstants.AsfFaceFunction.ASF_FACE_GENDER | AsfConstants.AsfFaceFunction.ASF_FACE_3DANGLE, out hEngine);
            return res;
        }

        /// <summary>
        /// 销毁引擎
        /// </summary>
        /// <param name="hEngine">引擎handle</param>
        /// <returns></returns>
        public int UnInitAsfSDK()
        {
            int res = 0;
            res = AsfFunctions.ASFUninitEngine(this.hEngine);
            return res;
        }

        /// <summary>
        /// 获取照片中人脸数量
        /// </summary>
        /// <param name="hEngine">引擎handle</param>
        /// <param name="imageData">照片byte数组</param>
        /// <param name="faceCount">返回人脸数量</param>
        /// <returns>返回调用结果,0为成功,其他为错误码</returns>
        public int GetImageFaceCount(byte[] imageData, out int faceCount)
        {
            faceCount = 0;
            try
            {
                AsfStruct.ASF_MultiFaceInfo detectedFaces = new AsfStruct.ASF_MultiFaceInfo();
                Bitmap bmap = ImageHelper.BytesToBitmap(imageData);
                ImageDataModel image = ImageDataConverter.ConvertToImageData(bmap);
                int res = AsfFunctions.ASFDetectFaces(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, out detectedFaces);
                image.Dispose();
                bmap.Dispose();
                if (res != AsfConstants.MOK)
                    return res;
                faceCount = detectedFaces.faceNum;
                return 0;
            }
            catch
            {
                return -1;
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// 获取单人脸特征（该图片必须只有一个人脸）
        /// </summary>
        /// <param name="hEngine">引擎 handle</param>
        /// <param name="imageData">图片信息</param>
        /// <param name="faceFeature">返回人脸特征</param>
        /// <returns>正确调用返回0,错误返回代码,-100代表图片没有或者有多个人脸</returns>
        private int GetFaceFeature(byte[] imageData, out AsfStruct.ASF_FaceFeature faceFeature)
        {
            faceFeature = new AsfStruct.ASF_FaceFeature();
            AsfStruct.ASF_MultiFaceInfo detectedFaces = new AsfStruct.ASF_MultiFaceInfo();
            Bitmap bmap = ImageHelper.BytesToBitmap(imageData);
            ImageDataModel image = ImageDataConverter.ConvertToImageData(bmap);
            int res = AsfFunctions.ASFDetectFaces(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, out detectedFaces);
            if (res != AsfConstants.MOK)
                return res;

            if (detectedFaces.faceNum == 1)
            {
                AsfStruct.ASF_FaceFeature featureout = new AsfStruct.ASF_FaceFeature();
                MultiFaceModel faceModel = new MultiFaceModel(detectedFaces);
                AsfStruct.ASF_SingleFaceInfo faceInfo = faceModel.FaceInfoList[0];
                res = AsfFunctions.ASFFaceFeatureExtract(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref faceInfo, out featureout);
                image.Dispose();
                bmap.Dispose();
                if (res != AsfConstants.MOK)
                    return res;
                faceFeature = new AsfStruct.ASF_FaceFeature()
                {
                    feature = Marshal.AllocCoTaskMem(featureout.featureSize),
                    featureSize = featureout.featureSize
                };
                CommonMethod.CopyMemory(faceFeature.feature, featureout.feature, featureout.featureSize);
                return 0;
            }
            else
            {
                return -100;
            }
        }

        /// <summary>
        /// 提取单人人脸特性值
        /// </summary>
        /// <param name="hEngine"></param>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public int ExtractFaceFeature(byte[] imageData, out byte[] featureData)
        {
            featureData = new byte[1];
            AsfStruct.ASF_FaceFeature faceFeature = new AsfStruct.ASF_FaceFeature();
            int res = GetFaceFeature(imageData, out faceFeature);
            if (res != AsfConstants.MOK)
                return res;
            featureData = new byte[faceFeature.featureSize];
            Marshal.Copy(faceFeature.feature, featureData, 0, featureData.Length);
            return 0;
        }

        /// <summary>
        /// 人脸比对（比对的两张图片必须只有1张人脸）
        /// </summary>
        /// <param name="hEngine">引擎handle</param>
        /// <param name="imageData1">图片1</param>
        /// <param name="imageData2">图片2</param>
        /// <param name="similscore">返回相似度</param>
        /// <returns></returns>
        public int FaceMatching(byte[] imageData1, byte[] imageData2, out float similscore)
        {
            similscore = 0;
            try
            {
                AsfStruct.ASF_FaceFeature faceFeature1 = new AsfStruct.ASF_FaceFeature();
                AsfStruct.ASF_FaceFeature faceFeature2 = new AsfStruct.ASF_FaceFeature();

                int res = GetFaceFeature(imageData1, out faceFeature1);
                if (res != AsfConstants.MOK)
                    return res;

                res = GetFaceFeature(imageData2, out faceFeature2);
                if (res != AsfConstants.MOK)
                    return res;
                res = AsfFunctions.ASFFaceFeatureCompare(hEngine, ref faceFeature1, ref faceFeature2, out similscore);
                if (res != AsfConstants.MOK)
                    return res;
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// 匹配数据库人脸信息，返回第一个查询到的相似值大于等于给定值的对象
        /// </summary>
        /// <param name="similar">给定相似值</param>
        /// <param name="fromForm"></param>
        /// <returns>无匹配结果返回null</returns>
        public FaceSampleModel FaceMatching(byte[] fromForm, float similar)
        {
            FaceSampleDAL faceSampleDAL = new FaceSampleDAL();
            float match_Result = 0.0F;
            FaceSampleModel model = null;
            IEnumerator<FaceSampleModel> modelsIEnumerator = faceSampleDAL.GetAllSampleInfo().GetEnumerator();
            while (modelsIEnumerator.MoveNext())
            {
                FaceMatching(fromForm, modelsIEnumerator.Current.sampleface, out match_Result);
                if (match_Result >= similar)
                {
                    model = modelsIEnumerator.Current;
                    break;
                }
            }
            return model;
        }

         /// <summary>
        /// 获取人脸信息列表
        /// </summary>
        /// <param name="hEngine">引擎handle</param>
        /// <param name="imageData">图片信息</param>
        /// <param name="faceInfo">返回人脸信息列表(包含年龄、性别、角度、人脸框)</param>
        /// <returns></returns>
        public int GetFaceInfo(byte[] imageData, out List<FaceInfoModel> faceInfo)
        {
            faceInfo = new List<FaceInfoModel>();
            ImageDataModel image = null;
            Bitmap bmap = null;
            try
            {
                AsfStruct.ASF_MultiFaceInfo detectedFaces = new AsfStruct.ASF_MultiFaceInfo();
                bmap = ImageHelper.BytesToBitmap(imageData);
                image = ImageDataConverter.ConvertToImageData(bmap);
                int res = AsfFunctions.ASFDetectFaces(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, out detectedFaces);
                if (res != AsfConstants.MOK)
                    return res;

                MultiFaceModel faceModel = new MultiFaceModel(detectedFaces);
                AsfStruct.ASF_MultiFaceInfo multiFaceInfo = faceModel.MultiFaceInfo;
                res = AsfFunctions.ASFProcess(hEngine, image.Width, image.Height, AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8, image.PImageData, ref multiFaceInfo, AsfConstants.AsfFaceFunction.ASF_FACE_AGE | AsfConstants.AsfFaceFunction.ASF_FACE_GENDER | AsfConstants.AsfFaceFunction.ASF_FACE_3DANGLE);
                if (res != AsfConstants.MOK)
                    return res;
                List<int> AgeList = new List<int>();
                List<int> GenderList = new List<int>();
                List<Face3DAngleModel> Face3DAngleList = new List<Face3DAngleModel>();
                List<AsfStruct.ASF_SingleFaceInfo> FaceSingleList = new List<AsfStruct.ASF_SingleFaceInfo>();

                AsfStruct.ASF_AgeInfo ageInfo = new AsfStruct.ASF_AgeInfo();
                res = AsfFunctions.ASFGetAge(hEngine, ref ageInfo);
                if (res != AsfConstants.MOK)
                    return res;
                AgeList = ageInfo.PtrToAgeArray(ageInfo.ageArray, ageInfo.num);

                AsfStruct.ASF_GenderInfo genderInfo = new AsfStruct.ASF_GenderInfo();
                res = AsfFunctions.ASFGetGender(hEngine, ref genderInfo);
                if (res != AsfConstants.MOK)
                    return res;
                GenderList = genderInfo.PtrToGenderArray(genderInfo.genderArray, genderInfo.num);

                AsfStruct.ASF_Face3DAngle face3DAngleInfo = new AsfStruct.ASF_Face3DAngle();
                res = AsfFunctions.ASFGetFace3DAngle(hEngine, ref face3DAngleInfo);
                if (res != AsfConstants.MOK)
                    return res;

                Face3DAngleList = face3DAngleInfo.PtrToFace3DAngleArray(face3DAngleInfo.roll, face3DAngleInfo.yaw, face3DAngleInfo.pitch, face3DAngleInfo.status, face3DAngleInfo.num);
                for (int n = 0; n < multiFaceInfo.faceNum; n++)
                {
                    FaceInfoModel faceinfo = new FaceInfoModel();
                    faceinfo.age = AgeList[n];
                    faceinfo.gender = GenderList[n];
                    faceinfo.face3dAngle = Face3DAngleList[n];
                    faceinfo.faceRect = faceModel.FaceInfoList[n].faceRect;
                    faceInfo.Add(faceinfo);
                }
                return 0;
            }
            catch
            {
                return -1;
            }
            finally
            {
                if (image != null)
                    image.Dispose();
                if (bmap != null)
                    bmap.Dispose();
                GC.Collect();
            }
        }

        /// <summary>
        /// 获取错误代码对应信息
        /// </summary>
        /// <param name="code">结果码</param>
        /// <returns></returns>
        public string GetCodeString(int code)
        {
            string result = string.Empty;
            switch (code)
            {
                #region 结果码
                case 1:
                    result = "错误原因不明";
                    break;
                case 2:
                    result = "无效的参数";
                    break;
                case 3:
                    result = "引擎不支持";
                    break;
                case 4:
                    result = "内存不足";
                    break;
                case 5:
                    result = "状态错误";
                    break;
                case 6:
                    result = "用户取消相关操作";
                    break;
                case 7:
                    result = "操作时间过期";
                    break;
                case 8:
                    result = "用户暂停操作";
                    break;
                case 9:
                    result = "缓冲上溢";
                    break;
                case 10:
                    result = "缓冲下溢";
                    break;
                case 11:
                    result = "存贮空间不足";
                    break;
                case 12:
                    result = "组件不存在";
                    break;
                case 13:
                    result = "全局数据不存在";
                    break;
                case 28673:
                    result = "无效的AppId";
                    break;
                case 28674:
                    result = "无效的SDKKey";
                    break;
                case 28675:
                    result = "AppId和SDKKey不匹配";
                    break;
                case 28676:
                    result = "SDKKey和使用的SDK不匹配";
                    break;
                case 28677:
                    result = "系统版本不被当前SDK所支持";
                    break;
                case 28678:
                    result = "SDK有效期过期,需要重新下载更新";
                    break;
                case 73729:
                    result = "无效的输入内存";
                    break;
                case 73730:
                    result = "无效的输入图像参数";
                    break;
                case 73731:
                    result = "无效的脸部信息1";
                    break;
                case 73732:
                    result = "无效的脸部信息1";
                    break;
                case 73733:
                    result = "待比较的两个人脸特征的版本不一致";
                    break;
                case 81921:
                    result = "人脸特征检测错误未知";
                    break;
                case 81922:
                    result = "人脸特征检测内存错误";
                    break;
                case 81923:
                    result = "人脸特征检测格式错误";
                    break;
                case 81924:
                    result = "人脸特征检测参数错误";
                    break;
                case 81925:
                    result = "人脸特征检测结果置信度低";
                    break;
                case 86017:
                    result = "Engine不支持的检测属性";
                    break;
                case 86018:
                    result = "需要检测的属性未初始化";
                    break;
                case 86019:
                    result = "待获取的属性未在process中处理过";
                    break;
                case 86020:
                    result = "PROCESS不支持的检测属性";
                    break;
                case 86021:
                    result = "无效的输入图像";
                    break;
                case 86022:
                    result = "无效的脸部信息2";
                    break;
                case 90113:
                    result = "SDK激活失败_请打开读写权限";
                    break;
                case 90114:
                    result = "SDK已激活";
                    break;
                case 90115:
                    result = "SDK未激活";
                    break;
                case 90116:
                    result = "detectFaceScaleVal不支持";
                    break;
                case 90117:
                    result = "SDK版本不匹配";
                    break;
                case 90118:
                    result = "设备不匹配";
                    break;
                case 90119:
                    result = "唯一标识不匹配";
                    break;
                case 90120:
                    result = "参数为空";
                    break;
                case 90121:
                    result = "活体检测功能已过期";
                    break;
                case 90122:
                    result = "版本不支持";
                    break;
                case 90123:
                    result = "签名错误";
                    break;
                case 90124:
                    result = "数据库插入错误";
                    break;
                case 90125:
                    result = "唯一标识符校验失败";
                    break;
                case 90126:
                    result = "颜色空间不支持";
                    break;
                case 90127:
                    result = "图片宽度或高度不支持";
                    break;
                case 90128:
                    result = "READ_PHONE_STATE权限被拒绝";
                    break;
                case 90129:
                    result = "激活数据被破坏, 请删除激活文件_重新进行激活";
                    break;
                case 94209:
                    result = "无法解析主机地址";
                    break;
                case 94210:
                    result = "无法连接服务器";
                    break;
                case 94211:
                    result = "网络连接超时";
                    break;
                case 94212:
                    result = "网络未知错误";
                    break;
                case 98305:
                    result = "无法连接激活码服务器";
                    break;
                case 98306:
                    result = "服务器系统错误";
                    break;
                case 98307:
                    result = "请求参数错误";
                    break;
                case 98308:
                    result = "激活码正确_且未被使用_但和传入的APPID及APPKEY不匹配";
                    break;
                case 98309:
                    result = "传入的KEY值虽然正确_但此KEY已经被激活";
                    break;
                case 98310:
                    result = "KEY格式不对_一般来说是KEY错误或者未传入KEY值";
                    break;
                case -100:
                    result = "图片没有或者含有多个人脸,比对只能有一个人脸";
                    break;
                default:
                    result = "未知错误码" + code.ToString();
                    break;
                #endregion
            }
            return result;
        }
    }
}
