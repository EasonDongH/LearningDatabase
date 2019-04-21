using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Models;

namespace UpdatePro
{
    public partial class FrmTips : Form
    {

        Point point = new Point();
        private int height = 0;
        private int bottom = 0;
        public FrmTips()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 用于弹出的定时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Up_Tick(object sender, EventArgs e)
        {
            height += 10;
            if (this.Top <= Screen.GetWorkingArea(point).Bottom - 170)
            {
                this.timer1_Up.Enabled = false;
                this.timer2_Down.Enabled = true;
            }
            else
            {
                this.Top = Screen.GetWorkingArea(point).Bottom - height;
            }
        }

        /// <summary>
        /// 窗体加载时定位窗体的初始位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTips_Load(object sender, EventArgs e)
        {
            this.Left = Screen.GetWorkingArea(point).Right - this.Width;
            this.Top = Screen.GetWorkingArea(point).Bottom;
        }

        int delay = 0;//用于窗口的停留延时

        /// <summary>
        /// 用于窗口退出的定时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Down_Tick(object sender, EventArgs e)
        {
            delay += 1;
            if (delay > 500)
            {
                bottom += 1;
                if (this.Top >= Screen.GetWorkingArea(point).Bottom)
                {
                    this.timer2_Down.Enabled = false;
                    this.Close();
                }
                else
                {
                    this.Top = this.Top + bottom;
                }
            }
        }
        //马上升级
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
            if (MessageBox.Show("即将退出当前程序！确认退出吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            Application.Exit();
            //启动升级程序
            System.Diagnostics.Process.Start(@"C:\WorkSpace\CSharp\AutoUpdateDemo\AutoUpdateDemo\bin\Debug\UpdatePro.exe");
        }
        //下次再说
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
