using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace MQTT.Util
{
    public class MqttServer
    {
        private IMqttServer _mqttServer = null;

        private string _ip = string.Empty;
        public string IP { get { return this._ip; } }

        private string _port = string.Empty;
        public string Port { get { return this._port; } }

        public Action<MqttConnectionValidatorContext> ConnectionValidator = null;
        public EventHandler<MqttClientConnectedEventArgs> ClientConnected = null;
        public EventHandler<MqttClientDisconnectedEventArgs> ClientDisconnected = null;
        public EventHandler<MqttApplicationMessageReceivedEventArgs> ApplicationMessageReceived = null;
        public EventHandler<MqttClientSubscribedTopicEventArgs> ClientSubscribedTopic = null;
        public EventHandler<MqttClientUnsubscribedTopicEventArgs> ClientUnsubscribedTopic = null;
        public EventHandler Started = null;
        public EventHandler Stopped = null;

        public MqttServer(string ip, string port)
        {
            this._ip = ip;
            this._port = port;
        }

        public async void Start()
        {
            // Backlog：表示服务器可以接受的并发请求的最大值
            var optionBuilder = new MqttServerOptionsBuilder().WithConnectionBacklog(1000).WithDefaultEndpointPort(Convert.ToInt32(this._port));
            optionBuilder.WithDefaultEndpointBoundIPAddress(IPAddress.Parse(this._ip));

            var options = optionBuilder.Build() as MqttServerOptions;
            options.ConnectionValidator += this.ConnectionValidator;

            this._mqttServer = new MqttFactory().CreateMqttServer();
            this._mqttServer.ClientConnected += this.ClientConnected;
            this._mqttServer.ClientDisconnected += this.ClientDisconnected;
            this._mqttServer.ApplicationMessageReceived += this.ApplicationMessageReceived;
            this._mqttServer.ClientSubscribedTopic += this.ClientSubscribedTopic;
            this._mqttServer.ClientUnsubscribedTopic += this.ClientUnsubscribedTopic;
            this._mqttServer.Started += this.Started;
            this._mqttServer.Stopped += this.Stopped;

            await _mqttServer.StartAsync(options);
        }

        public void Stop()
        {
            if (this._mqttServer == null)
                return;
            foreach (var clientSessionStatuse in this._mqttServer.GetClientSessionsStatusAsync().Result)
            {
                clientSessionStatuse.DisconnectAsync();
            }
            this._mqttServer.StopAsync();
            this._mqttServer = null;
        }
    }
}
