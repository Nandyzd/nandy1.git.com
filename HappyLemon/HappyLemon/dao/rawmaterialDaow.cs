using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//链接数据库需导的包
using MySql.Data.MySqlClient;
using HappyLemon.model;


namespace HappyLemon.dao
{
    class rawmaterialDaow//原材料的数据库操作
    {
       
        public static List<rawmaterial> find_all()//查询出所有的原材料信息
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<rawmaterial> rs = new List<rawmaterial>(); ;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawmaterial";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
              
                while (dataReader.Read())
                {
                    rawmaterial r = new rawmaterial();
                    r.Id = dataReader.GetInt16(0);
                    r.Rawmaterial_number = dataReader.GetString(1);
                    r.Rawmaterial_name = dataReader.GetString(2);
                    r.Rawmaterial_type = dataReader.GetString(3);
                    r.Rawmaterial_count = dataReader.GetDouble(4);
                    r.Rawmaterial_unit = dataReader.GetString(5);
                    rs.Add(r);

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

        public static List<rawmaterial> find_all2(string rawMaterial_type)//按类别查询出所有的原材料信息
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<rawmaterial> rs = new List<rawmaterial>(); ;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawmaterial where rawMaterial_type like '%" + rawMaterial_type+"%'";
                dataReader = command.ExecuteReader();
                Console.WriteLine("sql:"+ command.CommandText);

                while (dataReader.Read())
                {
                    rawmaterial r = new rawmaterial();
                    r.Id = dataReader.GetInt16(0);
                    r.Rawmaterial_number = dataReader.GetString(1);
                    r.Rawmaterial_name = dataReader.GetString(2);
                    r.Rawmaterial_type = dataReader.GetString(3);
                    r.Rawmaterial_count = dataReader.GetDouble(4);
                    r.Rawmaterial_unit = dataReader.GetString(5);
                    rs.Add(r);

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


    
        //向盘点表增加一次盘点信息
        public static bool add_pandian(string date)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;
           
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO inventory(date) VALUES('"+date+"')";
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }
        public static int find_pandianId(string date)//查询出盘点表的id
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            int id = 0; 
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT id FROM inventory where date='" + date + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
               
                while (dataReader.Read())
                {
                    id = dataReader.GetInt16(0);
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
            return id;
        }
        //向盘点表增加一次盘点信息
        public static bool add_pandian(inventory_rawmaterial r)
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO inventory_rawmaterial(id,rawMaterial_number,"+
                "system_stock,inventory_stock,result) VALUES(" + r.Id + ",'"+r.RawMaterial_number+
                "',"+r.System_stock+","+r.Inventory_stock+",'"+r.Result+"')";
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }
        public static List<int> find_inventory(string time)//查询根据事件查询盘点的id
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<int> ids = null; 
            try
            {
                command = conn.CreateCommand();
                string sql="SELECT id FROM inventory where date  like '%"+time+"%'";
                Console.WriteLine("sql:"+sql);
                command.CommandText = sql;
                dataReader = command.ExecuteReader();
                int i = 0;

                while (dataReader.Read())
                {
                    if (i == 0)
                    {
                        ids = new List<int>(); 
                    }
                    ids.Add(dataReader.GetInt16(0));
                    i++;

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
 
            return ids;
        }

        public static List<temp> find_inventory2(string time,string type,  bool lingkucun,string name)//查询符合条件的原材料
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<int> ids = find_inventory(time);
            bool youshijian=true;//在该时间内有过盘点
           
            if (ids == null)
            {
                youshijian = false;
            }
            if (youshijian == true)
            {
               
                List<temp> temps = new List<temp>();
                try
                {
                    command = conn.CreateCommand();
                    string sql= "SELECT inventory_rawmaterial.rawMaterial_number,inventory_rawmaterial.system_stock," +
                         "inventory_rawmaterial.inventory_stock,inventory_rawmaterial.result,rawmaterial.rawMaterial_name," +
                            "rawmaterial.rawMaterial_number,rawmaterial.rawMaterial_type,rawmaterial.rawMaterial_unit" +
                              "  FROM inventory_rawmaterial" +
                               "  JOIN rawmaterial ON" +
                                 "  inventory_rawmaterial.rawMaterial_number = rawmaterial.rawMaterial_number where ";
                    int i=0;
                    foreach(int id in ids){
                     if(i==0){
                         sql = sql + "  (inventory_rawmaterial.id=" + id;
                     }
                     else
                     {
                         sql = sql + "  or  inventory_rawmaterial.id=" + id;
                     }
                     i++;
                    }
                    sql = sql + ")";
                    if (type != "")
                    {
                        sql = sql + "  and  rawmaterial.rawMaterial_type='" + type+"' ";
                    }
                    if (lingkucun == true)
                    {
                        
                        sql = sql + "  and  inventory_rawmaterial.system_stock=0 ";
                    }
                    if (name != "")
                    {
                        sql = sql + "  and rawmaterial.rawMaterial_name='" + name + "' ";
                    }
                    Console.WriteLine("sql:" + sql);
                    command.CommandText = sql;
                    dataReader = command.ExecuteReader();
                   
                    while (dataReader.Read())
                    {
                        temp r = new temp();
                        r.Rawmaterial_name = dataReader.GetString("rawMaterial_name");
                        r.Rawmaterial_type = dataReader.GetString("rawMaterial_type");
                        r.Rawmaterial_unit = dataReader.GetString("rawMaterial_unit");
                        r.RawMaterial_number = dataReader.GetString("rawMaterial_number");
                        r.System_stock = dataReader.GetInt16("system_stock");
                        r.Inventory_stock = dataReader.GetInt16("inventory_stock");
                        r.Result = dataReader.GetString("result");
                        temps.Add(r);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    /**if (!dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }**/
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                return temps;
            }
            else
            {
                return null;
            }
            
        }
        public static rawmaterial find_oneRawmaterial(string number)//入库时根据商品编号查询原材料
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            rawmaterial r = null; 
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawmaterial where rawMaterial_number='"+number+"'";
                Console.WriteLine("sql:" + command.CommandText);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    r = new rawmaterial();
                    r.Id = dataReader.GetInt16(0);
                    r.Rawmaterial_number = dataReader.GetString("rawMaterial_number");
                    r.Rawmaterial_name = dataReader.GetString("rawMaterial_name");
                    r.Rawmaterial_type = dataReader.GetString("rawMaterial_type");
                    r.Rawmaterial_unit = dataReader.GetString("rawMaterial_unit");
                   

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


        public static rawmaterial find_oneRawmaterial2(string number)//出库时根据商品编号查询原材料
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            rawmaterial r = null;
            try
            {
                

                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM rawmaterial where rawMaterial_number='" + number + "'";
                 Console.WriteLine("sql:" + command.CommandText);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    r = new rawmaterial();
                    r.Id = dataReader.GetInt16(0);
                    r.Rawmaterial_number = dataReader.GetString("rawMaterial_number");
                    r.Rawmaterial_name = dataReader.GetString("rawMaterial_name");
                    r.Rawmaterial_type = dataReader.GetString("rawMaterial_type");
                    r.Rawmaterial_unit = dataReader.GetString("rawMaterial_unit");
                    r.Rawmaterial_count = dataReader.GetDouble("rawMaterial_count");
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


        public static bool add_rawmaterial(model.rawmaterial r)//入库时添加原材料
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO rawmaterial(rawMaterial_number,rawMaterial_name,"+
                "rawMaterial_type,rawMaterial_count,rawMaterial_unit) VALUES('"
                    +r.Rawmaterial_number+ "','" + r.Rawmaterial_name+ "','" +
                        r.Rawmaterial_type + "'," +r.Rawmaterial_count + ",'"+r.Rawmaterial_unit+"')";
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }

        public static bool update_rawmaterialCount(model.rawmaterial r)//入库时在原材料添加时增加数量
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "update rawmaterial  set rawMaterial_count = rawMaterial_count+" +r.Rawmaterial_count+
                "  where rawMaterial_number='"+ r.Rawmaterial_number + "'" ;
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }

        public static bool update_rawmaterialCount2(model.rawmaterial r)//出库时在原材料添加时减少数量
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "update rawmaterial  set rawMaterial_count = rawMaterial_count-" + r.Rawmaterial_count +
                "  where rawMaterial_number='" + r.Rawmaterial_number + "'";
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }


        public static bool add_instock(model.instock_rawmaterial r)//入库时向入库表添加数据
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO instock_rawmaterial(rawMaterial_number,rawMaterial_supplier," +
                "rawMaterial_count,rawMaterial_danjia,rawMaterial_money,mark,danju_number) VALUES('"
                    + r.RawMaterial_number + "','" + r.RawMaterial_supplier + "'," +
                        r.RawMaterial_count + "," +r.RawMaterial_danjia+","+r.RawMaterial_money+",'"+ r.Mark + "','"+r.Danju_number+"')";
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }

        public static bool add_outstock(model.outstock_rawmaterial r)//出库时向出库表添加数据
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO outstock_rawmaterial(rawMaterial_number,rawMaterial_supplier," +
                "rawMaterial_count,rawMaterial_danjia,rawMaterial_money,mark,danju_number) VALUES('"
                    + r.RawMaterial_number + "','" + r.RawMaterial_supplier + "'," +
                        r.RawMaterial_count + "," + r.RawMaterial_danjia + "," + r.RawMaterial_money + ",'" + r.Mark + "','" + r.Danju_number + "')";
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }


        public static bool add_instockOrder(model.instock_order r)//入库时向入库单表添加数据
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO instock_order(date,danju_number) VALUES('"
                    + r.Date + "','" + r.Danju_number + "')";
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }

        public static bool add_outstockOrder(model.outstock_order r)//入库时向入库单表添加数据
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO outstock_order(date,danju_number) VALUES('"
                    + r.Date + "','" + r.Danju_number + "')";
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }

        public static List<string> find_outDanju(string time)//出库单查询
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<string> ids = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "SELECT danju_number FROM outstock_order where date='" + time + "'";
                Console.WriteLine("sql:" + sql);
                command.CommandText = sql;
                dataReader = command.ExecuteReader();
                int i = 0;

                while (dataReader.Read())
                {
                    if (i == 0)
                    {
                        ids = new List<string>();
                    }
                    ids.Add(dataReader.GetString(0));
                    i++;

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
            return ids;
        }
        public static List<temp2> find_outstock(string time, string type, string danju)//查询符合条件的原材料
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<string> danjus = find_outDanju(time);
            bool youshijian = true;//在该时间内有过盘点

            if (danjus == null)
            {
               
                youshijian = false;
            }
            if (youshijian == true)
            {

                List<temp2> temps = new List<temp2>();
                try
                {
                    command = conn.CreateCommand();
                    string sql = "SELECT outstock_rawmaterial.rawMaterial_supplier,outstock_rawmaterial.rawMaterial_count," +
                         "outstock_rawmaterial.rawMaterial_danjia,outstock_rawmaterial.rawMaterial_money,outstock_rawmaterial.mark,outstock_rawmaterial.danju_number,rawmaterial.rawMaterial_name," +
                            "rawmaterial.rawMaterial_number,rawmaterial.rawMaterial_type,rawmaterial.rawMaterial_unit" +
                              "  FROM outstock_rawmaterial" +
                               "  JOIN rawmaterial ON" +
                                 "  outstock_rawmaterial.rawMaterial_number = rawmaterial.rawMaterial_number where ";
                    if (danju != "")
                    {
                        sql = sql + " outstock_rawmaterial.danju_number='" + danju + "' ";
                    }
                    else
                    {
                        int i = 0;
                        foreach (string danju1 in danjus)
                        {
                           
                            if (i == 0)
                            {
                                sql = sql + "  (outstock_rawmaterial.danju_number='" + danju1+"'  ";
                            }
                            else
                            {
                                sql = sql + "  or  outstock_rawmaterial.danju_number='" + danju1+"' ";
                            }
                            i++;
                        }
                        sql = sql + ")";
                    }
                    if (type != "")
                    {
                        sql = sql + "  and  rawmaterial.rawMaterial_type like '%" + type + "%' ";
                    }
                   
                    Console.WriteLine("sql:" + sql);
                    command.CommandText = sql;
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                       
                        temp2 r = new temp2();
                        r.Rawmaterial_name = dataReader.GetString("rawMaterial_name");
                        r.Rawmaterial_type = dataReader.GetString("rawMaterial_type");
                        r.Rawmaterial_unit = dataReader.GetString("rawMaterial_unit");
                     
                        r.Mark = dataReader.GetString("mark");
                        
                        r.Danju_number = dataReader.GetString("danju_number");;
                        r.Rawmaterial_number = dataReader.GetString("rawMaterial_number");
                        r.RawMaterial_supplier = dataReader.GetString("rawMaterial_supplier");
                        r.RawMaterial_money = dataReader.GetDouble("rawMaterial_money");
                      
                        r.RawMaterial_count = dataReader.GetDouble("rawMaterial_count");
                      
                        r.RawMaterial_danjia = dataReader.GetDouble("rawMaterial_danjia");
                        
                        temps.Add(r);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    /**if (!dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }**/
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                return temps;
            }
            else
            {
                return null;
            }

        }

        public static List<string> find_inDanju(string time)//出库单查询
        {
            MySqlConnection conn = Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<string> ids = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "SELECT danju_number FROM instock_order where date='" + time + "'";
                Console.WriteLine("sql:" + sql);
                command.CommandText = sql;
                dataReader = command.ExecuteReader();
                int i = 0;

                while (dataReader.Read())
                {
                    if (i == 0)
                    {
                        ids = new List<string>();
                    }
                    ids.Add(dataReader.GetString(0));
                    i++;

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
            return ids;
        }

        public static List<temp2> find_instock(string time, string type, string danju)//查询符合条件的原材料
        {
            MySqlConnection conn =Util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<string> danjus = find_inDanju(time);
            bool youshijian = true;//在该时间内有过盘点

            if (danjus == null)
            {
               
                youshijian = false;
            }
            if (youshijian == true)
            {

                List<temp2> temps = new List<temp2>();
                try
                {
                    command = conn.CreateCommand();
                    string sql = "SELECT instock_rawmaterial.rawMaterial_supplier,instock_rawmaterial.rawMaterial_count," +
                         "instock_rawmaterial.rawMaterial_danjia,instock_rawmaterial.rawMaterial_money,instock_rawmaterial.mark,instock_rawmaterial.danju_number,rawmaterial.rawMaterial_name," +
                            "rawmaterial.rawMaterial_number,rawmaterial.rawMaterial_type,rawmaterial.rawMaterial_unit" +
                              "  FROM instock_rawmaterial" +
                               "  JOIN rawmaterial ON" +
                                 "  instock_rawmaterial.rawMaterial_number = rawmaterial.rawMaterial_number where ";
                    if (danju != "")
                    {
                        sql = sql + " instock_rawmaterial.danju_number='" + danju + "' ";
                    }
                    else
                    {
                        int i = 0;
                        foreach (string danju1 in danjus)
                        {

                            if (i == 0)
                            {
                                sql = sql + "  (instock_rawmaterial.danju_number='" + danju1 + "'  ";
                            }
                            else
                            {
                                sql = sql + "  or  instock_rawmaterial.danju_number='" + danju1 + "' ";
                            }
                            i++;
                        }
                        sql = sql + ")";
                    }
                    if (type != "")
                    {
                        sql = sql + "  and  rawmaterial.rawMaterial_type='" + type + "' ";
                    }

                    Console.WriteLine("sql:" + sql);
                    command.CommandText = sql;
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {

                        temp2 r = new temp2();
                        r.Rawmaterial_name = dataReader.GetString("rawMaterial_name");
                        r.Rawmaterial_type = dataReader.GetString("rawMaterial_type");
                        r.Rawmaterial_unit = dataReader.GetString("rawMaterial_unit");
                       
                        r.Mark = dataReader.GetString("mark");

                        r.Danju_number = dataReader.GetString("danju_number"); ;
                        r.Rawmaterial_number = dataReader.GetString("rawMaterial_number");
                        r.RawMaterial_supplier = dataReader.GetString("rawMaterial_supplier");
                        r.RawMaterial_money = dataReader.GetDouble("rawMaterial_money");

                        r.RawMaterial_count = dataReader.GetDouble("rawMaterial_count");
                      
                        r.RawMaterial_danjia = dataReader.GetDouble("rawMaterial_danjia");

                        temps.Add(r);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    /**if (!dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }**/
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                return temps;
            }
            else
            {
                return null;
            }

        }

    }
}
