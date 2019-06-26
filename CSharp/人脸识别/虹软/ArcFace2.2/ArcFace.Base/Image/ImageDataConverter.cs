using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using ArcFace.Models;

namespace ArcFace.Base
{
    /// <summary>
    /// 图片信息转换类
    /// </summary>
    public class ImageDataConverter
    {
        [DllImport("kernel32.dll")]
        public static extern void CopyMemory(IntPtr destination, IntPtr source, int length);

        /// <summary>
        /// Bitmap转ImageData同时将宽度不为4的倍数的图像进行调整，注意ImageData在用完之后要用Dispose释放掉
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static ImageDataModel ConvertToImageData(Bitmap bitmap)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int width = (bitmap.Width + 3) / 4 * 4;
            int bytesCount = bmpData.Height * width * 3;
            IntPtr pImageData = Marshal.AllocCoTaskMem(bytesCount);
            if (width == bitmap.Width)
                CopyMemory(pImageData, bmpData.Scan0, bytesCount);
            else
                for (int i = 0; i < bitmap.Width; i++)
                    CopyMemory(IntPtr.Add(pImageData, i * width * 3), IntPtr.Add(bmpData.Scan0, i * bmpData.Stride), bmpData.Stride);
                    //CopyMemory(new IntPtr(pImageData.ToInt32() + i * width * 3), new IntPtr(bmpData.Scan0.ToInt32() + i * bmpData.Stride), bmpData.Stride);
            bitmap.UnlockBits(bmpData);
            return new ImageDataModel(width, bitmap.Height, pImageData);
        }

        //public void ParseImage(Bitmap image)
        //{
        //    int tempwidth = 0;
        //    if (image.Width % 4 != 0)
        //    {
        //        tempwidth = image.Width / 4 * 4;
        //    }
        //    else
        //    {
        //        tempwidth = image.Width;
        //    }
        //    BitmapData data = image.LockBits(new Rectangle(0, 0, tempwidth, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

        //    IntPtr ptr = data.Scan0;
        //    int soureBitArrayLength = data.Height * Math.Abs(data.Stride);

        //    byte[] sourceBitArray = new byte[soureBitArrayLength];

        //    //将bitmap中的内容拷贝到ptr_bgr数组中
        //    Marshal.Copy(ptr, sourceBitArray, 0, soureBitArrayLength);

        //    //Marshal.FreeHGlobal(ptr);

        //    Width = data.Width;
        //    Height = data.Height;
        //    Format = 0x201;
        //    int pitch = Math.Abs(data.Stride);

        //    int line = Width * 3;
        //    int bgr_len = line * Height;

        //    ImageData = new byte[bgr_len];
        //    for (int i = 0; i < Height; ++i)
        //    {
        //        Array.Copy(sourceBitArray, i * pitch, ImageData, i * line, line);
        //    }

        //    image.UnlockBits(data);

        //}
    }
}
