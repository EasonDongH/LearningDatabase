using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTT.Util;
using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace MQTT.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Util.MqttServer mqttServer = new Util.MqttServer("127.0.0.1", "1883");
            mqttServer.ConnectionValidator = ConnectionValidator;
            mqttServer.ClientConnected = CliendConnected;
            mqttServer.ClientDisconnected = ClientDisconnected;
            mqttServer.ApplicationMessageReceived = ApplicationMessageReceived;
            mqttServer.ClientSubscribedTopic = ClientSubscribedTopic;
            mqttServer.Started = Started;
            mqttServer.Stopped = Stopped;
            mqttServer.Start();

            Console.ReadLine();
        }

        static void ConnectionValidator(MqttConnectionValidatorContext context)
        {
            //if (context.ClientId.Length < 10)
            //{
            //    context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
            //    return;
            //}
            //if (!context.Username.Equals("admin"))
            //{
            //    context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
            //    return;
            //}
            //if (!context.Password.Equals("public"))
            //{
            //    context.ReturnCode = MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
            //    return;
            //}
            context.ReturnCode = MqttConnectReturnCode.ConnectionAccepted;
        }

        static void CliendConnected(object sender, MqttClientConnectedEventArgs args)
        {
            Console.WriteLine(string.Format("有客户端连接，ClientId：{0}  ", args.ClientId));
        }

        static void ClientDisconnected(object sender, MqttClientDisconnectedEventArgs args)
        {
            Console.WriteLine(string.Format("有客户端断开连接，ClientId：{0}  ", args.ClientId));
        }

        static void ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs args)
        {
            string msg = string.Format("有客户端发布主题：{1}，负载：{2}，QoS：{3}，ClientId：{0}  ", args.ClientId, args.ApplicationMessage.Topic, Encoding.UTF8.GetString(args.ApplicationMessage.Payload), args.ApplicationMessage.QualityOfServiceLevel.ToString());
            Console.WriteLine(msg);
        }

        static void ClientSubscribedTopic(object sender, MqttClientSubscribedTopicEventArgs args)
        {
            string msg = string.Format("有客户端订阅主题：{1}，QoS：{2}，ClientId：{0}", args.ClientId, args.TopicFilter.Topic, args.TopicFilter.QualityOfServiceLevel);
            Console.WriteLine(msg);
        }

        static void Started(object sender, EventArgs args)
        {
            Console.WriteLine("服务器启动成功……");
        }

        static void Stopped(object sender, EventArgs args)
        {
            Console.WriteLine("服务器已关闭！");
        }
    }
}
