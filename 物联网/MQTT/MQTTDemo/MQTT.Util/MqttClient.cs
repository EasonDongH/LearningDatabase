using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Util
{
    public class MqttClient
    {
        private IMqttClient _mqttClient = null;
        private MqttClientOptions _clientOption = null;

        private string _serverIP = string.Empty;
        public string ServerIP { get { return this._serverIP; } }

        private string _serverPort = string.Empty;
        public string ServerPort { get { return this._serverPort; } }

        public EventHandler<MqttApplicationMessageReceivedEventArgs> ApplicationMessageReceived = null;
        public EventHandler<MqttClientConnectedEventArgs> ClientConnected = null;
        public EventHandler<MqttClientDisconnectedEventArgs> ClientDisconnected = null;

        public MqttClient(string clientId = "", string ip="", string port="")
        {
            this._serverIP = ip;
            this._serverPort = port;
            if (clientId == string.Empty)
                clientId = Guid.NewGuid().ToString();

            this._clientOption = new MqttClientOptions() { ClientId = clientId };
            this._clientOption.CleanSession = false;
            this._clientOption.KeepAlivePeriod = TimeSpan.FromSeconds(90);

            this._mqttClient = new MqttFactory().CreateMqttClient();
        }

        public void Init()
        {
            _mqttClient.ApplicationMessageReceived += this.ApplicationMessageReceived;
            _mqttClient.Connected += this.ClientConnected;
            _mqttClient.Disconnected += this.ClientDisconnected;
        }

        /**
      host: 服务器地址
      port: 服务器端口
      tls:  是否使用tls协议，mosca是支持tls的，如果使用了要设置成true
      keepalive: 心跳时间，单位秒，每隔固定时间发送心跳包, 心跳间隔不得大于120s
      clean: session是否清除，这个需要注意，如果是false，代表保持登录，如果客户端离线了再次登录就可以接收到离线消息
      auth: 是否使用登录验证
      user: 用户名
      pass: 密码
      willTopic: 订阅主题
      willMsg: 自定义的离线消息
      willQos: 接收离线消息的级别
      clientId: 客户端id，需要特别指出的是这个id需要全局唯一，因为服务端是根据这个来区分不同的客户端的，默认情况下一个id登录后，假如有另外的连接以这个id登录，上一个连接会被踢下线, 我使用的设备UUID
*/
        public async void Connect(string userName, string pwd, string ip = "", string port = "")
        {
            if (ip != string.Empty)
                this._serverIP = ip;
            if (port != string.Empty)
                this._serverPort = port;
            try
            {
                if (_mqttClient == null)
                {
                    this._mqttClient = new MqttFactory().CreateMqttClient();
                    Init();
                }
                else if (this._mqttClient.IsConnected)
                {
                    await this._mqttClient.DisconnectAsync();
                }

                this._clientOption.ChannelOptions = new MqttClientTcpOptions()
                {
                    Server = this._serverIP,
                    Port = Convert.ToInt32(this._serverPort)
                };
                this._clientOption.Credentials = new MqttClientCredentials()
                {
                    Username = userName,
                    Password = pwd
                };

                await _mqttClient.ConnectAsync(this._clientOption);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Disconnect()
        {
            if (this._mqttClient == null)
                return;
            if (this._mqttClient.IsConnected)
                await _mqttClient.DisconnectAsync();
        }

        public void Stop()
        {
            if (this._mqttClient == null)
                return;
            this._mqttClient.Dispose();
            this._mqttClient = null;
        }

        public void SubscribeAsync(string topic, string qos)
        {
            Task.Factory.StartNew(async () =>
            {
                await _mqttClient.SubscribeAsync(
                    new List<TopicFilter>
                    {
                            new TopicFilter(
                                topic,
                                (MqttQualityOfServiceLevel)Enum.Parse(typeof (MqttQualityOfServiceLevel), qos))
                    });
            });
        }

        public void PublishAsync(string topic, string qos, string payload)
        {
            if (this._mqttClient == null)
                return;
            Task.Factory.StartNew(async () =>
            {
                var msg = new MqttApplicationMessage()
                {
                    Topic = topic,
                    Payload = Encoding.UTF8.GetBytes(payload),
                    QualityOfServiceLevel = (MqttQualityOfServiceLevel)Enum.Parse(typeof(MqttQualityOfServiceLevel), qos),
                    Retain = true // 是否保留信息
                };
                await _mqttClient.PublishAsync(msg);
            });
        }
    }
}
