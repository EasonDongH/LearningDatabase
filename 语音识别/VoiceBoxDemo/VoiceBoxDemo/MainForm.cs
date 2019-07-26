using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace VoiceBoxDemo
{
    public enum MsgType
    {
        Info,
        Reveive,
        Send,
        Remind,
        Error,
        HeartBeat
    }

    public partial class MainForm : Form
    {
        private VoiceBox _voiceBox = null;
        private string _txtFormat = "【{0}】{1}" + Environment.NewLine, _timeFormat = "HH:mm:ss";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshPortNames();
            this._voiceBox = new VoiceBox();
            this._voiceBox.ReportReceivedData = this.ReportReceivedData;
            this.cmbBaudRate.Text = "9600";
        }

        private void btnRefreshPort_Click(object sender, EventArgs e)
        {
            RefreshPortNames();
        }

        private void btnOperatePort_Click(object sender, EventArgs e)
        {
            OperatePort();
        }

        private void btnCompoudText_Click(object sender, EventArgs e)
        {
            string txt = this.txtTestText.Text.Trim();
            if (txt == string.Empty)
                return;
            this._voiceBox.QueueCompound(txt);
        }

        private void btnCommonIntercut_Click(object sender, EventArgs e)
        {
            CommonIntercut();
        }

        private void btnEmergencyIntercut_Click(object sender, EventArgs e)
        {
            EmergencyIntercut();
        }

        private void btnPauseCompound_Click(object sender, EventArgs e)
        {
            PauseCompound();
            EnableWhenPause();
        }

        private void btnRestoreCompound_Click(object sender, EventArgs e)
        {
            RestoreCompound();
            EnableWhenResotre();
        }

        private void btnStopCurrent_Click(object sender, EventArgs e)
        {
            StopCurrent();
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            StopAll();
        }

        private void btn4KText_Click(object sender, EventArgs e)
        {
            FillText(5000);
        }

        private void btnLoopTest_Click(object sender, EventArgs e)
        {
            LoopTest();
        }

        private void btnFillText_Click(object sender, EventArgs e)
        {
            Random random = new Random(DateTime.Now.Second);
            FillText(random.Next(10, 50));
        }

        private void OperatePort()
        {
            if (this.btnOperatePort.Text == "打开串口")
            {
                if (OpenPort())
                {
                    this.btnOperatePort.Text = "关闭串口";
                    this.cmbSerialPort.Enabled = false;
                }
            }
            else
            {
                ClosePort();
                this.cmbSerialPort.Enabled = true;
                this.btnOperatePort.Text = "打开串口";
            }
        }

        private bool OpenPort()
        {
            bool result = false;
            string portName = this.cmbSerialPort.SelectedItem.ToString();
            if (portName == string.Empty)
            {
                MessageBox.Show("无可用串口资源", "提示");
                return result;
            }
            string baudRate = this.cmbBaudRate.SelectedItem.ToString();
            try
            {
                this._voiceBox.OpenSerialPort(portName, Convert.ToInt32(baudRate));
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            return result;
        }

        private void ClosePort()
        {
            if (this._voiceBox != null)
            {
                this._voiceBox.CloseSerialPort();
            }
        }

        /// <summary>
        /// 重新获取本机的串口资源
        /// </summary>
        private void RefreshPortNames()
        {
            this.cmbSerialPort.Items.Clear();
            this.cmbSerialPort.Items.AddRange(SerialPortHelper.GetPortNames());
            if (this.cmbSerialPort.Items.Count > 0)
            {
                this.cmbSerialPort.SelectedIndex = 0;
            }
        }

        private void btnQueueCompoud_MouseHover(object sender, EventArgs e)
        {
            this.tooltip.SetToolTip(this.btnQueueCompoud, "依次播放");
        }

        private void btnCommonIntercut_MouseHover(object sender, EventArgs e)
        {
            this.tooltip.SetToolTip(this.btnCommonIntercut, "在当前语音播放完成后，再播放");
        }

        private void btnEmergencyIntercut_MouseHover(object sender, EventArgs e)
        {
            this.tooltip.SetToolTip(this.btnEmergencyIntercut, "打断当前播放的语音，进行播放");
        }

        private void CommonIntercut()
        {
            string txt = this.txtTestText.Text.Trim();
            if (txt == string.Empty)
                return;
            if (this._voiceBox != null)
                this._voiceBox.CommonIntercut(txt);
        }

        private void EmergencyIntercut()
        {
            string txt = this.txtTestText.Text.Trim();
            if (txt == string.Empty)
                return;
            if (this._voiceBox != null)
                this._voiceBox.EmergencyIntercut(txt);
        }

        private void PauseCompound()
        {
            if (this._voiceBox != null)
                this._voiceBox.PauseCurrentCompound();
        }

        private void ReportReceivedData(string msg)
        {
            AppendTextAsync(MsgType.Reveive, msg);
        }

        /// <summary>
        /// 异步将信息添加到控件，跨线程访问控件时使用
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        private void AppendTextAsync(MsgType msgType, string msg)
        {
            this.BeginInvoke(new Action(delegate
            {
                AppendText(msgType, msg);
            }));
        }

        private void AppendText(MsgType msgType, string msg)
        {
            Color color = Color.Black;
            switch (msgType)
            {
                case MsgType.Info:
                    color = Color.SteelBlue; break;
                case MsgType.Send:
                    color = Color.LimeGreen; break;
                case MsgType.Reveive:
                    color = Color.Blue; break;
                case MsgType.Remind:
                    color = Color.FromArgb(170, 179, 6); break;
                case MsgType.Error:
                    color = Color.Red; break;
                case MsgType.HeartBeat:
                    color = Color.Black; break;
            }
            this.rtbRecord.SelectionColor = color;
            this.rtbRecord.AppendText(string.Format(this._txtFormat, DateTime.Now.ToString(this._timeFormat), msg));
        }

        private void rtbRecord_TextChanged(object sender, EventArgs e)
        {
            this.rtbRecord.SelectionStart = this.rtbRecord.TextLength;
            this.rtbRecord.ScrollToCaret();
        }

        private void RestoreCompound()
        {
            if (this._voiceBox != null)
                this._voiceBox.RestoreCompound();
        }

        private void StopCurrent()
        {
            if (this._voiceBox != null)
                this._voiceBox.StopCurrentCompound();
        }

        private void StopAll()
        {
            if (this._voiceBox != null)
                this._voiceBox.StopAllCompound();
        }

        private void EnableWhenPause()
        {
            foreach (var ctr in this.panelCompound.Controls)
            {
                if (ctr is Button)
                {
                    ((Button)ctr).Enabled = false;
                }
            }
            this.btnRestoreCompound.Enabled = true;
        }

        private void EnableWhenResotre()
        {
            foreach (var ctr in this.panelCompound.Controls)
            {
                if (ctr is Button)
                {
                    ((Button)ctr).Enabled = true;
                }
            }
        }

        /// <summary>
        /// 填充指定长度的文本到测试文本输入框，注意：这里的长度是指字节长度
        /// 一个汉字两个字节
        /// </summary>
        /// <param name="length"></param>
        private void FillText(int length)
        {
            this.txtTestText.Text = GenerateChineseWord(length / 2);
            int arr = Encoding.GetEncoding("gb2312").GetByteCount(this.txtTestText.Text);
        }

        /// <summary>
        /// 随机产生常用汉字
        /// </summary>
        /// <param name="count">要产生汉字的个数</param>
        /// <returns>常用汉字</returns>
        public string GenerateChineseWord(int count)
        {
            string chineseWords = "";
            System.Random rm = new System.Random();
            var gb = Encoding.GetEncoding("gb2312");

            for (int i = 0; i < count; i++)
            {
                // 获取区码(常用汉字的区码范围为16-55)
                int regionCode = rm.Next(16, 56);

                // 获取位码(位码范围为1-94 由于55区的90,91,92,93,94为空,故将其排除)
                int positionCode;
                if (regionCode == 55)
                {
                    // 55区排除90,91,92,93,94
                    positionCode = rm.Next(1, 90);
                }
                else
                {
                    positionCode = rm.Next(1, 95);
                }

                // 转换区位码为机内码
                int regionCode_Machine = regionCode + 160;// 160即为十六进制的20H+80H=A0H
                int positionCode_Machine = positionCode + 160;// 160即为十六进制的20H+80H=A0H

                // 转换为汉字
                byte[] bytes = new byte[] { (byte)regionCode_Machine, (byte)positionCode_Machine };
                chineseWords += gb.GetString(bytes);
            }
            return chineseWords;
        }

        int index = 0, index1 = 0, index2 = 0;
        private void LoopTest()
        {
            if (this.btnLoopTest.Text == "循环测试")
            {
                
                index = 0; index1 = 0; index2 = 0;
                this.looptimer.Start();
                this.btnLoopTest.Text = "停止循环";
            }
            else
            {
                this._voiceBox.StopAllCompound();
                this.looptimer.Stop();
                this.btnLoopTest.Text = "循环测试";
            }
        }

        private void looptimer_Tick(object sender, EventArgs e)
        {
            string msg = "这是第{0}条测试数据", msg1 = "这是第{0}条普通插播", msg2 = "这是第{0}条紧急插播";
            this._voiceBox.QueueCompound(string.Format(msg, ++index));
            if (index % 3 == 0)
            {
                this._voiceBox.CommonIntercut(string.Format(msg1, ++index1));
            }
            if (index % 5 == 0)
            {
                this._voiceBox.EmergencyIntercut(string.Format(msg2, ++index2));
            }
        }
    }
}
