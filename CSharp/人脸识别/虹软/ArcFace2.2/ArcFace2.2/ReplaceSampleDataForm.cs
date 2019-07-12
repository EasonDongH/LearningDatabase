using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ArcFace.BLL;
using ArcFace.Base;
using ArcFace.Models;
using System.Drawing.Imaging;

namespace ArcFace2._2
{
    public partial class ReplaceSampleDataForm : Form
    {
        private bool isDBSettingOk = false;
        private bool isProcessing = false;// 是否正在处理数据
        private string currentJudgeId = string.Empty; // 当前正在做判断的图像的Id
        private FaceSampleBLL objFaceSampleBLL = new FaceSampleBLL();
        private ReplaceSampleDataControl<FaceSampleModel> replaceControl = null;
        private AsfFaceControl faceControl = null;
        private List<FaceSampleModel> modelsWaitForJudge = new List<FaceSampleModel>();
        private CancellationTokenSource cancelTokenSource = null;

        public ReplaceSampleDataForm()
        {
            InitializeComponent();

            try
            {
                this.faceControl = new AsfFaceControl();
                ColumnMapper.SetMapper();
            }
            catch (Exception ex)
            {

                throw;
            }

            this.btn_StartProcess.Enabled = false;
            this.btn_CancelProcess.Enabled = false;
        }

        private void btn_GetUpdateInfo_Click(object sender, EventArgs e)
        {
            if (isDBSettingOk == false)
            {
                MessageBox.Show("请设置数据库配置信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                this.cancelTokenSource = new CancellationTokenSource();
                this.replaceControl = new ReplaceSampleDataControl<FaceSampleModel>(DataBaseTable.face_sample, BeforeProcess, AfterProcess, EndProcess, HandleSpecialCase, HandleError, this.cancelTokenSource);

                this.isProcessing = false;
                this.pgb_Progress.Maximum = this.replaceControl.TotalSize;
                this.lbl_ProgressTotal.Text = this.replaceControl.TotalSize.ToString();

                this.lbl_ProcessSuccess.Text = "0";
                this.lbl_WaitToJudge.Text = "0";
                this.pgb_Progress.Value = 0;

                this.btn_GetUpdateInfo.Enabled = false;
                this.btn_StartProcess.Enabled = true;
                this.btn_CancelProcess.Enabled = true;

                this.lv_SpecialCase.Items.Clear();
                this.pb_Image.Image = null;
                this.flp_FaceImg.Controls.Clear();

                MessageBox.Show(string.Format("连接成功！{0}本次共有{1}条记录需要处理。", Environment.NewLine, this.replaceControl.TotalSize), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接异常！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BeforeProcess(byte[] imageData)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                Bitmap image = ImageHelper.BytesToBitmap(imageData);
                this.pb_Image.Image = image;
            }));
        }

