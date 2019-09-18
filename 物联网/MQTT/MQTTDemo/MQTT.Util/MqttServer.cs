using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Server;

namespace MQTT.Util
{
    public class MqttServer
    {
        public async void StartServer()
        {
            var options = new MqttServerOptions();
            var server = new MqttFactory().CreateMqttServer();
            await server.StartAsync(options);
        }
    }
}
