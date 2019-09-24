using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using HappyLemon.Util;
using System.Windows.Forms;
using System.Data;
namespace HappyLemon.dao
{
    class rawmaterialDaoz
    {
        public int su = 1;
        public void addRawmaterial(string number, string name, string type,double count, string unit)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command1 = new MySqlCommand();
            try
            {
                Console.Write(number);
                Console.Write(name);
                Console.Write(type);
                Console.Write(unit);
                command = conn.CreateCommand();

                command.CommandText = "select * from rawmaterial where rawMaterial_number='" + number + "'";
                command.ExecuteNonQuery();
                if (Convert.ToInt32(command.ExecuteScalar()) != 0)
                {
                    this.su = 0;
                    MessageBox.Show("原材料已存在！");
                }
                else
                {
                    Console.Write("wuwuwuwuwu!");
                    command1 = conn.CreateCommand();
                    command1.CommandText = "INSERT INTO rawmaterial(rawMaterial_number,rawMaterial_name,rawMaterial_type,rawMaterial_count,rawMaterial_unit) VALUES(@rawMaterial_number,@rawMaterial_name,@rawMaterial_type,@rawMaterial_count,@rawMaterial_unit)";
                    command1.Parameters.AddWithValue("@rawMaterial_number", number);
                    command1.Parameters.AddWithValue("@rawMaterial_name", name);
                    command1.Parameters.AddWithValue("@rawMaterial_type", type);
                    command1.Parameters.AddWithValue("@rawMaterial_count", count);
                    command1.Parameters.AddWithValue("@rawMaterial_unit", unit);
                   
                    command1.ExecuteNonQuery();
                    MessageBox.Show("插入成功！");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("插入失败！");


            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {

                    conn.Close();
                }
            }

            Console.ReadLine();

        }
        public static model.rawmaterial select(String number)//按编号查询
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.rawmaterial> kehus = new List<model.rawmaterial>();
            model.rawmaterial r = new model.rawmaterial();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawmaterial where rawMaterial_number='" + number + "'";
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
            return r;
        }
        public static List<model.rawmaterial> selectAll(String number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.rawmaterial> kehus = new List<model.rawmaterial>();
            model.rawmaterial r = new model.rawmaterial();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawmaterial where rawMaterial_number='" + number + "'";
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
                    kehus.Add(r);
                    

                }
            }
            catch (Exception)
            {
                MessageBox.Show("查询出错！");
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
            return kehus;
        }
        public static void delete(string number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "delete from rawmaterial where rawMaterial_number='" + number + "'";
                command.CommandText = sql;
                command.ExecuteNonQuery();
                Console.WriteLine();
                MessageBox.Show("删除成功！");

            }
            catch (Exception)
            {
                MessageBox.Show("操作有误！");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void update_rawmaterial(string number, string name, String type,double count, String unit)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "update rawmaterial set rawMaterial_name='" + name + "',rawMaterial_type='" +
                        type + "',rawMaterial_count='" +
                        count + "',rawMaterial_unit='" +
                        unit + "' where rawMaterial_number='" +
                    number + "'";
                command.CommandText = sql;

                command.ExecuteNonQuery();
                Console.WriteLine();

            }
            catch (Exception)
            {
                MessageBox.Show("操作不正确！");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public static List<model.rawmaterial> find_all()//查询出所有客户
        {
            MySqlConnection conn = Util.Util.getConn();
            String sql = "select * from rawmaterial";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            Console.WriteLine("ds:" + ds);
            da.Fill(ds);
            conn.Close();
            //获得DataSet里的数据
            List<model.rawmaterial> rs = new List<model.rawmaterial>();
            Console.Write("88888888888888888888881");
            if (ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)//判断DataSet里是否有值
            {
                rs = new List<model.rawmaterial>();
                int count = ds.Tables[0].Rows.Count;//获得表的行数
                for (int i = 0; i < count; i++)
                {
                    Console.Write("1111111111111");
                    model.rawmaterial r = new model.rawmaterial();
                    r.Id = (int)ds.Tables[0].Rows[i]["id"];
                    Console.Write("17777777777777771111111");
                    r.Rawmaterial_number = (string)ds.Tables[0].Rows[i]["rawMaterial_number"];
                    Console.Write("111111155555555555555551");
                    r.Rawmaterial_name = (string)ds.Tables[0].Rows[i]["rawMaterial_name"];
                    r.Rawmaterial_type = (string)ds.Tables[0].Rows[i]["rawMaterial_type"];
                    r.Rawmaterial_count = (double)ds.Tables[0].Rows[i]["rawMaterial_count"];
                    r.Rawmaterial_unit = (string)ds.Tables[0].Rows[i]["rawMaterial_unit"];
                    
                    rs.Add(r);

                }
            }
            return rs;
        }
    }
}
