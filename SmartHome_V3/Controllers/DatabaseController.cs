using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SmartHome_V3
{
    public class DatabaseController
    {
        //UpdateMessage GUI_Log;
        DataTable dataTable;
        public DatabaseManager database;
        public SQLmanager _SQLmanager;
        //public AccountManager _accountManager;
        /// <summary>
        /// construct database
        /// </summary>
        public DatabaseController() {
            database = new DatabaseManager();
            SQL_Initialize();
        }
        /// <summary>
        /// initialze sql database
        /// </summary>
        public void SQL_Initialize()
        {
            _SQLmanager = new SQLmanager();
            LoadDataToDBM();
        }
        /// <summary>
        /// load database into database
        /// </summary>
        private void LoadDataToDBM()
        {
            database.LoadDataTable(_SQLmanager.GetDataTableData());
            database.DoneInit();
        }
        /// <summary>
        /// return a datatable for display
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return dataTable;
        }
        /// <summary>
        /// insert data into database
        /// </summary>
        /// <param name="homeip">home ip</param>
        /// <param name="deviceip">device ip</param>
        /// <param name="data">data</param>
        public void InsertData(string homeip, string deviceip, string data)
        {
            // need to implement three state
            // 1 add data to sql database
            // 2 add data to tree database
            // 3 add data to bindlist to update information for graph
            // 4 add data to view

            //1 
            _SQLmanager.InsertData(homeip, deviceip, data);
            //2
            database.AddData(homeip, deviceip, data);
            //3 
            
            //4

        }
        /// <summary>
        /// get all data from select device
        /// </summary>
        /// <param name="ip">home ip</param>
        /// <param name="id">device id</param>
        /// <returns></returns>
        public List<Data> GetALLData(string ip, string id)
        {
            return database.GetAllData(ip, id);
        }
        public List<Data> GetDataFromDays(string homeip, string deviceid, DateTime start, DateTime end)
        {
            return database.GetDataFromDays(homeip, deviceid, start, end);
        }
        public List<Data> GetDataFromMonths(string homeip, string deviceid,DateTime start, DateTime end)
        {
            return database.GetDataFromMonths(homeip, deviceid, start, end);
        }
        public DateTime GetFirstDate(string homeip, string deviceid)
        {
            return database.GetFirstDate(homeip, deviceid);
        }



    }
}
