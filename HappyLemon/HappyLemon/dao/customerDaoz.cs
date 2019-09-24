using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using HappyLemon.Util;
using System.Windows.Forms;
namespace HappyLemon.dao
{
    class customerDaoz
    {
        public int kehu=1;
        public  void addCustomer(string number, string name, string phone, string address)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command1 = new MySqlCommand();
            try
            {
                Console.Write(number);
                Console.Write(name);
                Console.Write(phone);
                Console.Write(address);
                command = conn.CreateCommand();

                command.CommandText = "select * from customer where customer_number='"+number+"'";
                command.ExecuteNonQuery();
               if (Convert.ToInt32(command.ExecuteScalar())!= 0)
               {
                   this.kehu = 0;
                  MessageBox.Show("客户已存在！");
               }
              else
               {
                     Console.Write("wuwuwuwuwu!");
                    command1 = conn.CreateCommand();
                    command1.CommandText = "INSERT INTO customer(customer_number,customer_name,phone,address) VALUES(@customer_number,@customer_name,@phone,@address)";
                    command1.Parameters.AddWithValue("@customer_number", number);
                    command1.Parameters.AddWithValue("@customer_name", name);
                    command1.Parameters.AddWithValue("@phone", phone);
                    command1.Parameters.AddWithValue("@address", address);
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
        public  void update_customer(String number,String phone,String address)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "update customer set phone='" + phone + "',address='" +
                        address + "' where customer_number='" +
                    number + "'";
                command.CommandText = sql;

                command.ExecuteNonQuery();
                Console.WriteLine();

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
        public static List<model.kehu> find_all()//查询出所有客户
        {
            MySqlConnection conn = Util.Util.getConn();
            String sql = "select * from customer";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            Console.WriteLine("ds:" + ds);
            da.Fill(ds);
            conn.Close();
            //获得DataSet里的数据
            List<model.kehu> rs = new List<model.kehu>(); ;

            if (ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)//判断DataSet里是否有值
            {
                rs = new List<model.kehu>();
                int count = ds.Tables[0].Rows.Count;//获得表的行数
                for (int i = 0; i < count; i++)
                {
                    model.kehu r = new model.kehu();
                    r.id = (int)ds.Tables[0].Rows[i]["id"];
                    r.customer_name = (string)ds.Tables[0].Rows[i]["customer_name"];
                    r.customer_number = (string)ds.Tables[0].Rows[i]["customer_number"];
                    r.phone = (string)ds.Tables[0].Rows[i]["phone"];
                    r.address = (string)ds.Tables[0].Rows[i]["address"];

                    rs.Add(r);

                }
            }
            return rs;
        }
        public static List<model.kehu> selectAll(String name)//按名字查询
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.kehu> kehus = new List<model.kehu>();
            model.kehu r = new model.kehu();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM customer where customer_number='"+name+"'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
             
                    while (dataReader.Read())
                    {
                        r.Id = dataReader.GetInt16(0);
                        r.Customer_number = dataReader.GetString(1);
                        r.Customer_name = dataReader.GetString(2);
                        r.Phone = dataReader.GetString(3);
                        r.Address = dataReader.GetString(4);
                        kehus.Add(r);
                        
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
            return kehus;
        }
        public static model.kehu select(String number)//按编号查询
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.kehu> kehus = new List<model.kehu>();
            model.kehu r = new model.kehu();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM customer where customer_number='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Customer_number = dataReader.GetString(1);
                    r.Customer_name = dataReader.GetString(2);
                    r.Phone = dataReader.GetString(3);
                    r.Address = dataReader.GetString(4);
                   
                    
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
        public static void delete(string name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "delete from customer where customer_number='" + name + "'";           
                command.CommandText = sql;

                command.ExecuteNonQuery();
                Console.WriteLine();

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
    }

}

