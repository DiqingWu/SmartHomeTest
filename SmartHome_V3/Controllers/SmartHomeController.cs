using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    public static class SmartHomeController
    {

        /***********************************/
        /******************test******************/
        public static SHdata shdata;
        /************************************************/


        public static APImanager _apiManager;
        public static DatabaseController _databaseController;
        public static FunctionController _functionController;
        
        public static UpdateMessage _serverLog;
        public static AccountManager _accountManager;
        public static EmailSender _emailSender;
        public static GUImanager _guiManager;
        public static void InitialSmartHome()
        {
            
            _serverLog = UpdateLog;
            _apiManager = new APImanager(_serverLog);
            _databaseController = new DatabaseController();
            
            _accountManager = new AccountManager();
            _emailSender = new EmailSender();
            _guiManager = new GUImanager();
            _functionController = new FunctionController();
            /*************test********************/
            shdata = new SHdata("xuebo");
            /*************************************/
        }
        /// <summary>
        /// StartWS
        /// </summary>
        public static void StartWS()
        {
            _apiManager.CreateWSServer(Constants.port, Constants.NetWorkMode);
            _apiManager.SetWSOutput(WSoutput);

        }
        /// <summary>
        /// start MQTT
        /// </summary>
        public static void StartMQTT()
        {
            // you dont need to set the output below if you are not using other setup.
            _apiManager.CreateMQTTConnection(Constants.mqttip, Constants.mqttsub);
            _apiManager.SetMQTTOutput(MQTToutput);
        }
        public static void MQTToutput(string s)
        {
            /*************test********************/
            shdata.Clock_tick();
            /*************************************/


            if (FunctionManager.IsValidJson(s))
            {
                string[] temp = FunctionManager.DecripeJsonMQTT(s);
                _databaseController.InsertData(temp[0], temp[1], temp[2]);

                _serverLog("Message from " + temp[0] + ", device id: " + temp[1] + "data: " + temp[2]);
            }
            else
            {
                _serverLog("Message from MQTT Device: "+s);
            }
            

        }
        public static void WSoutput(string s)
        {

        }
        /// <summary>
        /// close websockes conenction
        /// </summary>
        public static void CloseWS()
        {
            _apiManager.CloseWS();
        }
        /// <summary>
        /// close MQTT connection
        /// </summary>
        public static void CloseMQTT()
        {
            _apiManager.CloseMQTT();
        }
        /// <summary>
        /// update message to the server log.
        /// </summary>
        /// <param name="st"></param>
        public static void UpdateLog(string s)
        {
            _guiManager.Update(s);
        }

    }
}
