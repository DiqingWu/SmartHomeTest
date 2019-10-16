using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    public class Data
    {
        /// <summary>
        /// value datetime stores time
        /// </summary>
        private DateTime time { set; get; }
        /// <summary>
        /// value data store data
        /// </summary>
        private String data { set; get; }
        /// <summary>
        /// outgoing data (string)
        /// sort data date by year
        /// </summary>
        /// <param name="data">out going string data</param>
        /// <returns>a string contains data creat time by year</returns>
        public Data(DateTime time, String data)
        {
            this.time = time;
            this.data = data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string getDataByYear(out String data)
        {
            data = this.data;
            return time.ToString("yyyy");
        }
        /// <summary>
        /// outgoing data (string)
        /// sort data date by month
        /// </summary>
        /// <param name="data">out going string data</param>
        /// <returns>a string contains data creat time by month</returns>
        public string getDataByMonth(out String data)
        {
            data = this.data;
            return time.ToString("MM/yyyy");
        }
        /// <summary>
        /// outgoing data (string)
        /// sort data date by day
        /// </summary>
        /// <param name="data">out going string data</param>
        /// <returns>a string contains data creat time by day</returns>
        public string getDataByDay(out String data)
        {
            data = this.data;
            return time.ToString("MM/dd/yyyy");
        }
        /// <summary>
        /// outgoing data (string)
        /// sort data date by Hour
        /// </summary>
        /// <param name="data">out going string data</param>
        /// <returns>a string contains data creat time by Hour</returns>
        public string getDataByHour(out String data)
        {
            data = this.data;
            return time.ToString("MM/dd/yyyy/HH");
        }
        /// <summary>
        /// outgoing data (string)
        /// sort data date by Hour
        /// </summary>
        /// <param name="data">out going string data</param>
        /// <returns>a string contains data creat time by Hour</returns>
        public string getDataByMinutes(out String data)
        {
            data = this.data;
            return time.ToString("MM/dd/yyyy/HH:mm");
        }
        /// <summary>
        /// outgoing data (string)
        /// sort data date by Seconds
        /// </summary>
        /// <param name="data">out going string data</param>
        /// <returns>a string contains data creat time by Seconds</returns>
        public string getDataBySeconds(out String data)
        {
            data = this.data;
            return time.ToString("MM/dd/yyyy/HH:mm:ss");
        }
        /// <summary>
        /// return date time
        /// </summary>
        /// <returns>datetime</returns>
        public DateTime getDateTime()
        {
            return time;
        }
        public string getUnix(out string data)
        {
            Int32 unixTimestamp = (Int32)(time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            data = this.data;
            return unixTimestamp.ToString();
        }
        public string getData()
        {
            return data;
        }
    }
}
