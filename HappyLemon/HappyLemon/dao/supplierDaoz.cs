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
    class supplierDaoz
    {
        public int su = 1;
        public void addSupplier(string number, string name1,string name2, string phone, string address,string type)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command1 = new MySqlCommand();
            try
            {
                Console.Write(number);
                Console.Write(name1);
                Console.Write(phone);
                Console.Write(address);
                command = conn.CreateCommand();

                command.CommandText = "select * from supplier where supplier_number='" + number + "'";
                command.ExecuteNonQuery();
                if (Convert.ToInt32(command.ExecuteScalar()) != 0)
                {
                    this.su = 0;
                    MessageBox.Show("供应商已存在！");
                }
                else
                {
                    Console.Write("wuwuwuwuwu!");
                    command1 = conn.CreateCommand();
                    command1.CommandText = "INSERT INTO supplier(supplier_number,supplier_name,charge_name,telephone,adress,type) VALUES(@supplier_number,@supplier_name,@charge_name,@telephone,@adress,@type)";
                    command1.Parameters.AddWithValue("@supplier_number", number);
                    command1.Parameters.AddWithValue("@supplier_name", name1);
                    command1.Parameters.AddWithValue("@charge_name", name2);                  
                    command1.Parameters.AddWithValue("@telephone", phone);
                    command1.Parameters.AddWithValue("@adress", address);
                    command1.Parameters.AddWithValue("@type", type);
                
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
        public void update_supplier(string number,String name,String phone, String address,string type)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "update supplier set charge_name='" + name + "',telephone='" +
                        phone + "',adress='" +
                        address + "',type='" +
                        type + "' where supplier_number='" +
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
        public static List<model.supplier> find_all()//查询出所有客户
        {
            MySqlConnection conn = Util.Util.getConn();
            String sql = "select * from supplier";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            Console.WriteLine("ds:" + ds);
            da.Fill(ds);
            conn.Close();
            //获得DataSet里的数据
            List<model.supplier> rs = new List<model.supplier>();

            if (ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)//判断DataSet里是否有值
            {
                rs = new List<model.supplier>();
                int count = ds.Tables[0].Rows.Count;//获得表的行数
                for (int i = 0; i < count; i++)
                {
                    model.supplier r = new model.supplier();
                    r.Id = (int)ds.Tables[0].Rows[i]["id"];
                    r.Supplier_number = (string)ds.Tables[0].Rows[i]["supplier_number"];
                    r.Supplier_name= (string)ds.Tables[0].Rows[i]["supplier_name"];
                    r.Charge_name = (string)ds.Tables[0].Rows[i]["charge_name"];
                    r.Telephone = (string)ds.Tables[0].Rows[i]["telephone"];
                    r.Address = (string)ds.Tables[0].Rows[i]["adress"];
                    r.Type = (string)ds.Tables[0].Rows[i]["type"];

                    rs.Add(r);

                }
            }
            return rs;
        }
       

        
        public static  List<model.supplier> selectAll(String number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.supplier> kehus = new List<model.supplier>();
            model.supplier r = new model.supplier();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM supplier where supplier_number='" + number + "'";
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
        public static model.supplier select(String number)//按编号查询
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.supplier> kehus = new List<model.supplier>();
            model.supplier r = new model.supplier();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM supplier where supplier_number='" + number + "'";
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
        public static void delete(string number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "delete from supplier where supplier_number='" + number + "'";
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
    }

}
