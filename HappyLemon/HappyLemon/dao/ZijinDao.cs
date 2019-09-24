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
    class ZijinDao
    {
        public void addShoukuandan(Shoukuan p)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
            try
            {
                command=conn.CreateCommand();
                command.CommandText = "INSERT INTO get_money(get_zhanghu,get_money,get_way,mark,get_suppliernumber,employee_number,date,get_danjuid) VALUES(@get_zhanghu,@get_money,@get_way,@mark,@get_suppliernumber,@employee_number,@date,@get_danjuid)";
                command.Parameters.AddWithValue("@get_zhanghu", p.Get_zhanghu);
                command.Parameters.AddWithValue("@get_money", p.Get_money);
                command.Parameters.AddWithValue("@get_way", p.Get_way);
                command.Parameters.AddWithValue("@mark", p.Mark);
                command.Parameters.AddWithValue("@get_suppliernumber", p.Get_suppliernumber);
                command.Parameters.AddWithValue("@employee_number", p.Employee_number);
                command.Parameters.AddWithValue("@date", p.Date);
                command.Parameters.AddWithValue("@get_danjuid", p.Get_danjuid);
                command.ExecuteNonQuery();
                //MessageBox.Show("插入成功");
            }
            catch(Exception)
            {
                MessageBox.Show("插入失败");
            }

            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public void addFukuandan(Fukuan p)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO payfor_money(payfor_zhanghu,payfor_money,payfor_way,mark,payfor_suppliernumber,employee_number,date,payfor_danjuid) VALUES(@payfor_zhanghu,@payfor_money,@payfor_way,@mark,@payfor_suppliernumber,@employee_number,@date,@payfor_danjuid)";
                command.Parameters.AddWithValue("@payfor_zhanghu", p.Payfor_zhanghu);
                command.Parameters.AddWithValue("@payfor_money", p.Payfor_money);
                command.Parameters.AddWithValue("@payfor_way", p.Payfor_way);
                command.Parameters.AddWithValue("@mark", p.Mark);
                command.Parameters.AddWithValue("@payfor_suppliernumber", p.Payfor_suppliernumber);
                command.Parameters.AddWithValue("@employee_number", p.Employee_number);
                command.Parameters.AddWithValue("@date", p.Date);
                command.Parameters.AddWithValue("@payfor_danjuid", p.Payfor_danjuid);
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
        public void addTuikuandan(Tuikuan p)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO tuikuan_money(tuikuan_zhanghu,tuikuan_money,tuikuan_way,mark,tuikuan_suppliernumber,employee_number,date,tuikuan_danjuid) VALUES(@tuikuan_zhanghu,@tuikuan_money,@tuikuan_way,@mark,@tuikuan_suppliernumber,@employee_number,@date,@tuikuan_danjuid)";
                command.Parameters.AddWithValue("@tuikuan_zhanghu", p.Tuikuan_zhanghu);
                command.Parameters.AddWithValue("@tuikuan_money", p.Tuikuan_money);
                command.Parameters.AddWithValue("@tuikuan_way", p.Tuikuan_way);
                command.Parameters.AddWithValue("@mark", p.Mark);
                command.Parameters.AddWithValue("@tuikuan_suppliernumber", p.Tuikuan_suppliernumber);
                command.Parameters.AddWithValue("@employee_number", p.Employee_number);
                command.Parameters.AddWithValue("@date", p.Date);
                command.Parameters.AddWithValue("@tuikuan_danjuid", p.Tuikuan_danjuid);
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
        public int selectMaxget_moneyid()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            int id;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT MAX(id) FROM get_money";
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

        public int selectMaxpayfor_moneyid()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            int id;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT MAX(id) FROM payfor_money";
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


        public int selectMaxtuikuan_moneyid()
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            int id;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT MAX(id) FROM tuikuan_money";
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
//收款单明细查询函数
        //按照单据日期查询
        public List<Shoukuan> selectGet_date(DateTime date1,DateTime date2)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Shoukuan shou = null;
            List<Shoukuan> rs = new List<model.Shoukuan>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText="SELECT * FROM get_money where date>='"+date1+"'and date<='"+date2+"'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while(dataReader.Read())
                {
                    shou = new Shoukuan();
                    shou.Id = dataReader.GetInt16(0);
                    shou.Get_zhanghu = dataReader.GetString(1);
                    shou.Get_money = dataReader.GetString(2);
                    shou.Get_way = dataReader.GetString(3);
                    shou.Mark = dataReader.GetString(4);
                    shou.Get_suppliernumber = dataReader.GetString(5);
                    shou.Employee_number = dataReader.GetString(6);
                    shou.Date = dataReader.GetDateTime(7);
                    shou.Get_danjuid = dataReader.GetString(8);
                    rs.Add(shou);
                }
            }
            catch(Exception)
            {

}
            finally
            {
               if(!dataReader.IsClosed)
               {
                    dataReader.Close();
                }
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rs;
        }
       
        //按照单据日期和客户查询
        public List<Shoukuan> selectGet_dateandkehuname(DateTime date1, DateTime date2,string customer_name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Shoukuan shou = null;
            List<Shoukuan> rs = new List<model.Shoukuan>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText="SELECT * FROM get_money where date>='"+date1+"'and date<='"+date2+"'and get_suppliernumber='"+customer_name+"'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while(dataReader.Read())
                {
                    shou = new Shoukuan();
                    shou.Id = dataReader.GetInt16(0);
                    shou.Get_zhanghu = dataReader.GetString(1);
                    shou.Get_money = dataReader.GetString(2);
                    shou.Get_way = dataReader.GetString(3);
                    shou.Mark = dataReader.GetString(4);
                    shou.Get_suppliernumber = dataReader.GetString(5);
                    shou.Employee_number = dataReader.GetString(6);
                    shou.Date = dataReader.GetDateTime(7);
                    shou.Get_danjuid = dataReader.GetString(8);
                    rs.Add(shou);
                }
            }
            catch(Exception)
            {

            }
            finally
            {
                if(!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rs;
        }
        public int selectGet_date1(DateTime date1, DateTime date2)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Shoukuan shou = null;
            Int16 sumget_money=0;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT sum(get_money)  FROM get_money where date>='" + date1 + "'and date<='" + date2 + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                     sumget_money = dataReader.GetInt16(0);
                   
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
            return sumget_money;
        }

