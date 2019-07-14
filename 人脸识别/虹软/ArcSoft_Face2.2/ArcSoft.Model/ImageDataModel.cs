using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ArcSoft.Model
{
    /// <summary>
    /// 图片信息类
    /// </summary>
    public class ImageDataModel : IDisposable
    {
        public ImageDataModel() { }

        public ImageDataModel(int width, int height, IntPtr pImageData, int format = AsfConstants.AsfFacePixelFormat.ASVL_PAF_RGB24_B8G8R8)
        {
            this.Width = width;
            this.Height = height;
            this.PImageData = pImageData;
            this.Format = format;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Format { get; set; }

        public IntPtr PImageData { get; set; }

        public void Dispose()
        {
            Marshal.FreeCoTaskMem(PImageData);
        }

    }
}
