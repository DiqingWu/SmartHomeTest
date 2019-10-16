/* Xuebo Liu
 * Draw the graph with the given datas. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHome_V3
{
    public class DrawGraph
    {
        //Create the variable for the conditions.
        private bool dayvmodel;
        private bool RealTimeSwitcher;
        private TimeTrans trans;
        private int timeinter;
        private List<double> realtime = new List<double>();
           //Construct does nothing
        public DrawGraph()
        {
            trans = new TimeTrans();
        }
        /// <summary>
        /// Put the daymodel, realtimeswitch, timeinter, list,datas in 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="real"></param>
        /// <param name="tinter"></param>
        /// <param name="list"></param>
        /// <param name="datas"></param>
        /// <param name="pp"></param>
        public List<double> GraphSensor(bool day, bool real, int tinter, List<double> list, List<Data> datas, ref Graph pp,ref int minlight,ref int maxlight)
        {
            dayvmodel = day;
            RealTimeSwitcher = real;
            timeinter = tinter;
            realtime = list;
            string[] values;
            string[] value;
            string line;
            List<DateTime> datetime = new List<DateTime>();

            int maxtemp = 0;
            int maxhumi = 0;
            int mintemp = 100;
            int minhumi = 100;

            float motionValue = 0;
            float lightValue = 0;
            float tempValue = 0;
            float humiValue = 0;
            List<double> time = new List<double>();

            pp.Text = "Temperature, Humidity and Light Sensor";
            pp.AddSeries("Temperature", true, 3, "line", "red");
            pp.AddSeries("Humility", true, 3, "line", "green");//  add points
            pp.AddSeries("Motion", true, 3, "stepline", "orange");
            pp.AddSeries("Light", false, 3, "line", "blue");

            foreach (Data d in datas)
            {
                // { "Device": "sensor 1", "Data": "Temperature:77.0,Humility:44.0,Light:95.0,Motion:0.0", "ID": "xuebo"}

                d.getDataByYear(out line);
                values = line.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    value = values[i].Split(':');
                    switch (value[0])
                    {
                        case "Temperature":
                            if (value[0] != "Unknown")
                            {

                                tempValue = Convert.ToSingle(value[1]);
                                if (maxtemp < tempValue) maxtemp = Convert.ToInt32(tempValue);
                                if (mintemp > tempValue) mintemp = Convert.ToInt32(tempValue);
                            }
                            break;
                        case "Humility":
                            if (value[0] != "Unknown")
                            {
                                humiValue = Convert.ToSingle(value[1]);
                                if (maxhumi < humiValue) maxtemp = Convert.ToInt32(maxhumi);
                                if (minhumi > humiValue) minhumi = Convert.ToInt32(humiValue);
                            }
                            break;
                        case "Motion":
                            if (value[0] != "Unknown")
                            {
                                motionValue = Convert.ToSingle(value[1]) * 25;

                            }
                            break;
                        case "Light":
                            if (value[0] != "Unknown")
                            {
                                lightValue = Convert.ToSingle(value[1]);
                                if (maxlight < lightValue) maxlight = Convert.ToInt32(lightValue);
                                if (minlight > lightValue) minlight = Convert.ToInt32(lightValue);
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (dayvmodel == true)
                {
                    double temptime = 0;
                    if (RealTimeSwitcher == true && timeinter != 0)
                    {
                        temptime = trans.MiniTrans(d.getDateTime());
                    }
                    else
                    {
                        temptime = trans.HourTrans(d.getDateTime());
                    }
                    if (time.Count == 0)
                    {
                        if (RealTimeSwitcher) realtime.Add(temptime);
                        time.Add(temptime);
                        pp.AddPoints("Temperature", "Humility", temptime, tempValue, humiValue);
                        pp.AddPoints("Motion", temptime, motionValue);
                        pp.AddPoints("Light", temptime, lightValue);
                    }
                    else if (temptime >= Convert.ToSingle(time[time.Count - 1]))
                    {
                        if (RealTimeSwitcher) realtime.Add(temptime);
                        time.Add(temptime);
                        pp.AddPoints("Temperature", "Humility", temptime, tempValue, humiValue);
                        pp.AddPoints("Motion", temptime, motionValue);
                        pp.AddPoints("Light", temptime, lightValue);
                    }

                }
                else
                {
                    pp.AddPoints("Temperature", d.getDateTime(), tempValue);
                    pp.AddPoints("Humility", d.getDateTime(), humiValue);
                    pp.AddPoints("Motion", d.getDateTime(), motionValue);
                    pp.AddPoints("Light", d.getDateTime(), lightValue);
                    datetime.Add(d.getDateTime());
                }

            }
            pp.adjustYAxis(10, 0, 100, "Temperature(F) & Humility(%)");
            pp.adjustY2Axis(20, ((int)((minlight - 5) / 10)) * 10, ((int)((maxlight + 10) / 10)) * 10, "Lumen(lm)");
            if (time.Count == 0 && datetime.Count == 0)
            {
                MessageBox.Show("There is no data at that days.");
            }
            else
            {
                if (RealTimeSwitcher)
                {
                    pp.adjustXAxis(1, Convert.ToInt32(time.ToArray()[0]), Convert.ToInt32(time.ToArray()[time.ToArray().Length - 1] + 5), "Times(Hour)");
                }
                else if (dayvmodel == true)
                    pp.adjustXAxis(0.25, Convert.ToInt32(time.ToArray()[0] - 0.5), Convert.ToInt32(time.ToArray()[time.ToArray().Length - 1] + 0.5), "Times(Hour)");
            }
            return realtime;
        }

        //Graph for devices.
        public List<double> GraphDevice(string title ,bool day, bool real, int tinter, List<double> list, List<Data> datas, ref Graph pp, ref int maxpower)
        {
            dayvmodel = day;
            RealTimeSwitcher = real;
            timeinter = tinter;
            realtime = list;
            //{"Device": "heater 1", "Data": "Status:0,Power:0.0", "ID": "xuebo"}
            string[] values;
            string[] value;
            List<DateTime> datetime = new List<DateTime>();
            List<double> time = new List<double>();

            string line;
            int statusnum = 0;
            float power = 0;

            pp.Text = title;//Set the title to the graph
            pp.AddSeries("Power", true, 2, "line", "blue");
            pp.AddSeries("Status", false, 3, "stepline", "orange");

            foreach (Data d in datas)
            {
                d.getDataByYear(out line);
                values = line.Split(',');

                for (int i = 0; i < values.Length; i++)
                {
                    value = values[i].Split(':');
                    switch (value[0])
                    {
                        case "Status":
                            if (value[0] != "Unknown")
                            {
                                if (value[1] == "1" || value[1] == "on")
                                {
                                    statusnum = 1;
                                }
                                else
                                {
                                    statusnum = 0;
                                }

                            }
                            break;
                        case "Power":
                            if (value[0] != "Unknown")
                            {
                                power = Convert.ToSingle(value[1]);
                                if (maxpower < power) maxpower = Convert.ToInt32(power);
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (dayvmodel == true)
                {
                    double temptime = 0;
                    if (RealTimeSwitcher == true && timeinter != 0)
                    {
                        temptime = trans.MiniTrans(d.getDateTime());
                    }
                    else
                    {
                        temptime = trans.HourTrans(d.getDateTime());
                    }
                    if (time.Count == 0)
                    {
                        if (RealTimeSwitcher) realtime.Add(temptime);
                        time.Add(temptime);
                        pp.AddPoints("Power", "Status", temptime, power, statusnum);
                    }
                    else if (temptime >= Convert.ToSingle(time[time.Count - 1]))
                    {
                        if (RealTimeSwitcher) realtime.Add(temptime);
                        time.Add(temptime);
                        pp.AddPoints("Power", "Status", temptime, power, statusnum);
                    }
                }
                else
                {
                    pp.AddPoints("Power", d.getDateTime(), power);
                    pp.AddPoints("Status", d.getDateTime(), statusnum);
                    datetime.Add(d.getDateTime());
                }

            }
            int interval = 0;
            if (maxpower >= 400) interval = 50;
            else if (maxpower >= 50) interval = 10;
            else if (maxpower >= 10) interval = 5;
            else interval = 2;
            pp.adjustYAxis(interval, 0, ((int)((maxpower + 10) / 10)) * 10, "Watts(W)");
            pp.adjustY2Axis(1, 0, 4, "Status(on/off)");
            if (time.Count == 0 && datetime.Count == 0)
            {
                MessageBox.Show("There is no data at that days.");
            }
            else
            {
                if (RealTimeSwitcher)
                {
                    pp.adjustXAxis(1, Convert.ToInt32(realtime.ToArray()[0] - 0.5), Convert.ToInt32(realtime.ToArray()[realtime.ToArray().Length - 1] + 2), "Times(Minute)");
                }
                else if (dayvmodel == true)
                    pp.adjustXAxis(0.25, Convert.ToInt32(time.ToArray()[0] - 0.5), Convert.ToInt32(time.ToArray()[time.ToArray().Length - 1] + 0.5), "Times(Hour)");
            }
            return realtime;
        }
       
    }
}
