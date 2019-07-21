using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Base;
using ArcSoft.Face2._2;

namespace ArcSoftFaceIDTest
{
    public partial class MainForm : Form
    {
        private const string txtFormat = "【{0}】{1}", timeFormat = "HH:mm:ss";
        private FaceControl _faceControlImg = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this._faceControlImg = new FaceControl(AsfEnums.AsfFaceDetectMode.ASF_DETECT_MODE_IMAGE);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._faceControlImg != null)
                this._faceControlImg.Dispose();
        }

        private void faceDetectResult(Bitmap bmp, object[] obj)
        {
            this.pb_CurrentFace.Image = bmp;
            this.pb_CurrentFace.Tag = obj;
            this.rtbInfo.Text += string.Format(txtFormat, DateTime.Now.ToString(timeFormat), "人脸检测信息回传成功");
        }

        private void btnDetectFace_Click(object sender, EventArgs e)
        {
            FaceDetectForm frm = new FaceDetectForm(faceDetectResult);
            frm.ShowDialog();
        }

        private void btnSaveFace_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchFace_Click(object sender, EventArgs e)
        {

        }

        private void btnAnalysisFace_Click(object sender, EventArgs e)
        {

        }

        private void rtbInfo_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            rtb.Select(rtb.Text.Length, 0);
            rtb.ScrollToCaret();
        }
    }
}
