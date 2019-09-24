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
    public partial class yuangongguanli : Form
    {
        public yuangongguanli()
        {
            InitializeComponent();
        }
        public static string number;
        public static int j;
        public DataTable dt = new DataTable("teble");
       
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void yuangongguanli_Load(object sender, EventArgs e)
        {
            try
            {

                
                dt.Columns.Add("序号", typeof(string));
                dt.Columns.Add("员工编号", typeof(string));
                dt.Columns.Add("员工姓名", typeof(string));
                dt.Columns.Add("员工电话", typeof(string));
               

                List<employee> kehus = new List<employee>();
                kehus = dao.employeeDaoz.find_all();
                int q = 1;
                foreach (employee k in kehus)
                {

                    dt.Rows.Add(q, k.Employee_number, k.Employee_name, k.Phone);
                    q++;
                }
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("无数据！");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {


            DataTable dt1 = new DataTable("teble");
                dt1.Columns.Add("序号", typeof(int));
                dt1.Columns.Add("员工编号", typeof(string));
                dt1.Columns.Add("员工姓名", typeof(string));
                dt1.Columns.Add("员工电话", typeof(string));

                int i=1;
                List<employee> kehus = new List<employee>();
                kehus = dao.employeeDaoz.selectAll(textBox1.Text);
                foreach (employee k in kehus)
                {

                    dt1.Rows.Add(i, k.Employee_number, k.Employee_name, k.Phone);
                    i++;
                }
                dataGridView1.DataSource = dt1;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            guanli.addemployee a = new guanli.addemployee();
            a.k = this;

            a.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int i = e.RowIndex;
                string name = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);

                string msg = "确定删除吗？";

                if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                {
                    return;
                }
                employeeDaoz.delete(name);
                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                MessageBox.Show("删除成功！");
            }
            else if (e.ColumnIndex == 0)//修改
            {
                j = e.RowIndex;
               guanli.employee_update k = new guanli.employee_update();
               k.number = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value);//获取要修改客户的number
               k.j = j;
                k.n = this;
               k.Show();

            }
        }
           
        }
    
}
