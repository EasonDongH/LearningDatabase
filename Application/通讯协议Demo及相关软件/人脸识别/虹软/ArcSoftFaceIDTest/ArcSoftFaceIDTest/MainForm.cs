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
using Model;
using BLL;
using System.Threading.Tasks;

namespace ArcSoftFaceIDTest
{
    public partial class MainForm : Form
    {
        private readonly string txtFormat = "【{0}】{1}" + Environment.NewLine, timeFormat = "HH:mm:ss";
        /// <summary>
        /// 标识当前操作的是哪个picturebox
        /// </summary>
        private int _pbIndex = -1;
        private FaceControl _faceControlImgMode = null;
        private ArcFaceBLL _arcFaceBLL = new ArcFaceBLL();

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
            PictureBox pb = this._pbIndex == 0 ? this.pbFace1 : this.pbFace2;
            pb.Image = bmp;
            pb.Tag = obj;
            AnalysisFaceData(pb);
            this.rtbInfo.Text += string.Format(txtFormat, DateTime.Now.ToString(timeFormat), "人脸检测信息回传成功");
        }

        private void btnDetectFace_Click(object sender, EventArgs e)
        {
            this._pbIndex = 0;
            DetectFace();
        }

        private void btnSaveFace_Click(object sender, EventArgs e)
        {
            SaveFace();
        }

        private void btnSearchFace_Click(object sender, EventArgs e)
        {
            SearchFace();
        }

        private void btnAnalysisFace_Click(object sender, EventArgs e)
        {
            AnalysisFace();
        }

        private void btnCompareFace_Click(object sender, EventArgs e)
        {
            CompareFace();
        }

        private void DetectFace()
        {
            FaceDetectForm frm = new FaceDetectForm(faceDetectResult);
            frm.ShowDialog();
        }

        /// <summary>
        /// 解析人脸回传数据
        /// </summary>
        private void AnalysisFaceData(PictureBox pb)
        {
            if (pb.Tag == null)
            {
                MessageBox.Show("人脸回传数据解析失败！");
                return;
            }
            object[] obj = pb.Tag as object[];
            pb.Tag = null;
            int faceIndex = 0;
            List<AsfStruct.ASF_SingleFaceInfo> faceList = null;
            if (obj == null || obj.Length != 2)
            {
                MessageBox.Show("人脸回传数据解析失败！");
                return;
            }
            faceList = obj[0] as List<AsfStruct.ASF_SingleFaceInfo>;
            if (faceList == null)
            {
                MessageBox.Show("人脸回传数据解析失败！");
                return;
            }
            if (int.TryParse(obj[1].ToString(), out faceIndex) == false)
            {
                MessageBox.Show("人脸回传数据解析失败！");
                return;
            }
            byte[] faceFeature = null;
            AsfEnums.ResultCode res = this._faceControlImgMode.GetSingleFaceFeature((Bitmap)this.pbFace1.Image, faceList[faceIndex], out faceFeature);
            if (res != AsfEnums.ResultCode.MOK)
            {
                MessageBox.Show("人脸特征值提取失败！错误信息：" + res.ToString());
                return;
            }
            pb.Tag = new object[] { faceIndex, faceFeature };
        }

        private void SaveFace()
        {
            if (this.pbFace1.Image == null)
            {
                MessageBox.Show("请在【左侧】添加图像！");
                return;
            }
            if (this.pbFace1.Tag == null)
            {
                MessageBox.Show("人脸回传数据解析失败！");
                return;
            }
            //AnalysisFaceData(this.pbFace1);
            int faceIndex = 0;
            byte[] faceFeature = null;
            object[] obj = this.pbFace1.Tag as object[];
            if (int.TryParse(obj[0].ToString(), out faceIndex) == false)
            {
                MessageBox.Show("人脸回传数据解析失败！");
                return;
            }
            faceFeature = obj[1] as byte[];
            if (faceFeature == null)
            {
                MessageBox.Show("人脸回传数据解析失败！");
                return;
            }
            ArcFaceModel model = new ArcFaceModel()
            {
                faceImage = ImageHelper.ImageToBytes(this.pbFace1.Image),
                faceindex = faceIndex,
                facefeature = faceFeature
            };
            if (this._arcFaceBLL.Insert(model) == false)
            {
                MessageBox.Show("保存失败！");
            }
            else
            {
                MessageBox.Show("保存成功！");
            }
        }

        private void SearchFace()
        {
            if (this.pbFace1.Image == null)
            {
                MessageBox.Show("请在【左侧】选择图像，或使用【人脸检测】回传图像！");
                return;
            }
            this.pbFace2.Image = null;
            object[] obj = this.pbFace1.Tag as object[];
            byte[] feature = obj[1] as byte[];
            float similar = 0;
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            IEnumerator<ArcFaceModel> models = this._arcFaceBLL.GetList().GetEnumerator();
            Bitmap dbFace = null;
            DateTime start = DateTime.Now;
            Task task = Task.Factory.StartNew(() =>
            {
                while (models.MoveNext())
                {
                    res = this._faceControlImgMode.FaceMatchingByFeature(feature, models.Current.facefeature, out similar);
                    if (res == AsfEnums.ResultCode.MOK && similar >= 0.8)
                    {
                        dbFace = ImageHelper.BytesToBitmap(models.Current.faceImage);
                        break;
                    }
                }
            });
            task.ContinueWith(t =>
            {
                string txt = string.Empty;
                if (dbFace != null)
                {
                    txt = "已在数据库匹配到人脸！";
                    this.pbFace2.Image = dbFace;
                }
                else
                {
                    txt = "未在数据库匹配到人脸！";
                }
                txt += string.Format("耗时：{0}毫秒", DateTime.Now.Subtract(start).TotalMilliseconds);
                this.BeginInvoke(new Action(delegate { this.rtbInfo.Text += string.Format(txtFormat, DateTime.Now.ToString(timeFormat), txt); }));
            });
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
                    txt += string.Format("年龄：{0}；性别(0男1女-1未知)：{1}；脸部3D角度：{2}" + Environment.NewLine, ageList[i], genderList[i], face3dAngleList[i].ToString());
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
                txt = "人脸对比异常！错误信息：" + res.ToString();
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
            PictureBox pb = sender as PictureBox;
            this._pbIndex = pb.Name == "pbFace1" ? 0 : 1;
            DetectFace();
        }

        private void rtbInfo_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            rtb.Select(rtb.Text.Length, 0);
            rtb.ScrollToCaret();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.pbFace1.Image = this.pbFace2.Image = null;
            this.rtbInfo.Text = string.Empty;
        }
    }
}
