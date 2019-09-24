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
    class supplierdao
    {
        //查询所有供应者
        public List<supplier> find_all()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            supplier r = null;
            List<supplier> rs = new List<supplier>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM supplier";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new supplier();
                    r.Id= dataReader.GetInt16(0);
                    r.Supplier_number = dataReader.GetString(1);
                    r.Supplier_name = dataReader.GetString(2);
                    r.Charge_name = dataReader.GetString(3);
                    r.Telephone = dataReader.GetString(4);
                    r.Address = dataReader.GetString(5);
                    r.Type= dataReader.GetString(6);
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

        //根据类别查询
        public List<supplier> selectType(string type)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            supplier r = null;
            List<supplier> rs = new List<model.supplier>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM supplier where type='" + type + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new supplier();
                    r.Id = dataReader.GetInt16(0);
                    r.Supplier_number = dataReader.GetString(1);
                    r.Supplier_name = dataReader.GetString(2);
                    r.Charge_name = dataReader.GetString(3);
                    r.Telephone = dataReader.GetString(4);
                    r.Address = dataReader.GetString(5);
                    r.Type = dataReader.GetString(6);
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
        //根据编号或者名称查询
        public List<supplier> selectNumberOrName(string name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            supplier r = null;
            List<supplier> rs = new List<model.supplier>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM supplier where supplier_number='" + name + "'or supplier_name='" + name + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new supplier();
                    r.Id = dataReader.GetInt16(0);
                    r.Supplier_number = dataReader.GetString(1);
                    r.Supplier_name = dataReader.GetString(2);
                    r.Charge_name = dataReader.GetString(3);
                    r.Telephone = dataReader.GetString(4);
                    r.Address = dataReader.GetString(5);
                    r.Type = dataReader.GetString(6);
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
        public supplier selectnumber(string number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            supplier r = new supplier();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM supplier where supplier_number ='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Supplier_number = dataReader.GetString(1);
                    r.Supplier_name = dataReader.GetString(2);
                    r.Charge_name = dataReader.GetString(3);
                    r.Telephone = dataReader.GetString(4);
                    r.Address = dataReader.GetString(5);
                    r.Type = dataReader.GetString(6);

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
        public supplier selectNumber(string number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            supplier r = new supplier();

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM supplier where supplier_number='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new supplier();
                    r.Id = dataReader.GetInt16(0);
                    r.Supplier_number = dataReader.GetString(1);
                    r.Supplier_name = dataReader.GetString(2);
                    r.Charge_name = dataReader.GetString(3);
                    r.Telephone = dataReader.GetString(4);
                    r.Address = dataReader.GetString(5);
                    r.Type = dataReader.GetString(6);
                    Console.Write("瑶瑶李");
                    Console.WriteLine(r.Supplier_name);
                    return r;
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
            return null;
        }
    }
}
