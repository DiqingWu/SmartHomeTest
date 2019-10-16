using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    class FunctionDefineList
    {

        MQTT_Message MQTT_send;
        UpdateMessage ServerLog;
        public string CurrentHomeIP { get; set; }
        public List<string> Functions { get; set; }

        SHdata shdata;
        //public Room CurrentHomeStatus { get; set; }

        /****************************************************************/
        //UpdateMessage WS_send; // disabled for now.
        /****************************************************************/

        /// <summary>
        /// construct functions
        /// </summary>
        public FunctionDefineList()
        {
            //define functions here
            MQTT_send = SmartHomeController._apiManager.SendMQTT;
            ServerLog = SmartHomeController._serverLog;
            //WS_send = SmartHomeController._apiManager.SendWS;  // disabled for now.
            Functions = new List<string>();
            Functions.Add("LightAI");
            Functions.Add("AcAndroid");
            Functions.Add("SHdata");
            //Functions.Add();
            


        }
        public void RunFunction(string function)
        {
            function = function.ToLower();

            switch(function){
                case "LightAI":
                case "lightai":
                    MQTT_send("Pi3", myfunction.LightAI(SmartHomeController._databaseController.database.homes[CurrentHomeIP]._currentRoom.lumen));
                    ServerLog("Sending message to Pi3, Action: Light Control");
                    break;
                case "SHdata":
                    shdata = new SHdata(CurrentHomeIP);
                    break;
                case "AcAndroid":
                case "acandroid":
                    if (!SmartHomeController._databaseController.database.homes[CurrentHomeIP]._currentRoom.AutoAC)
                    {
                        SmartHomeController._databaseController.database.homes[CurrentHomeIP]._currentRoom.ACinit();
                        ServerLog("room: "+ CurrentHomeIP + ", AC has initialed.");
                    }
                    else
                    {
                        ServerLog("Changing room "+ CurrentHomeIP + ", Action: AC Control");
                    }
                    SmartHomeController._databaseController.database.homes[CurrentHomeIP]._currentRoom.RunAC();
                    break;
                default:
                    throw new NotImplementedException("Function not implement, or input function is incorrect");
            }
        }
    }
}
