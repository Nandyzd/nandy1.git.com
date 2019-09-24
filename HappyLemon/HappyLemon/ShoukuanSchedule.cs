using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HappyLemon.model;
using HappyLemon.dao;
using System.IO;
namespace HappyLemon
{
    public partial class ShoukuanSchedule : Form
    {
        public ShoukuanSchedule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                DataTable dt = new DataTable("table");

                dt.Columns.Add("收款日期", typeof(string));
                dt.Columns.Add("单据号", typeof(string));
                dt.Columns.Add("收款金额", typeof(string));
                dt.Columns.Add("结算方式", typeof(string));
                dt.Columns.Add("备注", typeof(string));
                dt.Columns.Add("客户", typeof(string));
              
                ZijinDao p = new ZijinDao();
                List<Shoukuan> ps = new List<Shoukuan>();

                if (comboBox1.Text == "" )
                {
                    ps = p.selectGet_date(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
                    Console.Write("寇肖萌");
                }
               
                if (comboBox1.Text != "")
                {
                    string[] suppliername = comboBox1.Text.Split(' ');
                    ps = p.selectGet_dateandkehuname(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), suppliername[0]);
                }
                foreach(Shoukuan shou in ps)
                {
                    customer c1 = new customer();
                    customerdao cdao = new customerdao();
                    Console.WriteLine(shou.Get_suppliernumber);
                    c1 = cdao.selectnumber(shou.Get_suppliernumber);
                    Console.WriteLine(shou.Get_money);
                    Console.WriteLine(shou.Get_way);
                    Console.WriteLine(shou.Mark);
                    Console.WriteLine(c1.Customer_name);
                    Console.WriteLine(shou.Date);
                    Console.WriteLine(shou.Get_danjuid);
                    dt.Rows.Add(shou.Date, shou.Get_danjuid,shou.Get_money, shou.Get_way, shou.Mark,c1.Customer_name);

                }
                dataGridView1.DataSource = dt;
                
            }
            catch(SystemException)
            {
               MessageBox.Show("操作不当");
            }
        }

        private void ShoukuanSchedule_Load(object sender, EventArgs e)
        {
            customerdao cdao = new customerdao();
            List<customer> cc = new List<customer>();
            cc = cdao.find_all();
            foreach(customer c in cc)
            {
                comboBox1.Items.Add(c.Customer_number + " " + c.Customer_name);

            }
          
        }
    }
}
