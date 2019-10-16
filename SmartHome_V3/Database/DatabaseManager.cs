using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SmartHome_V3
{
    public class DatabaseManager
    {
        /// <summary>
        /// database stores all data
        /// </summary>
        public Dictionary<String, Home> homes;
        /// <summary>
        /// construct a database
        /// </summary>
        public DatabaseManager() {
            homes = new Dictionary<string, Home>();
        }
        /// <summary>
        /// add data to database if not found create one.
        /// </summary>
        /// <param name="homeip"></param>
        /// <param name="deviceid"></param>
        /// <param name="data"></param>
        public void AddData(string homeip, string deviceid,Data data) {
            Home h;
            if (TryFindValue(homeip, out h))
            {
                h.AddData(deviceid, data);
            }
            else {
                homes.Add(homeip,new Home(homeip));
                homes[homeip].AddData(deviceid, data);
            }
        }
        /// <summary>
        /// speed up process when finish enable, make it true.
        /// </summary>
        public void DoneInit()
        {
            foreach(KeyValuePair< String, Home> h in homes)
            {
                homes[h.Key]._init_flag = true;
            }
        }
        /// <summary>
        /// add data to database if not found create one.
        /// </summary>
        /// <param name="ip">ip string</param>
        /// <param name="id">id string</param>
        /// <param name="date">date</param>
        /// <param name="s">data</param>
        public void AddData(string homeip, string deviceid, DateTime date,String s)
        {
            Data data = new Data(date, s); 
            Home h;
            if (TryFindValue(homeip, out h))
            {
                h.AddData(deviceid, data);
            }
            else
            {
                homes.Add(homeip, new Home(homeip));
                homes[homeip].AddData(deviceid, data);
            }
        }
        /// <summary>
        /// add data to database if not found create one.
        /// </summary>
        /// <param name="ip">ip string</param>
        /// <param name="id">id string</param>
        /// <param name="date">date</param>
        /// <param name="s">data</param>
        public void AddData(string homeip, string deviceid, String s)
        {
            Data data = new Data(DateTime.Now, s);
            Home h;
            if (TryFindValue(homeip, out h))
            {
                h.AddData(deviceid, data);
            }
            else
            {
                homes.Add(homeip, new Home(homeip));
                homes[homeip].AddData(deviceid, data);
            }
        }
        /// <summary>
        /// add data to database if not found create one.
        /// </summary>
        /// <param name="homeip">ip int</param>
        /// <param name="deviceid">id int</param>
        /// <param name="data">data</param>
        public void AddData(int ip, int id, Data data)
        {
            string homeip = Convert.ToString(ip);
            string deviceid = Convert.ToString(id);
            Home h;
            if (TryFindValue(homeip, out h))
            {
                h.AddData(deviceid, data);
            }
            else
            {
                homes.Add(homeip, new Home(homeip));
                homes[homeip].AddData(deviceid, data);
            }
        }
        /// <summary>
        /// Over load3:
        /// add data to database if not found create one.
        /// </summary>
        /// <param name="ip">ip int</param>
        /// <param name="id">id int</param>
        /// <param name="date">date</param>
        /// <param name="s">data</param>
        public void AddData(int ip, int id, DateTime date,string s)
        {
            Data data = new Data(date,s);
            string homeip = Convert.ToString(ip);
            string deviceid = Convert.ToString(id);
            Home h;
            if (TryFindValue(homeip, out h))
            {
                h.AddData(deviceid, data);
            }
            else
            {
                homes.Add(homeip, new Home(homeip));
                homes[homeip].AddData(deviceid, data);
            }
        }
        /// <summary>
        /// Add a new home into database
        /// </summary>
        /// <param name="homeip">new home id</param>
        public bool AddHome(string homeip) {
            Home h;
            if (!TryFindValue(homeip,out h)) {
                homes.Add(homeip, new Home(homeip));
                return true;
            }
            return false;
        }
        /// <summary>
        /// Add a new device into database
        /// 
        /// </summary>
        /// <param name="homeip">home ip</param>
        /// <param name="deviceip">devce id</param>
        /// <returns>bool</returns>
        public bool AddDevice(string homeip, string deviceip) {
            Home h;
            if (TryFindValue(homeip, out h))
            {
                return h.AddDevice(deviceip);
            }
            return false;
        }
        /// <summary>
        /// try to find the device at homes, if not found return false.
        /// </summary>
        /// <param name="deviceid">device id that looking for</param>
        /// <param name="d">device out</param>
        /// <returns></returns>
        private bool TryFindValue(string homeip, out Home d)
        {
            foreach (KeyValuePair<String, Home> s in homes)
            {
                if (s.Key == homeip)
                {
                    d = s.Value;
                    return true;
                }
            }
            d = null;
            return false;
        }
        /// <summary>
        /// get all homes from database
        /// </summary>
        /// <returns>list string of homes</returns>
        public List<String> GetHomeList() {
            List<String> temp = new List<string>();
            foreach (KeyValuePair<String, Home> k in homes) {
                temp.Add(k.Key);
            }
            return temp;

        }
        /// <summary>
        /// get device from home id
        /// </summary>
        /// <param name="id">home ip</param>
        /// <returns>list of string for devices</returns>
        public List<string> GetDevices(string id) {
            return homes[id].GetDeviceList();
        }
        /// <summary>
        /// get device from home id
        /// </summary>
        /// <param name="id">home ip</param>
        /// <returns>list of string for devices</returns>
        public List<Data> GetAllData(string ip, string id)
        {
            return homes[ip].GetAllData(id);
        }
        /// <summary>
        /// find correct data for the correct date
        /// </summary>
        /// <param name="deviceid">device id</param>
        /// <param name="date">date range for data</param>
        /// <returns></returns>
        public List<Data> GetData(string homeip,string deviceid, DateTime date)
        {
            Home h;
            Device d;
            if (TryFindValue(homeip, out h))
            {
                h.GetData(deviceid, date);
            }
            return null;
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
        /// <returns>List<Data></returns>
        public List<Data> GetData(string homeip,string deviceid, string mode, DateTime date)
        {
            Home h;
            if (TryFindValue(homeip, out h))
            {
                return h.GetData(deviceid, mode, date);
            }
            return null;
        }
        public DateTime GetFirstDate(string homeip, string deviceid)
        {
            Home h;
            if(TryFindValue(homeip,out h))
            {
                return h.GetFirstDate(deviceid);
            }
            throw new KeyNotFoundException();
        }
        /// <summary>
        /// get data from select whole month
        /// </summary>
        /// <param name="homeip">home ip</param>
        /// <param name="deviceid">device id</param>
        /// <param name="start">starting date</param>
        /// <param name="end">ending date</param>
        /// <returns>List of data </returns>
        public List<Data> GetDataFromMonths(string homeip, string deviceid, DateTime start, DateTime end)
        {
            List<Data> temp = new List<Data>();
            List<Data> temp2;
            if (start.Year > end.Year)
            {
                throw new InvalidTimeZoneException();
            }
            else if (start.Year == end.Year && start.Month > end.Month)
            {
                throw new InvalidTimeZoneException();
            }
            int totalMonth = (start.Year - end.Year) * 12 + end.Month - start.Month;

            //double totaldays = (start.Date - end.Date).TotalDays;

            //date started year and then month 
            for (int i = 0; i <= totalMonth; i++)
            {
                temp2 = GetData(homeip, deviceid, "month", start);
                if (temp2 != null)
                    temp.AddRange(temp2);

                start = start.AddMonths(1);
            }
            return temp;
        }
        /// <summary>
        /// get data from select whole month
        /// </summary>
        /// <param name="homeip">home ip</param>
        /// <param name="deviceid">device id</param>
        /// <param name="start">starting date</param>
        /// <param name="end">ending date</param>
        /// <returns>List of data </returns>
        public List<Data> GetDataFromDays(string homeip, string deviceid, DateTime start, DateTime end)
        {
            List<Data> temp = new List<Data>();
            List<Data> temp2;
            if (start.Year > end.Year)
            {
                throw new InvalidTimeZoneException();
            }
            else if (start.Year == end.Year && start.Month > end.Month)
            {
                throw new InvalidTimeZoneException();
            }
            //int totalMonth = (start.Year - end.Year) * 12 + end.Month - start.Month;

            double totaldays = (end.Date - start.Date).TotalDays;

            //date started year and then month 
            for (int i = 0; i <= totaldays; i++)
            {
                temp2 = GetData(homeip, deviceid, "day", start);
                if (temp2 != null)
                    temp.AddRange(temp2);

                start = start.AddDays(1);
            }
            return temp;
        }
        public void LoadDataTable(DataTable dataTable)
        {

            foreach (DataRow dr in dataTable.Rows)
            {
                AddData(dr["homeip"].ToString(), dr["deviceip"].ToString(), new Data(Convert.ToDateTime(dr["time"].ToString()), dr["data"].ToString()));
            }
        }
        

    }
}
