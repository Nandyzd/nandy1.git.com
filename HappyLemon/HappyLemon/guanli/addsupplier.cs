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
    public partial class addsupplier : Form
    {
        public gongyingshangguanli k;
        public addsupplier()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Number.Text="";
           Name1.Text="";
            Name2.Text="";
            Telephone.Text="";
             Address.Text="";
             Type.Text="";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Number.Text == "")
            {
                MessageBox.Show("供应商编号不能为空！");
            }
            else if (Name1.Text == "")
            {
                MessageBox.Show("供应商姓名不能为空！");
            }
            else if (Name2.Text == "")
            {
                MessageBox.Show("负责人姓名不能为空！");
            }
            else if (Telephone.Text == "")
            {
                MessageBox.Show("电话不能为空！");
            }
            else if(Encoding.Default.GetByteCount(Telephone.Text)!=11)
            {
                MessageBox.Show("电话号码长度不为11！");
            }
            else if (Address.Text == "")
            {
                MessageBox.Show("地址不能为空！");
            }
            else if (Type.Text == "")
            {
                MessageBox.Show("类型不能为空！");
            }
            else
            {
                string number = Number.Text;
                string name1 = Name1.Text;
                string name2 = Name2.Text;
                string telephone = Telephone.Text;
                string address = Address.Text;
                string type = Type.Text;
                supplierDaoz c = new supplierDaoz();
                c.addSupplier(number, name1, name2, telephone, address, type);
                Console.Write(c.su + "!!!!");
                if (c.su == 0)
                {

                }
                else
                {
                    int node = k.dataGridView1.Rows.Count;
                    Console.Write("行数：" + node);
                    k.dt.Rows.Add(node + 1, number, name1, name2, telephone, address, type);
                    k.dataGridView1.DataSource = k.dt;
                    this.Close();
                }
            }

        }

        private void addsupplier_Load(object sender, EventArgs e)
        {

        }
    }
}
