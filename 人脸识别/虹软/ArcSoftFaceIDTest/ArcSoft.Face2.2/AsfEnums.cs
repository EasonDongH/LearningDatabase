using System;
using System.Collections.Generic;
using System.Text;

namespace ArcSoft.Face2._2
{
    /// <summary>
    /// AsfFace枚举
    /// </summary>
    public class AsfEnums
    {
        /// <summary>
        /// 人脸识别模式
        /// </summary>
        public enum AsfFaceDetectMode
        {
            /// <summary>
            /// Video模式，一般用于多帧连续检测
            /// </summary>
            ASF_DETECT_MODE_VIDEO = 0,

            /// <summary>
            /// Image模式，一般用于静态图的单次检测
            /// </summary>
            ASF_DETECT_MODE_IMAGE = 1
        }

        //检测方向的优先级 
        //根据应用场景,推荐选择单一角度,检测效果更优
        public enum ArcSoftFace_OrientPriority
        {
            ASF_OP_0_ONLY = 0x1,        // 仅检测 0 度  
            ASF_OP_90_ONLY = 0x2,       // 仅检测 90 度  
            ASF_OP_270_ONLY = 0x3,      // 仅检测 270 度  
            ASF_OP_180_ONLY = 0x4,      // 仅检测 180 度  
            ASF_OP_0_HIGHER_EXT = 0x5,  // 检测 0,90,270,180 全角度 
        }

        // 检测到的人脸角度（按逆时针方向） 
        public enum ArcSoftFace_OrientCode
        {
            ASF_OC_0 = 0x1,     // 0 degree   
            ASF_OC_90 = 0x2,    // 90 degree   
            ASF_OC_270 = 0x3,   // 270 degree   
            ASF_OC_180 = 0x4,   // 180 degree   
            ASF_OC_30 = 0x5,    // 30 degree   
            ASF_OC_60 = 0x6,    // 60 degree   
            ASF_OC_120 = 0x7,   // 120 degree   
            ASF_OC_150 = 0x8,   // 150 degree   
            ASF_OC_210 = 0x9,   // 210 degree   
            ASF_OC_240 = 0xa,   // 240 degree  
            ASF_OC_300 = 0xb,   // 300 degree   
            ASF_OC_330 = 0xc    // 330 degree  
        }

