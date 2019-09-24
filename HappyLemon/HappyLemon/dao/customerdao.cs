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
using HappyLemon.model;
using System.Windows.Forms;

namespace HappyLemon.dao
{
    class customerdao
    {
        //查询所有供应者
        public List<customer> find_all()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            customer r = null;
            List<customer> rs = new List<customer>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM customer";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new customer();
                    r.Id = dataReader.GetInt16(0);
                    r.Customer_number = dataReader.GetString(1);
                    r.Customer_name = dataReader.GetString(2);
                    r.Phone = dataReader.GetString(3);
                    r.Address = dataReader.GetString(4);
                  
                    rs.Add(r);
                    Console.Write("成功");
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

       
        //根据编号或者名称查询
        public List<customer> selectNumberOrName(string name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            customer r = null;
            List<customer> rs = new List<model.customer>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM customer where customer_number='" + name + "'or customer_name='" + name + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new customer();
                    r.Id = dataReader.GetInt16(0);
                    r.Customer_number = dataReader.GetString(1);
                    r.Customer_name = dataReader.GetString(2);
                    r.Phone = dataReader.GetString(3);
                    r.Address = dataReader.GetString(4);
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
        //根据编号查询
        public customer selectnumber(string number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            customer r = new customer();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM customer where customer_number ='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Id = dataReader.GetInt16(0);
                    r.Customer_number = dataReader.GetString(1);
                    r.Customer_name = dataReader.GetString(2);
                    r.Phone = dataReader.GetString(3);
                    r.Address = dataReader.GetString(4);

                    return r;
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
            return null;
        }
        //根据名称查询
        public customer selectname(string name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            customer r = new customer();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM customer where customer_name ='" + name + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Id = dataReader.GetInt16(0);
                    r.Customer_number = dataReader.GetString(1);
                    r.Customer_name = dataReader.GetString(2);
                    r.Phone = dataReader.GetString(3);
                    r.Address = dataReader.GetString(4);

                    return r;
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
            return null;
        }
    }
}
