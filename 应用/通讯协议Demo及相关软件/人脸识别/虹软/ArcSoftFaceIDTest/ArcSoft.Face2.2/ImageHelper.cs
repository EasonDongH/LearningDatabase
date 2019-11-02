using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace ArcSoft.Face2._2
{
    /// <summary>
    /// 图片信息转换类 
    /// </summary>
    public class ImageHelper
    {

        /// <summary>
        /// Convert Image to Byte[]
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image Image, ImageFormat imageFormat)
        {
            if (Image == null) { return null; }
            byte[] data = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap Bitmap = new Bitmap(Image))
                {
                    Bitmap.Save(ms, imageFormat);
                    ms.Position = 0;
                    data = new byte[ms.Length];
                    ms.Read(data, 0, Convert.ToInt32(ms.Length));
                    ms.Flush();
                }
            }
            return data;
        }

        /// <summary>
        /// 以ImageFormat.Jpeg格式转换图片
        /// </summary>
        /// <param name="Image"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image Image)
        {
            return ImageToBytes(Image, ImageFormat.Jpeg);
        }

        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// Convert Byte[] to a picture and Store it in file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string CreateImageFromBytes(string fileName, byte[] buffer)
        {
            string file = fileName;
            Image image = BytesToImage(buffer);
            ImageFormat format = image.RawFormat;
            if (format.Equals(ImageFormat.Jpeg))
            {
                file += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Png))
            {
                file += ".png";
            }
            else if (format.Equals(ImageFormat.Bmp))
            {
                file += ".bmp";
            }
            else if (format.Equals(ImageFormat.Gif))
            {
                file += ".gif";
            }
            else if (format.Equals(ImageFormat.Icon))
            {
                file += ".icon";
            }
            System.IO.FileInfo info = new System.IO.FileInfo(file);
            System.IO.Directory.CreateDirectory(info.Directory.FullName);
            File.WriteAllBytes(file, buffer);
            return file;
        }

        //byte[] 转换 Bitmap
        public static Bitmap BytesToBitmap(byte[] bytes)
        {
            Bitmap bitmap = null;
            MemoryStream stream = null;
            try
            {
                // 如果文件没有有效的图像格式，或者如果 GDI+ 不支持文件的像素格式，则此方法将引发 OutOfMemoryException 异常。
                // MSDN：http://msdn.microsoft.com/zh-cn/library/vstudio/stf701f5(v=vs.85).aspx
                stream = new MemoryStream(bytes);
                bitmap = new Bitmap(Image.FromStream(stream));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
            }
            return bitmap;
        }

        public static bool BytesToBitmap(byte[] bytes, ref Bitmap outBitmap)
        {
            bool res = false;
            MemoryStream stream = null;
            try
            {
                // 如果文件没有有效的图像格式，或者如果 GDI+ 不支持文件的像素格式，则此方法将引发 OutOfMemoryException 异常。
                // MSDN：http://msdn.microsoft.com/zh-cn/library/vstudio/stf701f5(v=vs.85).aspx
                stream = new MemoryStream(bytes);
                outBitmap = new Bitmap(Image.FromStream(stream));
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
                throw ex;
            }
            finally
            {
                stream.Close();
            }
            return res;
        }

        /// <summary>
        /// 根据faceRect来获取矩形图像
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="singleFaceInfo"></param>
        /// <returns></returns>
        public static Bitmap GetRectangleImage(Bitmap sourceImage, Rectangle faceRect)
        {
            Bitmap singleFace = new Bitmap(faceRect.Width, faceRect.Height);
            using (Graphics draw = Graphics.FromImage(singleFace))
            {
                draw.DrawImage(sourceImage, 0, 0, faceRect, GraphicsUnit.Pixel);
            }
            return singleFace;
        }

        /// <summary>
        /// 深度复制
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Bitmap DeepCopyBitmap(Bitmap bitmap)
        {
            try
            {
                Bitmap dstBitmap = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, bitmap);
                    ms.Seek(0, SeekOrigin.Begin);
                    dstBitmap = (Bitmap)bf.Deserialize(ms);
                    ms.Close();
                }
                return dstBitmap;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
