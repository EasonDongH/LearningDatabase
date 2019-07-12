using System;
using System.Collections.Generic;
using System.Text;

namespace ArcFace.Models
{
    /// <summary>
    /// AsfFace枚举
    /// </summary>
    public class AsfEnums
    {
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
    }
}
