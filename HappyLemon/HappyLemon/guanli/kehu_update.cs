using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HappyLemon.dao;
using HappyLemon.model;
using MySql.Data.MySqlClient;
using HappyLemon.Util;
namespace HappyLemon.guanli
{
    public partial class kehu_update : Form
    {
        public kehu_update()
        {
            InitializeComponent();
        }
        public kehuguanli n;
        public string number;
        public int j;

        private void kehu_update_Load(object sender, EventArgs e)
        {
               
                Console.Write("！！！！！" + kehuguanli.number);
                model.kehu r = dao.customerDaoz.select(number);
                Number.Text = r.Customer_number;
                Name1.Text = r.Customer_name;
            

            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (Phone.Text == "")
                {
                    MessageBox.Show("电话不能为空！");
                }
                else if(Encoding.Default.GetByteCount(Phone.Text)!=11)
                {
                    MessageBox.Show("电话格式不正确！");
                }
                else if (Address.Text == "")
                {
                    MessageBox.Show("住址不能为空！");
                }
                
                else
                {


                    string msg = "确定修改吗？";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                    {
                        return;
                    }
                    customerDaoz c = new customerDaoz();
                    c.update_customer(number, Phone.Text, Address.Text);
                    n.dataGridView1.Rows[j].Cells[5].Value = Phone.Text;
                    n.dataGridView1.Rows[j].Cells[6].Value = Address.Text;
                    MessageBox.Show("已修改！");
                    this.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("操作有误！");
            }
            finally
            {
            }
        }

        private void Number_TextChanged(object sender, EventArgs e)
        {

        }

        private void Name1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             Phone.Text="";
             Address.Text = "";
        }
    }
}
