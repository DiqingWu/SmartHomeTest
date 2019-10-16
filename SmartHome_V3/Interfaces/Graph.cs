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
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartHome_V3
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }
        public void SetTitle(string s)
        {
            uxChart.Text = s;
        }
        public void AddSinglePointRealTime(string series, double nowtime, float y)
        {
            Invoke(new Action(() =>
            {
                uxChart.Series[series].Points.AddXY(nowtime, y);
                uxChart.ChartAreas[0].AxisX.Title = "Time: " + DateTime.Now;
            }));
        }
        public void AddSinglePointRealTime(string series, double nowtime, int y)
        {

            Invoke(new Action(() =>
            {
                uxChart.Series[series].Points.AddXY(nowtime, y);
                uxChart.ChartAreas[0].AxisX.Title = "Time: " + DateTime.Now;
            }));
        }
        /// <summary>
        /// Add point not real time
        /// </summary>
        /// <param name="series"></param>
        /// <param name="d"></param>
        /// <param name="f"></param>
        public void AddPoints(string series, double d, float f)
        {
            uxChart.Series[series].Points.AddXY(d, f);
        }
        public void AddPoints(string series, DateTime d, float f)
        {
            uxChart.Series[series].Points.AddXY(d, f);
        }
        public void AddPoints(string series1, string series2, double d, float f1, float f2)
        {
            uxChart.Series[series1].Points.AddXY(d, f1);
            uxChart.Series[series2].Points.AddXY(d, f2);
        }
        public void AddPoints(string series1, string series2, DateTime d, float f1, float f2)
        {
            uxChart.Series[series1].Points.AddXY(d, f1);
            uxChart.Series[series2].Points.AddXY(d, f2);
        }
        public void AddSeries(string name, bool primary, int size, string type, string color)
        {
            try
            {
                System.Windows.Forms.DataVisualization.Charting.Chart current = uxChart;
                current.Series.Add(name);
                current.Series[name].LegendText = name;
                if (!primary)
                {
                    current.Series[name].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                }
                switch (type)
                {
                    case "line":
                        current.Series[name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        break;
                    case "stepline":
                        current.Series[name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                        break;
                }
                current.Series[name].BorderWidth = size;
                current.Series[name].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                switch (color)
                {
                    case "red"://ex: red
                        current.Series[name].Color = Color.Red;
                        break;
                    case "yellow":
                        current.Series[name].Color = Color.Yellow;
                        break;
                    case "green":
                        current.Series[name].Color = Color.Green;
                        break;
                    case "blue":
                        current.Series[name].Color = Color.Blue;
                        break;
                    case "orange":
                        current.Series[name].Color = Color.Orange;
                        break;
                    case "black":
                        current.Series[name].Color = Color.Black;
                        break;
                    case "silver":
                        current.Series[name].Color = Color.Silver;
                        break;
                    default:// default if it is not valid
                        current.Series[name].Color = Color.Purple;
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void adjustXAxis(double interval, int min, int max, string title)
        {
            uxChart.ChartAreas[0].AxisX.Interval = interval;
            uxChart.ChartAreas[0].AxisX.Minimum = min;
            uxChart.ChartAreas[0].AxisX.Maximum = max;
            uxChart.ChartAreas[0].AxisX.Title = title;
        }
        public void adjustXAxisRealTime(double interval, int min, int max)
        {
            Invoke(new Action(() =>
            {
                uxChart.ChartAreas[0].AxisX.Interval = interval;
                uxChart.ChartAreas[0].AxisX.Minimum = min;
                uxChart.ChartAreas[0].AxisX.Maximum = max;
            }));
        }
        public void adjustYAxis(int interval, int min, int max, string title)
        {

            uxChart.ChartAreas[0].AxisY.Interval = interval;
            uxChart.ChartAreas[0].AxisY.Minimum = min;
            uxChart.ChartAreas[0].AxisY.Maximum = max;
            uxChart.ChartAreas[0].AxisY.Title = title;
        }
        public void adjustYAxisRealTime(int interval, int min, int max)
        {
            Invoke(new Action(() =>
            {
                uxChart.ChartAreas[0].AxisY.Interval = interval;
                uxChart.ChartAreas[0].AxisY.Minimum = min;
                uxChart.ChartAreas[0].AxisY.Maximum = max;
            }));
        }
        public void adjustY2Axis(int interval, int min, int max, string title)
        {
            uxChart.ChartAreas[0].AxisY2.Interval = interval;
            uxChart.ChartAreas[0].AxisY2.Minimum = min;
            uxChart.ChartAreas[0].AxisY2.Maximum = max;
            uxChart.ChartAreas[0].AxisY2.Title = title;
        }
        public void adjustY2AxisRealTime(int interval, int min, int max)
        {
            Invoke(new Action(() =>
            {
                uxChart.ChartAreas[0].AxisY2.Interval = interval;
                uxChart.ChartAreas[0].AxisY2.Minimum = min;
                uxChart.ChartAreas[0].AxisY2.Maximum = max;
            }));
        }

        /// <summary>
        /// If the chart size changed, the plot changed followed the size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartForm_SizeChanged(object sender, EventArgs e)
        {
            int width = this.Size.Width;
            int height = this.Size.Height;
            uxChart.Size = new Size(width * 14 / 15, height * 13 / 16);
            uxChart.Location = new Point(21, 27);
            uxChart.Legends[0].Font = new Font("Arial", (Width + Height) / 150);
            uxChart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", (Width + Height) / 150);
            uxChart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", (Width + Height) / 150);
            uxChart.ChartAreas[0].AxisY2.TitleFont = new Font("Arial", (Width + Height) / 150);
        }
        public void FormClean(string str)
        {
            Invoke(new Action(() =>
            {
                uxChart.Series[str].Points.Clear();
            }));
        }
    }
}
