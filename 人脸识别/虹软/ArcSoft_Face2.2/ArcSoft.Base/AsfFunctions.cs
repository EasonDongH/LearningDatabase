using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ArcSoft.Model;
using System.IO;

namespace ArcSoft.Base
{
    /// <summary>
    /// AsfFace 函数引用
    /// </summary>
    public class AsfFunctions
    {
        private const string DllPath = @"SDK\libarcsoft_face_engine.dll";
        /// <summary>
        /// 激活SDK（激活一次即可）
        /// </summary>
        /// <param name="AppId">官网获取的 APPID</param>
        /// <param name="SDKKey">官网获取的 SDKKEY</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFActivation", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFActivation(string AppId, string SDKKey);

        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <param name="detectMode">[in]VIDEO 模式/IMAGE 模式 VIDEO 模式:处理连续帧的图像数据，并返回检测结果，需要将所有图像帧的数据都传入接口进行处理; IMAGE 模式:处理单帧的图像数据，并返回检测结果</param>
        /// <param name="detectFaceOrientPriority">[in] 检测脸部的角度优先值，推荐仅检测单一角度，效果更优</param>
        /// <param name="detectFaceScaleVal">[in]用于数值化表示的最小人脸尺寸，该尺寸代表人脸尺寸相对于图片长 边的占比。 video 模式有效值范围[2,16], Image模式有效值范围[2,32] 推荐值为 16</param>
        /// <param name="detectFaceMaxNum">[in] 最大需要检测的人脸个数[1-50]</param>
        /// <param name="combinedMask">[in] 用户选择需要检测的功能组合，可单个或多个</param>
        /// <param name="hEngine">[out] 初始化返回的引擎 handle</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFInitEngine", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFInitEngine(uint detectMode, int orientPriority, int scale, int maxFaceNumber, uint combinedMask, out IntPtr pEngine);

        /// <summary>
        /// 销毁引擎
        /// </summary>
        /// <param name="hEngine">[in] 引擎 handle</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFUninitEngine", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFUninitEngine(IntPtr hEngine);

        /// <summary>
        /// 人脸检测
        /// </summary>
        /// <param name="hEngine">[in] 引擎 handle</param>
        /// <param name="width">[in] 图片宽度为 4 的倍数且大于 0</param>
        /// <param name="height">[in] YUYV/I420/NV21/NV12 格式的图片高度为 2 的倍数，BGR24 格式的图片高度不限制</param>
        /// <param name="format">[in] 颜色空间格式</param>
        /// <param name="imgData">[in] 图片数据</param>
        /// <param name="detectedFaces">[out] 检测到的人脸信息</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFDetectFaces", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFDetectFaces(IntPtr pEngine, int width, int height, int format, IntPtr imgData, ref AsfStruct.ASF_MultiFaceInfo faceInfo);

        /// <summary>
        /// 单人脸特征提取
        /// </summary>
        /// <param name="pEngine">[in] 引擎handle</param>
        /// <param name="width">[in] 图片宽度为4的倍数且大于0</param>
        /// <param name="height">[in] YUYV/I420/NV21/NV12格式的图片高度为2的倍数，BGR24格式的图片高度不限制</param>
        /// <param name="format">[in] 颜色空间格式</param>
        /// <param name="imgData">[in] 图片数据</param>
        /// <param name="faceInfo">[out] 单张人脸位置和角度信息</param>
        /// <param name="faceFeature">[out] 人脸特征</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFFaceFeatureExtract", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFFaceFeatureExtract(IntPtr pEngine, int width, int height, int format, IntPtr imgData, ref AsfStruct.ASF_SingleFaceInfo faceInfo, ref AsfStruct.ASF_FaceFeature faceFeature);

        /// <summary>
        /// 人脸特征比对
        /// </summary>
        /// <param name="hEngine">[in] 引擎 handle</param>
        /// <param name="feature1">[in] 待比对的人脸特征</param>
        /// <param name="feature2">[in] 待比对的人脸特征</param>
        /// <param name="confidenceLevel">[out] 比对结果，置信度数值</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFFaceFeatureCompare", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFFaceFeatureCompare(IntPtr pEngine, ref AsfStruct.ASF_FaceFeature faceFeature1, ref AsfStruct.ASF_FaceFeature faceFeature2, ref float confidenceLevel);

        /// <summary>
        /// 人脸信息检测（年龄/性别/人脸 3D 角度），最多支持 4 张人脸信息检测，超过部分返回未知。
        /// </summary>
        /// <param name="hEngine">[in] 引擎 handle</param>
        /// <param name="width">[in] 图片宽度为 4 的倍数且大于 0</param>
        /// <param name="height">[in] YUYV/I420/NV21/NV12 格式的图片高度为 2 的倍数，BGR24 格式的图片高度不限制</param>
        /// <param name="format">[in] 颜色空间格式</param>
        /// <param name="imgData">[in] 图片数据</param>
        /// <param name="multiFaceInfo">[in] 检测到的人脸信息</param>
        /// <param name="combinedMask">[in] 初始化中参数 combinedMask 与 ASF_AGE| ASF_GENDER|ASF_FACE3DANGLE 的交集的子集</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFProcess", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFProcess(IntPtr pEngine, int width, int height, int format, IntPtr imgData, ref AsfStruct.ASF_MultiFaceInfo multiFaceInfo, uint combinedMask);


        /// <summary>
        /// 获取年龄信息
        /// </summary>
        /// <param name="hEngine">[in] 引擎 handle</param>
        /// <param name="ageInfo">[out] 检测到的年龄信息</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFGetAge", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFGetAge(IntPtr pEngine, ref AsfStruct.ASF_AgeInfo ageInfo);

        /// <summary>
        /// 获取性别信息 
        /// </summary>
        /// <param name="hEngine">[in] 引擎 handle</param>
        /// <param name="genderInfo">[out] 检测到的性别信息</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFGetGender", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFGetGender(IntPtr pEngine, ref AsfStruct.ASF_GenderInfo genderInfo);

        /// <summary>
        /// 获取 3D 角度信息
        /// </summary>
        /// <param name="hEngine">[in] 引擎 handle</param>
        /// <param name="face3dAngle">[out] 检测到脸部 3D 角度信息</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFGetFace3DAngle", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ASFGetFace3DAngle(IntPtr hEngine, ref AsfStruct.ASF_Face3DAngle face3dAngle);

        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// <param name="hEngine">[in] 引擎 handle</param>
        /// <returns></returns>
        [DllImport(DllPath, EntryPoint = "ASFGetVersion", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr ASFGetVersion(IntPtr hEngine);
    }
}
