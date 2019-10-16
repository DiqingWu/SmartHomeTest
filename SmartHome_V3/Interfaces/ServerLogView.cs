using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHome_V3
{
    public partial class ServerLogView : Form
    {
        public ServerLogView(List<string> list)
        {
            InitializeComponent();
            foreach(string line in list)
            {
                uxLog.Text = line + Environment.NewLine + uxLog.Text; 
            }
        }
        public void AddMessage(string line)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    uxLog.Text = line + Environment.NewLine + uxLog.Text;
                }));
            }
            catch (Exception)
            {

            }


        }
    }
}
