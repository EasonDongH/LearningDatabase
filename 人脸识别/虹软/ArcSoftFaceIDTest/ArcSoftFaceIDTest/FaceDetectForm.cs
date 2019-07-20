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

namespace ArcSoftFaceIDTest
{
    public partial class FaceDetectForm : Form
    {
        private bool isHidden = false;
        private FaceControl _faceControl = null;
        private Camera.Camera _camera = null;
        private IntPtr _engine = IntPtr.Zero;
        private AsfEnums.ResultCode mResultCode = AsfEnums.ResultCode.MOK;

        public FaceDetectForm()
        {
            InitializeComponent();
        }

        private void FaceDetectForm_Load(object sender, EventArgs e)
        {
            this._faceControl = new FaceControl();
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
            if (this._camera != null) this._camera.StopCapture();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Mat mat = new Mat(ofd.FileName,Emgu.CV.CvEnum.LoadImageType.AnyColor);
                this.imageBox.Image = mat;
                ProcessFace(mat);
            }
        }

        private bool IsValid()
        {
            return true;
        }

        private void OnSave()
        { 
        
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

            }
        }

        private void ProcessFace(Mat face)
        {
            try
            {
                int x = 0, y = 0; // 设置检测区域边缘：边缘部分的人脸不被检测（指不会被画出）
                int width = face.Width - x;
                int height = face.Height - y;

                int lineBold = 2;
                // 画基准红线框：配合设置区域边缘，实现仅检测红线框内的人脸（指不会被画出）
                //MatExtendsions.DrawRectCenterNew(face, width, height, Color.Red, lineBold, x, y);
                imageBox.Image = face;
                // 获取有效检测区域：这里的有效是指该方框内的人脸会被画出来
                Rectangle centerSave = new Rectangle(x + lineBold, y + lineBold, width - lineBold * 2, height - lineBold * 2);
                MultiFaceModel multiFace = null;
                this.mResultCode = this._faceControl.GetDetectedFaceInfo(face.Bitmap, ref multiFace);
                if (this.mResultCode != AsfEnums.ResultCode.MOK)
                {
                    MessageBox.Show("人脸引擎识别异常！");
                    return;
                }
                foreach (var singleFaceInfo in multiFace.FaceInfoList)
                {
                    Mat m = new Mat(face, centerSave);
                    MatExtendsions.DrawDashRect(m, 8, 8, singleFaceInfo.faceRect.GetRectangle(), Color.LightGreen, 2);
                }
                imageBox.Image = face;
            }
            catch (Exception ex)
            {

            }
        }

        private void lb_MouseMove(object sender, MouseEventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void lb_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;
        }

      
    }
}
