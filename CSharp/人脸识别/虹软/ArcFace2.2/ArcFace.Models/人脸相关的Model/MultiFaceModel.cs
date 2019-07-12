using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ArcFace.Models
{
    /// <summary>
    /// 多人脸信息Model类
    /// </summary>
    public class MultiFaceModel : IDisposable
    {
        /// <summary>
        ///  多人脸信息
        /// </summary>
        public AsfStruct.ASF_MultiFaceInfo MultiFaceInfo { get; private set; }

        /// <summary>
        /// 单人脸信息List
        /// </summary>
        public List<AsfStruct.ASF_SingleFaceInfo> FaceInfoList { get; private set; }

        public MultiFaceModel() { }

        public MultiFaceModel(AsfStruct.ASF_MultiFaceInfo multiFaceInfo)
        {
            this.MultiFaceInfo = multiFaceInfo;
            this.FaceInfoList = new List<AsfStruct.ASF_SingleFaceInfo>();
            //AsfStruct.ASF_FaceRect[] faceRects = multiFaceInfo.faceRect.ToStructArray<AsfStruct.ASF_FaceRect>(multiFaceInfo.faceNum);
            //int[] faceOrient = multiFaceInfo.faceOrient.ToStructArray<int>(multiFaceInfo.faceNum);
            //for (int i = 0; i < multiFaceInfo.faceNum; i++)
            //{
            //    AsfStruct.ASF_SingleFaceInfo faceInfo = new AsfStruct.ASF_SingleFaceInfo
            //    {
            //        faceOrient = faceOrient[i],
            //        faceRect = faceRects[i]
            //    };
            //    FaceInfoList.Add(faceInfo);
            //}
            FaceInfoList = PtrToMultiFaceArray(multiFaceInfo.faceRect, multiFaceInfo.faceOrient, multiFaceInfo.faceNum);
        }

        private List<AsfStruct.ASF_SingleFaceInfo> PtrToMultiFaceArray(IntPtr faceRect, IntPtr faceOrient, int length)
        {
            List<AsfStruct.ASF_SingleFaceInfo> FaceInfoList = new List<AsfStruct.ASF_SingleFaceInfo>();
            var size = Marshal.SizeOf(typeof(int));
            var sizer = Marshal.SizeOf(typeof(AsfStruct.ASF_FaceRect));
            
            for (var i = 0; i < length; i++)
            {
                AsfStruct.ASF_SingleFaceInfo faceInfo = new AsfStruct.ASF_SingleFaceInfo();

                AsfStruct.ASF_FaceRect rect = new AsfStruct.ASF_FaceRect();
                var iPtr = new IntPtr(faceRect.ToInt32() + i * sizer);
                rect = (AsfStruct.ASF_FaceRect)Marshal.PtrToStructure(iPtr, typeof(AsfStruct.ASF_FaceRect));
                faceInfo.faceRect = rect;

                int orient = 0;
                iPtr = new IntPtr(faceOrient.ToInt32() + i * size);
                orient = (int)Marshal.PtrToStructure(iPtr, typeof(int));
                faceInfo.faceOrient = orient;

                FaceInfoList.Add(faceInfo);
            }
            return FaceInfoList;
        }

        public void Dispose()
        {
            Marshal.FreeCoTaskMem(MultiFaceInfo.faceRect);
            Marshal.FreeCoTaskMem(MultiFaceInfo.faceOrient);
        }

    }

}
