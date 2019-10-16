using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartHome_V3
{
    public class FunctionManager
    {
        FunctionDefineList _func;
        public FunctionManager()
        {
            _func = new FunctionDefineList();

        }
        public void RunFunctions(string homeip ,string function)
        {
            _func.CurrentHomeIP = homeip;
            //_func.CurrentHomeStatus = r;
            _func.RunFunction(function);
        }
        public void RunFunctions(string homeip,List<string> function)
        {
            _func.CurrentHomeIP = homeip;
           // _func.CurrentHomeStatus = r;
            foreach (string s in function)
            {
                _func.RunFunction(s);
            }
        }
        /// <summary>
        /// change json format store into database
        /// </summary>
        /// <param name="s">json string</param>
        /// <returns></returns>
        public static string[] DecripeJsonMQTT(string s)
        {
            
            var msg = JsonConvert.DeserializeObject<Dictionary<string, string>>(s);
            //s is a confirmed Json

            //format Json into string[3]
            string[] temp = new string[3];
                temp = new string[3] { msg["ID"], msg["Device"], msg["Data"] };
            return temp;
        }
        /// <summary>
        /// Add for the data analyse deserialize the Json
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string[] DecripeJson(string s)
        {
            var msg = JsonConvert.DeserializeObject<Dictionary<string, string>>(s);
            //s is a confirmed Json

            //format Json into string[3]
            string[] temp = new string[3];
            temp = new string[3] { msg["ID"], msg["Device"], msg["Data"] };
            return temp;
        }
        /// <summary>
        /// change json format store into database
        /// </summary>
        /// <param name="s">json string</param>
        /// <returns></returns>
        public static string[] DecripeJsonWS(string s, out int type)
        {
            var msg = JsonConvert.DeserializeObject<Dictionary<string, string>>(s);
            //s is a confirmed Json

            //format Json into string[3]
            string[] temp = new string[5];
                try
                {
                    temp = new string[5] { msg["Account"], msg["Base"], msg["Instruction"], msg["Device"], msg["Action"] };
                    type = 1;
                }
                catch (Exception ex)
                {
                    try
                    {
                        temp = new string[5] { msg["Account"], msg["Base"], msg["Instruction"], msg["Device"], msg["DataType"] };
                        type = 2;
                    }
                    catch (Exception exx)
                    {
                        type = 0;
                        try
                        {
                            temp = new string[4] { msg["Account"], msg["Password"], msg["Instruction"], msg["Email"]}; 
                            type = 3;
                        }
                        catch(Exception exxx)
                        {
                            
                        }
                        }
                }
            
            

            return temp;
        }
        /// <summary>
        /// method check if string is json
        /// </summary>
        /// <param name="strInput">string</param>
        /// <returns></returns>
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Add for the data analyse check the string is json or not
        /// 
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public bool ValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static List<Data> DataSort(List<Data> datas, int range)
        {
            Stack<Data> stack = new Stack<Data>();
            List<Data> temp = new List<Data>();
            for (int i = datas.Count - 1; i > datas.Count - range - 1; i--)
            {
                stack.Push(datas[i]);
            }
            while (stack.Count > 0)
            {
                temp.Add(stack.Pop());
            }
            return temp;

        }
        public string GetFunctionNames()
        {
            string output = "functionlist_";
            foreach(string s in _func.Functions)
            {
                output += s + ",";
            }
            return output.Remove(output.Length-1);
        }
        public string[] GetFunctionList()
        {
            string[] list = new string[_func.Functions.Count];
            int index = 0;
            foreach (string s in _func.Functions)
            {
                list[index] = s;
                index++;
            }
            return list;
        }
        public static bool isDateTime(string s, out DateTime date)
        {

            try
            {
                date = Convert.ToDateTime(s);
                return true;
            }
            catch (FormatException)
            {
                date = DateTime.Now;
                return false;
            }
        }
    }
}