        public enum ResultCode
        {
            // 成功
            MOK = 0x0,
            // 错误原因不明
            MERR_UNKNOWN = 0x1,
            // 无效的参数
            MERR_INVALID_PARAM = 0x2,
            // 引擎不支持
            MERR_UNSUPPORTED = 0x3,
            // 内存不足
            MERR_NO_MEMORY = 0x4,
            // 状态错误
            MERR_BAD_STATE = 0x5,
            // 用户取消相关操作
            MERR_USER_CANCEL = 0x6,
            // 操作时间过期
            MERR_EXPIRED = 0x7,
            // 用户暂停操作
            MERR_USER_PAUSE = 0x8,
            // 缓冲上溢
            MERR_BUFFER_OVERFLOW = 0x9,
            // 缓冲下溢
            MERR_BUFFER_UNDERFLOW = 0xA,
            // 存贮空间不足
            MERR_NO_DISKSPACE = 0xB,
            // 组件不存在
            MERR_COMPONENT_NOT_EXIST = 0xC,
            // 全局数据不存在
            MERR_GLOBAL_DATA_NOT_EXIST = 0xD,
            // 无效的AppId
            MERR_FSDK_INVALID_APP_ID = 0x7001,
            // 无效的SDKkey
            MERR_FSDK_INVALID_SDK_ID = 0x7002,
            // AppId和SDKKey不匹配
            MERR_FSDK_INVALID_ID_PAIR = 0x7003,
            // SDKKey和使用的SDK不匹配
            //（注意：调用初始化引擎接口时，请确认激活接口传入的参数，并重新激活）
            MERR_FSDK_MISMATCH_ID_AND_SDK = 0x7004,
            // 系统版本不被当前SDK所支持
            MERR_FSDK_SYSTEM_VERSION_UNSUPPORTED = 0x7005,
            // SDK有效期过期，需要重新下载更新
            MERR_FSDK_LICENCE_EXPIRED = 0x7006,
            // 无效的输入内存
            MERR_FSDK_FR_INVALID_MEMORY_INFO = 0x12001,
            // 无效的输入图像参数
            MERR_FSDK_FR_INVALID_IMAGE_INFO = 0x12002,
            // 无效的脸部信息
            MERR_FSDK_FR_INVALID_FACE_INFO = 0x12003,
            // 待比较的两个人脸特征的版本不一致
            MERR_FSDK_FR_MISMATCHED_FEATURE_LEVEL = 0x12005,
            // 人脸特征检测错误未知
            MERR_FSDK_FACEFEATURE_UNKNOWN = 0x14001,
            // 人脸特征检测内存错误
            MERR_FSDK_FACEFEATURE_MEMORY = 0x14002,
            // 人脸特征检测格式错误
            MERR_FSDK_FACEFEATURE_INVALID_FORMAT = 0x14003,
            // 人脸特征检测参数错误
            MERR_FSDK_FACEFEATURE_INVALID_PARAM = 0x14004,
            // 人脸特征检测结果置信度低
            MERR_FSDK_FACEFEATURE_LOW_CONFIDENCE_LEVEL = 0x14005,
            // Engine不支持的检测属性
            MERR_ASF_EX_FEATURE_UNSUPPORTED_ON_INIT = 0x15001,
            // 需要检测的属性未初始化
            MERR_ASF_EX_FEATURE_UNINITED = 0x15002,
            // 待获取的属性未在process中处理过
            MERR_ASF_EX_FEATURE_UNPROCESSED = 0x15003,
            // PROCESS不支持的检测属性，例如FR，有自己独立的处理函数
            MERR_ASF_EX_FEATURE_UNSUPPORTED_ON_PROCESS = 0x15004,
            // 无效的输入图像
            MERR_ASF_EX_INVALID_IMAGE_INFO = 0x15005,
            // 无效的脸部信息
            MERR_ASF_EX_INVALID_FACE_INFO = 0x15006,
            // SDK激活失败，请打开读写权限
            MERR_ASF_ACTIVATION_FAIL = 0x16001,
            // SDK已激活
            MERR_ASF_ALREADY_ACTIVATED = 0x16002,
            // SDK未激活
            MERR_ASF_NOT_ACTIVATED = 0x16003,
            // detectFaceScaleVal不支持
            MERR_ASF_SCALE_NOT_SUPPORT = 0x16004,
            // 激活文件与SDK类型不匹配，请确认使用的sdk
            MERR_ASF_ACTIVEFILE_SDKTYPE_MISMATCH = 0x16005,
            // 设备不匹配
            MERR_ASF_DEVICE_MISMATCH = 0x16006,
            // 唯一标识不合法
            MERR_ASF_UNIQUE_IDENTIFIER_ILLEGAL = 0x16007,
            // 参数为空
            MERR_ASF_PARAM_NULL = 0x16008,
            // 版本不支持
            MERR_ASF_VERSION_NOT_SUPPORT = 0x1600A,
            // 签名错误
            MERR_ASF_SIGN_ERROR = 0x1600B,
            // 激活信息保存异常
            MERR_ASF_DATABASE_ERROR = 0x1600C,
            // 唯一标识符校验失败
            MERR_ASF_UNIQUE_CHECKOUT_FAIL = 0x1600D,
            // 颜色空间不支持
            MERR_ASF_COLOR_SPACE_NOT_SUPPORT = 0x1600E,
            // 图片宽高不支持，宽度需四字节对齐
            MERR_ASF_IMAGE_WIDTH_HEIGHT_NOT_SUPPORT = 0x1600F,
            // 激活数据被破坏,请删除激活文件，重新进行激活
            MERR_ASF_ACTIVATION_DATA_DESTROYED = 0x16011,
            // 服务端未知错误
            MERR_ASF_SERVER_UNKNOWN_ERROR = 0x16012,
            // 激活文件与SDK版本不匹配,请重新激活
            MERR_ASF_ACTIVEFILE_SDK_MISMATCH = 0x16014,
            // 设备信息太少，不足以生成设备指纹
            MERR_ASF_DEVICEINFO_LESS = 0x16015,
            // 客户端时间与服务器时间（即北京时间）前后相差在30分钟以上
            MERR_ASF_REQUEST_TIMEOUT = 0x16016,
            // 数据校验异常
            MERR_ASF_APPID_DATA_DECRYPT = 0x16017,
            // 传入的AppId和AppKey与使用的SDK版本不一致
            MERR_ASF_APPID_APPKEY_SDK_MISMATCH = 0x16018,
            // 短时间大量请求会被禁止请求,30分钟之后解封
            MERR_ASF_NO_REQUEST = 0x16019,
            // 激活文件不存在
            MERR_ASF_ACTIVE_FILE_NO_EXIST = 0x1601A,
            // IMAGE模式下不支持全角度(ASF_OP_0_HIGHER_EXT)检测
            MERR_ASF_IMAGEMODE_0_HIGHER_EXT_UNSUPPORT = 0x1601B,
            // 无法解析主机地址
            MERR_ASF_NETWORK_COULDNT_RESOLVE_HOST = 0x17001,
            // 无法连接服务器
            MERR_ASF_NETWORK_COULDNT_CONNECT_SERVER = 0x17002,
            // 网络连接超时
            MERR_ASF_NETWORK_CONNECT_TIMEOUT = 0x17003,
            // 网络未知错误
            MERR_ASF_NETWORK_UNKNOWN_ERROR = 0x17004,
            // 未知错误，一般为程序错误
            ERROR_UNKNOWN = -1,
            // 多人脸
            ERROR_MULTIFACES = -2,
            // 无人脸
            ERROR_NOFACE = -3,
            // 最大人脸没有比次大人脸大指定百分比，无法提取特征值错误
            ERROR_MAXFACENOTBIGENOUGH = -4,
            // 最大人脸不止一个
            ERROR_MULTIMAXFACES = -5
        }
    }
}
