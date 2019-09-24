using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HappyLemon.model;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using HappyLemon.model;
using System.Windows.Forms;

namespace HappyLemon.dao
{
    class employeedaow
    {

        //查询所有供应者
        public List<employee> find_all()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            employee r = null;
            List<employee> rs = new List<employee>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM  employee";
                dataReader = command.ExecuteReader();
               
                while (dataReader.Read())
                {
                    r = new employee();
                    r.Employee_name = dataReader.GetString("employee_name");
                    r.Employee_number = dataReader.GetString("employee_number");
                    r.Phone = dataReader.GetString("phone");
                    rs.Add(r);
                   
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rs;
        }

        public List<employee> find_all2(string number,string name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            employee r = null;
            List<employee> rs = new List<employee>();
            try
            {
                command = conn.CreateCommand();
               
                string sql;
                if (number == "" && name != "")
                {
                    sql = "SELECT * FROM  employee where employee_name='" + name + "'";
                }
                else if (number != "" && name == "")
                {
                    sql = "SELECT * FROM  employee where employee_number='" + number + "'";
                }
                else if (number != "" && name != "")
                {
                    sql = "SELECT * FROM  employee where employee_number='" + number + "'  and employee_name='" + name + "'";
                }
                else
                {
                    sql = "SELECT * FROM  employee";
                }
                Console.WriteLine("sql:" + sql);
                command.CommandText = sql;
               dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    r = new employee();
                    r.Employee_name = dataReader.GetString("employee_name");
                    r.Employee_number = dataReader.GetString("employee_number");
                    r.Phone = dataReader.GetString("phone");
                    rs.Add(r);

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                /**if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }**/
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rs;
        }



    }
}