        private void AfterProcess(int processValue, double costTime)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                this.lbl_ProcessSuccess.Text = processValue.ToString();
                this.pgb_Progress.Value = processValue;
                this.lbl_CostTime.Text = CommonMethod.ConvertTime(costTime);
            }));
        }

        private void EndProcess(int processValue)
        {
            this.Invoke(new Action(delegate
            {
                this.lbl_ProcessSuccess.Text = processValue.ToString();
                this.pgb_Progress.Value = processValue;

                this.btn_GetUpdateInfo.Enabled = true;
                this.btn_StartProcess.Enabled = false;
                this.btn_CancelProcess.Enabled = false;
                this.isProcessing = false;

                string reminder = string.Format("成功自动替换{0}条数据！", processValue);

                MessageBox.Show(reminder, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }

        private void HandleSpecialCase(int failSize, FaceSampleModel model)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = model.Id;
                lvi.SubItems.AddRange(new string[]{
                        model.DisplayName,
                        "×"
                    });

                lvi.Text = failSize.ToString();

                this.lv_SpecialCase.Items.Add(lvi);
                this.lbl_WaitToJudge.Text = failSize.ToString();
            }));
        }

        private void HandleError(Exception ex)
        {
            this.cancelTokenSource.Cancel();
            MessageBox.Show("出现异常！请检查后重试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_StartProcess_Click(object sender, EventArgs e)
        {
            this.isProcessing = true;
            this.btn_StartProcess.Enabled = false;
            this.replaceControl.StartProcessData();
        }

        private void btn_TestForm_Click(object sender, EventArgs e)
        {
            TestForm frm = new TestForm();
            frm.ShowDialog();
        }

        private void btn_CancelProcess_Click(object sender, EventArgs e)
        {
            if (this.cancelTokenSource != null)
                this.cancelTokenSource.Cancel();

            this.isProcessing = false;

            this.btn_CancelProcess.Enabled = false;
            this.btn_StartProcess.Enabled = false;
            this.btn_GetUpdateInfo.Enabled = true;
        }

        private void lv_MultiFace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (isProcessing)
            {
                MessageBox.Show("图像处理中，请等待处理完毕或取消处理！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.flp_FaceImg.Controls.Clear();

            this.currentJudgeId = this.lv_SpecialCase.FocusedItem.Tag.ToString();
            ImageFaceDataModel imgFace = this.replaceControl.GetImgFaceDataById(this.currentJudgeId);
            this.pb_Image.Image = imgFace.SourceImage;
            foreach (var face in imgFace.FaceDatas)
            {
                AddFaceImage(face.Face, face.FaceFeature);
            }
        }

        private void AddFaceImage(Bitmap singleFaceImg, byte[] feature)
        {
            try
            {
                RadioButton rb = new RadioButton();
                rb.Tag = feature;
                rb.Padding = new System.Windows.Forms.Padding(0);
                rb.Appearance = Appearance.Button;
                rb.FlatStyle = FlatStyle.Flat;
                rb.FlatAppearance.BorderSize = 5;
                rb.FlatAppearance.BorderColor = Color.White;
                rb.BackgroundImage = singleFaceImg;
                rb.BackgroundImageLayout = ImageLayout.Zoom;
                rb.Width = rb.Height = 256;
                rb.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

                this.flp_FaceImg.Controls.Add(rb);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.FlatAppearance.BorderColor = rb.Checked ? Color.LightGreen : Color.White;
        }

        private byte[] GetSelectFace()
        {
            foreach (var c in this.flp_FaceImg.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked == true)
                    {
                        return rb.Tag as byte[];
                    }
                }
            }
            return null;
        }

        private void ProcessSingleFaceSuccess()
        {
            int success = Convert.ToInt32(this.lbl_ProcessSuccess.Text.Trim());
            int judge = Convert.ToInt32(this.lbl_WaitToJudge.Text.Trim());
            if (success < this.replaceControl.TotalSize)
                success += 1;
            if (judge > 0)
                judge -= 1;

            this.pgb_Progress.Value = success;
            this.lbl_ProcessSuccess.Text = success.ToString();
            this.lbl_WaitToJudge.Text = judge.ToString();
        }

        private void btn_SaveSelect_Click(object sender, EventArgs e)
        {
            if (this.flp_FaceImg.Controls.Count == 0)
                return;
            try
            {
                byte[] feature = GetSelectFace();
                if (feature == null)
                {
                    MessageBox.Show("请选择人脸");
                    return;
                }

                if (this.replaceControl.UpdateSingleData(this.currentJudgeId, feature))
                {
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (ListViewItem item in this.lv_SpecialCase.Items)
                    {
                        if (item.Tag.ToString() == this.currentJudgeId)
                        {
                            if (item.SubItems[2].Text == "×")
                            {
                                item.SubItems[2].Text = "√";
                                item.BackColor = Color.LightGreen;
                                ProcessSingleFaceSuccess();
                            }
                            break;
                        }
                    }
                }
                else
                    throw new Exception("保存失败！");

            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtn_DBSetting_Click(object sender, EventArgs e)
        {
            DataBaseSettingForm frm = new DataBaseSettingForm(DataBaseSettingState.Add);
            if (DialogResult.OK != frm.ShowDialog())
                return;
            this.isDBSettingOk = true;
        }

        private void ReplaceSampleDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 预防在线程处理中强制关闭UI后，可能出现的访问UI控件异常
            //if (this.cancelTokenSource != null)
            //{
            //    this.cancelTokenSource.Cancel();
            //    Thread.Sleep(100);
            //}
        }
    }
}
