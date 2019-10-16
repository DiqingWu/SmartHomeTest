using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    public class Room
    {
        public float humi=0;
        public float lumen=0;
        public float temp=0;
        public bool light1=false;
        public bool motion=false;
        public bool AutoAC = false;
        private AcAndroid _ac;
        public int PreTemp { get; set; }

        string homeid ;
        public Room(string homeid)
        {
            this.homeid = homeid;
            humi = 0;
            lumen = 0;
            temp = 0;
            light1 = false;
            PreTemp = 0;
        }
        public void updateStatus(string data)
        {

            string[] values;
            string[] value;
            values = data.Split(',');

            for (int i = 0; i < values.Length; i++)
            {
                value = values[i].Split(':');
                switch (value[0])
                {
                    case "Status":
                        if (value[1] != "Unknown")
                        {
                            if (value[1] != "on")
                            {
                                light1 = true;
                            }
                            else
                            {
                                light1 = false;
                            }
                        }
                        break;
                    case "Light":
                        if (value[1] != "Unknown")
                        {
                            lumen = Convert.ToSingle(value[1]);
                        }
                        break;
                    case "Humility":
                        if (value[1] != "Unknown")
                        {
                            humi = Convert.ToSingle(value[1]);
                        }
                        break;
                    case "Humidity":
                        if (value[1] != "Unknown")
                        {
                            humi = Convert.ToSingle(value[1]);
                        }
                        break;
                    case "Temperature":
                        if (value[1] != "Unknown")
                        {
                            temp = Convert.ToSingle(value[1]);
                        }
                        break;
                    case "Current":
                        if (value[1] != "Unknown")
                        {
                            throw new NotImplementedException();
                        }
                        break;
                    case "Motion":
                        if (value[1] != "Unknown")
                        {
                            if (value[1] == "1")
                            {
                                motion = true;
                            }
                            else
                            {
                                motion = false;
                            }

                        }
                        break;
                    default:
                        break;
                }

            }

        }
        public bool ACinit()
        {
            if (AutoAC)
            {
                return false;
            }
            AutoAC = true;
            _ac = new AcAndroid(homeid);
            return true;
        }
        public void RunAC()
        {
            _ac.UpdateInfo();
        }
        public void SetPreferedTemp(int pretemp)
        {
            PreTemp = pretemp;
        }
    }
}
