﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArcSoft.Model
{
    /// <summary>
    /// 3D角度信息Model类
    /// </summary>
    public class Face3DAngleModel
    {
        /// <summary>
        /// 横滚角度
        /// </summary>
        public float roll { get; set; }

        /// <summary>
        /// 偏航角度
        /// </summary>
        public float yaw { get; set; }

        /// <summary>
        /// 俯仰角度
        /// </summary>
        public float pitch { get; set; }

        /// <summary>
        /// 0为正常
        /// </summary>
        public int status { get; set; }
    }
}
