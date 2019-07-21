using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using log4net;
using System.Reflection;

namespace Camera
{
    public class Camera
    {
        private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private Emgu.CV.Capture _capture = null;
        private bool _captureInProgress = false;
        private int _captureTotalCount = 0;//采集帧数
        public delegate void GrabbedFrameHandler(Mat frame);
        public event GrabbedFrameHandler GrabbedFrameEvent;
        private Mat _fram = new Mat();

        private int _ProcessFrameInterval = 3;
        public int ProcessFrameInterval
        {
            get { return _ProcessFrameInterval; }
            set { _ProcessFrameInterval = value; }
        }

        /// <summary>
        /// 本机摄像头
        /// </summary>
        /// <param name="index">摄像头序号</param>
        public Camera(int index, bool isMirror=false)
        {
            _capture = new Emgu.CV.Capture(index);
            _capture.FlipHorizontal = isMirror;
            InitCamera();
        }

        /// <summary>
        /// 可以用于网络摄像头，捕捉nvr，ipc视频流
        /// </summary>
        /// <param name="fileName">视频流地址</param>
        public Camera(string fileName, bool isMirror=false)
        {
            _capture = new Emgu.CV.Capture(fileName);
            _capture.FlipHorizontal = isMirror;
            InitCamera();
        }

        private void InitCamera()
        {
            _capture.ImageGrabbed += new EventHandler(_capture_ImageGrabbed);
        }

        private void _capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                _captureTotalCount++;
                if (_captureTotalCount % ProcessFrameInterval != 0)
                    return;

                if (_capture != null && this._captureInProgress)
                {
                    bool retrieve = _capture.Retrieve(_fram, 0);//解码并且返回刚刚抓取的视频帧，假如没有视频帧被捕获（相机没有连接或者视频文件中没有更多的帧）将返回false。
                    if (retrieve && GrabbedFrameEvent != null)
                        GrabbedFrameEvent(_fram);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        public void StartCapture()
        {
            try
            {
                CvInvoke.UseOpenCL = false;
                if (!_captureInProgress)
                {
                    _capture.Start();
                    _captureInProgress = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        public void PasueCapture()
        {
            try
            {
                if (_captureInProgress)
                {
                    _captureInProgress = false;
                    _capture.Pause();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        public void StopCapture()
        {
            try
            {
                if (_captureInProgress)
                {
                    _captureInProgress = false;
                    _capture.Stop();
                    CvInvoke.WaitKey(1000);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        public void Dispose()
        {
            try
            {
                if (_capture != null)
                {
                    _capture.Dispose();
                    _capture = null;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }
    }
}
