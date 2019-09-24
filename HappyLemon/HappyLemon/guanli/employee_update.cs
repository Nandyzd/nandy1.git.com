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
    public partial class employee_update : Form
    {
        public employee_update()
        {
            InitializeComponent();
        }
        public yuangongguanli n;
        public string number;
        public int j;

        private void employee_update_Load(object sender, EventArgs e)
        {

            Console.Write("！！！！！" + kehuguanli.number);
            model.employee r = dao.employeeDaoz.select(number);
            Number.Text = r.Employee_number;
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(Name1.Text=="")
                {
                    MessageBox.Show("员工姓名不能为空！");
                }
                else if (Phone.Text == "")
                {
                    MessageBox.Show("电话不能为空！");
                }
                else if (Encoding.Default.GetByteCount(Phone.Text) != 11)
                {
                    MessageBox.Show("电话格式不正确！");
                }
                
                else
                {


                    string msg = "确定修改吗？";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                    {
                        return;
                    }
                   employeeDaoz c = new employeeDaoz();
                    c.update_employee(number,Name1.Text, Phone.Text);
                    n.dataGridView1.Rows[j].Cells[4].Value = Name1.Text;
                    n.dataGridView1.Rows[j].Cells[5].Value = Phone.Text;
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
            Name1.Text="";
            Phone.Text="";
        }
    }
}
