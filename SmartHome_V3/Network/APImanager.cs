using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    public delegate void UpdateMessage(string st);
    public delegate bool MQTT_Message(string sub,string st);
    public class APImanager
    {
        UpdateMessage WSOutput;
        UpdateMessage MQTToutput;
        UpdateMessage MainComm;
        WSController_super wsc;
        MQTTmanager mqttc;
        WSController_standard wsc2;

        string mode;
        public APImanager(UpdateMessage mainCom)
        {
            MainComm = mainCom;
            WSOutput = MainComm;
            MQTToutput = MainComm;
        }
        /// <summary>
        /// create WebSocket by ip and port
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool CreateWSServer( int port, string state)
        {
            try
            {
                if(state == "super")
                {
                    wsc = new WSController_super(port, WSOutput);
                }
                else
                {
                    wsc2 = new WSController_standard(port, WSOutput);
                }
                mode = state;
                return true;
            }
            catch (Exception e) {
                MainComm(e.ToString());
                return false;
            }
        }
        /// <summary>
        /// close connection for websocket server
        /// </summary>
        public void CloseWS()
        {
            try
            {
                if (mode == "super")
                {
                    wsc.StopServer();
                }
                else
                {
                    wsc2.StopServer();
                }
                
            }
            catch (Exception)
            {
                MainComm("Need to create a websocket to set output.");
            }
        }
        /// <summary>
        /// send message to sicfeic client
        /// </summary>
        /// <param name="message"> message string</param>
        /// <returns></returns>
        public bool SendWS(string message)
        {
            try
            {
                if (mode == "super")
                {
                    wsc.SendMessage(message, null);
                }
                else
                {
                    //wsc2.SendMessage(message, null);
                }
                
                return true;
            }
            catch (Exception e) {
                MainComm("Message send failed. due to:"+Environment.NewLine+e.ToString());
                return false;
            }
        }
        /// <summary>
        /// Set output for lisenting message 
        /// </summary>
        /// <param name="um">UpdateMessage that make print or take message</param>
        public void SetWSOutput(UpdateMessage um)
        {
            WSOutput = um;
            try
            {
                if (mode == "super")
                {
                    wsc.ImplementDelegate(um);
                }
                else
                {
                    wsc2.ImplementDelegate(um);
                }
                
            }
            catch (Exception)
            {
                MainComm("Need to create a websocket to set output.");
            }
        }

        public bool CreateMQTTConnection(string ip, string sub)
        {
            try
            {
                mqttc = new MQTTmanager(ip, sub, MQTToutput);
                return true;
            }
            catch (Exception e)
            {
                MainComm(e.ToString());
                return false;
            }
        }
        public void CloseMQTT()
        {
            try
            {
                mqttc.CloseMQTT();
            }
            catch (Exception)
            {
                MainComm("Need to create a websocket to set output.");
            }
        }

        public bool SendMQTT(string topic ,string message)
        {
            try
            {
                mqttc.SendMessage(topic, message);
                return true;
            }
            catch (Exception e)
            {
                MainComm("Message send failed. due to:" + Environment.NewLine + e.ToString());
                return false;
            }
        }
        /// <summary>
        /// Set output for lisenting message 
        /// </summary>
        /// <param name="um">UpdateMessage that make print or take message</param>
        public void SetMQTTOutput(UpdateMessage um)
        {
            MQTToutput = um;
            try
            {
                mqttc.ImplementDelegate(um);
            }
            catch (Exception)
            {
                MainComm("Need to create a MQTT client to set output.");
            }
        }
        public void MessageEncryptionOn()
        {
            throw new NotImplementedException();
        }
        public void MessageEncryptionOff()
        {
            throw new NotImplementedException();
        }

        public void SelectEncryptionMode()
        {
            throw new NotImplementedException();
        }
    }
}
