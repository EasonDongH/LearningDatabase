using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ArcFace.Models
{
    /// <summary>
    /// AsfFace 结构体
    /// </summary>
    public class AsfStruct
    {
        /// <summary>
        /// 人脸在图片中的位置
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ASF_FaceRect
        {

            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public Rectangle GetRectangle()
            {
                return new Rectangle(Left, Top, Right - Left, Bottom - Top);
            }
        }

        /// <summary>
        /// 版本和授权信息
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct AsfVersion
        {
            /// <summary>
            /// 版本号
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string Version;

            /// <summary>
            /// 构建日期 
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string BuildDate;

            /// <summary>
            ///  版权说明 
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string CopyRight;
        }

        /// <summary>
        /// 单人脸信息
        /// </summary>
        public struct ASF_SingleFaceInfo
        {
            /// <summary>
            /// 人脸框
            /// </summary>
            public ASF_FaceRect faceRect;

            /// <summary>
            /// 人脸角度
            /// </summary>
            public int faceOrient;

        }

        /// <summary>
        /// 多人脸信息
        /// </summary>
        public struct ASF_MultiFaceInfo
        {
            /// <summary>
            /// 人脸框数组
            /// </summary>
            public IntPtr faceRect;

            /// <summary>
            /// 人脸角度数组
            /// </summary>
            public IntPtr faceOrient;

            /// <summary>
            /// 检测到的人脸个数
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int faceNum;
        }

        /// <summary>
        /// 年龄信息
        /// </summary>
        public struct ASF_AgeInfo
        {
            /// <summary>
            /// 年龄结果
            /// </summary>
            public IntPtr ageArray;

            /// <summary>
            /// 检测到人脸的个数
            /// </summary>
            public int num;

            /// <summary>
            /// 年龄信息转化为List
            /// </summary>
            /// <param name="self">年龄句柄handle</param>
            /// <param name="length">句柄长度</param>
            /// <returns></returns>
            public List<int> PtrToAgeArray(IntPtr self, int length)
            {
                var size = Marshal.SizeOf(typeof(int));
                List<int> ageArray = new List<int>();
                for (var i = 0; i < length; i++)
                {
                    int age = 0;
                    var iPtr = new IntPtr(self.ToInt32() + i * size);
                    age = (int)Marshal.PtrToStructure(iPtr, typeof(int));
                    ageArray.Add(age);
                }
                return ageArray;
            }
        }

        /// <summary>
        /// 性别信息
        /// </summary>
        public struct ASF_GenderInfo
        {
            /// <summary>
            /// 0男，1女，-1未知
            /// </summary>
            public IntPtr genderArray;

            /// <summary>
            /// 检测到的人脸的个数
            /// </summary>
            public int num;

            /// <summary>
            /// 性别信息转化为List
            /// </summary>
            /// <param name="self">性别句柄handle</param>
            /// <param name="length">句柄长度</param>
            /// <returns></returns>
            public List<int> PtrToGenderArray(IntPtr self, int length)
            {
                var size = Marshal.SizeOf(typeof(int));
                List<int> genderArray = new List<int>();
                for (var i = 0; i < length; i++)
                {
                    int gender = 0;
                    var iPtr = new IntPtr(self.ToInt32() + i * size);
                    gender = (int)Marshal.PtrToStructure(iPtr, typeof(int));
                    genderArray.Add(gender);
                }
                return genderArray;
            }
        }


        /// <summary>
        /// 人脸特征信息
        /// </summary>
        public struct ASF_FaceFeature
        {
            /// <summary>
            /// 特征信息
            /// </summary>
            public IntPtr feature;

            /// <summary>
            /// 人脸特征的长度
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int featureSize;
        }

        /// <summary>
        /// 3D角度信息
        /// </summary>
        public struct ASF_Face3DAngle
        {
            /// <summary>
            /// 横滚角度
            /// </summary>
            public IntPtr roll;

            /// <summary>
            /// 偏航角度
            /// </summary>
            public IntPtr yaw;

            /// <summary>
            /// 俯仰角度
            /// </summary>
            public IntPtr pitch;

            /// <summary>
            /// 0为正常
            /// </summary>
            public IntPtr status;

            /// <summary>
            /// 检测到人脸的个数
            /// </summary>
            public int num;

            /// <summary>
            /// 3D角度信息转化为List
            /// </summary>
            /// <param name="roll">横滚角度handle</param>
            /// <param name="yaw">偏航角度handle</param>
            /// <param name="pitch">俯仰角度handle</param>
            /// <param name="status">状态值handle</param>
            /// <param name="length">句柄长度</param>
            /// <returns></returns>
            public List<Face3DAngleModel> PtrToFace3DAngleArray(IntPtr roll, IntPtr yaw, IntPtr pitch, IntPtr status, int length)
            {
                List<Face3DAngleModel> Face3DAngleList = new List<Face3DAngleModel>();
                var size = Marshal.SizeOf(typeof(int));
                for (var i = 0; i < length; i++)
                {
                    Face3DAngleModel model = new Face3DAngleModel();
                    int r = 0;
                    var iPtr = new IntPtr(roll.ToInt32() + i * size);
                    r = (int)Marshal.PtrToStructure(iPtr, typeof(int));
                    model.roll = r;

                    int y = 0;
                    iPtr = new IntPtr(yaw.ToInt32() + i * size);
                    y = (int)Marshal.PtrToStructure(iPtr, typeof(int));
                    model.yaw = y;

                    int p = 0;
                    iPtr = new IntPtr(pitch.ToInt32() + i * size);
                    p = (int)Marshal.PtrToStructure(iPtr, typeof(int));
                    model.pitch = p;

                    int s = 0;
                    iPtr = new IntPtr(status.ToInt32() + i * size);
                    s = (int)Marshal.PtrToStructure(iPtr, typeof(int));
                    model.status = s;

                    Face3DAngleList.Add(model);
                }
                return Face3DAngleList;
            }
        }
    }
}
