using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ArcFace.Base;
using ArcFace.BLL;
using ArcFace.Models;
using System.Threading.Tasks;

namespace ArcFace2._2
{
    public partial class TestForm : Form
    {
        private FaceSampleBLL objFaceSampleBLL = new FaceSampleBLL();
        private AsfFaceControl asfControl = null;

        public TestForm()
        {
            InitializeComponent();


            //窗体加载立马初始化引擎
            try
            {
                asfControl = new AsfFaceControl();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btn_SelectPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "选择JPG图片 | *.jpg;*jpeg";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(ofd.FileName);
                Bitmap bm = new Bitmap(image);
                this.pb_Image.Image = bm;
                this.pb_DBImg.Image = null;
                this.flp_FaceImg.Controls.Clear();
            }
        }

        private void AddFaceToPanel(Bitmap singleFaceImg, byte[] feature)
        {
            RadioButton rb = new RadioButton();
            rb.Tag = feature;
            rb.Padding = new System.Windows.Forms.Padding(0);
            rb.Appearance = Appearance.Button;
            rb.FlatStyle = FlatStyle.Flat;
            rb.FlatAppearance.BorderSize = this.flp_FaceImg.Width / 30;
            rb.FlatAppearance.BorderColor = Color.White;
            rb.BackgroundImage = singleFaceImg;
            rb.BackgroundImageLayout = ImageLayout.Zoom;
            int sideLength = Convert.ToInt32((this.flp_FaceImg.Width - rb.FlatAppearance.BorderSize) * 0.9);
            rb.Width = rb.Height = sideLength;
            rb.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            this.flp_FaceImg.Controls.Add(rb);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.FlatAppearance.BorderColor = rb.Checked ? Color.LightGreen : Color.White;
        }

        public byte[] GetSelectFace()
        {
            foreach (var c in this.flp_FaceImg.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked)
                    {
                        return rb.Tag as byte[];
                    }
                }
            }

            return null;
        }

        private FaceSampleModel GetModel()
        {
            FaceSampleModel model = new FaceSampleModel();
            try
            {
                byte[] feature = GetSelectFace();
                if (feature == null)
                {
                    MessageBox.Show("请选择人脸");
                    return null;
                }
                model.FaceFeature = feature;
                model.FaceImage = ImageHelper.ImageToBytes(this.pb_Image.Image, ImageFormat.Jpeg);
                model.barcode = DateTime.Now.ToString("yyyyMMddHHmmssms");
                model.childno = "Test" + model.barcode;
                model.DisplayName = "Test" + model.barcode;
                model.childsex = "男";
                model.childbirth = DateTime.Now.ToString("yyyy-MM-dd");
                model.mothername = "Test";
                model.sampleorient = 1;
                model.familykind = "本人";
                model.clienttype = "INNER_EXAMINE";
                model.clientname = "询问诊";
                model.usercode = "123";
                model.username = "Test";
                model.status = 1;
                model.createtime = DateTime.Now;
                model.updatetime = DateTime.Now;
            }
            catch (Exception ex)
            {
                model = null;
                MessageBox.Show(ex.Message);
            }

            return model;
        }

        private bool DetectFace()
        {
            if (this.pb_Image.Image == null)
            {
                MessageBox.Show("请选择图片");
                return false;
            }
            ImageFaceDataModel imgFaceData = new ImageFaceDataModel();
            int res = this.asfControl.GetFaceDatas(new Bitmap(this.pb_Image.Image), ref imgFaceData);
            if (res != AsfConstants.MOK)
            {
                MessageBox.Show(AsfFaceControl.GetCodeString(res));
                return false;
            }
            foreach (var face in imgFaceData.FaceDatas)
            {
                AddFaceToPanel(face.Face, face.FaceFeature);
            }
            return true;
        }

        private void btn_DetectFace_Click(object sender, EventArgs e)
        {
            DetectFace();
        }

        private void btn_SaveFeature_Click(object sender, EventArgs e)
        {
            FaceSampleModel model = GetModel();
            if (model != null)
            {
                try
                {
                    if (this.objFaceSampleBLL.Add(model))
                    {
                        MessageBox.Show("保存成功！");
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_SearchDB_Click(object sender, EventArgs e)
        {
            if (this.flp_FaceImg.Controls.Count == 0 && !DetectFace())
                return;
            byte[] feature = GetSelectFace();
            if (feature == null)
                return;

            this.pb_DBImg.Image = null;
            this.lbl_WaitRemind.Visible = true;
            this.lbl_TimeCost.Visible = false;

            this.timer_WaitRemind.Start();
            DateTime start, stop;
            start = DateTime.Now;
            Task task = Task.Factory.StartNew(() =>
            {
                //FaceSampleModel match_Result = this.asfControl.FaceMatching(ImageHelper.ImageToBytes(this.pb_Image.Image, ImageFormat.Jpeg), (float)Convert.ToDouble(this.nud_SimilarValue.Value));
                FaceSampleModel match_Result = this.asfControl.FaceMatchingByFeature(feature, (float)Convert.ToDouble(this.nud_SimilarValue.Value));
                if (match_Result != null)
                {
                    this.Invoke(new Action(delegate
                    {
                        Bitmap match_Image = ImageHelper.BytesToBitmap(match_Result.FaceImage);
                        this.pb_DBImg.Image = match_Image;
                    }));
                }
                else
                {
                    MessageBox.Show("数据库无匹配结果！");
                }
                this.timer_WaitRemind.Stop();
                stop = DateTime.Now;
                this.Invoke(new Action(delegate
                {
                    this.lbl_WaitRemind.Visible = false;
                    this.lbl_TimeCost.Visible = true;
                    this.lbl_TimeCost.Text = stop.Subtract(start).TotalMilliseconds.ToString();
                }));
            });

        }

        private void timer_WaitRemind_Tick(object sender, EventArgs e)
        {
            switch (this.lbl_WaitRemind.Text)
            {
                case "查询中":
                    this.lbl_WaitRemind.Text = "查询中.";
                    break;
                case "查询中.":
                    this.lbl_WaitRemind.Text = "查询中..";
                    break;
                case "查询中..":
                    this.lbl_WaitRemind.Text = "查询中...";
                    break;
                case "查询中...":
                    this.lbl_WaitRemind.Text = "查询中";
                    break;
                default:
                    this.lbl_WaitRemind.Text = "查询中";
                    break;
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.pb_DBImg.Image = null;
            this.pb_Image.Image = null;
            this.flp_FaceImg.Controls.Clear();
            this.lbl_TimeCost.Visible = false;
        }

        private void btn_ClearDBData_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show("即将将数据库相关相关测试数据置零，是否确认？", "提示", MessageBoxButtons.YesNo))
                return;
            try
            {
                if (this.objFaceSampleBLL.ResetDBTestData())
                    MessageBox.Show("重置成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("重置失败！"+Environment.NewLine + ex.Message);
            }
            
        }


    }
}
