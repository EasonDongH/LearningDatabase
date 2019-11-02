using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace MyCostumControl
{
    [DefaultEvent("Enter")]
    public class ExGroupGox : Control
    {
        private string _caption = string.Empty;
        private int _captionHeight = 23;
        private Font _captionFont = SystemFonts.DefaultFont;
        private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;
        private ContentAlignment _captionAlign = ContentAlignment.MiddleCenter;
        private Rectangle btnRect = Rectangle.Empty;
        private bool _expend = true;
        private int _orgHeight = 0;
        private bool _buttonEnable = true;
        private bool _buttonVisible = false;
        private Image _expendImage = Properties.Resources.expend;
        private Image _collapseImage = Properties.Resources.collapse;
        private Color _captionBkColor = ColorTranslator.FromHtml("#E5EFFE");
        private Color _borderColor = ColorTranslator.FromHtml("#BED5F3");
        private bool _dockMenuStyle = false;
        private bool _captionUseLinearGradient = false;
        private Color _captionLinearGradientColorStart = Color.AliceBlue;
        private Color _captionLinearGradientColorEnd = Color.LightSteelBlue;
        private bool _transparent = false;
        private int _opacity = 50;
        private bool _captionTransparent = false;
        private int _captionOpacity = 50;
        private bool _border = true;
        private Color _contentBackColor = Color.White;

        public ExGroupGox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //该设置忽略WM_ERASEBKGND系统消息来减少闪烁(true)，WM_ERASEBKGND是操作系统指示整个窗体被擦除的时候才被调用
            //那么，这段话主要就是要求在双缓存中绘制图形，然后再显示到Screen上，这个要求USERPaint是开启（true）的状态
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //这个就是为绘制开启双缓存，前提就是上面的设置，因为要使用双缓存必须启用WM_Paint...，则要求所有的绘制都在WM_Paint中，那么就是ALLPaintInWm_Paint
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //这个标签是通知系统，当控件大小发生改变的时候应该进行重绘
            this.SetStyle(ControlStyles.Selectable, true);
            //通知系统该控件接受焦点，即可以被选中....
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //通知系统该控件支持透明的背景色,其启用条件是USERPaint为true，且其父控件派生自Control才可以，我们这个控件是派生自Button，所以是可以使用的
            this.BackColor = Color.White;
            this.Width = 150;
            this.Height = 100;
            this.Caption = "标题";
            //this.ForeColor= Color.FromArgb(244, 119, 0);
            this.MouseClick += new MouseEventHandler(ExGroupGox_MouseClick);
            this.ControlAdded += new ControlEventHandler(ExGroupGox_ControlAdded);
            this.ControlRemoved += new ControlEventHandler(ExGroupGox_ControlRemoved);
            this.DockChanged += new EventHandler(ExGroupGox_DockChanged);
            //this.Margin = new Padding(0);
            //this.Padding = new Padding(0);
        }

        void ExGroupGox_DockChanged(object sender, EventArgs e)
        {
            if (_buttonVisible)
            {
                if (this.Dock == DockStyle.Fill)
                {
                    throw new Exception("ButtonVisible时，Dock属性不能设置为Fill");
                }
            }
        }

        void ExGroupGox_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (this._dockMenuStyle)
            {
                int allHeight = 0;
                foreach (Control ctl in this.Controls)
                {
                    allHeight += ctl.Height;
                }
                this.Height = allHeight + this.Padding.Top + this.Padding.Bottom + _captionHeight;
                this.Refresh();
            }
        }

        void ExGroupGox_ControlAdded(object sender, ControlEventArgs e)
        {

            if (this._dockMenuStyle)
            {
                e.Control.Dock = DockStyle.Top;
                int allHeight = 0;
                foreach (Control ctl in this.Controls)
                {
                    allHeight += ctl.Height;
                }
                this.Height = allHeight + this.Padding.Top + this.Padding.Bottom + _captionHeight;
                this.Refresh();
            }
        }

        protected void ExGroupGox_MouseClick(object sender, MouseEventArgs e)
        {
            ButtonClick(e);
        }

        protected virtual void ButtonClick(MouseEventArgs e)
        {
            if (btnRect != Rectangle.Empty && _buttonVisible && _buttonEnable)
            {
                if (btnRect.Contains(e.Location))
                {
                    if (_expend)
                    {
                        _orgHeight = this.Height;
                        this.Height = _captionHeight;
                    }
                    else
                    {
                        this.Height = _orgHeight;
                    }
                    _expend = !_expend;
                    this.Refresh();
                }
            }
        }

        public void Expend()
        {
            this._expend = true;
            this.Height = _orgHeight;
            this.Refresh();

        }

        public void Collapse()
        {
            this._expend = false;
            _orgHeight = this.Height;
            this.Height = _captionHeight;
            this.Refresh();

        }

        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                if (value == DockStyle.Fill || value == DockStyle.Left || value == DockStyle.Right)
                {
                    if (_buttonVisible)
                    {
                        throw new Exception("ButtonVisible设置为true时，Dock属性不能设置为Fill,Left或者Right");
                    }
                    else
                        base.Dock = value;
                }
                else
                    base.Dock = value;
            }
        }

        public bool CaptionUseLinearGradient
        {
            get { return _captionUseLinearGradient; }
            set { _captionUseLinearGradient = value; }
        }

        public Color CaptionLinearGradientColorStart
        {
            get { return _captionLinearGradientColorStart; }
            set { _captionLinearGradientColorStart = value; }
        }

        public Color CaptionLinearGradientColorEnd
        {
            get { return _captionLinearGradientColorEnd; }
            set { _captionLinearGradientColorEnd = value; }
        }



        [Description("是否停靠菜单样式")]
        public bool DockMenuStyle
        {
            get { return _dockMenuStyle; }
            set { _dockMenuStyle = value; }
        }

        [Description("标题背景色")]
        public Color CaptionBackColor
        {
            get { return _captionBkColor; }
            set { _captionBkColor = value; }
        }

        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        [Description("展开图标")]
        public Image ExpandImage
        {
            get { return _expendImage; }
            set { _expendImage = value; }
        }

        [Description("伸缩图标")]
        public Image CollapseImage
        {
            get { return _collapseImage; }
            set { _collapseImage = value; }
        }

        [Description("展开、伸缩按钮可见性")]
        [Browsable(true)]
        public bool ButtonVisible
        {
            get { return _buttonVisible; }
            set
            {
                _buttonVisible = value;
                if (_buttonVisible && (this.Dock == DockStyle.Fill || this.Dock == DockStyle.Left || this.Dock == DockStyle.Right))
                {
                    throw new Exception("Dock属性为Fill,Left或者Right时,ButtonVisible不能设置为true");
                }

            }
        }

        [Description("标题")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; this.Refresh(); }
        }

        [Browsable(false)]
        public override Rectangle DisplayRectangle
        {
            get
            {
                return new Rectangle(this.Padding.Left, _captionHeight + this.Padding.Top, this.Width - this.Padding.Left - this.Padding.Right, this.Height - CaptionHeight - this.Padding.Top - this.Padding.Bottom);

            }
        }

        [Description("标题区域高度")]
        public int CaptionHeight
        {
            get { return _captionHeight; }
            set { _captionHeight = value; }
        }

        [Description("标题字体")]
        public Font CaptionFont
        {
            get { return _captionFont; }
            set { _captionFont = value; this.Refresh(); }
        }

        [Description("内容字体对齐方式")]
        public ContentAlignment TextAlign
        {
            get { return _textAlign; }
            set { _textAlign = value; this.Refresh(); }
        }

        [Description("标题字体对齐方式")]
        public ContentAlignment CaptionAlign
        {
            get { return _captionAlign; }
            set { _captionAlign = value; this.Refresh(); }
        }

        public bool Transparent
        {
            get { return _transparent; }
            set { _transparent = value; this.Refresh(); }
        }

        public int Opacity
        {
            get { return _opacity; }
            set { _opacity = value; this.Refresh(); }
        }

        public bool CaptionTransparent
        {
            get { return _captionTransparent; }
            set { _captionTransparent = value; this.Refresh(); }
        }

        public int CaptionOpacity
        {
            get { return _captionOpacity; }
            set { _captionOpacity = value; this.Refresh(); }
        }


        public bool Border
        {
            get { return _border; }
            set { _border = value; this.Refresh(); }
        }

        public Color ContentBackColor
        {
            get { return _contentBackColor; }
            set { _contentBackColor = value; this.Refresh(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //int arcWidth = 8;
            // int widthoffset = 0;

            base.OnPaint(e);
            Rectangle rectMain = new Rectangle(this.Margin.Left, Margin.Top + _captionHeight, this.Width - Margin.Left - Margin.Right, this.Height - _captionHeight);
            Rectangle rectCaption = new Rectangle(this.Margin.Left, Margin.Top, this.Width - Margin.Left - Margin.Right, _captionHeight);
            Rectangle rectContent = new Rectangle(this.Margin.Left, Margin.Top + _captionHeight, this.Width - Margin.Left - Margin.Right, this.Height - _captionHeight);

            GraphicsPath pathBk = new GraphicsPath();
            pathBk.AddRectangle(rectMain);
            GraphicsPath captionPath = new GraphicsPath();
            captionPath.AddRectangle(rectCaption);

            //画背景
            e.Graphics.FillPath(new SolidBrush(_contentBackColor), pathBk);

            //画内容区域
            e.Graphics.FillPath(new SolidBrush(_contentBackColor), pathBk);


            //pathBk.AddRectangle(ClientRectangle);
            //if (CaptionTransparent)
            //{
            //    //e.Graphics.FillPath(new SolidBrush(Color.FromArgb(20,255,255,255)), pathBk);
            //}
            ////else
            ////{
            //pathBk.AddRectangle(rectBound);
            //    e.Graphics.FillPath(new SolidBrush(Color.White), pathBk);
            ////}

            //GraphicsPath path = new GraphicsPath();
            //if (_expend)
            //{
            //    rectBound = new Rectangle(this.Margin.Left, Margin.Top + _captionHeight, this.Width - Margin.Left - Margin.Right, this.Height - _captionHeight);
            //    path.AddRectangle(rectBound);
            //}
            //else
            //{
            //    //path = GraphicsUtil.GetRectPath(new Rectangle(this.Margin.Left, this.Margin.Top, this.Width - this.Margin.Left - this.Margin.Right, this._captionHeight-this.Margin.Bottom), arcWidth);
            //    path.AddRectangle(new Rectangle(this.Margin.Left, this.Margin.Top, this.Width - this.Margin.Left - this.Margin.Right, this._captionHeight - this.Margin.Bottom));
            //}
            //if (_expend)
            //{
            //    e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
            //}

            //画标题区域
            //GraphicsPath captionPath = new GraphicsPath();

            // Rectangle rectCaption = new Rectangle(this.Margin.Left, this.Margin.Top, this.Width - this.Margin.Left - this.Margin.Right, _captionHeight);
            // captionPath.AddRectangle(rectCaption);

            if (_captionUseLinearGradient)
            {
                LinearGradientBrush captionBrush = new LinearGradientBrush(new Rectangle(new Point(this.Margin.Left, this.Margin.Top), new Size(this.Width - this.Margin.Left - this.Margin.Right, _captionHeight)), _captionLinearGradientColorStart, _captionLinearGradientColorEnd, 90);
                e.Graphics.FillPath(captionBrush, captionPath);
            }
            else
            {
                Brush captionBrush = null;
                if (CaptionTransparent)
                    captionBrush = new SolidBrush(Color.FromArgb(CaptionOpacity, _captionBkColor));
                else
                    captionBrush = new SolidBrush(_captionBkColor);
                e.Graphics.FillPath(captionBrush, captionPath);
            }
            if (_expend)
            {
                if (Border)
                {
                    Pen ExpendBorderPen = new Pen(this.BorderColor, 1);
                    e.Graphics.DrawPath(ExpendBorderPen, captionPath);
                }
            }
            DrawBackGroundImage(e);
            //边框
            Rectangle rectBorder = new Rectangle(this.Margin.Left, Margin.Top, this.Width - Margin.Left - Margin.Right, this.Height - Margin.Top - Margin.Bottom);
            GraphicsPath pathBorder = new GraphicsPath();
            pathBorder.AddRectangle(rectBorder);

            if (Border)
            {
                Pen borderPen = new Pen(this.BorderColor, 1);
                e.Graphics.DrawPath(borderPen, pathBorder);
            }
            //画字符
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            if (_expend)
            {
                e.Graphics.DrawString(this.Text, Font, new SolidBrush(this.ForeColor), GetContentPosX(_textAlign), GetContentPosY(_textAlign), GetStringFprmat(_textAlign));
            }
            e.Graphics.DrawString(this._caption, _captionFont, new SolidBrush(this.ForeColor), rectCaption, GetStringFprmat(_captionAlign));

            if (_buttonVisible)
            {
                DrawExpandButton(e);
            }
        }

        private int GetCaptionPosX(ContentAlignment ca)
        {
            //int x = 0;
            int x = this.Margin.Left;
            switch (ca)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    x = this.Margin.Left + (this.Width - this.Margin.Left - this.Margin.Right) / 2;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    x = this.Width - this.Margin.Right;
                    break;
                default:
                    break;
            }
            return x;
        }

        private int GetCaptionPosY(ContentAlignment ca)
        {
            //int y = 0;
            int y = this.Margin.Top;
            switch (ca)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    break;
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    y = this.Margin.Top + (_captionHeight - this._captionFont.Height) / 2;
                    break;
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomRight:
                    y = this.Margin.Top + this._captionHeight - this._captionFont.Height;
                    break;
                default:
                    break;
            }
            return y;
        }

        private int GetContentPosX(ContentAlignment ca)
        {
            int x = 0;
            switch (ca)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    x = this.Width / 2;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    x = this.Width;
                    break;
                default:
                    break;
            }
            return x;
        }

        private int GetContentPosY(ContentAlignment ca)
        {
            int y = _captionHeight;
            switch (ca)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    break;
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    y = (this.Height + _captionHeight - this.Font.Height) / 2;
                    break;
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomRight:
                    y = this.Height - this.Font.Height;
                    break;
                default:
                    break;
            }
            return y;
        }

        private StringFormat GetStringFprmat(ContentAlignment ca)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
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

        private void DrawExpandButton(PaintEventArgs e)
        {
            int btnHeight = 16;
            btnRect = new Rectangle(this.Width - btnHeight - this.Margin.Right - 4, (_captionHeight - btnHeight - this.Margin.Top) / 2, btnHeight, btnHeight);
            if (_collapseImage != null && _expend)
            {
                e.Graphics.DrawImage(_collapseImage, btnRect);
            }
            if (_expendImage != null && !_expend)
            {
                e.Graphics.DrawImage(_expendImage, btnRect);
            }


        }

        protected void DrawBackGroundImage(PaintEventArgs e)
        {
            if (this.BackgroundImage != null)
            {
                switch (this.BackgroundImageLayout)
                {
                    case ImageLayout.None:
                        e.Graphics.DrawImage(this.BackgroundImage, this.Margin.Left, this.Margin.Top);
                        break;
                    case ImageLayout.Center:
                        e.Graphics.DrawImage(this.BackgroundImage, (this.Width - BackgroundImage.Width) / 2, (this.Height - BackgroundImage.Height) / 2);
                        break;
                    case ImageLayout.Stretch:
                    case ImageLayout.Zoom:
                        e.Graphics.DrawImage(this.BackgroundImage, new Rectangle(this.Margin.Left, this.Margin.Top, this.Width - this.Margin.Left - this.Margin.Right, this.Height - this.Margin.Top - this.Margin.Bottom));
                        break;
                    case ImageLayout.Tile:
                        break;
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ExGroupGox
            // 
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.ResumeLayout(false);

        }

    }
}
