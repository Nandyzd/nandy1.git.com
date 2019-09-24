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
namespace HappyLemon.guanli
{
    public partial class supplier_update : Form
    {
        public gongyingshangguanli g;
        public string number;
        public int j;
        public supplier_update()
        {
            InitializeComponent();
        }

        private void supplier_update_Load(object sender, EventArgs e)
        {
            Console.Write("！！！！！" + number);
            model.supplier r = dao.supplierDaoz.select(number);
            Number.Text = r.Supplier_number;
            Name1.Text = r.Supplier_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Name2.Text == "")
                {
                    MessageBox.Show("负责人不能为空！");
                }
                else if (Telephone.Text == "")
                {
                    MessageBox.Show("电话不能为空！");
                }
                else if(Address.Text=="")
                {
                    MessageBox.Show("地址不能为空！");
                }
                else if(Type.Text=="")
                {
                    MessageBox.Show("类型不能为空！");
                }
                else
                {


                    string msg = "确定修改吗？";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                    {
                        return;
                    }
                    supplierDaoz c = new supplierDaoz();
                    c.update_supplier(number,Name2.Text,Telephone.Text, Address.Text,Type.Text);
                    g.dataGridView1.Rows[j].Cells[5].Value = Name2.Text;
                    g.dataGridView1.Rows[j].Cells[6].Value = Telephone.Text;
                    g.dataGridView1.Rows[j].Cells[7].Value = Address.Text;
                    g.dataGridView1.Rows[j].Cells[8].Value = Type.Text;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Name2.Text="";
            Telephone.Text="";
            Address.Text="";
            Type.Text = "";
        }
    }
}
