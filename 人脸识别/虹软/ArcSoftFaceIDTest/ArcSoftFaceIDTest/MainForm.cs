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
        private readonly string txtFormat = "【{0}】{1}" + Environment.NewLine, timeFormat = "HH:mm:ss";
        private FaceControl _faceControlImgMode = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this._faceControlImgMode = new FaceControl(AsfEnums.AsfFaceDetectMode.ASF_DETECT_MODE_IMAGE);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._faceControlImgMode != null)
                this._faceControlImgMode.Dispose();
        }

        private void faceDetectResult(Bitmap bmp, object[] obj)
        {
            this.pbFace1.Image = bmp;
            this.pbFace1.Tag = obj;
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
            AnalysisFace();
        }

        private void btnCompareFace_Click(object sender, EventArgs e)
        {
            CompareFace();
        }

        private void AnalysisFace()
        {
            if (this.pbFace1.Image == null)
            {
                MessageBox.Show("请在第一个图片框中添加图像！");
                return;
            }
            byte[] imgData = ImageHelper.ImageToBytes(this.pbFace1.Image);
            AsfStruct.ASF_AgeInfo ageInfo = new AsfStruct.ASF_AgeInfo(); 
            AsfStruct.ASF_GenderInfo genderInfo = new AsfStruct.ASF_GenderInfo(); 
            AsfStruct.ASF_Face3DAngle face3dAngle = new AsfStruct.ASF_Face3DAngle();
            AsfEnums.ResultCode res = this._faceControlImgMode.AnalysisFace(imgData, ref ageInfo, ref genderInfo, ref face3dAngle);
            string txt = string.Empty;
            if (res != AsfEnums.ResultCode.MOK)
            {
                txt = "人脸解析失败！错误信息：" + res.ToString();
                MessageBox.Show(txt);
            }
            else
            {
                List<int> ageList = AsfStruct.ASF_AgeInfo.PtrToAgeArray(ageInfo);
                List<int> genderList = AsfStruct.ASF_GenderInfo.PtrToGenderArray(genderInfo);
                List<Face3DAngleModel> face3dAngleList = AsfStruct.ASF_Face3DAngle.PtrToFace3DAngleArray(face3dAngle);
                txt += "人脸信息如下：" + Environment.NewLine;
                for (int i = 0; i < ageList.Count; ++i)
                {
                    txt += string.Format("年龄：{0}；性别(0男1女-1未知)：{1}；脸部3D角度：{2}", ageList[i], genderList[i], face3dAngleList[i].ToString()); 
                }
            }
            this.rtbInfo.Text += string.Format(txtFormat, DateTime.Now.ToString(timeFormat), txt);
        }

        private void CompareFace()
        {
            if (this.pbFace1.Image == null)
            {
                MessageBox.Show("请选择第一张人脸图片！");
                return;
            }
            if (this.pbFace2.Image == null)
            {
                MessageBox.Show("请选择第二张人脸图片！");
                return;
            }

            float similar = 0;
            byte[] imgData1 = ImageHelper.ImageToBytes(this.pbFace1.Image);
            byte[] imgData2 = ImageHelper.ImageToBytes(this.pbFace2.Image);
            AsfEnums.ResultCode res = this._faceControlImgMode.FaceMatching(imgData1, imgData2, out similar);
            string txt = string.Empty;
            if (res != AsfEnums.ResultCode.MOK)
            {
                txt = "人脸对比异常！错误信息："+res.ToString();
                MessageBox.Show(txt);
            }
            else
            {
                txt = "人脸对比成功！相似度：" + similar;
            }
            this.rtbInfo.Text += string.Format(txtFormat, DateTime.Now.ToString(timeFormat), txt);
        }

        private void pbSelectFace_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PictureBox pb = sender as PictureBox;
                pb.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void rtbInfo_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            rtb.Select(rtb.Text.Length, 0);
            rtb.ScrollToCaret();
        }
    }
}
