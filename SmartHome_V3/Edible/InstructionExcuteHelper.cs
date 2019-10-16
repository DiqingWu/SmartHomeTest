using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    class InstructionExcuteHelper
    {
        public static string ExcuteMsg(string msg)
        {
            string homeid = "";
            //send message to server log
            SmartHomeController._serverLog("message from andriod: \t" + msg);
            // check if it is Json
            if (!FunctionManager.IsValidJson(msg)){
                
                return "unkown message.";
            }
            //1. define account
            //2. define msg income type
            //3. find information and create output
            //string[] temp = msg.Split(',');
            int type;
            string[] temp = FunctionManager.DecripeJsonWS(msg, out type);
            
            if(type == 0 )
            {
                throw new InvalidOperationException("JSON decription failed. check function");
            }
            else if(type == 1)
            {
                
                try
                {
                    homeid = SmartHomeController._accountManager.GetLinkedBase(temp[0])[Convert.ToInt32(temp[1])];
                }
                catch (Exception ex)
                {
                    throw new NullReferenceException("No Linked Base.");
                }
            }

            //0 account, 1 base, 2 instruction, 3 device, 4 action or datatype
            //0 account, 1 password, 2 instruction, 3 email
            temp[2] = temp[2].ToLower();
            switch (temp[2])
            {
                case "request":
                    if (temp[3].Equals("functionlist"))
                    {
                        return SmartHomeController._functionController._functionManager.GetFunctionNames();
                    }

                    string output = "data_" + temp[3] + "_";
                    DateTime day;
                    List<Data> datas = new List<Data>();

                    if (FunctionManager.isDateTime(temp[4], out day))
                    {
                        datas = SmartHomeController._databaseController.database.GetData(homeid, temp[3], "day", day);
                        if (datas == null)
                        {
                            return "";
                            //return "no data in this date.";
                        }
                    }
                    else
                    {
                        datas = SmartHomeController._databaseController.database.GetAllData(homeid, temp[3]);
                        datas = FunctionManager.DataSort(datas, Convert.ToInt32(temp[2]));

                    }
                    
                    foreach (Data d in datas)
                    {
                        string s;
                        output += d.getUnix(out s) + ",";
                        temp = s.Split(',');
                        string[] humidity = temp[0].Split(':');
                        //if(temp[]) //  temp[0]+ ","+
                        temp = temp[1].Split(':');
                        //output += temp[1];
                        output += humidity[1] + "," + temp[1] + ";";

                    }
                    return (output);
                    break;
                case "function":
                    if (temp[3].ToLower().Equals("on"))
                    {
                        SmartHomeController._databaseController.database.homes[homeid].AddFunction(temp[4]);
                    }
                    else
                    {
                        SmartHomeController._databaseController.database.homes[homeid].DeleteFunction(temp[4]);
                    }
                    return "";
                    break;
                case "status":
                    if (temp[3] == "lights")
                    {
                        string status = "off";
                        if (SmartHomeController._databaseController.database.homes[homeid]._currentRoom.light1)
                        {
                            status = "on";
                        }

                        return ("status_light_" + status + "," + SmartHomeController._databaseController.database.homes[homeid]._currentRoom.lumen);
                    }
                    else if (temp[1] == "temp")
                    {
                        //something 
                        float tempe = SmartHomeController._databaseController.database.homes[homeid]._currentRoom.temp;
                        return tempe.ToString();
                    }
                    return "";
                    break;
                case "set":
                    if (temp[3] == "temp")
                    {
                        
                        if (temp[4] == "off")
                        {
                            //turn off AC
                            //and function
                            int d;
                            if (!SmartHomeController._accountManager.TryGetIndex(temp[0], out d))
                            {
                                throw new Exception();

                            }
                            SmartHomeController._accountManager._users[d].LinkedHomes.Remove("AcAndroid");

                        }
                        else
                        {

                            //set value and turn on function.
                            SmartHomeController._databaseController.database.homes[homeid]._currentRoom.SetPreferedTemp(Convert.ToInt32(temp[4]));

                        }
                        return ("debug one, Server has reviced your message for turn on or off AC.");
                    }
                    else if (temp[3] == "lamp 1")
                    {
                        if (temp[4] == "off")
                        {
                            SmartHomeController._apiManager.SendMQTT("Pi3", "{\"ID\":\"xuebo\",\"Device\":\"lamp 1\",\"Status\":\"0\"}");
                        }
                        else if (temp[4] == "on")
                        {
                            SmartHomeController._apiManager.SendMQTT("Pi3", "{\"ID\":\"xuebo\",\"Device\":\"lamp 1\",\"Status\":\"1\"}");
                        }
                        return ("done.");

                    }
                    return "";
                    break;
                case "login":
                    if(SmartHomeController._accountManager.Login(temp[0], temp[1])){
                        return "login_true";
                    }
                    else
                    {
                        return "login_false";
                    }
                    break;
                case "register":
                    if (SmartHomeController._accountManager.AddAccount(temp[0], temp[1],temp[3]))
                    {
                        return "register_true";
                    }
                    else
                    {
                        return "register_false";
                    }
                    break;
                case "logout":
                    if (SmartHomeController._accountManager.Logout(temp[0]))
                    {
                        return "logout_true";
                    }
                    else
                    {
                        return "logout_false";
                    }
                    break;
                default:
                    int dump;
                    if (!SmartHomeController._accountManager.TryGetIndex(temp[0], out dump))
                    {
                        throw new Exception();

                    }
                    if (temp[4] == "off")
                    {
                        //turn off AC
                        //and function
                        SmartHomeController._accountManager._users[dump].LinkedHomes.Remove(temp[3]);
                    }
                    else
                    {
                        SmartHomeController._accountManager._users[dump].AddFunction(temp[3]);
                    }
                    return "";
                    throw new Exception();
                    break;
            }
            return "unknown instuction.";
        }
    }
}
