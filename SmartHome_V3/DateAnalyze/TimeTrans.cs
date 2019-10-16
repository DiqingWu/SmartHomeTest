using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    public class TimeTrans
    {
        public TimeTrans()
        {

        }
        public double[] ListHours(List<DateTime> list)
        {
            List<double> temp = new List<double>();
            foreach (DateTime d in list)
            {
                temp.Add(HourTrans(d));
            }
            return temp.ToArray();
        }
        public double[] ListDays(List<DateTime> list)
        {
            List<double> temp = new List<double>();
            foreach (DateTime d in list)
            {
                temp.Add(DayTrans(d));
            }
            return temp.ToArray();
        }
        public double[] ListMins(List<DateTime> list)
        {
            List<double> temp = new List<double>();
            foreach (DateTime d in list)
            {
                temp.Add(MiniTrans(d));
            }
            return temp.ToArray();
        }
        public double HourTrans(DateTime d)
        {
            return Convert.ToInt32(d.Hour.ToString()) + Convert.ToInt32(d.Minute.ToString()) / 60.00;
        }
        public double MiniTrans(DateTime d)
        {
            return Convert.ToInt32(d.Minute.ToString()) + Convert.ToInt32(d.Second.ToString()) / 60.00;
        }
        public double DayTrans(DateTime d)
        {
            return Convert.ToInt32(d.Day.ToString()) + Convert.ToInt32(d.Hour.ToString()) / 60.00;
        }
    }
}
