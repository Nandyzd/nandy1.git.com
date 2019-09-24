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
    class sale
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
        //添加购物单
        public void addDanju(DateTime d, string danju, string employee_id, double money, string remark, string customer)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO sale_danju(date,danju,employee_id,customer_number,money,remark) VALUES(@date,@danju,@employee_id,@customer_number,@money,@remark)";
                command.Parameters.AddWithValue("@date", d);
                command.Parameters.AddWithValue("@danju", danju);
                command.Parameters.AddWithValue("@employee_id", employee_id);
                command.Parameters.AddWithValue("@customer_number", customer);
                command.Parameters.AddWithValue("@money", money);
                command.Parameters.AddWithValue("@remark", remark);
                Console.WriteLine( d);
                Console.WriteLine(danju);
                Console.WriteLine(employee_id);
                Console.WriteLine(customer);
                Console.WriteLine(money);
                Console.WriteLine(remark);
                command.ExecuteNonQuery();
               // MessageBox.Show("插入成功");
            }
            catch (Exception)
            {
                MessageBox.Show("插入失败aa");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void addsale(sale_good p)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO sale_good(good_number,customernumber,unit,count,price,money,remark,dan_date,danju_id) VALUES(@good_id,@customerid,@unit,@count,@price,@money,@remark,@dan_date,@danju_id)";
                command.Parameters.AddWithValue("@good_id", p.Good_number);
                command.Parameters.AddWithValue("@customerid", p.Customernumber);
                command.Parameters.AddWithValue("@unit", p.Unit);
                command.Parameters.AddWithValue("@count", p.Count);
                command.Parameters.AddWithValue("@price", p.Price);
                command.Parameters.AddWithValue("@money", p.Money);
                command.Parameters.AddWithValue("@remark", p.Remark);
                command.Parameters.AddWithValue("@dan_date", p.Dan_date);
              
                command.Parameters.AddWithValue("@danju_id", p.Danju_id);
                command.ExecuteNonQuery();
                //MessageBox.Show("插入成功");
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
                command.CommandText = "SELECT * FROM good";
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
        //获取已经存在的最大的单据id
        public int selectMaxdanjuid()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            int id;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT MAX(id) FROM sale_danju";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    id = dataReader.GetInt16(0);

                    return id;
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
            return 0;
        }
        //根据日期查询单据
        public List<saleDanju> selectdate(DateTime t1, DateTime t2)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            saleDanju r = null;
            List<saleDanju> rs = new List<model.saleDanju>();
            Console.Write("13");
            try
            { 
               
                command = conn.CreateCommand();
                Console.WriteLine(t1);
                Console.WriteLine(t2);
                String sql = "SELECT * FROM sale_danju where date>='" + t1 + "' and date<='" + t2 + "'";
                command.CommandText = sql;
                Console.WriteLine(sql);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    r = new saleDanju();
                    r.Id = dataReader.GetInt16(0);
                    r.Date = dataReader.GetDateTime(1);
                    r.Danju = dataReader.GetString(2);
                    r.Emploee_id = dataReader.GetString(3);
                    r.Customer_number = dataReader.GetString(4);
                    r.Money = dataReader.GetDouble(5);
                    r.Remark = dataReader.GetString(6);
                   
                    //Console.Write("瑶瑶李");
                    rs.Add(r);
                    Console.Write("qqqqqqq");
                }
                }
            catch (Exception)
            {

            }
            finally
            {
               
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rs;
          
            
        }

        //根据单据名称模糊查询
        public List<saleDanju> selectdateAndNum_Supp(string num)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            saleDanju r = null;
            List<saleDanju> rs = new List<model.saleDanju>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM sale_danju where danju like '%" + num + "%'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new saleDanju();
                    r.Id = dataReader.GetInt16(0);
                    r.Date = dataReader.GetDateTime(1);
                    r.Danju = dataReader.GetString(2);
                    r.Emploee_id = dataReader.GetString(3);
                    r.Customer_number = dataReader.GetString(4);
                    r.Money = dataReader.GetDouble(5);
                    r.Remark = dataReader.GetString(6);
                    //Console.Write("瑶瑶李");
                    rs.Add(r);
                    //Console.Write("瑶瑶李");
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rs;
        }
        //根据单据查询销货sale_good
        public List<sale_good> selectMaterial_danhao(string danju_number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            sale_good r = null;
            List<sale_good> rs = new List<model.sale_good>();
            try
            {
                command = conn.CreateCommand();
                string sql = "SELECT * FROM sale_good where danju_id='" + danju_number + "'";
                Console.Write(sql);
                command.CommandText =sql;
                
                dataReader = command.ExecuteReader();
                
                while (dataReader.Read())
                {
                    Console.Write("测试");
                    r = new sale_good();
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Customernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
                    Console.Write(r.Id);
                    Console.Write(r.Good_number);
                    Console.Write(r.Customernumber);
                    Console.Write(r.Unit);
                    Console.Write(r.Count);
                    Console.Write(r.Price);
                    Console.Write(r.Money);
                    Console.Write(r.Remark);
                    Console.Write(r.Dan_date);
                    rs.Add(r);
                    Console.Write("测试");
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rs;
        }

        //根据日期查询purchase_material表中status为0的数据
        public List<sale_good> selectMaterial_date(DateTime date1, DateTime date2)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            sale_good r = null;
            List<sale_good> rs = new List<model.sale_good>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM sale_good where dan_date>='" + date1 + "' and dan_date<='" + date2 + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new sale_good();
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Customernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
                    r.Danju_id = dataReader.GetString(9);
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

        //根据日期和原材料名称查询purchase_material表中status为0的数据
        public List<sale_good> selectMaterial_dateandrname(DateTime date1, DateTime date2, string name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            sale_good r = null;
            List<sale_good> rs = new List<model.sale_good>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM sale_good where dan_date>='" + date1 + "' and dan_date<='" + date2 + "' and good_number=(select good_number from good where good_name like '%" + name + "%')" ;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new sale_good();
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Customernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
                    r.Danju_id = dataReader.GetString(9);
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

        //根据日期和供应商查询purchase_material表中status为0的数据
        public List<sale_good> selectMaterial_dateandsnumber(DateTime date1, DateTime date2, string customer_name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            sale_good r = null;
            List<sale_good> rs = new List<model.sale_good>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM sale_good where dan_date>='" + date1 + "' and dan_date<='" + date2 + "' and customernumber='" + customer_name + "' ";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new sale_good();
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Customernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
                  
                    r.Danju_id = dataReader.GetString(9);
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
        //根据日期和供应商、原材料名称查询purchase_material表中status为0的数据
        public List<sale_good> selectMaterial_dateandrnameandsupplier(DateTime date1, DateTime date2, string customernumber, string name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            sale_good r = null;
            List<sale_good> rs = new List<model.sale_good>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM sale_good where dan_date>='" + date1 + "' and dan_date<='" + date2 + "' and good_number=(select good_number from good where good_name like '%" + name + "%') and customernumber='" + customernumber + "' " ;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new sale_good();
                    r.Id = dataReader.GetInt16(0);
                    r.Good_number = dataReader.GetString(1);
                    r.Customernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
             
                    r.Danju_id = dataReader.GetString(9);
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
    }
}
