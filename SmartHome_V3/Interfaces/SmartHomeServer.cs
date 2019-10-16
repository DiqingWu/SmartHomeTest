using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SmartHome_V3
{
    public partial class SmartHomeServer : Form 
    {
        public SmartHomeServer()
        {
            InitializeComponent();
            
            uxMqttOff.MouseClick += UxMqttoff_Click;
            uxMqttOn.MouseClick += UxMqttOn_Click;
            uxWSOff.MouseClick += UxWSOff_Click;
            uxWSOn.MouseClick += UxWSOn_Click;

            this.uxMqttStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.red;
            this.uxWsStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.red;
        }
        private void UxMqttoff_Click(object sender, EventArgs e)
        {
            uxMqttOff.Checked = true;
            uxMqttOn.Checked = false;
        }

        /// <summary>
        /// Mqtt server start.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxMqttOn_Click(object sender, EventArgs e)
        {
            uxMqttOff.Checked = false;
            uxMqttOn.Checked = true;
        }
        private void UxWSOff_Click(object sender, EventArgs e)
        {
            uxWSOn.Checked = false;
            uxWSOff.Checked = true;
        }
        private void UxWSOn_Click(object sender, EventArgs e)
        {
            uxWSOff.Checked = false;
            uxWSOn.Checked = true;
        }

        /// <summary>
        /// server log button. creat a new thread to view server log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxServerlog_Click_1(object sender, EventArgs e)
        {
            SmartHomeController._guiManager.OpenServerLog();
    }
        /// <summary>
        /// open a new form for database analyze//add by xuebo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxDatabase_Click_1(object sender, EventArgs e)
        {
            SmartHomeController._guiManager.OpenDataAnalyze();
        }
        

        private void UxFunctionC_Click_1(object sender, EventArgs e)
        {
            SmartHomeController._guiManager.OpenFunction();
        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            SmartHomeController._guiManager.OpenAccountAnalyze();
        }

        private void UxMqttOn_CheckedChanged_1(object sender, EventArgs e)
        {
            if (uxMqttOn.Checked)
            {
                uxMqttOff.Checked = false;
                try
                {
                    uxMqttOff.Checked = false;
                    SmartHomeController.StartMQTT();
                    this.uxMqttStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.green;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    this.uxMqttStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.yellow;
                }
            }
            else
            {
                this.uxMqttStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.red;
            }
        }

        private void UxMqttOff_CheckedChanged(object sender, EventArgs e)
        {
            if (uxMqttOff.Checked)
            {
                try
                {

                    uxMqttOn.Checked = false;
                    SmartHomeController.CloseMQTT();
                    this.uxMqttStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.red;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    this.uxMqttStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.yellow;
                }
            }
            else
            {

                this.uxMqttStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.red;
            }
        }

        private void UxWSOn_CheckedChanged_1(object sender, EventArgs e)
        {
            if (uxWSOn.Checked)
            {
                try
                {
                    SmartHomeController.StartWS();
                    this.uxWsStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.green;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    this.uxWsStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.yellow;
                }
            }
            else
            {
                this.uxWsStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.red;
            }
        }

        private void UxWSOff_CheckedChanged_1(object sender, EventArgs e)
        {
            if (uxWSOff.Checked)
            {
                try
                {
                    SmartHomeController.CloseWS();
                    this.uxWsStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.red;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    this.uxWsStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.yellow;
                }
            }
            else
            {
                this.uxWsStatus.BackgroundImage = global::SmartHome_V3.Properties.Resources.red;
            }
        }
    }
}
