using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCostumControl
{
    public partial class ScrollBar : UserControl
    {
        Timer timer = null;

        #region 属性
        /// <summary>
        /// 设置显示内容
        /// </summary>
        public string ShowText
        {
            get
            {
                return this.lbl_Text.Text;
            }
            set
            {
                this.lbl_Text.Text = value;
            }
        }
        /// <summary>
        /// 设置显示内容的颜色
        /// </summary>
        public Color TextForeColor
        {
            get
            {
                return this.lbl_Text.ForeColor;
            }
            set
            {
                this.lbl_Text.ForeColor = value;
            }
        }
        /// <summary>
        /// 设置显示内容的字体
        /// </summary>
        public Font TextFont
        {
            get
            {
                return this.lbl_Text.Font;
            }
            set
            {
                this.lbl_Text.Font = value;
            }
        }
        /// <summary>
        /// 设置滚动条滚动间隔时间
        /// </summary>
        public int Interval
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = value;
            }
        }
        #endregion
        
        public ScrollBar()
        {
            InitializeComponent();
        }

        private void ScrollBar_Load(object sender, EventArgs e)
        {
            this.timer = new Timer();
            this.timer.Interval = 100;
            this.timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // 每次向左移动5像素
            int left = this.lbl_Text.Left + 5;
            // 到达右极限后回到初始位置
            if (left + this.lbl_Text.Width >= this.Width)
                left = 0;
            this.lbl_Text.Left = left;
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        /// <summary>
        /// 调整label空间置于上下的中间
        /// </summary>
        private void AdjustLabelCenter()
        {
            this.lbl_Text.Top = (this.Height - this.lbl_Text.Height) / 2;
        }

        private void ScrollBar_Resize(object sender, EventArgs e)
        {
            AdjustLabelCenter();
        }

        private void lbl_Text_FontChanged(object sender, EventArgs e)
        {
            AdjustLabelCenter();
        }
    }
}
