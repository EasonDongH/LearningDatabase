using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System.Threading;

namespace MQTT.Util
{
    public class MqttClient
    {
        public async void StartClient()
        {
            var client = new MqttFactory().CreateMqttClient();
            MqttClientTcpOptions tcpOptions = new MqttClientTcpOptions()
            {
                Server = "127.0.0.1",
                
            };
            var clientOptions = new MqttClientOptions()
            {
                ChannelOptions = tcpOptions,
                ClientId = "123"
            };
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            await client.ConnectAsync(clientOptions, cancellationTokenSource.Token);
        }
    }
}
