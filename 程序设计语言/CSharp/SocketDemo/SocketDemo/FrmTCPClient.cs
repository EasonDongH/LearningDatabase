using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace SocketDemo
{
    public partial class FrmTCPClient : Form
    {
        private Socket socket = null;
        private CommonMethod commonMethod = new CommonMethod();
        public FrmTCPClient()
        {
            InitializeComponent();

            DisConnectServer();
        }

        private void DisConnectServer()
        {
            this.btn_ConnectServer.Enabled = true;
            this.btn_DisConnect.Enabled = false;
            this.btn_SelectFile.Enabled = false;
            this.btn_Send.Enabled = false;
        }

        private void Btn_ConnectServer_Click(object sender, EventArgs e)
        {
            // 【1】实例化Socket
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 【2】配置IP、Port
            IPAddress address = IPAddress.Parse(this.txt_ServerIP.Text.Trim());
            IPEndPoint iPEndPoint = new IPEndPoint(address, Convert.ToInt32(this.txt_ServerPort.Text.Trim()));

            try
            {
                // 【3】与服务器进行连接
                this.socket.Connect(iPEndPoint);
                Thread thread = new Thread(ReceiveMsg);
                thread.IsBackground = true;
                thread.Start();

                this.btn_ConnectServer.Enabled = false;
                this.btn_DisConnect.Enabled = true;
                this.btn_SelectFile.Enabled = true;
                this.btn_Send.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiveMsg()
        {
            while (this.socket != null)
            {
                byte[] msgBuffer = new byte[1024 * 1024 * 2];
                int length = -1;
                try
                {
                    length = this.socket.Receive(msgBuffer);
                }
                catch (Exception)
                {
                    DisConnectServer();
                }

                if (length > 1)
                {
                    string msg = $"[{DateTime.Now.ToLongTimeString()}（接收）]  {this.socket.RemoteEndPoint.ToString()}：" + Environment.NewLine;
                    switch (msgBuffer[0])
                    {
                        case (byte)MsgType.Text:
                            msg += Encoding.UTF8.GetString(msgBuffer, 1, length - 1);// 首字节为标志位
                            Invoke(new Action(() => this.rtb_Info.Text += msg + Environment.NewLine));
                            break;
                        case (byte)MsgType.File:
                            string fileName = Invoke(commonMethod.FileSaveFunc, msgBuffer).ToString();
                            if (fileName != string.Empty)
                            {
                                msg += "保存文件：" + fileName;
                                Invoke(new Action(() => this.rtb_Info.Text += msg + Environment.NewLine));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Btn_DisConnect_Click(object sender, EventArgs e)
        {
            DisConnectServer();
            this.socket?.Close();
            this.socket = null;
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            string msg = this.rtb_ClientSend.Text.Trim();
            if (msg != string.Empty)
            {
                byte[] msgInByte = commonMethod.GetSendBytes(msg, MsgType.Text);
                this.socket.Send(msgInByte);

                this.rtb_Info.Text += $"[{DateTime.Now.ToLongTimeString()}（发送）] ：" + Environment.NewLine + msg + Environment.NewLine;
                this.rtb_ClientSend.Text = string.Empty;
            }
            msg = this.txt_FilePath.Text.Trim();
            if (msg != string.Empty && File.Exists(msg))
            {
                byte[] msgInByte = commonMethod.GetSendBytes(msg, MsgType.File);
                this.socket.Send(msgInByte);

                this.rtb_Info.Text += $"[{DateTime.Now.ToLongTimeString()}（发送）] ：" + Environment.NewLine + "文件：" + msg.Substring(msg.LastIndexOf('\\') + 1) + Environment.NewLine;
                this.rtb_ClientSend.Text = string.Empty;
                this.txt_FilePath.Text = string.Empty;
            }
        }

        private void FrmTCPClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Btn_DisConnect_Click(null, null);
        }

        private void Btn_SelectFile_Click(object sender, EventArgs e)
        {
            this.txt_FilePath.Text = commonMethod.SelectFile();
        }
    }
}
