using AForge.Video;
using AForge.Video.DirectShow;
using ArcSoft.BLL;
using ArcSoft.Model;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcSoft_Face2._2
{
    public partial class MainForm : Form
    {
        //创建摄像头操作对象
        private FilterInfoCollection videoDevices = null;
        //本程序使用的那个摄像头
        public VideoCaptureDevice Cam = null;
        private FaceControl _faceControl = new FaceControl(AsfEnums.AsfFaceDetectMode.ASF_DETECT_MODE_IMAGE);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_EnterFace_Click(object sender, EventArgs e)
        {
            if (GetCameraList() == false)
            {
                MessageBox.Show("无摄像头！");
                return;
            }
            OpenCamera();
        }

        private bool GetCameraList()
        {
            // 枚举所有视频输入设备
            this.videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0) return false;
            return true;
        }

        private void OpenCamera()
        {
           // VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            this.Cam = new VideoCaptureDevice(videoDevices[0].MonikerString);
            this.Cam.NewFrame += Cam_NewFrame;
            var resoultion = this.Cam.VideoResolution;
            this.Cam.Start();
            //videoSourcePlayer.VideoSource = videoSource;
            //videoSourcePlayer.Start();
        }

        private void CloseCamera()
        {
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
        }

        private Bitmap TakePhoto()
        {
            if (videoSourcePlayer.IsRunning)
            {
                Bitmap bmp = videoSourcePlayer.GetCurrentVideoFrame();
                if (bmp != null)
                    return (Bitmap)bmp.Clone();
            }
            return null;
        }

        private void ProcessFace(Bitmap bmp)
        {
            AsfEnums.ResultCode res = AsfEnums.ResultCode.MOK;
            AsfStruct.ASF_MultiFaceInfo detectedFaces = new AsfStruct.ASF_MultiFaceInfo();
            res = this._faceControl.GetDetectedFaceInfo(bmp, ref detectedFaces);
            if (res != AsfEnums.ResultCode.MOK || detectedFaces.faceNum == 0)
            {
                return;
            }
            MultiFaceModel multiFace = new MultiFaceModel(detectedFaces);
            this.BeginInvoke(new Action(delegate
            {
                Graphics dc = this.pb_MatchedFace.CreateGraphics();
                for (int i = 0; i < detectedFaces.faceNum; ++i)
                {
                    AsfStruct.ASF_SingleFaceInfo singleFaceInfo = multiFace.FaceInfoList[i];
                    Rectangle rect = singleFaceInfo.faceRect.GetRectangle();
                    dc.DrawRectangle(new Pen(Color.LightGreen, 2), rect);
                }
            }));
        }

        private static object locker = new object();

        ///<summary>
        ///摄像头设备Cam的NewFrame事件处理程序
        ///用于实时显示捕获的视频流
        ///</summary>
        ///<paramname="sender"></param>
        ///<paramname="eventArgs"></param>
        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            lock (locker)
            {
                Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
                this.pb_MatchedFace.Image = bmp;
                //ProcessFace(bmp);
            }
        }
    }
}
