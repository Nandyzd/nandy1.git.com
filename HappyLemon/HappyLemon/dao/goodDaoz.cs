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
    class goodDaoz
    {
        public int su=1;
        public void addGood(string number, string name, string type, string unit, double price)
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

                command.CommandText = "select * from good where good_number='" + number + "'";
                command.ExecuteNonQuery();
                if (Convert.ToInt32(command.ExecuteScalar()) != 0)
                {
                    this.su = 0;
                    MessageBox.Show("商品已存在！");
                }
                else
                {
                    Console.Write("wuwuwuwuwu!");
                    command1 = conn.CreateCommand();
                    command1.CommandText = "INSERT INTO good(good_number,good_name,good_type,good_unit,good_price) VALUES(@good_number,@good_name,@good_type,@good_unit,@good_price)";
                    command1.Parameters.AddWithValue("@good_number", number);
                    command1.Parameters.AddWithValue("@good_name", name);
                    command1.Parameters.AddWithValue("@good_type", type);
                    command1.Parameters.AddWithValue("@good_unit", unit);
                    command1.Parameters.AddWithValue("@good_price",price);
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
        public static model.good  select(String number)//按编号查询
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.good> kehus = new List<model.good>();
            model.good r = new model.good();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM good where good_number='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Good_name = dataReader.GetString(2);
                    r.Good_type = dataReader.GetString(3);
                    r.Good_unit = dataReader.GetString(4);
                    r.Good_type = dataReader.GetString(5);

                    
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
        public static List<model.good> selectAll(String number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.good> kehus = new List<model.good>();
            model.good r = new model.good();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM good where good_number='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Good_name = dataReader.GetString(2);
                    r.Good_type = dataReader.GetString(3);
                    r.Good_unit = dataReader.GetString(4);
                    r.Good_price= dataReader.GetDouble(5);
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
                string sql = "delete from good where good_number='" + number + "'";
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
        public void update_good(string number,string name, String type, String unit, double price )
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "update good set good_name='" + name + "',good_type='" +
                        type + "',good_unit='" +
                        unit + "',good_price='" +
                        price + "' where good_number='" +
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
        public static List<model.good> find_all()//查询出所有客户
        {
            MySqlConnection conn = Util.Util.getConn();
            String sql = "select * from good";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            Console.WriteLine("ds:" + ds);
            da.Fill(ds);
            conn.Close();
            //获得DataSet里的数据
            List<model.good> rs = new List<model.good>();

            if (ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)//判断DataSet里是否有值
            {
                rs = new List<model.good>();
                int count = ds.Tables[0].Rows.Count;//获得表的行数
                for (int i = 0; i < count; i++)
                {
                    model.good r = new model.good();
                    r.Id = (int)ds.Tables[0].Rows[i]["id"];
                    r.Good_number = (string)ds.Tables[0].Rows[i]["good_number"];
                    r.Good_name = (string)ds.Tables[0].Rows[i]["good_name"];
                    r.Good_type = (string)ds.Tables[0].Rows[i]["good_type"];
                    r.Good_unit = (string)ds.Tables[0].Rows[i]["good_unit"];
                    r.Good_price = (double)ds.Tables[0].Rows[i]["good_price"];
                    rs.Add(r);

                }
            }
            return rs;
        }
    }
}
