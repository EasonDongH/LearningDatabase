using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace MyCostumControl
{
    public class GraphicsUtil
    {
        public static GraphicsPath GetRectPath(int x, int y, int width, int height, int arcWidth)
        {
            GraphicsPath gp = new GraphicsPath();
            if (arcWidth > 0)
            {
                gp.AddArc(x, y, arcWidth, arcWidth, 180, 90);
                gp.AddArc(width + x - arcWidth - 1, y, arcWidth, arcWidth, 270, 90);
                gp.AddArc(width + x - arcWidth - 1, height + y - arcWidth - 1, arcWidth, arcWidth, 0, 90);
                gp.AddArc(x, height + y - arcWidth - 1, arcWidth, arcWidth, 90, 90);
                gp.CloseAllFigures();
            }
            else
            {
                gp.AddRectangle(new Rectangle(x, y, arcWidth, arcWidth));
            }
            return gp;
        }

        public static GraphicsPath GetRectPath(Rectangle rect, int arcWidth)
        {
            return GetRectPath(rect.X, rect.Y, rect.Width, rect.Height, arcWidth);
        }

        public static GraphicsPath GetRectRightRoundPath(int x, int y, int width, int height, int arcWidth)
        {
            GraphicsPath gp = new GraphicsPath();
            if (arcWidth > 0)
            {
                gp.AddArc(width + x - arcWidth - 1, height + y - arcWidth - 1, arcWidth, arcWidth, 0, 90);
                gp.AddLine(x, height + y - 1, x, height + y - 1);
                gp.AddLine(x, y, x, y);
                gp.AddArc(width + x - arcWidth - 1, y, arcWidth, arcWidth, 270, 90);
                gp.CloseAllFigures();
            }
            else
            {
                gp.AddRectangle(new Rectangle(x, y, arcWidth, arcWidth));
            }
            return gp;
        }

        public static GraphicsPath GetRectRightRoundPath(Rectangle rect, int arcWidth)
        {
            return GetRectRightRoundPath(rect.X, rect.Y, rect.Width, rect.Height, arcWidth);
        }

        public static GraphicsPath GetRectTopRoundPath(int x, int y, int width, int height, int arcWidth)
        {
            GraphicsPath gp = new GraphicsPath();
            if (arcWidth > 0)
            {
                gp.AddArc(x, y, arcWidth, arcWidth, 180, 90);
                gp.AddArc(width + x - arcWidth - 1, y, arcWidth, arcWidth, 270, 90);
                gp.AddLine(x + width - 1, height + y - 1, x + width - 1, height + y - 1);
                gp.AddLine(x, height + y - 1, x, height + y - 1);
                gp.CloseAllFigures();
            }
            else
            {
                gp.AddRectangle(new Rectangle(x, y, arcWidth, arcWidth));
            }
            return gp;
        }

        public static GraphicsPath GetRectTopRoundPath(Rectangle rect, int arcWidth)
        {
            return GetRectTopRoundPath(rect.X, rect.Y, rect.Width, rect.Height, arcWidth);
        }
    }
}
