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
    public partial class employee_zijin : Form
    {
        public FukuanDan fukuan;
        public ShoukuanDan shoukuan;
        public TuikuanDan tuikuan;
        public string type;
        public employee_zijin()
        {
            InitializeComponent();
        }

        private void employee_zijin_Load(object sender, EventArgs e)
        {
            DataGridView data = new DataGridView();
            employeedao p = new employeedao();
            List<employ> rs = new List<employ>();
            rs = p.find_all1();
            Console.Write(rs);
            int i = 0;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table_New");
            dt.Columns.Add("工号", typeof(string));
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("联系电话", typeof(String));
            foreach (employ r1 in rs)
            {
                dt.Rows.Add(r1.Employee_number, r1.Employee_name, r1.Phone);
                i++;
            }
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "输入工号" || textBox1.Text == "")
                {
                    DataGridView data = new DataGridView();
                    employeedao p = new employeedao();
                    List<employ> rs = new List<employ>();
                    rs = p.find_all1();
                    Console.Write(rs);
                    int i = 0;
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable("Table_New");
                    dt.Columns.Add("工号", typeof(string));
                    dt.Columns.Add("姓名", typeof(string));
                    dt.Columns.Add("联系电话", typeof(String));
                    foreach (employ r1 in rs)
                    {
                        dt.Rows.Add(r1.Employee_number, r1.Employee_name, r1.Phone);
                        i++;
                    }
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    DataGridView data = new DataGridView();
                    employeedao p = new employeedao();
                    employ r1 = p.selectid(textBox1.Text);
                    Console.Write(textBox1.Text);

                    if (r1 == null)
                    {
                        MessageBox.Show("不存在此人");
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable("Table_New");
                        dt.Columns.Add("工号", typeof(string));
                        dt.Columns.Add("姓名", typeof(string));
                        dt.Columns.Add("联系电话", typeof(String));
                        dt.Rows.Add(r1.Employee_number, r1.Employee_name, r1.Phone);
                        dataGridView1.DataSource = dt;

                    }
                }
            }
            catch (SystemException)
            {
                MessageBox.Show("操作有误");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = this.dataGridView1.CurrentRow.Index;
            if (this.type == "付款单")
            {
                 fukuan.textBox2.Text = dataGridView1.Rows[r].Cells[1].Value.ToString() + " " + dataGridView1.Rows[r].Cells[2].Value.ToString();
                this.Close();
            }
            else if(this.type=="收款单")
            {
                 shoukuan.textBox2.Text = dataGridView1.Rows[r].Cells[1].Value.ToString() + " " + dataGridView1.Rows[r].Cells[2].Value.ToString();
                this.Close();
            }
            else if(this.type=="退款单")
            {
                 tuikuan.textBox2.Text = dataGridView1.Rows[r].Cells[1].Value.ToString() + " " + dataGridView1.Rows[r].Cells[2].Value.ToString();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
