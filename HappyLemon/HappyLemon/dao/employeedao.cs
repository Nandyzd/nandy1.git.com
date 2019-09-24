using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyLemon.model;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using HappyLemon.Util;
using System.Windows.Forms;

namespace HappyLemon.dao
{
    class employeedao
    {
        public List<employ> find_all1()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            employ r = null;
            List<employ> rs = new List<model.employ>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM employee";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new employ();
                    r.Id = dataReader.GetInt16(0);
                    r.Employee_number = dataReader.GetString(1);
                    r.Employee_name = dataReader.GetString(2);
                    r.Phone = dataReader.GetString(3);
                    Console.Write("瑶瑶李");
                    rs.Add(r);
                    Console.Write("瑶瑶李");
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

        //根据工号查询
        public employ selectid(string number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            employ e = new employ();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM employee where employee_number ='"+number+"'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    e.Id = dataReader.GetInt16(0);
                    e.Employee_number = dataReader.GetString(1);
                    e.Employee_name = dataReader.GetString(2);
                    e.Phone = dataReader.GetString(3);

                    
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
            return e;
        }  
    }
}
