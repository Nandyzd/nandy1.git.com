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
    class rawmaterialdao
    {
        //添加原材料
        public void add(rawmaterial r)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO rawMaterial(rawMaterial_number,rawMaterial_name,rawMaterial_type,rawMaterial_count,rawMaterial_unit) VALUES(@rawMaterial_number,@rawMaterial_name,@rawMaterial_type,@rawMaterial_count,@rawMaterial_unit)";
                command.Parameters.AddWithValue("@rawMaterial_number", r.Rawmaterial_number);
                command.Parameters.AddWithValue("@rawMaterial_name", r.Rawmaterial_name);
                command.Parameters.AddWithValue("@rawMaterial_type", r.Rawmaterial_type);
                command.Parameters.AddWithValue("@rawMaterial_count", r.Rawmaterial_count);
                command.Parameters.AddWithValue("@rawMaterial_unit", r.Rawmaterial_unit);
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
        public List<rawmaterial> find_all1()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            rawmaterial r = null;
            List<rawmaterial> rs = new List<model.rawmaterial>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawMaterial";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new rawmaterial();
                    r.Id = dataReader.GetInt16(0);
                    r.Rawmaterial_number = dataReader.GetString(1);
                    r.Rawmaterial_name = dataReader.GetString(2);
                    r.Rawmaterial_type = dataReader.GetString(3);
                    r.Rawmaterial_count = dataReader.GetDouble(4);
                    r.Rawmaterial_unit = dataReader.GetString(5);
                    Console.Write(r.Rawmaterial_count);
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

        //根据id查询原材料
        public rawmaterial selectAll(int id)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            rawmaterial r = new rawmaterial();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawMaterial where id =" + id;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Rawmaterial_number = dataReader.GetString(1);
                    r.Rawmaterial_name = dataReader.GetString(2);
                    r.Rawmaterial_type = dataReader.GetString(3);
                    r.Rawmaterial_count = dataReader.GetDouble(4);
                    r.Rawmaterial_unit = dataReader.GetString(5);
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
        //根据类别查询
        public List<rawmaterial> selectType(string type)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            rawmaterial r = null;
            List<rawmaterial> rs = new List<model.rawmaterial>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawMaterial where rawMaterial_type='"+type+"'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new rawmaterial();
                    r.Id = dataReader.GetInt16(0);
                    r.Rawmaterial_number = dataReader.GetString(1);
                    r.Rawmaterial_name = dataReader.GetString(2);
                    r.Rawmaterial_type = dataReader.GetString(3);
                    r.Rawmaterial_count = dataReader.GetDouble(4);
                    r.Rawmaterial_unit = dataReader.GetString(5);
                    Console.Write(r.Rawmaterial_count);
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
        public List<rawmaterial> selectNumberOrName(string name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            rawmaterial r = null;
            List<rawmaterial> rs = new List<model.rawmaterial>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawMaterial where rawMaterial_number='" + name + "'or rawMaterial_name='"+name+"'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new rawmaterial();
                    r.Id = dataReader.GetInt16(0);
                    r.Rawmaterial_number = dataReader.GetString(1);
                    r.Rawmaterial_name = dataReader.GetString(2);
                    r.Rawmaterial_type = dataReader.GetString(3);
                    r.Rawmaterial_count = dataReader.GetDouble(4);
                    r.Rawmaterial_unit = dataReader.GetString(5);
                    Console.Write(r.Rawmaterial_count);
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
        public rawmaterial selectNumber(string number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            rawmaterial r = new rawmaterial();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawMaterial where rawMaterial_number ='" +number+"'" ;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Rawmaterial_number = dataReader.GetString(1);
                    r.Rawmaterial_name = dataReader.GetString(2);
                    r.Rawmaterial_type = dataReader.GetString(3);
                    r.Rawmaterial_count = dataReader.GetDouble(4);
                    r.Rawmaterial_unit = dataReader.GetString(5);
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
