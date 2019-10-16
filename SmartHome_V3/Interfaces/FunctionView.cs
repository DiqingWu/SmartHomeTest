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
    public partial class FunctionView : Form
    {
        public FunctionView()
        {
            InitializeComponent();
            uxCheckList.CheckOnClick = true;
            string [] list = SmartHomeController._functionController._functionManager.GetFunctionList();
            uxCheckList.Items.AddRange(list);
            //string[] list = { "abc", "acb", "bcd" };
            for (int i = 0; i < list.Count(); i++)
            {
                bool check;
                SmartHomeController._functionController.TryGetValue(list[i], out check);
                if (check)
                {
                    //uxCheckList.Items[i] = true;
                    uxCheckList.SetItemChecked(i, true);
                }

            }
            uxCheckList.Click += CheckBox_Clicked;
        }
        public void CheckBox_Clicked(Object sender, EventArgs e)
        {
            int count = 0;
            foreach (string s in uxCheckList.Items)
            {
                if (!uxCheckList.GetItemChecked(count))
                {
                    SmartHomeController._functionController.MakeCheck(s);
                }
                else
                {
                    SmartHomeController._functionController.MakeUncheck(s);
                }
                count++;
            }
        }

    }
}