//付款单明细查询


        //按照单据日期查询
        public List<Fukuan> selectPayfor_date(DateTime date1, DateTime date2)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Fukuan fu = null;
            List<Fukuan> rs = new List<model.Fukuan>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM payfor_money where date>='" + date1 + "'and date<='" + date2 + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                    fu = new Fukuan();
                    fu.Id = dataReader.GetInt16(0);
                    fu.Payfor_zhanghu = dataReader.GetString(1);
                    fu.Payfor_money = dataReader.GetString(2);
                    fu.Payfor_way = dataReader.GetString(3);
                    fu.Mark = dataReader.GetString(4);
                    fu.Payfor_suppliernumber = dataReader.GetString(5);
                    fu.Employee_number = dataReader.GetString(6);
                    fu.Date = dataReader.GetDateTime(7);
                    fu.Payfor_danjuid = dataReader.GetString(8);
                    rs.Add(fu);
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

        //按照单据日期和客户查询
        public List<Fukuan> selectPayfor_dateandkehuname(DateTime date1, DateTime date2, string supplier_name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Fukuan fu = null;
            List<Fukuan> rs = new List<model.Fukuan>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM payfor_money where date>='" + date1 + "'and date<='" + date2 + "'and payfor_suppliernumber='" + supplier_name + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    fu = new Fukuan();
                    fu.Id = dataReader.GetInt16(0);
                    fu.Payfor_zhanghu = dataReader.GetString(1);
                    fu.Payfor_money = dataReader.GetString(2);
                    fu.Payfor_way = dataReader.GetString(3);
                    fu.Mark = dataReader.GetString(4);
                    fu.Payfor_suppliernumber = dataReader.GetString(5);
                    fu.Employee_number = dataReader.GetString(6);
                    fu.Date = dataReader.GetDateTime(7);
                    fu.Payfor_danjuid = dataReader.GetString(8);
                    rs.Add(fu);
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


        public int selectPayfor_date1(DateTime date1, DateTime date2)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Fukuan fu = null;
            Int16 sumpayfor_money=0;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT sum(payfor_money) FROM payfor_money where date>='" + date1 + "'and date<='" + date2 + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                    sumpayfor_money = dataReader.GetInt16(0);
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
            return sumpayfor_money ;
        }

//退款单明细查询

        //按照单据日期查询
        public List<Tuikuan> selectTuikuan_date(DateTime date1, DateTime date2)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Tuikuan tui = null;
            List<Tuikuan> rs = new List<model.Tuikuan>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM tuikuan_money where date>='" + date1 + "'and date<='" + date2 + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                    tui = new Tuikuan();
                    tui.Id = dataReader.GetInt16(0);
                    tui.Tuikuan_zhanghu = dataReader.GetString(1);
                    tui.Tuikuan_money = dataReader.GetString(2);
                    tui.Tuikuan_way = dataReader.GetString(3);
                    tui.Mark = dataReader.GetString(4);
                    tui.Tuikuan_suppliernumber = dataReader.GetString(5);
                    tui.Employee_number = dataReader.GetString(6);
                    tui.Date = dataReader.GetDateTime(7);
                    tui.Tuikuan_danjuid = dataReader.GetString(8);
                    rs.Add(tui);
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

        //按照单据日期和客户查询
        public List<Tuikuan> selectTuikuan_dateandkehuname(DateTime date1, DateTime date2, string supplier_name)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Tuikuan tui = null;
            List<Tuikuan> rs = new List<model.Tuikuan>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM tuikuan_money where date>='" + date1 + "'and date<='" + date2 + "'and payfor_suppliernumber='" + supplier_name + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    tui = new Tuikuan();
                    tui.Id = dataReader.GetInt16(0);
                    tui.Tuikuan_zhanghu = dataReader.GetString(1);
                    tui.Tuikuan_money = dataReader.GetString(2);
                    tui.Tuikuan_way = dataReader.GetString(3);
                    tui.Mark = dataReader.GetString(4);
                    tui.Tuikuan_suppliernumber = dataReader.GetString(5);
                    tui.Employee_number = dataReader.GetString(6);
                    tui.Date = dataReader.GetDateTime(7);
                    tui.Tuikuan_danjuid = dataReader.GetString(8);
                    rs.Add(tui);
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

        public int selectTuikuan_date1(DateTime date1, DateTime date2)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Tuikuan tui = null;
            Int16 sumtuikuan_money=0;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT sum(tuikuan_money) FROM tuikuan_money where date>='" + date1 + "'and date<='" + date2 + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                     sumtuikuan_money = dataReader.GetInt16(0);
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
            return sumtuikuan_money;
        }
    }
}
