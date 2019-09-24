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


namespace HappyLemon.guanli
{
    public partial class addkehu : Form
    {
        
        public kehuguanli k;
        
        public addkehu()
        {
            InitializeComponent();
        }

        private void addkehu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            //可以不执行代码哦

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Number.Text == "")
            {
                MessageBox.Show("客户编码不能为空！");
            }
            else if (Name1.Text == "")
            {
                MessageBox.Show("客户名称不能为空！");
            }

            else if (Phone.Text == "")
            {
                MessageBox.Show("手机号不能为空！");
            }
            else if(Encoding.Default.GetByteCount(Phone.Text)!=11)
            {
                MessageBox.Show("手机号长度不为11！");
            }
            else if (Address.Text == "")
            {
                MessageBox.Show("地址不能为空！");
            }
            else
            {
                string number = Number.Text;
                string name = Name1.Text;
                string phone = Phone.Text;
                string address = Address.Text;
                model.kehu r = new model.kehu();
                r.Phone = phone;
                r.Address = address;
                r.Customer_name = name;
                r.Customer_number = number;
                customerDaoz c = new customerDaoz();
                c.addCustomer(number, name, phone, address);
                Console.Write(c.kehu + "!!");
                if (c.kehu == 0)
                {
                    
                }
                else
                {
                    int node = k.dataGridView1.Rows.Count;
                    k.dt.Rows.Add(node + 1, number, name, phone, address);
                    k.dataGridView1.DataSource = k.dt;
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Number.Text="";
            Name1.Text="";
            Phone.Text="";
            Address.Text="";
        }


    }
}
