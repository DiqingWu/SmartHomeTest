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
    public partial class AccountAnalyze : Form
    {
        public AccountAnalyze()
        {
            InitializeComponent();
            LoadAccounts();

            uxAccount.SelectedIndexChanged += UxAccount_SelectedIndexChanged1;
            //uxAccount.
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SmartHomeController._guiManager.OpenAccountLogin();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SmartHomeController._guiManager.OpenAccountRegister();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
           /* if (SmartHomeController._accountManager.VerifyEmail(uxUsername.Text, uxVerifyCode.Text))
            {
                MessageBox.Show("Account Registed.");
            }*/
            LoadAccounts();
        }

        public void LoadAccounts()
        {
            uxAccount.DataSource = SmartHomeController._accountManager.GetAllAccounts();
        }

        public void UxAccount_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //MessageBox.Show(SmartHomeController._accountManager.GetAccountInfo(uxAccount.SelectedItem.ToString()).Email);
            User u = SmartHomeController._accountManager.GetAccountInfo(uxAccount.SelectedItem.ToString());
            uxPass.Text = u.GetPassword();
            uxEmail.Text = u.Email;
            uxStatus.Text = Convert.ToString(u.GetStatus());
            uxHomes.DataSource = u.LinkedHomes;
            uxLightSta.Text = "";
            uxHumi.Text = "";
            uxLumen.Text = "";
            uxTemp.Text = "";
            uxMotion.Text = "";

        }

        private void UxHomes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(uxHomes.SelectedItem.ToString() != "")
            {
                //uxFunction.DataSource = SmartHomeController._databaseController.database.homes[uxHomes.SelectedItem.ToString()]._functionList;
                Room r = SmartHomeController._databaseController.database.homes[uxHomes.SelectedItem.ToString()]._currentRoom;
                uxLightSta.Text = Convert.ToString(r.light1);
                uxHumi.Text = Convert.ToString(r.humi);
                uxLumen.Text = Convert.ToString(r.lumen);
                uxTemp.Text = Convert.ToString(r.temp);
                uxMotion.Text = Convert.ToString(r.motion);
            }
            
        }
    }
}
