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
namespace HappyLemon.guanli
{
    public partial class addemployee : Form
    {
        public yuangongguanli k;
        public addemployee()
        {
            InitializeComponent();
        }

        private void addemployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Number.Text == "")
            {
                MessageBox.Show("员工编码不能为空！");
            }
            else if (Name1.Text == "")
            {
                MessageBox.Show("员工名称不能为空！");
            }

            else if (Phone.Text == "")
            {
                MessageBox.Show("手机号不能为空！");
            }
            else if (Encoding.Default.GetByteCount(Phone.Text) != 11)
            {
                MessageBox.Show("手机号长度不为11！");
            }
            
            else
            {
                string number = Number.Text;
                string name = Name1.Text;
                string phone = Phone.Text;

                model.employee r = new model.employee();
                
                 employeeDaoz c = new employeeDaoz();
                c.addEmployee(number, name, phone);
                Console.Write(c.kehu + "!!");
                if (c.kehu == 0)
                {
                   
                }
                else
                {
                    int node = k.dataGridView1.Rows.Count;
                    k.dt.Rows.Add(node + 1, number, name, phone);
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
        }
    }
}
