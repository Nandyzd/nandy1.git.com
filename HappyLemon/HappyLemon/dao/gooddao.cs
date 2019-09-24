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
    class gooddao
    {
        //添加商品
        public void add(good r)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO good(good_number,good_name,good_type,good_unit,good_price) VALUES(@good_number,@good_name,@good_type,@good_unit,@good_price,)";
                command.Parameters.AddWithValue("@good_number", r.Good_number);
                command.Parameters.AddWithValue("@good_name", r.Good_name);
                command.Parameters.AddWithValue("@good_type", r.Good_type);
                command.Parameters.AddWithValue("@good_unit", r.Good_unit);
                command.Parameters.AddWithValue("@good_price", r.Good_price);
                command.ExecuteNonQuery();
                MessageBox.Show("插入成功");
            }
            catch (Exception)
            {
                MessageBox.Show("插入失败");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public List<good> find_all1()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            good r = null;
            List<good> rs = new List<model.good>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawMaterial";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new good();
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Good_name = dataReader.GetString(2);
                    r.Good_type = dataReader.GetString(3);
                    r.Good_unit = dataReader.GetString(4);
                    r.Good_price = dataReader.GetDouble(5);
                    Console.Write(r.Good_price);
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

        //根据id查询商品
        public good selectAll(int id)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            good r = new good();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM good where id =" + id;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Good_name = dataReader.GetString(2);
                    r.Good_type = dataReader.GetString(3);
                    r.Good_unit = dataReader.GetString(4);
                    r.Good_price = dataReader.GetDouble(5);
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
        //根据类别查询商品
        public List<good> selectType(string type)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            good r = null;
            List<good> rs = new List<model.good>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM good where good_type='" + type + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new good();
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Good_name = dataReader.GetString(2);
                    r.Good_type = dataReader.GetString(3);
                    r.Good_unit = dataReader.GetString(4);
                    r.Good_price = dataReader.GetDouble(5);
                    Console.Write(r.Good_price);
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
        //根据编号或者名称查询商品
        public List<good> selectNumberOrName(string name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            good r = null;
            List<good> rs = new List<model.good>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM good where good_number='" + name + "'or good_name='" + name + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new good();
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Good_name = dataReader.GetString(2);
                    r.Good_type = dataReader.GetString(3);
                    r.Good_unit = dataReader.GetString(4);
                    r.Good_price = dataReader.GetDouble(5);
                    Console.Write(r.Good_price);
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
        //根据商品编号查询
        public good selectNumber(string number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            good r = new good();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM good where good_number ='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Good_name = dataReader.GetString(2);
                    r.Good_type = dataReader.GetString(3);
                    r.Good_unit = dataReader.GetString(4);
                    r.Good_price = dataReader.GetDouble(5);
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
