using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using HappyLemon.Util;
using System.Windows.Forms;
namespace HappyLemon.dao
{
    class employeeDaoz
    {
        public int kehu = 1;
        public void addEmployee(string number, string name, string phone)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = new MySqlCommand();
            MySqlCommand command1 = new MySqlCommand();
            try
            {
                Console.Write(number);
                Console.Write(name);
                Console.Write(phone);
                
                command = conn.CreateCommand();

                command.CommandText = "select * from employee where employee_number='" + number + "'";
                command.ExecuteNonQuery();
                if (Convert.ToInt32(command.ExecuteScalar()) != 0)
                {
                    this.kehu = 0;
                    MessageBox.Show("员工已存在！");
                }
                else
                {
                    Console.Write("wuwuwuwuwu!");
                    command1 = conn.CreateCommand();
                    command1.CommandText = "INSERT INTO employee(employee_number,employee_name,phone) VALUES(@employee_number,@employee_name,@phone)";
                    command1.Parameters.AddWithValue("@employee_number", number);
                    command1.Parameters.AddWithValue("@employee_name", name);
                    command1.Parameters.AddWithValue("@phone", phone);
                   
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
        public static List<model.employee> find_all()//查询出所有客户
        {
           
                MySqlConnection conn = Util.Util.getConn();
                String sql = "select * from employee";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                Console.WriteLine("ds:" + ds);
                da.Fill(ds);
                conn.Close();
                //获得DataSet里的数据
                List<model.employee> rs = new List<model.employee>();
                try
                {
                if (ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)//判断DataSet里是否有值
                {
                    rs = new List<model.employee>();
                    int count = ds.Tables[0].Rows.Count;//获得表的行数
                    for (int i = 0; i < count; i++)
                    {
                        model.employee r = new model.employee();
                        r.Id = (int)ds.Tables[0].Rows[i]["id"];
                        r.Employee_name = (string)ds.Tables[0].Rows[i]["employee_name"];
                        r.Employee_number = (string)ds.Tables[0].Rows[i]["employee_number"];
                        r.Phone = (string)ds.Tables[0].Rows[i]["phone"];


                        rs.Add(r);

                    }
                }
               
            }
            catch
            {
                MessageBox.Show("查询出错！");
            }
                return rs;
        }
        public static List<model.employee> selectAll(String number)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.employee> kehus = new List<model.employee>();
            model.employee r = new model.employee();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM employee where employee_number='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Employee_number = dataReader.GetString(1);
                    r.Employee_name = dataReader.GetString(2);
                    r.Phone = dataReader.GetString(3);
                    
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
        public void update_employee(String number, String name, String phone)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "update employee set employee_name='" + name + "',phone='" +
                        phone + "' where employee_number='" +
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
        public static model.employee select(String number)//按编号查询
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<model.employee> kehus = new List<model.employee>();
            model.employee r = new model.employee();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM employee where employee_number='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Id = dataReader.GetInt16(0);
                    r.Employee_number = dataReader.GetString(1);
                    r.Employee_name = dataReader.GetString(2);
                    r.Phone = dataReader.GetString(3);
                 

                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("操作有误！");
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
                string sql = "delete from employee where employee_number='" + name + "'";
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
