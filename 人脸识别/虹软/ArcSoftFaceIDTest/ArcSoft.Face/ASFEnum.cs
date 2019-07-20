using System;
using System.Collections.Generic;
using System.Text;

namespace ArcSoft.Face
{
    /// <summary>
    /// 检测方向的优先级
    /// </summary>
    public enum DetectionOrientPriority
    {
        ASF_OP_0_ONLY = 0x1,    //仅检测0度
        ASF_OP_90_ONLY = 0x2,   //仅检测90度
        ASF_OP_270_ONLY = 0x3,  //仅检测270度
        ASF_OP_180_ONLY = 0x4,  //仅检测180度
        ASF_OP_0_HIGHER_EXT = 0x5, //检测0、90、270、180全角度
    }

    /// <summary>
    /// 检测到的人脸角度
    /// </summary>
    public enum DetectedOrientCode
    {
        ASF_OC_0 = 0x1,     //0度
        ASF_OC_90 = 0x2,     //90度
        ASF_OC_270 = 0x3,     //270度
        ASF_OC_180 = 0x4,     //180度
        ASF_OC_30 = 0x5,     //30度
        ASF_OC_60 = 0x6,     //60度
        ASF_OC_120 = 0x7,     //120度
        ASF_OC_150 = 0x8,     //150度
        ASF_OC_210 = 0x9,     //210度
        ASF_OC_240 = 0xa,     //240度
        ASF_OC_300 = 0xb,     //300度
        ASF_OC_330 = 0xc,     //330度
    }

