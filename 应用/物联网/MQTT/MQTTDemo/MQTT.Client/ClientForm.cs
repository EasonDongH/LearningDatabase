using MQTTnet;
using MQTTnet.Client;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace MQTT.Client
{
    public partial class ClientForm : Form
    {
        private Util.MqttClient _mqttClient = null;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            this.cmbSubQoS.SelectedIndex = 1;
            this.cmbPublishQoS.SelectedIndex = 1;
            this.btnDisConnect.Enabled = false;

            this.lblClientId.Text = CountSameProcess().ToString();

            this._mqttClient = new Util.MqttClient(this.lblClientId.Text);
            this._mqttClient.ApplicationMessageReceived = ApplicationMessageReceived;
            this._mqttClient.ClientConnected = ClientConnected;
            this._mqttClient.ClientDisconnected = ClientDisconnected;
        }

        bool hasInit = false;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this._mqttClient == null)
                return;
            if (!hasInit)
            {
                hasInit = true;
                this._mqttClient.Init(this.txtServer.Text.Trim(), this.txtPort.Text.Trim(), "admin", "admin");
            }
            try
            {
                this._mqttClient.Connect();
                this.btnConnect.Enabled = false;
                this.btnDisConnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            if (this._mqttClient == null)
                return;
            try
            {
                this._mqttClient.Disconnect();
                this.btnConnect.Enabled = true;
                this.btnDisConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            if (this.cmbSubTopic.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入要订阅的主题！");
                return;
            }
            try
            {
                string topic = this.cmbSubTopic.Text.Trim();
                this._mqttClient.SubscribeAsync(topic, this.cmbSubQoS.Text);
                AppentText(string.Format("订阅主题成功，主题：{0}", topic));
                if (!this.cmbSubTopic.Items.Contains(topic))
                    this.cmbSubTopic.Items.Add(topic);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            if (this.cmbPublishTopic.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入要发布的主题！");
                return;
            }
            if (this.txtPayload.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入要发布的负载！");
                return;
            }
            try
            {
                string topic = this.cmbPublishTopic.Text.Trim();
                this._mqttClient.PublishAsync(topic, this.cmbPublishQoS.Text, this.txtPayload.Text.Trim());
                AppentText(string.Format("发布主题成功，主题：{0}", topic));
                if (!this.cmbPublishTopic.Items.Contains(topic))
                    this.cmbPublishTopic.Items.Add(topic);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AppentText(string msg)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                this.rtbContent.Text += string.Format("【{0}】{1}\n", DateTime.Now.ToShortTimeString(), msg);
            }));
        }

        private void ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs args)
        {
            string msg = string.Format("接收信息：主题：{0}  负载：{1}  QoS：{2}", args.ApplicationMessage.Topic, Encoding.UTF8.GetString(args.ApplicationMessage.Payload), args.ApplicationMessage.QualityOfServiceLevel.ToString());
            AppentText(msg);
        }

        private void ClientConnected(object sender, MqttClientConnectedEventArgs args)
        {
            AppentText(string.Format("客户端已连接"));
        }

        private void ClientDisconnected(object sender, MqttClientDisconnectedEventArgs args)
        {
            AppentText(string.Format("客户端断开连接"));
        }

        private int CountSameProcess()
        {
            Process cur = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(cur.ProcessName);
            return processes.Length;
        }
    }
}
