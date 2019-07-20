using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Camera
{
    public static class MatExtendsions
    {
        /// <summary>
        /// 画虚线框
        /// </summary>
        /// <param name="img">图片帧</param>
        /// <param name="linelength">线长度</param>
        /// <param name="dashlength">空白长度</param>
        /// <param name="rect">矩形区域</param>
        /// <param name="color">边框颜色</param>
        /// <param name="thickness">边框线条粗细</param>
        public static void DrawDashRect(Mat img, int linelength, int dashlength, Rectangle rect, Color color, int thickness)
        {
            int w = rect.Width;//width
            int h = rect.Height;//height

            int tl_x = rect.X;//top left x
            int tl_y = rect.Y;//top  left y

            int totallength = dashlength + linelength;
            int nCountX = w / totallength;//
            int nCountY = h / totallength;//

            Point start, end;//start and end point of each dash
            start = Point.Empty;
            end = Point.Empty;
            //draw the horizontal lines
            start.Y = tl_y;
            start.X = tl_x;

            end.X = tl_x;
            end.Y = tl_y;

            for (int i = 0; i < nCountX; i++)
            {
                end.X = tl_x + (i + 1) * totallength - dashlength;//draw top dash line
                end.Y = tl_y;
                start.X = tl_x + i * totallength;
                start.Y = tl_y;
                CvInvoke.Line(img, start, end, new Bgr(color).MCvScalar, thickness, LineType.EightConnected, 0);
            }
            for (int i = 0; i < nCountX; i++)
            {
                start.X = tl_x + i * totallength;
                start.Y = tl_y + h;
                end.X = tl_x + (i + 1) * totallength - dashlength;//draw bottom dash line
                end.Y = tl_y + h;
                CvInvoke.Line(img, start, end, new Bgr(color).MCvScalar, thickness, LineType.EightConnected, 0);
            }
            for (int i = 0; i < nCountY; i++)
            {
                start.X = tl_x;
                start.Y = tl_y + i * totallength;
                end.Y = tl_y + (i + 1) * totallength - dashlength;//draw left dash line
                end.X = tl_x;
                CvInvoke.Line(img, start, end, new Bgr(color).MCvScalar, thickness, LineType.EightConnected, 0);
            }
            for (int i = 0; i < nCountY; i++)
            {
                start.X = tl_x + w;
                start.Y = tl_y + i * totallength;
                end.Y = tl_y + (i + 1) * totallength - dashlength;//draw right dash line
                end.X = tl_x + w;
                CvInvoke.Line(img, start, end, new Bgr(color).MCvScalar, thickness, LineType.EightConnected, 0);
            }
        }

        /// <summary>
        /// 图片帧居中画虚线框
        /// </summary>
        /// <param name="img">图片帧</param>
        /// <param name="linelength"></param>
        /// <param name="dashlength"></param>
        /// <param name="width">Rect</param>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        public static void DrawDashRectCenter(Mat img, int linelength, int dashlength, int width, int height, Color color, int thickness)
        {
            int w = width;//width
            int h = height;//height


            int tl_x = (img.Width - w) / 2;//top left x
            int tl_y = (img.Height - h) / 2;//top  left y


            DrawDashRect(img, linelength, dashlength, new Rectangle(tl_x, tl_y, w, h), color, thickness);



        }

        /// <summary>
        /// 图片帧居中位置画实线框
        /// </summary>
        /// <param name="img">图片帧</param>
        /// <param name="width">Rectangle宽度</param>
        /// <param name="height">Rectangle高度</param>
        /// <param name="color">边框颜色</param>
        /// <param name="thickness">边框线条粗细</param>
        public static void DrawRectCenter(Mat img, int width, int height, Color color, int thickness)
        {
            int w = width;//width
            int h = height;//height


            int tl_x = (img.Width - w) / 2;//top left x
            int tl_y = (img.Height - h) / 2;//top  left y

            CvInvoke.Rectangle(img, new Rectangle(tl_x, tl_y, w, h), new Bgr(color).MCvScalar, 1, LineType.EightConnected, 0);

        }


        public static void DrawRectCenterNew(Mat img, int width, int height, Color color, int thickness, int x, int y)
        {
            int w = width;//width
            int h = height;//height


            int tl_x = x;//top left x
            int tl_y = y;//top  left y

            CvInvoke.Rectangle(img, new Rectangle(tl_x, tl_y, w, h), new Bgr(color).MCvScalar, 1, LineType.EightConnected, 0);

        }

        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">颜色</param>
        /// <param name="thickness">边框线条粗细</param>
        public static void DrawRect(Mat img, Rectangle rect, Color color, int thickness)
        {

            CvInvoke.Rectangle(img, rect, new Bgr(color).MCvScalar, 1, LineType.EightConnected, 0);

        }
    }
}
