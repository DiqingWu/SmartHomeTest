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
    public partial class Register : Form
    {
        int state = 0;
        public Register()
        {
            InitializeComponent();
            uxVerify.Enabled = false;
        }

        private void UxButton_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case 0:
                    try
                    {
                        if (SmartHomeController._accountManager.AddAccount(uxRegAccount.Text, uxRegPassword.Text, uxRegEmail.Text))
                        {
                            state = 1;
                            uxButton.Text = "Verify";
                            uxRegAccount.Enabled = false;
                            uxRegEmail.Enabled = false;
                            uxRegPassword.Enabled = false;
                            uxVerify.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Account exist already.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Email doesnt enter correct \n" + ex.ToString() );
                    }
                    
                    break;
                case 1:
                    if (SmartHomeController._accountManager.VerifyEmail(uxRegAccount.Text,uxVerify.Text))
                    {
                        MessageBox.Show("Account Registed.");
                    }
                    break;
                default:
                    break;
            }
            
        }
    }
}
