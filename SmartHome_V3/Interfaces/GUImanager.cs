using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SmartHome_V3
{
    public class GUImanager
    {
        //Thread thread = new Thread(new ThreadStart(OpenNewServerLog));
        //thread.Start();
        List<string> _Log;

        List<UpdateMessage> Data_ums;
        List<UpdateMessage> Log_ums;
        public GUImanager()
        {
            _Log = new List<string>();
          Data_ums = new List<UpdateMessage>();
          Log_ums = new List<UpdateMessage>();

        }

        public void Update(string s)
        {
            
            _Log.Add(DateTime.Now.ToString() +": \t"+ s);
            if(Data_ums.Count > 0)
            {
                foreach (UpdateMessage um in Data_ums)
                {
                    
                }
            }

            if (Log_ums.Count > 0)
            {
                foreach (UpdateMessage um in Log_ums)
                {
                    um(DateTime.Now.ToString() + ": \t" + s);
                }
            }


        }

        /// <summary>
        /// create new thread
        /// </summary>
        public void OpenNewFunctionView()
        {
            try
            {
                //FunctionView pp = new FunctionView();
                // do any background work
                //Application.Run(pp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public void OpenDataAnalyze()
        {
            Thread thread = new Thread(new ThreadStart(OpenNewDatabaseAnalyze));
            thread.Start();
        }
        /// <summary>
        /// create new thread//add by xuebo
        /// </summary>
        public void OpenNewDatabaseAnalyze()
        {
            try
            {
                DataAnalyze pp = new DataAnalyze();
                // do any background work
                Data_ums.Add(pp.NewMessage);
                Application.Run(pp);
            }
            catch (Exception ex)
            {
                // log errors
                MessageBox.Show(ex.ToString());
            }
        }
        public void OpenServerLog()
        {
            Thread thread = new Thread(new ThreadStart(OpenNewServerLog));
            thread.Start();
        }
        /// <summary>
        /// method create a new form for view server log
        /// </summary>
        private void OpenNewServerLog()
        {
            try
            {
                ServerLogView pp = new ServerLogView(_Log);
                // do any background work
                Log_ums.Add(pp.AddMessage);
                Application.Run(pp);
                Log_ums.Remove(pp.AddMessage);
            }
            catch (Exception ex)
            {
                // log errors
                MessageBox.Show(ex.ToString());
            }
        }
        public void OpenAccountAnalyze()
        {
            Thread thread = new Thread(new ThreadStart(OpenNewAccountAnalyze));
            thread.Start();
        }
        /// <summary>
        /// create new thread//add by xuebo
        /// </summary>
        public void OpenNewAccountAnalyze()
        {
            try
            {
                AccountAnalyze pp = new AccountAnalyze();
                Application.Run(pp);
            }
            catch (Exception ex)
            {
                // log errors
                MessageBox.Show(ex.ToString());
            }
        }
        public void OpenAccountLogin()
        {
            Thread thread = new Thread(new ThreadStart(OpenNewAccountLogin));
            thread.Start();
        }
        /// <summary>
        /// create new thread//add by xuebo
        /// </summary>
        public void OpenNewAccountLogin()
        {
            try
            {
                Login pp = new Login();
                Application.Run(pp);
            }
            catch (Exception ex)
            {
                // log errors
                MessageBox.Show(ex.ToString());
            }
        }

        public void OpenAccountRegister()
        {
            Thread thread = new Thread(new ThreadStart(OpenNewAccountRegister));
            thread.Start();
        }
        /// <summary>
        /// create new thread//add by xuebo
        /// </summary>
        public void OpenNewAccountRegister()
        {
            try
            {
                Register pp = new Register();
                Application.Run(pp);
            }
            catch (Exception ex)
            {
                // log errors
                MessageBox.Show(ex.ToString());
            }
        }
        public void OpenFunction()
        {
            Thread thread = new Thread(new ThreadStart(OpenNewFunction));
            thread.Start();
        }
        /// <summary>
        /// create new thread//add by xuebo
        /// </summary>
        public void OpenNewFunction()
        {
            try
            {
                FunctionView pp = new FunctionView();
                Application.Run(pp);
            }
            catch (Exception ex)
            {
                // log errors
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
