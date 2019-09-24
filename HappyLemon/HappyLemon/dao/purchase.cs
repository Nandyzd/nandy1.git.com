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
    class purchase
    {
        //添加原材料
        public  void add(rawmaterial r)
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
        //添加购物单
        public void addDanju(DateTime d,string danju,string employee_id,double money,string remark,string supplier,int status)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO purchase_danju(date,danju,employee_id,supplier_number,money,remark,status) VALUES(@date,@danju,@employee_id,@supplier_number,@money,@remark,@status)";
                command.Parameters.AddWithValue("@date", d);
                command.Parameters.AddWithValue("@danju", danju);
                command.Parameters.AddWithValue("@employee_id", employee_id);
                command.Parameters.AddWithValue("@supplier_number", supplier);
                command.Parameters.AddWithValue("@money", money);
                command.Parameters.AddWithValue("@remark", remark);
                command.Parameters.AddWithValue("@status", status);
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
        public void addpurchase(purchase_material p)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO purchase_material(rawMaterial_number,suppliernumber,unit,count,price,money,remark,dan_date,status,danju_id) VALUES(@rawMaterial_id,@supplierid,@unit,@count,@price,@money,@remark,@dan_date,@status,@danju_id)";
                command.Parameters.AddWithValue("@rawMaterial_id", p.RawMaterial_number);
                command.Parameters.AddWithValue("@supplierid", p.Suppliernumber);
                command.Parameters.AddWithValue("@unit", p.Unit);
                command.Parameters.AddWithValue("@count", p.Count);
                command.Parameters.AddWithValue("@price", p.Price);
                command.Parameters.AddWithValue("@money", p.Money);
                command.Parameters.AddWithValue("@remark",p.Remark);
                command.Parameters.AddWithValue("@dan_date", p.Dan_date);
                command.Parameters.AddWithValue("@status", p.Status);
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
        public   List<rawmaterial> find_all1()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            rawmaterial r = null;
            List<rawmaterial> rs = new List<model.rawmaterial>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawMaterial" ;
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
        public  rawmaterial selectAll(int id)
        { 
           MySqlConnection conn = Util.Util.getConn();  
            MySqlDataReader dataReader = null;  
            MySqlCommand command = null;
            rawmaterial r = new rawmaterial();
            try  
            {  
                command = conn.CreateCommand();  
                command.CommandText = "SELECT * FROM rawMaterial where id ="+id;  
                dataReader =command.ExecuteReader();  
                Console.WriteLine();  
                    while (dataReader.Read())  
                    {
                        r.Id=dataReader.GetInt16(0);
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
        //获取已经存在的最大的单据id
        public int selectMaxdanjuid()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            int id ;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT MAX(id) FROM purchase_danju";
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
        public List<purchaseDanju> selectdate(DateTime t1,DateTime t2,int status)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            purchaseDanju r = null;
            List<purchaseDanju> rs = new List<model.purchaseDanju>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM purchase_danju where date>='"+t1+"' and date<='"+t2+"' and status ="+status;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new purchaseDanju();
                    r.Id = dataReader.GetInt16(0);
                    r.Date = dataReader.GetDateTime(1);
                    r.Danju = dataReader.GetString(2);
                    r.Emploee_id= dataReader.GetString(3);
                    r.Supplier_number = dataReader.GetString(4);
                    r.Money = dataReader.GetDouble(5);
                    r.Remark = dataReader.GetString(6);
                    r.Status = dataReader.GetInt16(7);
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


        public List<purchaseDanju> selectdateAndNum_Supp(string num,int status)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            purchaseDanju r = null;
            List<purchaseDanju> rs = new List<model.purchaseDanju>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM purchase_danju where danju like '%"+num+"%' and status="+status;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new purchaseDanju();
                    r.Id = dataReader.GetInt16(0);
                    r.Date = dataReader.GetDateTime(1);
                    r.Danju = dataReader.GetString(2);
                    r.Emploee_id = dataReader.GetString(3);
                    r.Supplier_number = dataReader.GetString(4);
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
        //根据单据查询购货purchase_material
        public List<purchase_material> selectMaterial_danhao(string danju_number,int status)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            purchase_material r = null;
            List<purchase_material> rs = new List<model.purchase_material>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM purchase_material where danju_id='"+danju_number+"' and status ="+status;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new purchase_material();
                    r.Id = dataReader.GetInt16(0);
                    r.RawMaterial_number= dataReader.GetString(1);
                    r.Suppliernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
                    r.Status= dataReader.GetInt16(9);
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
        //根据日期查询purchase_material表中status为0的数据
        public List<purchase_material> selectMaterial_date(DateTime date1,DateTime date2, int status)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            purchase_material r = null;
            List<purchase_material> rs = new List<model.purchase_material>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM purchase_material where dan_date>='" + date1 + "' and dan_date<='" + date2 + "' and status =" + status;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new purchase_material();
                    r.Id = dataReader.GetInt16(0);
                    r.RawMaterial_number = dataReader.GetString(1);
                    r.Suppliernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
                    r.Status = dataReader.GetInt16(9);
                    r.Danju_id = dataReader.GetString(10);
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
        public List<purchase_material> selectMaterial_dateandrname(DateTime date1, DateTime date2,  string name, int status)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            purchase_material r = null;
            List<purchase_material> rs = new List<model.purchase_material>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM purchase_material where dan_date>='" + date1 + "' and dan_date<='" + date2 + "' and rawMaterial_number=(select rawMaterial_number from rawmaterial where rawMaterial_name like '%"+name+"%') and status =" + status;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new purchase_material();
                    r.Id = dataReader.GetInt16(0);
                    r.RawMaterial_number = dataReader.GetString(1);
                    r.Suppliernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
                    r.Status = dataReader.GetInt16(9);
                    r.Danju_id = dataReader.GetString(10);
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
        public List<purchase_material> selectMaterial_dateandsnumber(DateTime date1, DateTime date2, string supplier_name, int status)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            purchase_material r = null;
            List<purchase_material> rs = new List<model.purchase_material>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM purchase_material where dan_date>='" + date1 + "' and dan_date<='" + date2 + "' and suppliernumber='"+supplier_name+"' and status =" + status;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new purchase_material();
                    r.Id = dataReader.GetInt16(0);
                    r.RawMaterial_number = dataReader.GetString(1);
                    r.Suppliernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
                    r.Status = dataReader.GetInt16(9);
                    r.Danju_id = dataReader.GetString(10);
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
        public List<purchase_material> selectMaterial_dateandrnameandsupplier(DateTime date1, DateTime date2,string suppliernumber, string name, int status)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            purchase_material r = null;
            List<purchase_material> rs = new List<model.purchase_material>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM purchase_material where dan_date>='" + date1 + "' and dan_date<='" + date2 + "' and rawMaterial_number=(select rawMaterial_number from rawmaterial where rawMaterial_name like '%" + name + "%') and suppliernumber='" + suppliernumber + "' and status =" + status;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new purchase_material();
                    r.Id = dataReader.GetInt16(0);
                    r.RawMaterial_number = dataReader.GetString(1);
                    r.Suppliernumber = dataReader.GetString(2);
                    r.Unit = dataReader.GetString(3);
                    r.Count = dataReader.GetDouble(4);
                    r.Price = dataReader.GetDouble(5);
                    r.Money = dataReader.GetDouble(6);
                    r.Remark = dataReader.GetString(7);
                    r.Dan_date = dataReader.GetDateTime(8);
                    r.Status = dataReader.GetInt16(9);
                    r.Danju_id = dataReader.GetString(10);
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
