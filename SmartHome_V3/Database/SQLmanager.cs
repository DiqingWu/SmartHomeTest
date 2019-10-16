using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SmartHome_V3
{
    public class SQLmanager
    {
        SqlConnection connection;

        string data_path = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\diqing\\Desktop\\SmartHomeServer_v1\\SmartHomeServer_v1\\Database1.mdf;Integrated Security=True";

        /// <summary>
        /// get the datatable from sql 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableData()
        {
            DataTable dataTable = new DataTable();
            using (connection = new SqlConnection(data_path))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * FROM lineardata", connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="homeip"></param>
        /// <param name="deviceip"></param>
        /// <param name="data"></param>
        public void InsertData(string homeip, string deviceip, string data)
        {
            DateTime t = DateTime.Now;
            // 1
            using (connection = new SqlConnection(data_path))
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO lineardata VALUES(@homeip, @deviceip, @time, @data)", connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("homeip", homeip);
                    command.Parameters.AddWithValue("deviceip", deviceip);
                    command.Parameters.AddWithValue("time", t);
                    command.Parameters.AddWithValue("data", data);
                    command.ExecuteScalar();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// get the datatable from sql 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAccount()
        {
            DataTable dataTable = new DataTable();
            using (connection = new SqlConnection(Constants.SQL_Connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * FROM AccountTable", connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        /// <summary>
        /// create a new num
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public void InsertAccount(string account, string password, string email,int ran)
        {
            using (connection = new SqlConnection(Constants.SQL_Connection))
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO AccountTable VALUES( @username, @password, @email, @linkedbase, @emailchecked)", connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("username", account);
                    command.Parameters.AddWithValue("password", password);
                    command.Parameters.AddWithValue("email", email);
                    command.Parameters.AddWithValue("linkedbase", "");
                    command.Parameters.AddWithValue("emailchecked", ran);
                    command.ExecuteScalar();
                    connection.Close();
                }
            }
        }
        /*
              change line command
             "DELETE FROM supplier WHERE supplier_id ="
             "UPDATE supplier SET supplier_id = " + textBox1.Text + ", supplier_name = " + textBox2.Text + "WHERE supplier_id = " + textBox1.Text;
             "UPDATE Student SET Address = @add, City = @cit Where FirstName = @fn AND LastName = @ln"
             */

        //command.CommandText = "UPDATE Student(LastName, FirstName, Address, City) VALUES (@ln, @fn, @add, @cit) WHERE LastName='" + lastName + "' AND FirstName='" + firstName+"'";
        public void ChangeLine(string username, string valuename, string valuechange)
        {
            using (connection = new SqlConnection(Constants.SQL_Connection))
            {
                using (SqlCommand command = new SqlCommand("UPDATE AccountTable SET "+ valuename + " = @b WHERE username = @c" , connection))
                {
                    connection.Open();
                    //command.Parameters.AddWithValue("a", valuename);
                    command.Parameters.AddWithValue("b", valuechange);
                    command.Parameters.AddWithValue("c", username);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}
