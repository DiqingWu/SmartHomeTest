using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    public class User
    {
        public int id { set; get; }
        public string Username { get; set; }
        string Password {    get; set;  }
        public List<string> LinkedHomes { get; set; }
        public string Email { get; set; }

        public string EmailChecked = "default";
        
        bool Flag = false;



        public string LastLoginIP { get; set; }

        public User(string username, string password, string email,int ran)
        {
            Username = username;
            Password = password;
            Email = email;
            EmailChecked = ran.ToString();
        }
        public User(int id, string username, string password, string email, string linkedbase, string emailchecked)
        {
            this.id = id;
            Username = username;
            Password = password;
            Email = email;

            string[] temp = linkedbase.Split(',');
            LinkedHomes = new List<string>();
            foreach(string s in temp)
            {
                LinkedHomes.Add(s);
            }

            EmailChecked = emailchecked;

        }
        public User(string username, string password, string email,string LinkedHome)
        {
            Username = username;
            Password = password;
            Email = email;
            string[] temp = LinkedHome.Split(',');
            foreach(string s in temp)
            {
                LinkedHomes.Add(s);
            }
        }
        public void AddFunction(string function)
        {
            string dump;
            if(TryGetFunction(function,out dump))
            {
                return;
            }
            LinkedHomes.Add(function);
        }
        public string GetPassword()
        {
            return Password;
        }
        public void ChangePassword(string s)
        {
            Password = s;
        }
        public string GetUserName()
        {
            return Username;
        }
        public string GetEmail()
        {
            return Email;
        }
        public void ChangeEmail(string s)
        {
            Email = s;
        }
        public void ChangeFlagTrue()
        {
            Flag = true;
        }
        public void ChangeFlagFalse()
        {
            Flag = false;
        }
        public void RemoveFunction(string function)
        {
            string dump;
            if (TryGetFunction(function, out dump))
            {
                LinkedHomes.Remove(function);
            }
            
        }
        public string GetAllBase()
        {
            string temp = "";
            foreach(string s in LinkedHomes)
            {
                temp += s + ",";
            }
            temp = temp.Remove(temp.Length - 1, 1);
            return temp;
        }
        public bool TryGetFunction(string function, out string fcname)
        {
            fcname = "";
            foreach (string s in LinkedHomes)
            {
                if (s == function)
                {
                    fcname = s;
                    return true;
                }
            }
            return false;
        }
        public bool GetStatus()
        {
            return Flag;
        }
    }
}
