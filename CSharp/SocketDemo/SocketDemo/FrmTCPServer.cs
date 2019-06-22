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
   
    public partial class FrmTCPServer : Form
    {
        private Socket socket = null;
        private Dictionary<string, Socket> clientDic = new Dictionary<string, Socket>();
        private CommonMethod commonMethod = new CommonMethod();
        public FrmTCPServer()
        {
            InitializeComponent();
            EnableActionWhenStopServer();
        }

        private void EnableActionWhenStartServer()
        {
            this.btn_StartServer.Enabled = false;
            this.btn_StopServer.Enabled = true;
            this.btn_Send.Enabled = true;
            this.btn_SelectFile.Enabled = true;
        }

        private void EnableActionWhenStopServer()
        {
            this.btn_StartServer.Enabled = true;
            this.btn_StopServer.Enabled = false;
            this.btn_Send.Enabled = false;
            this.btn_SelectFile.Enabled = false;
        }

        private void Btn_StartServer_Click(object sender, EventArgs e)
        {
            //【1】实例化Socket
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 【2】bind绑定IP、Port
            IPAddress address = IPAddress.Parse(this.txt_ServerIP.Text.Trim());
            IPEndPoint iPEndPoint = new IPEndPoint(address, Convert.ToInt32(this.txt_ServerPort.Text.Trim()));
            this.socket.Bind(iPEndPoint);
            // 【3】开启监听
            this.socket.Listen(10);
            // 【4】多线程的方式接收客户端的连接
            Thread thread = new Thread(ClientConnect);
            thread.IsBackground = true;
            thread.Start();

            this.btn_StartServer.Enabled = false;
            this.btn_StopServer.Enabled = true;

            this.rtb_Info.Text += "服务已启动……" + Environment.NewLine;
            EnableActionWhenStartServer();
        }

        private void ClientConnect()
        {
            while (this.socket != null)
            {
                // 【5】接收客户端的连接请求
                Socket client = null;
                try
                {
                    client = this.socket.Accept();// 此时阻塞
                }
                catch (Exception)
                {
                    break;
                }

                this.clientDic.Add(client.RemoteEndPoint.ToString(), client);

                Invoke(new Action(() => this.rtb_Info.Text += $"[{DateTime.Now.ToLongTimeString()}]  " + client.RemoteEndPoint.ToString() + " 上线！" + Environment.NewLine));
                this.lb_OnlineClientList.Invoke(new Action<string>(url => this.lb_OnlineClientList.Items.Add(url)), client.RemoteEndPoint.ToString());

                Thread thread = new Thread(ReceiveClientMsg);
                thread.IsBackground = true;
                thread.Start(client);
            }
        }

        private void ReceiveClientMsg(object client)
        {
            Socket clientSocket = client as Socket;
            while (true)
            {
                byte[] msgBuffer = new byte[1024 * 1024 * 2];
                int length = -1;
                try
                {
                    length = clientSocket.Receive(msgBuffer);
                }
                catch (Exception)
                {
                    Invoke(new Action(() => this.rtb_Info.Text += $"[{DateTime.Now.ToLongTimeString()}]  " + clientSocket.RemoteEndPoint.ToString() + " 下线！" + Environment.NewLine));
                    Invoke(new Action<string>(url => this.lb_OnlineClientList.Items.Remove(url)), clientSocket.RemoteEndPoint.ToString());
                    this.clientDic.Remove(clientSocket.RemoteEndPoint.ToString());
                    break;
                }

                if (length > 1)
                {
                    string msg = $"[{DateTime.Now.ToLongTimeString()}（接收）]  {clientSocket.RemoteEndPoint.ToString()}：" + Environment.NewLine;
                    switch (msgBuffer[0])
                    {
                        case (byte)MsgType.Text:
                            msg += Encoding.UTF8.GetString(msgBuffer, 1, length - 1);// 首字节为标志位
                            break;
                        case (byte)MsgType.File:
                            msg += "保存文件：" + Invoke(commonMethod.FileSaveFunc, msgBuffer).ToString();
                            break;
                        default:
                            break;
                    }
                    Invoke(new Action(() => this.rtb_Info.Text += msg + Environment.NewLine));
                }
                //else
                //{
                //    Invoke(new Action(() => this.rtb_Info.Text += clientSocket.RemoteEndPoint.ToString() + "下线！" + Environment.NewLine));
                //    Invoke(new Action<string>(url => this.lb_OnlineClientList.Items.Remove(url)), clientSocket.RemoteEndPoint.ToString());
                //    this.clientDic.Remove(clientSocket.RemoteEndPoint.ToString());
                //    break;
                //}
            }
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            string msg = this.rtb_ServerSend.Text.Trim();
            if (this.lb_OnlineClientList.SelectedIndex == -1)
            {
                MessageBox.Show("未选择客户端");
                return;
            }
            // 发送“文本”信息
            if (msg != string.Empty)
            {
                byte[] msgInByte = commonMethod.GetSendBytes(msg, MsgType.Text);
                foreach (var clientURL in this.lb_OnlineClientList.SelectedItems)
                {
                    this.clientDic[clientURL.ToString()].Send(msgInByte);
                }

                this.rtb_Info.Text += $"[{DateTime.Now.ToLongTimeString()}（发送）] ：" + Environment.NewLine + msg + Environment.NewLine;
                this.rtb_ServerSend.Text = string.Empty;
            }
            msg = this.txt_FilePath.Text.Trim();
            // 发送“文件”信息
            if (msg != string.Empty && File.Exists(msg))
            {
                byte[] msgInByte = commonMethod.GetSendBytes(msg, MsgType.File);
                foreach (var clientURL in this.lb_OnlineClientList.SelectedItems)
                {
                    this.clientDic[clientURL.ToString()].Send(msgInByte);
                }

                this.rtb_Info.Text += $"[{DateTime.Now.ToLongTimeString()}（发送）] ：" + Environment.NewLine + "文件："+msg.Substring(msg.LastIndexOf('\\')+1) + Environment.NewLine;
                this.rtb_ServerSend.Text = string.Empty;
                this.txt_FilePath.Text = string.Empty;
            }
        }

        private void BtnOpenClient_Click(object sender, EventArgs e)
        {
            FrmTCPClient frm = new FrmTCPClient();
            frm.Show();
        }

        private void Btn_StopServer_Click(object sender, EventArgs e)
        {
            this.socket?.Close();
            this.socket = null;
            this.rtb_Info.Text += "服务已停止！" + Environment.NewLine;
            EnableActionWhenStopServer();
        }

        private void FrmTCPServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Btn_StopServer_Click(null, null);
        }

        private void Btn_SelectFile_Click(object sender, EventArgs e)
        {
            this.txt_FilePath.Text = commonMethod.SelectFile();
        }
    }
}
