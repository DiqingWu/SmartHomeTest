
//add by xuebo
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SmartHome_V3
{
    public partial class DataAnalyze : Form
    {
        
        DataTable dataTable;
        BindingList<string> homeip;
        BindingList<string> deviceid;
        BindingList<string> time;
        BindingList<string> data;
        int newGraphs = 0;
        Graph pp;

        // Add by Xuebo
        bool DeviceGraph = false;
        int timeinter = 0;
        TimeTrans trans = new TimeTrans();
        List<double> realtime = new List<double>();
        bool dayvmodel = false;
        bool RealTimeSwitcher = false;
        DrawGraph drawGraph = new DrawGraph();
        int maxlight = 0;
        int minlight = 100;
        Dictionary<string, int> maxpower;
        string CurrentDevice;

        public DataAnalyze()
        {
            InitializeComponent();
            ViewBox_Initial();
            uxRealTime.CheckStateChanged += uxRealTime_CheckStateChanged;
            uxDaySelected.CheckStateChanged += uxTimeSelected_CheckStateChanged;

            uxDateEnd.MaxDate = DateTime.Now;
            uxDateStart.MaxDate = DateTime.Now;
            uxDateEnd.Enabled = false;
            uxDateStart.Enabled = false;
            maxpower = new Dictionary<string, int>();
            
        }
        public void AddMessageRealTime(string st)
        {
            if (RealTimeSwitcher == true)
            {
                Invoke(new Action(() =>
                {
                    string[] temp;
                    
                    if (SmartHomeController._functionController._functionManager.ValidJson(st))
                    {
                        temp = SmartHomeController._functionController._functionManager.DecripeJson(st);
                    }
                    else
                    {
                        MessageBox.Show("Input is not JSON.");
                        return;
                    }
                    try
                    {
                        string[] tempdevice = temp[1].Split(',');
                        tempdevice = tempdevice[0].Split(' ');

                        //Temperature: 25.0,Humility: 40.0
                        temp = temp[2].Split(',');
                        string[] values;
                        values = temp[0].Split(':');
                        double nowtime = trans.MiniTrans(DateTime.Now);
                        if (nowtime < 0.2)
                        {
                            realtime.Clear();
                            if (tempdevice[0] == "sensor" && DeviceGraph == false)
                            {
                                pp.FormClean("Temperature");
                                pp.FormClean("Humility");
                                pp.FormClean("Light");
                                pp.FormClean("Motion");
                                
                            }
                            else if (tempdevice[0] == CurrentDevice && DeviceGraph == true)
                            {
                                pp.FormClean("Status");
                                pp.FormClean("Power");
                            }
                            
                        }
                        realtime.Add(nowtime);
                        if (realtime[0] < (nowtime - timeinter))
                            realtime.RemoveAt(0);
                        if (tempdevice[0] == "sensor" && DeviceGraph == false)
                        {
                            pp.AddSinglePointRealTime("Temperature", nowtime, Convert.ToSingle(values[1]));
                            values = temp[1].Split(':');
                            pp.AddSinglePointRealTime("Humility", nowtime, Convert.ToSingle(values[1]));
                            values = temp[2].Split(':');

                            //Invoke the light 
                            float lightValue = Convert.ToSingle(values[1]);
                            if (maxlight < lightValue) maxlight = Convert.ToInt32(lightValue);
                            if (minlight > lightValue) minlight = Convert.ToInt32(lightValue);
                            pp.AddSinglePointRealTime("Light", nowtime, Convert.ToSingle(lightValue));

                            int interval = ((int)Math.Round((maxlight - minlight) / 10.0)) * 10;
                            if (interval >= 400) interval = 50;
                            else if (interval >= 50) interval = 5;
                            else interval = 1;
                            pp.adjustY2AxisRealTime(interval/20, ((int)((minlight - 5) / 10)) * 10, ((int)((maxlight + 10) / 10)) * 10);


                            values = temp[3].Split(':');
                            pp.AddSinglePointRealTime("Motion", nowtime, Convert.ToSingle(values[1]) * 25);

                        }
                        else if (tempdevice[0] == CurrentDevice && DeviceGraph == true)
                        {
                            
                            int sta = 0;
                            if (values[1] == "1") sta = 1;
                            pp.AddSinglePointRealTime("Status", nowtime, Convert.ToSingle(sta));
                            values = temp[1].Split(':');
                            int interval = 0;
                            if (maxpower[CurrentDevice] >= 400) interval = 50;
                            else if (maxpower[CurrentDevice] >= 50) interval = 5;
                            else interval = 1;
                            pp.AddSinglePointRealTime("Power", nowtime, Convert.ToSingle(values[1]));
                            pp.adjustYAxisRealTime(interval, 0, ((int)((maxpower[CurrentDevice] + 10) / 10)) * 10);
                        }
                        pp.adjustXAxisRealTime(1, Convert.ToInt32(realtime.ToArray()[0] - 0.5), Convert.ToInt32(realtime.ToArray()[realtime.ToArray().Length - 1] + 2));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }));
            }

        }
        private void ViewBox_Initial()
        {
            homeip = toBindingList(SmartHomeController._databaseController.database.GetHomeList());
            uxView.DataSource = homeip;
            homeip.AllowNew = true;
            homeip.AllowRemove = true;

            uxView1.DataSource = null;
            uxView2.DataSource = null;
            uxView3.DataSource = null;
            uxView.SelectedIndexChanged += SelectedIndexChanged1;
            uxView1.SelectedIndexChanged += SelectedIndexChanged2;
            //uxView2.SelectedIndexChanged += SelectedIndexChanged3;
            //uxView3.SelectedIndexChanged += SelectedIndexChanged4;


            homeip.ResetBindings();

            //below code shows all data from database
            //showDataBase(SmartHomeController.dbc.GetDataTable());
        }
        public void showDataBase(DataTable temptable)
        {
            dataTable = temptable;
            uxView.DisplayMember = "homeip";
            uxView.ValueMember = "Id";
            uxView.DataSource = dataTable;

            uxView1.DisplayMember = "deviceip";
            uxView1.ValueMember = "Id";
            uxView1.DataSource = dataTable;

            uxView2.DisplayMember = "time";
            uxView2.ValueMember = "Id";
            uxView2.DataSource = dataTable;

            uxView3.DisplayMember = "data";
            uxView3.ValueMember = "Id";
            uxView3.DataSource = dataTable;
        }
        /// <summary>
        /// new data message from 
        /// </summary>
        public void NewMessage(string st)
        {
            AddMessageRealTime(st);
        }
        private void SelectedIndexChanged1(object sender, EventArgs e)
        {
            deviceid = toBindingList(SmartHomeController._databaseController.database.GetDevices(uxView.SelectedItem.ToString()));
            uxView1.DataSource = deviceid;
            deviceid.AllowNew = true;
            deviceid.AllowRemove = true;
            deviceid.ResetBindings();
            uxView2.DataSource = null;
            uxView3.DataSource = null;
        }
        private void SelectedIndexChanged2(object sender, EventArgs e)
        {

            //MessageBox.Show("Selected: " + uxView1.SelectedItem.ToString());
            List<Data> temp = SmartHomeController._databaseController.database.GetAllData(uxView.SelectedItem.ToString(), uxView1.SelectedItem.ToString());
            time = new BindingList<string>();
            time.AllowNew = true;
            time.AllowRemove = true;
            data = new BindingList<String>();
            data.AllowNew = true;
            data.AllowRemove = true;
            string line;
            foreach (Data d in temp)
            {
                time.Add(d.getDataBySeconds(out line));
                data.Add(line);
            }
            uxView2.DataSource = time;
            uxView3.DataSource = data;
            data.ResetBindings();
            time.ResetBindings();
            try
            {
                uxDateEnd.MinDate = SmartHomeController._databaseController.database.GetFirstDate(uxView.SelectedItem.ToString(), uxView1.SelectedItem.ToString());
                uxDateStart.MinDate = SmartHomeController._databaseController.database.GetFirstDate(uxView.SelectedItem.ToString(), uxView1.SelectedItem.ToString());
                uxDateEnd.Enabled = true;
                uxDateStart.Enabled = true;
            }
            catch (EntryPointNotFoundException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// convert list to binding list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private BindingList<string> toBindingList(List<string> list)
        {
            BindingList<string> temp = new BindingList<string>();
            if (list == null)
                return null;
            foreach (string s in list)
            {
                temp.Add(s);
            }
            return temp;
        }

        private void UxGraph_Click(object sender, EventArgs e)
        {
            try
            {
                pp = new Graph();
                //add all settings
                if (uxRealTime.Checked == true)
                {
                    if (newGraphs == 0)
                    {
                        try
                        {
                            timeinter = Convert.ToInt32(uxRealTimeCount.Text);
                            List<Data> temp = DataSort(SmartHomeController._databaseController.database.GetAllData(uxView.SelectedItem.ToString(), uxView1.SelectedItem.ToString()), timeinter);
                            string[] device = uxView1.SelectedItem.ToString().Split(' ');
                            RealTimeSwitcher = true;
                            dayvmodel = true;
                            uxGraph.Enabled = false;
                            if (device[0] == "sensor")
                            {
                                realtime = drawGraph.GraphSensor(dayvmodel, RealTimeSwitcher, timeinter, realtime, temp, ref pp, ref minlight , ref maxlight);
                                DeviceGraph = false;
                            }
                            else
                            {
                                maxpower.Add(device[0], 0);
                                maxpower.TryGetValue(device[0], out int max);//Initial Max power
                                CurrentDevice = device[0];
                                DeviceGraph = true;
                                realtime = drawGraph.GraphDevice(CurrentDevice, dayvmodel, RealTimeSwitcher, timeinter, realtime, temp, ref pp, ref max);
                            }
                        }

                        catch (FormatException)
                        {
                            MessageBox.Show("Please enter integer in the box");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please close all graphs before start realtime graphing.");
                    }

                }
                else
                {
                    try
                    {
                        DateTime start = uxDateStart.Value;
                        DateTime end = uxDateEnd.Value;
                        if (start.Day == end.Day) dayvmodel = true;
                        else dayvmodel = false;
                        List<Data> temp = SmartHomeController._databaseController.database.GetDataFromDays(uxView.SelectedItem.ToString(), uxView1.SelectedItem.ToString(), start, end);
                        if (temp != null)
                        {
                            string[] device = uxView1.SelectedItem.ToString().Split(' ');
                            if (device[0] == "sensor")
                            {
                                drawGraph.GraphSensor(dayvmodel, RealTimeSwitcher, timeinter, realtime, temp, ref pp, ref minlight, ref maxlight);
                            }
                            else 
                            {
                                maxpower.Add(device[0], 0);
                                maxpower.TryGetValue(device[0], out int max);//Initial Max power
                                drawGraph.GraphDevice(device[0], dayvmodel, RealTimeSwitcher, timeinter, realtime, temp, ref pp, ref max);
                            }
                        }
                        else MessageBox.Show("There is no data during that days.");
                    }

                    catch (FormatException)
                    {
                        MessageBox.Show("Please enter integer in the box");
                    }
                }
            }
            catch (Exception ex)
            {
                // log errors
                MessageBox.Show(ex.ToString());
            }
            try
            {
                newGraphs++;
                Invoke(new Action(() =>
                {
                    Thread thread = new Thread(new ThreadStart(OpenNewGraph));
                    thread.Start();
                }));
            }
            catch (Exception)
            {

            }

        }
        private List<Data> DataSort(List<Data> list, int num)
        {
            int tempstartday = DateTime.Now.Day;
            int tempstarthour = DateTime.Now.Hour;
            List<Data> temp = new List<Data>();
            int count = list.Count;
            for (int i = count - num * 10; i < count; i++)
            {
                if (list[i].getDateTime().Day == tempstartday)
                {
                    if(list[i].getDateTime().Hour == tempstarthour)
                        temp.Add(list[i]);
                }
            }
            return temp;
        }

        private void UxFunctionC_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// create new thread
        /// </summary>
        public void OpenNewGraph()
        {
            //pp = new Graph();
            Application.Run(pp);
            Invoke(new Action(() =>
            {
                RealTimeSwitcher = false;
                uxGraph.Enabled = true;
                newGraphs--;
            }));
        }
        public void uxRealTime_CheckStateChanged(object sender, EventArgs e)
        {
            if (uxRealTime.Checked == true)
            {
                uxDaySelected.Checked = false;
                uxDaySelected.Enabled = false;
            }
            else
            {
                uxDaySelected.Checked = false;
                uxDaySelected.Enabled = true;
            }

        }
        public void uxTimeSelected_CheckStateChanged(object sender, EventArgs e)
        {
            if (uxDaySelected.Checked == true)
            {
                uxRealTime.Checked = false;
                uxRealTime.Enabled = false;
            }
            else
            {
                uxRealTime.Checked = false;
                uxRealTime.Enabled = true;
            }

        }
    }
}
