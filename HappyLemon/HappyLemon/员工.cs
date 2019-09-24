using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyLemon
{
    public partial class 员工 : Form
    {
        public DataGridView data = new DataGridView();
        public 员工()
        {
            InitializeComponent();
        }

        private void 员工_Load(object sender, EventArgs e)
        {
            try
            {
                dao.employeedaow s = new dao.employeedaow();
                List<model.employee> ss = new List<model.employee>();
                ss = s.find_all();
                Console.Write(ss);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");

                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("姓名", typeof(string));
                dt.Columns.Add("电话", typeof(string));
                int i = 0;
                foreach (model.employee s1 in ss)
                {

                    dt.Rows.Add(s1.Employee_number, s1.Employee_name, s1.Phone);
                    i++;
                }
                dataGridView1.DataSource = dt;
                foreach (DataGridViewColumn co in dataGridView1.Columns)
                {
                    if (co.Index != 0)
                        co.ReadOnly = true;
                }
                data = dataGridView1;
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string number = textBox1.Text;
                string name = textBox2.Text;
                dao.employeedaow s = new dao.employeedaow();
                List<model.employee> ss = new List<model.employee>();
                ss = s.find_all2(number, name);
                Console.Write(ss);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");

                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("姓名", typeof(string));
                dt.Columns.Add("电话", typeof(string));
                int i = 0;
                foreach (model.employee s1 in ss)
                {

                    dt.Rows.Add(s1.Employee_number, s1.Employee_name, s1.Phone);
                    i++;
                }
                dataGridView1.DataSource = dt;
                foreach (DataGridViewColumn co in dataGridView1.Columns)
                {
                    if (co.Index != 0)
                        co.ReadOnly = true;
                }
                data = dataGridView1;
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                int xuanzhong = 0;//选中的个数
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    x++;

                    if (Convert.ToBoolean(this.data.Rows[i].Cells[0].Value) == true)
                    {
                        xuanzhong++;
                        {
                            出库单.kehu = data.Rows[i].Cells[1].Value.ToString() + " " + data.Rows[i].Cells[2].Value.ToString();
                        }
                    }

                    if (xuanzhong > 1)
                    {
                        MessageBox.Show("只能选择一个供应商！");
                    }
                }
                if (xuanzhong == 1)
                {
                    if (x == data.Rows.Count)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误");
            }
        }
    }
}
