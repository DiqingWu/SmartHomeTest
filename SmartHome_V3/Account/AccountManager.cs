using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SmartHome_V3
{
    public class AccountManager
    {

        public List<User> _users;
        public AccountManager()
        {
            _users = new List<User>();
            LoadDataTableForUser(SmartHomeController._databaseController._SQLmanager.GetDataTableAccount());
        }
        public bool Login(string username, string password)
        {
            int dump;
            if (TryGetIndex(username, out dump))
            {
                if (!_users[dump].GetPassword().Equals(password))
                {
                    return false;
                }
                _users[dump].ChangeFlagTrue();
                return true;
            }
            return false;
        }
        public bool Logout(string username)
        {
            // add login status into account status
            int dump;
            if (TryGetIndex(username, out dump))
            {
                _users[dump].ChangeFlagFalse();
                return true;
            }
            return false;

        }
        public bool linkAccount(string username, string password, string bases)
        {

            int dump;
            if (TryGetIndex(username, out dump))
            {
                if (_users[dump].GetStatus())
                {
                    _users[dump].LinkedHomes.Add(bases);
                    SmartHomeController._databaseController._SQLmanager.ChangeLine(username, "linkedbase", _users[dump].GetAllBase());
                    return true;
                }
                else
                {
                    return false;
                }


            }
            return false;
        }
        // add
        public bool AddAccount(string username, string password, string email)
        {
            User dump;
            if (TryGetAccount(username, out dump))
            {
                return false;
            }
            int ran = EmailSender.VerifyNumberGenerator();
            _users.Add(new User(username, password, email, ran));
            SmartHomeController._databaseController._SQLmanager.InsertAccount(username, password, email, ran);
            SmartHomeController._emailSender.SendEmail(email,ran);
            return true;
        }
        public string GetAccountEmail(string username)
        {
            User dump;
            if (TryGetAccount(username, out dump))
            {
                return dump.Email;
            }
            return "No such account";
        }
        public void LoadAccount(int id, string username, string password, string email, string linkedbase, string emailchecked)
        {
            _users.Add(new User(id, username, password, email, linkedbase, emailchecked));
        }
        // delete
        // insert
        // plus
        // change pass 
        public bool ChangePassword(string username, string password, string Newpassword)
        {
            int dump;
            if (TryGetIndex(username, out dump))
            {
                if (_users[dump].GetPassword() != password)
                {
                    return false;
                }
                _users[dump].ChangePassword(Newpassword);
                SmartHomeController._databaseController._SQLmanager.ChangeLine(username, "password", Newpassword);
                return true;
            }
            return false;
        }
        // change emaik
        // verify
        public bool TryGetAccount(string username, out User info)
        {
            foreach (User i in _users)
            {
                if (i.Username.Equals(username))
                {
                    info = i;
                    return true;
                }
            }
            info = null;
            return false;
        }
        public bool CheckPassword(string user, string pass)
        {
            User dump;
            if (TryGetAccount(user, out dump))
            {
                if (pass == dump.GetPassword())
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryGetIndex(string s, out int output)
        {
            output = 0;
            foreach (User ss in _users)
            {
                if (s == ss.Username)
                {
                    return true;
                }
                output++;
            }
            return false;
        }
        public void LoadDataTableForUser(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                LoadAccount(Convert.ToInt32(dr["Id"]), dr["username"].ToString(), dr["password"].ToString(), dr["email"].ToString(), dr["linkedbase"].ToString(), dr["emailchecked"].ToString());
            }
        }
        public List<string> GetLinkedBase(string Account)
        {
            User dump;
            if (TryGetAccount(Account, out dump))
            {
                return dump.LinkedHomes;
            }
            return null;
        }
        public bool VerifyEmail(string account, string verify)
        {
            int dump;
            if (TryGetIndex(account, out dump))
            {
                if (_users[dump].EmailChecked == verify || _users[dump].EmailChecked == "pass")
                {
                    _users[dump].EmailChecked = "pass";
                    SmartHomeController._databaseController._SQLmanager.ChangeLine(account, "emailchecked", "pass");
                    return true;
                }
                
            }
            return false;
        }
        public bool FindPassByEmail(string email)
        {
            foreach (User u in _users)
            {
                if (u.Email == email)
                {
                    SmartHomeController._emailSender.SendEmail(email, u.GetPassword());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool FindPassByAccount(string account)
        {
            foreach (User u in _users)
            {
                if (u.Username == account)
                {
                    SmartHomeController._emailSender.SendEmail(u.Email, u.GetPassword());
                    return true;
                }
            }
            return false;
        }
        public User GetAccountInfo(string username)
        {
            User u = null;
            TryGetAccount(username,out u);
            return u;
        }
        public List<string> GetAllAccounts()
        {
            List<string> list = new List<string>();
            foreach(User u in _users)
            {
                list.Add(u.Username);
            }
            return list;
        }
    }
}
