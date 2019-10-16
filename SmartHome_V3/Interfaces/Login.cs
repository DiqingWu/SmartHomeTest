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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void UxLogin_Click(object sender, EventArgs e)
        {
            if(SmartHomeController._accountManager.Login(uxLoginAccount.Text, uxLoginPassword.Text))
            {
                MessageBox.Show("Login successful.");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (SmartHomeController._accountManager.FindPassByAccount(uxLoginAccount.Text))
            {
                MessageBox.Show("An email contains your password send to email: "+ SmartHomeController._accountManager.GetAccountEmail(uxLoginAccount.Text));
            }
            else
            {
                MessageBox.Show("Your Account is not exist or not entered correct.");
            }
        }
    }
}
