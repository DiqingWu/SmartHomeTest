using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    public class Home
    {
        /// <summary>
        /// store all the data
        /// </summary>
        private Dictionary<String, Device> _home;
        /// <summary>
        /// room status
        /// </summary>
        public Room _currentRoom;
        /// <summary>
        /// constructor for Home. construct homes libary
        /// </summary>
        public bool _init_flag = false;

        public List<string> _functionList;
        public Home( string homeid )
        {
            _home = new Dictionary<string, Device>();
            _functionList = new List<string>();
            HomeID = homeid;
            _currentRoom = new Room(homeid);
        }

        public string HomeID = "";
        public void TriggerCLK()
        {
            if(_functionList.Count <= 0)
            {
                return;
            }
            else if(_functionList.Count == 1)
            {
                SmartHomeController._functionController._functionManager.RunFunctions(HomeID, _functionList[0]);
            }
            else
            {
                SmartHomeController._functionController._functionManager.RunFunctions(HomeID, _functionList);
            }
            
        }
        /// <summary>
        /// add data to libary if not found exist create new
        /// </summary>
        /// <param name="deviceip">string ip for device name or id</param>
        /// <param name="data">data</param>
        public void AddData(string deviceid, Data data) {
            if (_init_flag)
            {
                _currentRoom.updateStatus(data.getData());
                TriggerCLK();
            }
            bool found = false;
                foreach (KeyValuePair<String, Device> s in _home)
                {
                    if (s.Key == deviceid)
                    {
                        s.Value.AddData(data);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    _home.Add(deviceid, new Device());
                    _home[deviceid].AddData(data);
                }

        }
        /// <summary>
        /// remove device from home
        /// </summary>
        /// <param name="s">string for device id</param>
        /// <returns></returns>
        public bool RemoveDevice(string s) {
            return _home.Remove(s);
        }
        /// <summary>
        /// try to find the device at home, if not found return false.
        /// </summary>
        /// <param name="deviceid">device id that looking for</param>
        /// <param name="d">device out</param>
        /// <returns></returns>
        private bool TryFindValue(string deviceid,out Device d) {
            foreach (KeyValuePair<String, Device> s in _home)
            {
                if (s.Key == deviceid)
                {
                    d = s.Value;
                    return true;
                }
            }
            d = null;
            return false;
        }
        /// <summary>
        /// add a device into database, can store data later
        /// </summary>
        /// <param name="deviceid">device id</param>
        /// <returns>boolean device id exist or not</returns>
        public bool AddDevice(string deviceid) {

            Device d;
            if (!TryFindValue(deviceid, out d))
            {
                _home.Add(deviceid,new Device());
                return true;
            }
            return false;

        }
        public List<Data> GetAllData(string id) {
            return _home[id].GetAllData();
        }
        /// <summary>
        /// find correct data for the correct date
        /// </summary>
        /// <param name="deviceid">device id</param>
        /// <param name="date">date range for data</param>
        /// <returns></returns>
        public List<Data> GetData(string deviceid,DateTime date) {
            Device d;
            if (TryFindValue(deviceid,out d)) {
                return TimeOperator("auto", d, date);
            }
            return null;
        }
        /// <summary>
        /// get all device names from database
        /// </summary>
        /// <returns>list string of device</returns>
        public List<String> GetDeviceList()
        {
            List<String> temp = new List<string>();
            foreach (KeyValuePair<String, Device> k in _home)
            {
                temp.Add(k.Key);
            }
            return temp;

        }
        /// <summary>
        /// overload: Mode:
        /// year: get data in this year
        /// month: get data in this month
        /// day: get date in this day
        /// hour: get data in this hour
        /// minute: get data in this minute
        /// </summary>
        /// <param name="deviceid">device id</param>
        /// <param name="mode">operation mode</param>
        /// <param name="date">date range for data</param>
        /// <returns></returns>
        public List<Data> GetData(string deviceid,string mode,DateTime date) {
            Device d;
            if (TryFindValue(deviceid, out d))
            {
                return TimeOperator(mode, d, date);
            }
            return null;
        }
        /// <summary>
        /// an operator checks the condition
        /// </summary>
        /// <param name="d"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private List<Data> TimeOperator(string mode , Device d,DateTime date) {
            if (mode == "auto") {
                if (date.Year == 0001)
                {
                    return null;
                }
                else if (date.Month == 1 && date.Day == 1 && date.Hour == 12 && date.Minute == 0)
                {
                    return d.GetDatasFromYear(date);
                }
                else if (date.Day == 1 && date.Hour == 12 && date.Minute == 0)
                {
                    return d.GetDatasFromMonth(date);
                }
                else if (date.Hour == 12 && date.Minute == 0)
                {
                    return d.GetDatasFromDay(date);
                }
                else if (date.Minute == 0)
                {
                    return d.GetDatasFromHour(date);
                }
                else {
                    return d.GetDatasFromMinute(date);
                }
            }
            switch (mode) {
                case "year":
                    return d.GetDatasFromYear(date);
                case "month":
                    return d.GetDatasFromMonth(date);
                case "day":
                    return d.GetDatasFromDay(date);
                case "hour":
                    return d.GetDatasFromHour(date);
                case "minute":
                    return d.GetDatasFromMinute(date);
                default:
                    throw new InvalidOperationException("wrong mode entered");
            }
        }
        public DateTime GetFirstDate( string deviceid)
        {
            Device d;
            if(TryFindValue(deviceid,out d))
            {
                return _home[deviceid].GetFirstDate();
            }
            throw new KeyNotFoundException();
        }

        public void AddFunction(string s)
        {
            int dump;
            if (TryGetValue(s,out dump))
            {
                return;
            }
            _functionList.Add(s);
        }
        public void DeleteFunction(string s)
        {
            s = s.ToLower();
            int dump;
            if (TryGetValue(s,out dump))
            {
                _functionList.Remove(s);
            }
        }
        public bool TryGetValue(string s, out int output)
        {
            output = 0;
            foreach(string ss in _functionList){
                if(s == ss)
                {
                    return true;
                }
                output++;
            }
            return false;
        }
    }
}
