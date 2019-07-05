using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace MyCostumControl
{
    [ToolboxBitmap(typeof(TabControl))]
    public partial class ExTabControl : TabControl
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_DRAWITEM = 0x2B;//43/0x002B
        private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;
        private Color _activeTabTextColor = Color.Black;
        private Color _tabTextColor = Color.White;
        private TextImageRelation _TextImageRelation = TextImageRelation.ImageAboveText;
        private Color _tabBkColor = SystemColors.Control;
        private Color _tabBorderColor = SystemColors.ButtonShadow;
        private Color _tabBkColorLinearStart = Color.WhiteSmoke;
        private Color _tabBkColorLinearEnd = Color.LightSteelBlue;
        private LinearGradientMode _tabBkLinearGradientMode = LinearGradientMode.Vertical;
        private bool _useTabBkColorLinear = true;
        private bool _enableBorder = true;
        private Image _closeImage = null;
        private static int DRAW_INDEX = -1;

        [Description("标签文件对齐方式")]
        public ContentAlignment TextAlign
        {
            get { return _textAlign; }
            set { _textAlign = value; }
        }

        [Description("选中的标签的文字颜色")]
        public Color ActivedTabTextColor
        {
            get { return _activeTabTextColor; }
            set { _activeTabTextColor = value; }
        }

        [Description("标签的文字颜色")]
        public Color TabTextColor
        {
            get { return _tabTextColor; }
            set { _tabTextColor = value; }
        }

        [Description("标签文字和图像排列方式")]
        public TextImageRelation TextImageRelation
        {
            get { return _TextImageRelation; }
            set { _TextImageRelation = value; }
        }

        [Description("标签背景色")]
        public Color TabBackColor
        {
            get { return _tabBkColor; }
            set { _tabBkColor = value; }
        }

        [Description("标签边框颜色")]
        public Color TabBorderColor
        {
            get { return _tabBorderColor; }
            set { _tabBorderColor = value; }
        }

        [Description("标签渐进背景色的起始颜色")]
        public Color TabBkColorLinearStart
        {
            get { return _tabBkColorLinearStart; }
            set { _tabBkColorLinearStart = value; }
        }

        [Description("标签渐进背景色的结束颜色")]
        public Color TabBkColorLinearEnd
        {
            get { return _tabBkColorLinearEnd; }
            set { _tabBkColorLinearEnd = value; }
        }

        [Description("标签背景色渐进模式")]
        public LinearGradientMode TabBkLinearGradientMode
        {
            get { return _tabBkLinearGradientMode; }
            set { _tabBkLinearGradientMode = value; }
        }

        [Description("启用标签背景色渐进模式")]
        public bool EnableTabBkColorLinear
        {
            get { return _useTabBkColorLinear; }
            set { _useTabBkColorLinear = value; }
        }

        public Image CloseImage
        {
            get { return _closeImage; }
            set { _closeImage = value; }
        }


        public ExTabControl()
            : base()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.ResizeRedraw = true;
            this.ItemSize = new Size(80, 80);
            this.Padding = new Point(20, 0);
            this.HotTrack = true;
            this.ShowToolTips = true;
            this.SizeMode = TabSizeMode.Fixed;
            this.MouseMove += new MouseEventHandler(ExTabControl_MouseMove);
            this.DrawItem += new DrawItemEventHandler(ExTabControl_DrawItem);
            this.MouseClick += new MouseEventHandler(ExTabControl_MouseClick);
        }

        void ExTabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.SelectedIndex >= 0 && _closeImage != null)
            {
                Rectangle rect = GetTabImageRect(this.SelectedIndex);
                rect.Location = PointToScreen(rect.Location);
                if (rect.Contains(Cursor.Position))
                {
                    int index = this.SelectedIndex;
                    this.TabPages.RemoveAt(this.SelectedIndex);
                    index--;
                    if (index < 0)
                        index = 0;
                    this.SelectedIndex = index;
                }
            }
        }

        void ExTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Console.WriteLine(e.State.ToString());

        }


        void ExTabControl_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            if (this.SelectedIndex >= 0 && _closeImage != null)
            {
                Rectangle rect = GetTabImageRect(this.SelectedIndex);
                rect.Location = PointToScreen(rect.Location);
                if (rect.Contains(Cursor.Position))
                {
                    //g.DrawImage(this.ImageList.Images[0], this.GetTabImageRect(SelectedIndex));
                    g.DrawRectangle(new Pen(Color.LightSteelBlue), GetTabImageRect(this.SelectedIndex));
                }
            }
            for (int i = 0; i < this.TabCount; i++)
            {
                if (this.SelectedIndex != i)
                {
                    Rectangle rect = GetTabRect(i);
                    rect.Location = PointToScreen(rect.Location);
                    if (rect.Contains(Cursor.Position))
                    {
                        Rectangle rectItem = GetTabRect(i);
                        GraphicsPath path = GraphicsUtil.GetRectTopRoundPath(rectItem, 12);
                        g.DrawPath(new Pen(_tabBkColorLinearEnd, (float)1), path);
                    }
                }
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_DRAWITEM:
                    Console.WriteLine("WM_DRAWITEM");
                    break;
                case 0x1d:
                    Console.WriteLine("0x1d");
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }

        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            PaintTabTransparentBackColor(pevent.Graphics);
            PaintPageRectangle(pevent.Graphics);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintTabTransparentBackColor(e.Graphics);
            PaintTabItems(e.Graphics);
            PaintPageRectangle(e.Graphics);
            PaintTabBorder(e.Graphics);
        }

        private void PaintTabTransparentBackColor(Graphics g)
        {
            Rectangle rect = this.ClientRectangle;
            rect.Offset(this.Location);
            if ((this.Parent != null))
            {
                PaintEventArgs e = new PaintEventArgs(g, rect);
                GraphicsState state = g.Save();
                g.SmoothingMode = SmoothingMode.HighSpeed;
                try
                {
                    g.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);
                    this.InvokePaintBackground(this.Parent, e);
                    this.InvokePaint(this.Parent, e);
                }

                finally
                {
                    g.Restore(state);
                    rect.Offset(-this.Location.X, -this.Location.Y);
                }
            }
            else
            {
                System.Drawing.Drawing2D.LinearGradientBrush backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(this.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                g.FillRectangle(backBrush, this.Bounds);
                backBrush.Dispose();
            }
        }

        private void PaintPageRectangle(Graphics g)
        {
            Rectangle rect = this.DisplayRectangle;
            rect.Inflate(5, 3);
            if (_useTabBkColorLinear)
            {
                //GraphicsPath path=new GraphicsPath();
                //path.AddRectangle(rect);
                //LinearGradientBrush backBrush = new LinearGradientBrush(rect, _tabBkColorLinearStart, _tabBkColorLinearEnd, _tabBkLinearGradientMode);
                //g.FillPath(backBrush, path);
                //backBrush.Dispose();
                g.FillRectangle(new SolidBrush(_tabBkColorLinearEnd), rect);
            }
            else
                g.FillRectangle(new SolidBrush(_tabBkColor), rect);
        }

        private void PaintTabBorder(Graphics g)
        {
            if (this.SelectedIndex >= 0)
            {
                Rectangle rect = this.DisplayRectangle;
                rect.Inflate(5, 3);
                Rectangle rectItem = this.GetItemRect(this.SelectedIndex);
                GraphicsPath path = new GraphicsPath();
                path.AddArc(rectItem.X, rectItem.Y, 8, 8, 180, 90);
                path.AddArc(rectItem.Right - 8, rectItem.Top, 8, 8, 270, 90);
                Point[] points = new Point[8];
                points[0] = new Point(rectItem.Right, rectItem.Top + 8);
                points[1] = new Point(rectItem.Right, rect.Top);
                points[2] = new Point(rect.Right, rect.Top);
                points[3] = new Point(rect.Right, rect.Bottom);
                points[4] = new Point(rect.Left, rect.Bottom);
                points[5] = new Point(rect.Left, rect.Top);
                points[6] = new Point(rectItem.Left, rect.Top);
                points[7] = new Point(rectItem.Left, rectItem.Top + 8);
                path.AddLines(points);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                path.CloseAllFigures();
                g.DrawPath(new Pen(_tabBorderColor, 1), path);
            }
        }

        private Rectangle GetItemRect(int index)
        {
            Rectangle rect = this.GetTabRect(index);
            rect.Inflate(-2, 3);
            return rect;
        }

        private GraphicsPath GetItemPath(int index)
        {
            Rectangle rect = this.GetTabRect(index);
            rect.Inflate(-2, 3);
            GraphicsPath path = GraphicsUtil.GetRectTopRoundPath(rect, 8);
            path.FillMode = FillMode.Winding;
            return path;

        }

        private Rectangle GetTabImageRect(int index)
        {
            Rectangle rectTab = this.GetTabRect(index);
            return new Rectangle(new Point(rectTab.Right - 16 - 5, (rectTab.Height - 16) / 2 + rectTab.Top), new Size(16, 16));
        }

        private void PaintTabItems(Graphics g)
        {
            for (int index = 0; index < this.TabCount; index++)
            {
                PaintItem(g, index);
            }
        }

        private void PaintItem(Graphics g, int index)
        {
            if (this.SelectedIndex == index)
            {

                PaintSelectedItem(g, index);
            }
            else
            {
                PaintTransparentItem(g, index);
            }

        }

        private void PaintSelectedItem(Graphics g, int index)
        {
            GraphicsPath itemPath = GetItemPath(index);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (_useTabBkColorLinear)
            {
                Rectangle rcShadow = this.GetItemRect(index);
                rcShadow.Offset(3, 3);
                GraphicsPath pathrcShadow = GraphicsUtil.GetRectTopRoundPath(rcShadow, 8);
                PathGradientBrush brShadow = new PathGradientBrush(pathrcShadow);
                brShadow.CenterColor = Color.Black;
                brShadow.SurroundColors = new Color[] { SystemColors.ControlDark };
                g.FillPath(brShadow, pathrcShadow);

                LinearGradientBrush backBrush = new LinearGradientBrush(this.GetItemRect(index), _tabBkColorLinearStart, _tabBkColorLinearEnd, _tabBkLinearGradientMode);
                g.FillPath(backBrush, itemPath);
                brShadow.Dispose();
                backBrush.Dispose();
                if (_closeImage != null)
                    g.DrawImage(_closeImage, GetTabImageRect(index));
            }
            else
            {
                g.FillPath(new SolidBrush(_tabBkColor), itemPath);
            }
            if (_enableBorder)
                g.DrawPath(new Pen(new SolidBrush(_tabBorderColor), (float)1.5), itemPath);
            PaintItemImage(g, index);
            PaintItemText(g, index);
        }

        private void PaintFocusItem(Graphics g, int index)
        {
            Rectangle rect = this.GetTabRect(index);
            rect.Inflate(-16, -16);
            rect.Offset(rect.Width / 4, rect.Height / 4);
            Brush brush = new SolidBrush(Color.FromArgb(50, Color.White));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillEllipse(brush, rect);
        }

        private void PaintTransparentItem(Graphics g, int index)
        {
            PaintItemImage(g, index);
            PaintItemText(g, index);
        }

        private void PaintItemText(Graphics g, int index)
        {
            Rectangle rect = this.GetTabRect(index);
            TabPage page = TabPages[index];
            Color color = _tabTextColor;
            int space = 10;
            if (this.SelectedIndex == index)
                color = _activeTabTextColor;
            if (this.ImageList != null && (!string.IsNullOrEmpty(page.ImageKey) || page.ImageIndex >= 0))
            {
                int txtHeight = (int)g.MeasureString(page.Text, this.Font).Height;
                int txtWidth = (int)g.MeasureString(page.Text, this.Font).Width;
                if (_TextImageRelation == TextImageRelation.TextAboveImage)
                {
                    rect.Height = txtHeight + space;
                }
                else if (_TextImageRelation == TextImageRelation.ImageAboveText)
                {
                    rect.Y = rect.Bottom - txtHeight - space;
                    rect.Height = txtHeight + space;
                }
                else if (_TextImageRelation == TextImageRelation.TextBeforeImage)
                {
                    rect.Width = txtWidth + space;
                }
                else if (_TextImageRelation == TextImageRelation.ImageBeforeText)
                {
                    rect.X = rect.Right - txtWidth - space;
                    rect.Width = txtWidth + space;
                }
            }
            g.DrawString(page.Text, this.Font, new SolidBrush(color), rect, GetStringFprmat(_textAlign));
        }

        private void PaintItemImage(Graphics g, int index)
        {
            Rectangle rect = this.GetTabRect(index);
            TabPage page = TabPages[index];
            int space = 5;
            if (this.ImageList != null)
            {
                Image img = null;
                if (!string.IsNullOrEmpty(page.ImageKey))
                {
                    img = this.ImageList.Images[page.ImageKey];
                }
                else if (page.ImageIndex >= 0)
                {
                    img = this.ImageList.Images[page.ImageIndex];
                }
                if (img != null)
                {
                    int imgHeight = this.ImageList.ImageSize.Height;
                    int imgWidth = this.ImageList.ImageSize.Width;
                    Point p = new Point((rect.Width - imgWidth) / 2, (rect.Height - imgHeight) / 2);
                    if (_TextImageRelation == TextImageRelation.TextAboveImage)
                    {
                        p.X = (rect.Width - imgWidth) / 2 + rect.Left;
                        p.Y = rect.Bottom - imgHeight - space;
                    }
                    else if (_TextImageRelation == TextImageRelation.ImageAboveText)
                    {
                        p.X = (rect.Width - imgWidth) / 2 + rect.Left;
                        p.Y = space;
                    }
                    else if (_TextImageRelation == TextImageRelation.TextBeforeImage)
                    {
                        p.X = rect.Right - imgWidth - space;
                        p.Y = (rect.Height - imgHeight) / 2 + rect.Top;
                    }
                    else if (_TextImageRelation == TextImageRelation.ImageBeforeText)
                    {
                        p.X = space;
                        p.Y = (rect.Height - imgHeight) / 2 + rect.Top;
                    }
                    g.DrawImage(img, p);
                }
            }
        }

        private StringFormat GetStringFprmat(ContentAlignment ca)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            switch (ca)
            {
                case ContentAlignment.TopLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    break;
                default:
                    break;
            }
            return sf;
        }



        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct tagDRAWITEMSTRUCT
        {

            /// UINT->unsigned int
            public uint CtlType;

            /// UINT->unsigned int
            public uint CtlID;

            /// UINT->unsigned int
            public uint itemID;

            /// UINT->unsigned int
            public uint itemAction;

            /// UINT->unsigned int
            public uint itemState;

            /// HWND->HWND__*
            public System.IntPtr hwndItem;

            /// HDC->HDC__*
            public System.IntPtr hDC;

            /// RECT->tagRECT
            public Rectangle rcItem;

            /// ULONG_PTR->unsigned int
            public uint itemData;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct tagRECT
        {

            /// LONG->int
            public int left;

            /// LONG->int
            public int top;

            /// LONG->int
            public int right;

            /// LONG->int
            public int bottom;
        }


        //ctltype
        public const int ODT_COMBOBOX = 3;
        public const int ODT_LISTBOX = 2;
        public const int ODT_STATIC = 5;
        public const int ODT_BUTTON = 4;
        public const int ODT_MENU = 1;
        public const int ODT_TAB = 101;

        //itemaction
        public const int ODA_DRAWENTIRE = 1;// 当整个控件都需要被绘制时，设置该值 
        public const int ODA_SELECT = 2;// 如果控件需要在选中状态改变时被绘制，则设置该值。此时应该检查itemstate   成员，以确定控件是否处于选中状态
        public const int ODA_FOCUS = 4;// 如果控件需要在获得或失去焦点时被绘制，则设置该值。此时应该检查itemstate成员，以确定控件是否具有输入焦点。

        //itemstate
        public const int ODS_FOCUS = 16;// 如果控件需要输入焦点，则设置该值。   
        public const int ODS_GRAYED = 2;//如果控件需要被灰色显示，则设置该值。该值只在绘制菜单时使用。   
        public const int ODS_CHECKED = 8;// 如果菜单项将被选中，则可设置该值。该值只对菜单项有用。
        public const int ODS_DEFAULT = 32;//  默认值。   
        public const int ODS_NOACCEL = 256;//控件是否有快速键盘。   
        public const int ODS_DISABLED = 4;//如果控件将被禁止，则设置该值。   
        public const int ODS_HOTLIGHT = 64;//如果鼠标指针位于控件之上，则设置该值，这时控件会显示高亮颜色。
        public const int ODS_INACTIVE = 128;//表示没有激活的菜单项。   
        public const int ODS_SELECTED = 1;//选中的菜单项。   
        public const int ODS_NOFOCUSRECT = 512;//不绘制捕获焦点的效果。
        public const int ODS_COMBOBOXEDIT = 4096;//在自绘组合框控件中只绘制选择区域。  
    }
}
