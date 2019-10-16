using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System.Net;

namespace SmartHome_V3
{
    class MQTTmanager
    {
        UpdateMessage um;
        MqttClient client;
        public MQTTmanager(string ip,string sub,UpdateMessage um)
        {
            try
            {
                this.um = um;
                client = new MqttClient(IPAddress.Parse(ip));

                // register to message received
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

                var clientId = Guid.NewGuid().ToString();
                client.Connect(clientId);

                // subscribe to the topic "/home/temperature" with QoS 2
                client.Subscribe(
                    new string[] { sub },
                    new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            }
            catch (MqttConnectionException)
            {

                um("Failed connected to MQTT server" + Environment.NewLine);
            }

        }
        private void client_MqttMsgPublishReceived(
            object sender, MqttMsgPublishEventArgs e)
        {
            // handle message received
            string str = Encoding.UTF8.GetString(e.Message, 0, e.Message.Length);
            //Console.WriteLine("message=" + str);
            //Console.WriteLine("message=" + e.ToString());

            um(str);
        }
        /// <summary>
        /// send message
        /// </summary>
        /// <param name="topic">topic tunel</param>
        /// <param name="msg">message</param>
        public void SendMessage(string topic, string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            client.Publish(topic, buffer);
        }
        /// <summary>
        /// update and make a tunal for output
        /// </summary>
        /// <param name="um"></param>
        public void ImplementDelegate(UpdateMessage um)
        {
            this.um = um;
        }
        /// <summary>
        /// close connection for MQTT
        /// </summary>
        public void CloseMQTT() {
            client.Disconnect();
        }
    }
}
