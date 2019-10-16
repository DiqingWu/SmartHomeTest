using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    class Device
    {
        /// <summary>
        /// stores all the data with date for this device
        /// </summary>
        private List<Data> datas;
        public string _deviceID; // A3sdf!@EAD  or sensor 1
        public string _devicetype; // sensor
        /// <summary>
        /// construct device
        /// stores all data on device 
        /// </summary>
        public Device()
        {
            datas = new List<Data>();
        }
        /// <summary>
        /// add a date into the list 
        /// </summary>
        /// <param name="d"></param>
        public void AddData(Data d)
        {
            datas.Add(d);
        }
        /// <summary>
        /// add a date into the list 
        /// </summary>
        /// <param name="d"></param>
        public void AddData(DateTime time, string data)
        {
            datas.Add(new Data(time,data));
        }

        /// <summary>
        /// Get all data from specified year
        /// </summary>
        /// <param name="time">specified year</param>
        /// <returns>List<Data> contains datas, return null if no find</returns>
        public List<Data> GetDatasFromYear(DateTime time)
        {
            List<Data> result = new List<Data>();
            foreach (Data d in datas)
            {
                DateTime date = d.getDateTime();
                if (time.Year.Equals(date.Year))
                {
                    result.Add(d);
                }
            }
            if (result.Count == 0)
                return null;
            return result;
        }
        /// <summary>
        /// get all data from device
        /// </summary>
        /// <returns>list string of homes</returns>
        public List<Data> GetAllData()
        {
            return datas;

        }
        /// <summary>
        /// Get all data from specified Month
        /// </summary>
        /// <param name="month">specified Month</param>
        /// <returns>List<Data> contains datas, return null if no find</returns>
        public List<Data> GetDatasFromMonth(DateTime time)
        {
            List<Data> result = new List<Data>();
            foreach (Data d in datas)
            {
                DateTime date = d.getDateTime();
                if (time.Year.Equals(date.Year) && time.Month.Equals(date.Month))
                {
                    result.Add(d);
                }
            }
            if (result.Count == 0)
                return null;
            return result;
        }
        /// <summary>
        /// Get all data from specified Day
        /// </summary>
        /// <param name="month">specified Day</param>
        /// <returns>List<Data> contains datas, return null if no find</returns>
        public List<Data> GetDatasFromDay(DateTime time)
        {
            List<Data> result = new List<Data>();
            foreach (Data d in datas)
            {
                DateTime date = d.getDateTime();
                if (time.Year.Equals(date.Year) && time.Month.Equals(date.Month) && time.Day.Equals(date.Day))
                {
                    result.Add(d);
                }
            }
            if (result.Count == 0)
                return null;
            return result;
        }
        /// <summary>
        /// Get all data from specified Hour
        /// </summary>
        /// <param name="month">specified Hour</param>
        /// <returns>List<Data> contains datas, return null if no find</returns>
        public List<Data> GetDatasFromHour(DateTime time)
        {
            List<Data> result = new List<Data>();
            foreach (Data d in datas)
            {
                DateTime date = d.getDateTime();
                if (time.Year.Equals(date.Year) && time.Month.Equals(date.Month) && time.Day.Equals(date.Day) && time.Hour.Equals(date.Hour))
                {
                    result.Add(d);
                }
            }
            if (result.Count == 0)
                return null;
            return result;
        }
        /// <summary>
        /// Get all data from specified minute
        /// </summary>
        /// <param name="month">specified minute</param>
        /// <returns>List<Data> contains datas, return null if no find</returns>
        public List<Data> GetDatasFromMinute(DateTime time)
        {
            List<Data> result = new List<Data>();
            foreach (Data d in datas)
            {
                DateTime date = d.getDateTime();
                if (time.Year.Equals(date.Year) && time.Month.Equals(date.Month) && time.Day.Equals(date.Day) && time.Hour.Equals(date.Hour)&& time.Minute.Equals(date.Minute))
                {
                    result.Add(d);
                }
            }
            if (result.Count == 0)
                return null;
            return result;
        }
        public DateTime GetFirstDate()
        {
            return datas[0].getDateTime();
        }
    }
}
