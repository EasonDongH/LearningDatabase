using AForge.Video.DirectShow;
using System;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Math;
using AForge.Video;
using System.Drawing;

namespace CarmeraDemo
{
    public partial class TestAforgeCameraForm : Form
    {
        private FilterInfoCollection videoDevices = null;

        public TestAforgeCameraForm()
        {
            InitializeComponent();
        }

        private void TestAforgeCameraForm_Load(object sender, EventArgs e)
        {
            FillCamera();
        }

        private void btn_StartCamera_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        /// <summary>
        /// 获取本地摄像头，并填充到下拉列表
        /// </summary>
        private void FillCamera()
        {
            // 枚举所有视频输入设备
             this.videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("无可用摄像头！");

                return;
            }

            foreach (FilterInfo device in videoDevices)
            {
                this.cboCameraTypeList.Items.Add(device.Name);
            }

            this.cboCameraTypeList.SelectedIndex = 0;
        }

        private void StartCamera()
        {
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[this.cboCameraTypeList.SelectedIndex].MonikerString);
            videoSourcePlayer.VideoSource = videoSource;
            videoSourcePlayer.Start();
        }

        private void CloseCamera()
        {
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
        }

        private void TakePhoto()
        {
            if (videoSourcePlayer.IsRunning)
            {
               Bitmap bmp =  videoSourcePlayer.GetCurrentVideoFrame();
                this.pictureBox1.Image = bmp;
            }
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            TakePhoto();
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
        }

        private void btnCloseCarema_Click(object sender, EventArgs e)
        {
            CloseCamera();
        }
    }
}
