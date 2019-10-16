using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    public static class Constants
    {
        /// <summary>
        /// Google mail
        /// </summary>
        //public static string WorkEmail = "smarthomepandaservice@gmail.com"; 
        //public static string WorkPassword = "SmartPanda123";
        //public static string EmailServer = "smtp.gmail.com";
        //public static int STMP_port = 587;
        /// <summary>
        /// outlook mail
        /// </summary>
        /*
        public static string WorkEmail = "SmartHomeResearch2019@outlook.com"; 
        public static string WorkPassword = "SmartHome2019";
        public static string EmailServer = "smtp-mail.outlook.com";
        public static int STMP_port = 587;
        */
        public static string WorkEmail = "wudiqing@hotmail.com";
        public static string WorkPassword = "wdq110";
        public static string EmailServer = "smtp.live.com";
        public static int STMP_port = 587;
        

        public static string mqttip = "192.168.8.177";
        public static string mqttsub = "Server";
        public static int port = 8686;
        public static string NetWorkMode = "standard";
        public static string MQTT_Base = "Pi3";
        public static string SQL_Connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\diqing\\Desktop\\SmartHome_V3\\SmartHome_V3\\DatabaseAccount.mdf;Integrated Security=True";
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\diqing\Desktop\SmartHome_V3\SmartHome_V3\DatabaseAccount.mdf;Integrated Security=True


    }
}
