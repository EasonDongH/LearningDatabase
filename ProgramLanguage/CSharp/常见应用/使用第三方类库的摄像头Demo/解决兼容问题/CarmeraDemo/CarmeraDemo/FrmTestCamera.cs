using System;
using System.Drawing;
using System.Windows.Forms;


using Camera_NET;//引入相关的命名空间

namespace CarmeraDemo
{
    public partial class FrmTestCamera : Form
    {
        //创建摄像头操作对象
        private CameraChoice cameraChoice = new CameraChoice();

        public FrmTestCamera()
        {
            InitializeComponent();

            //设置按钮
            this.btnTask.Enabled = false;
            this.btnClearImage.Enabled = false;
            this.btnCloseCarema.Enabled = false;

            //填充摄像头下拉框和设置默认摄像头
            FillCameraList();
            if (cboCameraTypeList.Items.Count > 0)
            {
                cboCameraTypeList.SelectedIndex = 0;
            }
        }

        //找到当前计算机上可用的摄像头
        private void FillCameraList()
        {
            cboCameraTypeList.Items.Clear();//首先清空下拉列表
            cameraChoice.UpdateDeviceList();//更新设备列表
            //循环把设备列表添加到下拉框
            foreach (var device in cameraChoice.Devices)
            {
                cboCameraTypeList.Items.Add(device.Name);
            }
        }
        //填充可用分辨率的下拉框
        private void FillResolutionList()
        {
            cboResolutionList.Items.Clear();//清空下拉框
            if (!this.cameraControl.CameraCreated) return; //如果没有摄像头则退出
            //获取可用分辨率列表
            ResolutionList resolutions = Camera.GetResolutionList(cameraControl.Moniker);
            if (resolutions == null) return;

            int selectedIndex = -1;
            for (int i = 0; i < resolutions.Count; i++)
            {
                cboResolutionList.Items.Add(resolutions[i].ToString());
                //如果当前的可用分辨率和摄像头分辨率一样，则默认选择最佳分辨率
                if (resolutions[i].CompareTo(cameraControl.Resolution) == 0)
                {
                    selectedIndex = i;
                }
            }
            //设置当前默认的分辨率
            if (selectedIndex >= 0)
            {
                cboResolutionList.SelectedIndex = selectedIndex;
            }
        }
        //根据不同的选择设置摄像头并打开
        private void comboBoxCameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCameraTypeList.SelectedIndex < 0)
            {
                cameraControl.CloseCamera();
            }
            else
            {
                // Set camera
                cameraControl.SetCamera(cameraChoice.Devices[cboCameraTypeList.SelectedIndex].Mon, null);
                //SetCamera(_CameraChoice.Devices[ comboBoxCameraList.SelectedIndex ].Mon, null);
            }
            FillResolutionList();//显示可用的分辨率
        }
        //分辨率变化，同时摄像头要重新设置
        private void comboBoxResolutionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cameraControl.CameraCreated)
                return;
            int comboBoxResolutionIndex = cboResolutionList.SelectedIndex;
            if (comboBoxResolutionIndex < 0) return;

            ResolutionList resolutions = Camera.GetResolutionList(cameraControl.Moniker);

            if (resolutions == null) return;

            if (comboBoxResolutionIndex >= resolutions.Count) return;

            if (0 == resolutions[comboBoxResolutionIndex].CompareTo(cameraControl.Resolution))
            {
                // this resolution is already selected
                return;
            }
            // Recreate camera
            //SetCamera(_Camera.Moniker, resolutions[comboBoxResolutionIndex]);
            cameraControl.SetCamera(cameraControl.Moniker, resolutions[comboBoxResolutionIndex]);
        }
        //开启摄像头
        private void btnStartTask_Click(object sender, EventArgs e)
        {
            comboBoxCameraList_SelectedIndexChanged(null, null);
            this.btnStartTask.Enabled = false;
            this.btnTask.Enabled = true;
            this.btnClearImage.Enabled = true;
            this.btnCloseCarema.Enabled = true;
        }

        //开始拍照
        private void btnTask_Click(object sender, EventArgs e)
        {
            if (!cameraControl.CameraCreated) return;

            Bitmap bitmap = cameraControl.SnapshotOutputImage();

            if (bitmap == null) return;

            pbImage.Image = bitmap;
            pbImage.Update();
        }

        //清除照片
        private void btnClearImage_Click(object sender, EventArgs e)
        {
            this.pbImage.Image = null;
        }

        //关闭摄像头
        private void btnCloseCarema_Click(object sender, EventArgs e)
        {
            this.cameraControl.CloseCamera();
            this.btnTask.Enabled = false;
            this.btnClearImage.Enabled = false;
            this.btnCloseCarema.Enabled = false;
            this.btnStartTask.Enabled = true;
        }
    }
}
