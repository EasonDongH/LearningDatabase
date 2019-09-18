using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTT.Util;

namespace MQTT.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttServer server = new MqttServer();
            server.StartServer();
            Console.WriteLine("MqttServer启动成功！");

            Console.ReadLine();
        }
    }
}
