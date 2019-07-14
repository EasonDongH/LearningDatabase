using System;
using System.Collections.Generic;
using System.Text;

namespace ArcSoft.Model
{
    /// <summary>
    /// 人脸特征信息Model类
    /// </summary>
    public class FaceInfoModel
    {
        /// <summary>
        /// 年龄
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int gender { get; set; }

        /// <summary>
        /// 3D角度信息
        /// </summary>
        public Face3DAngleModel face3dAngle { get; set; }

        /// <summary>
        /// 人脸框信息
        /// </summary>
        public AsfStruct.ASF_FaceRect faceRect { get; set; }
    }
}