    /// <summary>
    /// 结果代码
    /// </summary>
    public enum ResultCode
    {
        MOK = 0,//成功
        MERR_UNKNOWN = 1,//错误原因不明
        MERR_INVALID_PARAM = 2,//无效的参数
        MERR_UNSUPPORTED = 3,//引擎不支持
        MERR_NO_MEMORY = 4,//内存不足
        MERR_BAD_STATE = 5,//状态错误
        MERR_USER_CANCEL = 6,//用户取消相关操作
        MERR_EXPIRED = 7,//操作时间过期
        MERR_USER_PAUSE = 8,//用户暂停操作
        MERR_BUFFER_OVERFLOW = 9,//缓冲上溢
        MERR_BUFFER_UNDERFLOW = 10,//缓冲下溢
        MERR_NO_DISKSPACE = 11,//存贮空间不足
        MERR_COMPONENT_NOT_EXIST = 12,//组件不存在
        MERR_GLOBAL_DATA_NOT_EXIST = 13,//全局数据不存在
        MERR_FSDK_INVALID_APP_ID = 28673,//无效的AppId
        MERR_FSDK_INVALID_SDK_ID = 28674,//无效的SDKKey
        MERR_FSDK_INVALID_ID_PAIR = 28675,//AppId和SDKKey不匹配
        MERR_FSDK_MISMATCH_ID_AND_SDK = 28676,//SDKKey和使用的SDK不匹配
        MERR_FSDK_SYSTEM_VERSION_UNSUPPORTED = 28677,//系统版本不被当前SDK所支持
        MERR_FSDK_LICENCE_EXPIRED = 28678,//SDK有效期过期_需要重新下载更新
        MERR_FSDK_FR_INVALID_MEMORY_INFO = 73729,//无效的输入内存
        MERR_FSDK_FR_INVALID_IMAGE_INFO = 73730,//无效的输入图像参数
        MERR_FSDK_FR_INVALID_FACE_INFO = 73731,//无效的脸部信息1
        MERR_FSDK_FR_NO_GPU_AVAILABLE = 73732,//当前设备无GPU可用
        MERR_FSDK_FR_MISMATCHED_FEATURE_LEVEL = 73733,//待比较的两个人脸特征的版本不一致
        MERR_FSDK_FACEFEATURE_UNKNOWN = 81921,//人脸特征检测错误未知
        MERR_FSDK_FACEFEATURE_MEMORY = 81922,//人脸特征检测内存错误
        MERR_FSDK_FACEFEATURE_INVALID_FORMAT = 81923,//人脸特征检测格式错误
        MERR_FSDK_FACEFEATURE_INVALID_PARAM = 81924,//人脸特征检测参数错误
        MERR_FSDK_FACEFEATURE_LOW_CONFIDENCE_LEVEL = 81925,//人脸特征检测结果置信度低
        MERR_ASF_EX_FEATURE_UNSUPPORTED_ON_INIT = 86017,//Engine不支持的检测属性
        MERR_ASF_EX_FEATURE_UNINITED = 86018,//需要检测的属性未初始化
        MERR_ASF_EX_FEATURE_UNPROCESSED = 86019,//待获取的属性未在process中处理过
        MERR_ASF_EX_FEATURE_UNSUPPORTED_ON_PROCESS = 86020,//PROCESS不支持的检测属性
        ERR_ASF_EX_INVALID_IMAGE_INFO = 86021,//无效的输入图像
        MERR_ASF_EX_INVALID_FACE_INFO = 86022,//无效的脸部信息2
        MERR_ASF_ACTIVATION_FAIL = 90113,//SDK激活失败_请打开读写权限
        MERR_ASF_ALREADY_ACTIVATED = 90114,//SDK已激活
        MERR_ASF_NOT_ACTIVATED = 90115,//SDK未激活
        MERR_ASF_SCALE_NOT_SUPPORT = 90116,//detectFaceScaleVal不支持
        MERR_ASF_VERION_MISMATCH = 90117,//SDK版本不匹配
        MERR_ASF_DEVICE_MISMATCH = 90118,//设备不匹配
        MERR_ASF_UNIQUE_IDENTIFIER_MISMATCH = 90119,//唯一标识不匹配
        MERR_ASF_PARAM_NULL = 90120,//参数为空
        MERR_ASF_LIVENESS_EXPIRED = 90121,//活体检测功能已过期
        MERR_ASF_VERSION_NOT_SUPPORT = 90122,//版本不支持
        MERR_ASF_SIGN_ERROR = 90123,//签名错误
        MERR_ASF_DATABASE_ERROR = 90124,//数据库插入错误
        MERR_ASF_UNIQUE_CHECKOUT_FAIL = 90125,//唯一标识符校验失败
        MERR_ASF_COLOR_SPACE_NOT_SUPPORT = 90126,//颜色空间不支持
        MERR_ASF_IMAGE_WIDTH_HEIGHT_NOT_SUPPORT = 90127,//图片宽度或高度不支持
        MERR_ASF_READ_PHONE_STATE_DENIED = 90128,//READ_PHONE_STATE权限被拒绝
        MERR_ASF_ACTIVATION_DATA_DESTROYED = 90129,//激活数据被破坏, 请删除激活文件_重新进行激活
        MERR_ASF_SERVER_UNKNOWN_ERROR = 90130,//服务端未知错误
        MERR_ASF_INTERNET_DENIED = 90131,//INTERNET 权限被拒绝
        MERR_ASF_ACTIVEFILE_SDK_MISMATCH = 90132,//激活文件与 SDK 版本不匹配,请重新激活
        MERR_ASF_DEVICEINFO_LESS = 90133,//设备信息太少，不足以生成设备指纹
        MERR_ASF_REQUEST_TIMEOUT = 90134,//客户端时间与服务器时间（即北京时间）前后相差在 30 分钟之内
        MERR_ASF_APPID_DATA_DECRYPT = 90135,//服务端解密失败
        MERR_ASF_APPID_APPKEY_SDK_MISMATCH = 90136,//传入的 AppId 和 AppKey 与使用的SDK 版本不一致
        MERR_ASF_NO_REQUEST = 90137,//短时间大量请求会被禁止请求,30分钟之后会解封
        MERR_ASF_NETWORK_COULDNT_RESOLVE_HOST = 94209,//无法解析主机地址
        MERR_ASF_NETWORK_COULDNT_CONNECT_SERVER = 94210,//无法连接服务器
        MERR_ASF_NETWORK_CONNECT_TIMEOUT = 94211,//网络连接超时
        MERR_ASF_NETWORK_UNKNOWN_ERROR = 94212,//网络未知错误
        MERR_ASF_ACTIVEKEY_COULDNT_CONNECT_SERVER = 98305,//无法连接激活码服务器
        MERR_ASF_ACTIVEKEY_SERVER_SYSTEM_ERROR = 98306,//服务器系统错误
        MERR_ASF_ACTIVEKEY_POST_PARM_ERROR = 98307,//请求参数错误
        MERR_ASF_ACTIVEKEY_PARM_MISMATCH = 98308,//激活码正确_且未被使用_但和传入的APPID及APPKEY不匹配
        MERR_ASF_ACTIVEKEY_ACTIVEKEY_ACTIVATED = 98309,//传入的KEY值虽然正确_但此KEY已经被激活
        MERR_ASF_ACTIVEKEY_ACTIVEKEY_FORMAT_ERROR = 98310,//KEY格式不对_一般来说是KEY错误或者未传入KEY值
        MERR_ASF_ACTIVEKEY_APPID_PARM_MISMATCH = 98311,//激活码正确，被使用，但传入的APPID 不匹配
        MERR_ASF_ACTIVEKEY_PAYSDK_FREEFILE_MISMATCH = 98312 //付费版 sdk 不能使用免费版本的激活文件
    }


    /// <summary>
    /// 引擎的工作模式
    /// </summary>
    public enum EngineMode
    {
        /// <summary>
        /// 人脸检测
        /// </summary>
        ASF_FACE_DETECT = 0x00000001,
        /// <summary>
        /// 人脸识别
        /// </summary>
        ASF_FACERECOGNITION = 0x00000004,
        /// <summary>
        /// 年龄识别
        /// </summary>
        ASF_AGE = 0x00000008,
        /// <summary>
        /// 性别识别
        /// </summary>
        ASF_GENDER = 0x00000010,
        /// <summary>
        /// 角度识别
        /// </summary>
        ASF_FACE3DANGLE = 0x00000020,
        /// <summary>
        /// 活体检测
        /// </summary>
        ASF_LIVENESS = 0x00000080 
    }
}
