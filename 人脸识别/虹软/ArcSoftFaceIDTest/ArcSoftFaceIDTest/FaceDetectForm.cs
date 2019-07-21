using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ArcSoft.Face2._2;
using Emgu.CV;
using Camera;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using log4net;
using System.Reflection;

namespace ArcSoftFaceIDTest
{
    public partial class FaceDetectForm : Form
    {
        private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // 每次拍照的需要过滤的帧数
        private uint frameFilterCount = 5, currentFrameCount = 0;
        /// <summary>
        /// 0：图片流 1：视频流
        /// </summary>
        private uint _currentMode = 0;
        private FaceControl _faceControlVideo = null, _faceControlImage = null;
        private Camera.Camera _camera = null;
        private IntPtr _engine = IntPtr.Zero;
        private AsfEnums.ResultCode mResultCode = AsfEnums.ResultCode.MOK;
        private Action<Bitmap, object[]> faceDetectResult = null;

        public FaceDetectForm(Action<Bitmap, object[]> faceDetectResult)
        {
            InitializeComponent();
            this.faceDetectResult = faceDetectResult;
        }

        private void FaceDetectForm_Load(object sender, EventArgs e)
        {
            this.cmbDetectMode.SelectedIndex = 0;
        }

        private void FaceDetectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._camera != null)
            {
                this._camera.StopCapture();
                this._camera.Dispose();
                this._camera = null;
            }
            if (this._faceControlImage != null)
                this._faceControlImage.Dispose();
            if (this._faceControlVideo != null)
                this._faceControlVideo.Dispose();
        }

        private void imageBox_Click(object sender, EventArgs e)
        {
            if (this.cmbDetectMode.SelectedIndex == 0)
            {
                ImageMode();
            }
            else if (this.cmbDetectMode.SelectedIndex == 1)
            {
                VideoMode();
            }
        }

        private void VideoMode()
        {
            this._currentMode = 1;
            this.currentFrameCount = 0;
            this.lb_RePhoto.Visible = true;
            this.flpMultiFace.Controls.Clear();
            if (this._faceControlVideo == null)
                this._faceControlVideo = new FaceControl(AsfEnums.AsfFaceDetectMode.ASF_DETECT_MODE_VIDEO);
            if (this._camera == null)
            {
                InitCamera(0);
            }
            if (this._camera != null)
            {
                this._camera.StartCapture();
            }
        }

        private void ImageMode()
        {
            this._currentMode = 0;
            this.flpMultiFace.Controls.Clear();
            if (this._camera != null) this._camera.StopCapture();
            this.lb_RePhoto.Visible = false;
            if (this._faceControlImage == null)
                this._faceControlImage = new FaceControl(AsfEnums.AsfFaceDetectMode.ASF_DETECT_MODE_IMAGE);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Mat mat = new Mat(ofd.FileName, Emgu.CV.CvEnum.LoadImageType.AnyColor);
                this.imageBox.Image = mat;
                ProcessFace(mat);
            }
        }

        /// <summary>
        /// 初始化摄像机
        /// </summary>
        /// <param name="camIndex"></param>
        private void InitCamera(int camIndex)
        {
            try
            {
                if (_camera == null)
                {
                    _camera = new Camera.Camera(camIndex, false);
                    _camera.ProcessFrameInterval = 1;
                    _camera.GrabbedFrameEvent += new Camera.Camera.GrabbedFrameHandler((Mat frame) =>
                    {
                        if (frame != null && !frame.IsEmpty)
                        {
                            ProcessFace(frame);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        private void ReleaseCamera()
        {
            if (this._camera == null) return;

            this._camera.StopCapture();
            this._camera.Dispose();
            this._camera = null;
        }

        private void ProcessFace(Mat face)
        {
            try
            {
                imageBox.Image = face;
                // 视频流模式：对前几帧的图像不做处理，以过滤无效图像
                if (this._currentMode == 1 && this.currentFrameCount < this.frameFilterCount)
                {
                    this.currentFrameCount += 1;
                    return;
                }
                else
                {
                    this.currentFrameCount = 0;
                }

                int x = 0, y = 0; // 设置检测区域边缘：边缘部分的人脸不被检测（指不会被画出）
                int width = face.Width - x;
                int height = face.Height - y;
                int lineBold = 2;
                // 画基准红线框：配合设置区域边缘，实现仅检测红线框内的人脸（指不会被画出）
                //MatExtendsions.DrawRectCenterNew(face, width, height, Color.Red, lineBold, x, y);

                // 获取有效检测区域：这里的有效是指该方框内的人脸会被画出来
                Rectangle centerSave = new Rectangle(x + lineBold, y + lineBold, width - lineBold * 2, height - lineBold * 2);

                MultiFaceModel multiFaceModel = null;
                FaceControl faceControl = this._currentMode == 0 ? this._faceControlImage : this._faceControlVideo;
                this.mResultCode = faceControl.GetDetectedFaceInfo(face.Bitmap, ref multiFaceModel);
                if (this.mResultCode != AsfEnums.ResultCode.MOK)
                {
                    MessageBox.Show("人脸引擎识别异常！");
                    return;
                }
                if (multiFaceModel.FaceInfoList.Count == 0)
                    return;
                Mat m = new Mat(face, centerSave);
                this.BeginInvoke(new Action(delegate
                    {
                        this.flpMultiFace.Controls.Clear();
                        for (int i = 0; i < multiFaceModel.FaceInfoList.Count; ++i)
                        {
                            Rectangle faceRect = multiFaceModel.FaceInfoList[i].faceRect.GetRectangle();
                            AddFaceImage(ImageHelper.GetRectangleImage(face.Bitmap, faceRect), multiFaceModel.FaceInfoList[i], i);
                            //MatExtendsions.DrawDashRect(m, 8, 8, faceRect, Color.LightGreen, 2);//直接在图像上画框
                        }
                        // 发现人脸后，停止摄像头
                        if (this._camera != null)
                            this._camera.PasueCapture();
                    }));

                imageBox.Image = face;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        private void AddFaceImage(Bitmap singleFaceImg, AsfStruct.ASF_SingleFaceInfo single, int index)
        {
            try
            {
                RadioButton rb = new RadioButton();
                rb.Tag = new object[] { single, index };
                rb.Padding = new System.Windows.Forms.Padding(0);
                rb.Appearance = Appearance.Button;
                rb.FlatStyle = FlatStyle.Flat;
                rb.FlatAppearance.BorderSize = 5;
                rb.FlatAppearance.BorderColor = Color.White;
                rb.BackgroundImage = singleFaceImg;
                rb.BackgroundImageLayout = ImageLayout.Zoom;
                rb.Width = rb.Height = 256;
                rb.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
                if (this.flpMultiFace.Controls.Count == 0)
                    rb.Checked = true;

                this.flpMultiFace.Controls.Add(rb);
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

        private void lb_MouseMove(object sender, MouseEventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void lb_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;
        }

        /// <summary>
        /// 有人脸则返回true，无人脸返回false
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            // 因为添加第一个控件时会自己选中，所以这里只需要判断是否有人脸加入，以排序无人脸的情况
            return this.flpMultiFace.Controls.Count > 0;
        }

        private bool GetFaceInfo(out object[] obj)
        {
            obj = new object[2];
            bool res = false;
            foreach (var ctrl in this.flpMultiFace.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton rb = ctrl as RadioButton;
                    if (rb.Checked)
                    {
                        obj = rb.Tag as object[];
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }

        private void OnSave()
        {
            if (IsValid() == false)
            {
                MessageBox.Show("没有检测到人脸，请重试！");
                return;
            }
            Bitmap bmp = this.imageBox.Image.Bitmap;
            object[] obj = null;
            if (GetFaceInfo(out obj) == false)
            {
                MessageBox.Show("人脸检测信息回传异常！");
                return;
            }
            if (this.faceDetectResult != null)
                this.faceDetectResult(bmp, obj);
            this.Close();
        }

        private void lb_Save_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void lb_RePhoto_Click(object sender, EventArgs e)
        {
            this.flpMultiFace.Controls.Clear();
            if (this._camera != null)
                this._camera.StartCapture();
        }
    }
}
