using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

using UpdatePro;

namespace AutoUpdateDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            VersionInfo versionInfo = new VersionInfo();
            // versionInfo.ReadRemoteVersion();
            //if (versionInfo.NeedUpdate)
            //{
                Application.Exit();
                System.Diagnostics.Process.Start("UpdatePro.exe");
            //}
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            VersionInfo versionInfo = new VersionInfo();
            versionInfo.ReadRemoteVersion();
            if (versionInfo.NeedUpdate)
            {
                FrmTips frmTips = new FrmTips();
                frmTips.Show();
            }
            this.timer1.Enabled = false;
        }
    }
}
