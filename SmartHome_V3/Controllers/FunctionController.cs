using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
namespace SmartHome_V3
{
    public delegate bool SendMQTT(string topic, string message);
    delegate bool SendWS(string message);
    public class FunctionController
    {

        public  FunctionManager _functionManager;

        public Dictionary<string, bool> function_names;
        SendMQTT MQTT_send;
        SendWS WS_send;
        bool ac_switch = false;
        /// <summary>
        /// construct functions
        /// </summary>
        public FunctionController()
        {

            _functionManager = new FunctionManager();
            //MQTT_send = SmartHomeController.api.SendMQTT;
            //WS_send = SmartHomeController.api.SendWS;
            function_names = new Dictionary<string, bool>();
            MyFunctions();
        }
        /*
            to add function.
            1. add inital MyFunctions()
            2. define function RunFunctions()
            3. done
            4. message to serverlog----> SmartHomeController.output("");
             */
        public void MyFunctions()
        {
            foreach(string s in _functionManager.GetFunctionList())
            {
                function_names.Add(s, false);
            }
        }
        public void RunFunctions()
        {
            
        }

        /// <summary>
        /// create new thread
        /// </summary>
        public void OpenNewDatabaseAnalyze()
    {
        try
        {
                //acc = new AcControl(MQTT_send);
                //Application.Run(acc);
                ac_switch = false;
        }
        catch (Exception ex)
        {
            // log errors
        }
    }
    public void AddFunction(string s)
        {
            bool temp;
            if(!TryGetValue(s,out temp))
            function_names.Add(s,false);
        }
        public void MakeCheck(string s)
        {
            function_names[s] = true;   
        }
        public void MakeUncheck(string s)
        {
            function_names[s] = false;
        }
        /// <summary>
        /// get a list contains all the functions name
        /// </summary>
        /// <returns></returns>
        public string[] GetFunctionsList()
        {
            string[] temp = new string[function_names.Count];
            int count = 0;
            foreach (KeyValuePair<string, bool> k in function_names)
            {
                temp[count] = (k.Key);
                count++;
            }
            return temp;
        }
        public bool TryGetValue(string s, out bool list)
        {
            foreach (KeyValuePair<string, bool> k in function_names)
            {
                if (k.Key.Equals(s))
                {
                    list = k.Value;
                    return true;
                }
            }
            list = false;
            return false;
        }
        

    }
}
