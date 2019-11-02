using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.IO.Ports;


namespace SerialPortHelperDemo
{
    public partial class FrmHelper : Form
    {
        //创建串口操作助手对象
        private SerialPortHelper serialPortHelper = new SerialPortHelper();

        #region  系统初始化
        public FrmHelper()
        {
            InitializeComponent();

            //串口基本参数初始化
            this.cboBaudRrate.SelectedIndex = 5;   //波特率默认9600
            this.cboCheckBit.SelectedIndex = 0;      //校验位默认NONE
            this.cboDataBit.SelectedIndex = 2;         //数据位默认8
            this.cboStopBit.SelectedIndex = 0;         //停止位默认1

            //获取当前计算机的端口
            if (this.serialPortHelper.PortNames.Length == 0)
            {
                MessageBox.Show("当前计算机上没有找到可用的端口！", "警告信息");
                this.btnOperatePort.Enabled = false;//禁用打开端口按钮
            }
            else
            {
                //将端口添加到下拉框
                this.cboCOMList.Items.AddRange(this.serialPortHelper.PortNames);
                this.cboCOMList.SelectedIndex = 0;
            }

            //串口对象委托和串口接收数据事件关联
            this.serialPortHelper.SerialPortObject.DataReceived +=
                new SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
        }

        #endregion

        #region 串口参数设置

        //波特率的设置
        private void cboBaudRrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.serialPortHelper.SerialPortObject.BaudRate = Convert.ToInt32(this.cboBaudRrate.Text);
        }
        //设置奇偶校验
        private void cboCheckBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCheckBit.Text == "EVEN")
                serialPortHelper.SerialPortObject.Parity = System.IO.Ports.Parity.Even;
            else if (cboCheckBit.Text == "NONE")
                serialPortHelper.SerialPortObject.Parity = System.IO.Ports.Parity.None;
            else if (cboCheckBit.Text == "0DD")
                serialPortHelper.SerialPortObject.Parity = System.IO.Ports.Parity.Odd;
        }
        //设置数据位
        private void cboDataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.serialPortHelper.SerialPortObject.DataBits = Convert.ToInt32(cboDataBit.Text);
        }
        //设置停止位
        private void cboStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStopBit.Text == "1")
                serialPortHelper.SerialPortObject.StopBits = System.IO.Ports.StopBits.One;
            else if (cboStopBit.Text == "2")
                serialPortHelper.SerialPortObject.StopBits = System.IO.Ports.StopBits.Two;
        }

        #endregion

        #region 打开与关闭端口

        private void btnOperatePort_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnOperatePort.Text.Trim() == "打开端口")
                {
                    this.serialPortHelper.OpenSerialPort(this.cboCOMList.Text.Trim(), 1);
                    this.lblSerialPortStatus.Text = "端口已打开";
                    this.lblStatusShow.BackColor = Color.Green;
                    this.btnOperatePort.Text = "关闭端口";
                    this.btnOperatePort.Image = this.imageList.Images[0];
                }
                else
                {
                    this.serialPortHelper.OpenSerialPort(this.cboCOMList.Text.Trim(), 0);
                    this.lblSerialPortStatus.Text = "端口未打开";
                    this.lblStatusShow.BackColor = Color.Red;
                    this.btnOperatePort.Text = "打开端口";
                    this.btnOperatePort.Image = this.imageList.Images[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("端口操作异常：" + ex.Message);
            }
        }

        #endregion

        #region 发送数据

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.txtSender.Text.Trim().Length == 0)
            {
                MessageBox.Show("发送内容不能为空！", "提示信息");
            }
            else
            {
                //开始发送
                SendData(this.txtSender.Text.Trim());
            }
        }

        //这个方法独立出来，是为了后面扩展自动定时发送数据的时候调用
        private void SendData(string data)
        {
            try
            {
                if (this.ckb16Send.Checked)//发送十六进制数据
                {
                    this.serialPortHelper.SendData(data, SendFormat.Hex);
                }
                else  //发送字符串
                {
                    this.serialPortHelper.SendData(data, SendFormat.String);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送数据出现错误：" + ex.Message, "错误提示！");
            }
        }

        #endregion

        #region 串口接收数据的事件

        /// <summary>
        /// 串口接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                ReceiveData(this.serialPortHelper.ReceiveData());
            }
            catch (Exception ex)
            {
                MessageBox.Show("接收数据出现错误：" + ex.Message);
            }
        }
        /// <summary>
        /// 接收数据的具体实现过程
        /// </summary>
        /// <param name="byteData"></param>
        private void ReceiveData(byte[] byteData)
        {
            string data = string.Empty;
            if (this.ckb16Receive.Checked)//十六机制接收
            {
                data = this.serialPortHelper.AlgorithmHelperObject.BytesTo16(byteData, Enum16Hex.Blank);
                //在这里编写具体的数据处理过程。。。可以保存到数据库，或其他文件...
            }
            else
            {
                data = this.serialPortHelper.AlgorithmHelperObject.BytesToString(byteData, Enum16Hex.None);
            }

            //显示到当年文本框中
            //因为接收数据的事件是一个独立显存，所有必须通过跨线程访问可视化控件的方法来完成展示
            //Invoke（）方法的第一个参数必须是返回值为void的委托，第二个参数是给委托对应方法传递的参数
            this.txtReceiver.Invoke(new Action<string>(s => { this.txtReceiver.Text += "   " + s; }), data);

            //屏蔽跨线程访问可视化空间引发的异常（不建议使用这种方式）
            //  Control.CheckForIllegalCrossThreadCalls = false;
        }

        #endregion

        //请空数据按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtReceiver.Clear();
            this.txtSender.Clear();
        }

        private void cboCOMList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmHelper_Load(object sender, EventArgs e)
        {

        }
    }
}

