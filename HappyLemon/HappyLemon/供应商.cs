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

namespace HappyLemon
{
    public partial class 供应商 : Form
    {
        public DataGridView data = new DataGridView();
        public 供应商()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "类别" && textBox1.Text == "输入编号/名称")
                {

                }
                else if (comboBox1.Text != "类别" && textBox1.Text == "输入编号/名称")
                {
                    supplierdaow p = new supplierdaow();
                    List<supplier> rs = new List<supplier>();
                    rs = p.selectType(comboBox1.Text);
                    Console.Write(rs);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable("Table_New");
                    dt.Columns.Add("类型", typeof(string));
                    dt.Columns.Add("编号", typeof(string));
                    dt.Columns.Add("名称", typeof(string));
                    dt.Columns.Add("负责人", typeof(string));
                    dt.Columns.Add("联系电话", typeof(string));
                    dt.Columns.Add("地址", typeof(string));
                    int i = 0;
                    foreach (supplier s1 in rs)
                    {

                        dt.Rows.Add(s1.Type, s1.Supplier_number, s1.Supplier_name, s1.Charge_name, s1.Telephone, s1.Address);
                        i++;
                    }
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "类别" && textBox1.Text != "输入编号/名称")
                {
                    supplierdaow p = new supplierdaow();
                    List<supplier> rs = new List<supplier>();
                    rs = p.selectNumberOrName(textBox1.Text);
                    Console.Write(rs);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable("Table_New");
                    dt.Columns.Add("类型", typeof(string));
                    dt.Columns.Add("编号", typeof(string));
                    dt.Columns.Add("名称", typeof(string));
                    dt.Columns.Add("负责人", typeof(string));
                    dt.Columns.Add("联系电话", typeof(string));
                    dt.Columns.Add("地址", typeof(string));
                    int i = 0;
                    foreach (supplier s1 in rs)
                    {

                        dt.Rows.Add(s1.Type, s1.Supplier_number, s1.Supplier_name, s1.Charge_name, s1.Telephone, s1.Address);
                        i++;
                    }
                    dataGridView1.DataSource = dt;
                }
                data = dataGridView1;
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
        }

        private void 供应商_Load(object sender, EventArgs e)
        {
            try
            {
                supplierdaow s = new supplierdaow();
                List<supplier> ss = new List<supplier>();
                ss = s.find_all();
                Console.Write(ss);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");

                dt.Columns.Add("类型", typeof(string));
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("名称", typeof(string));
                dt.Columns.Add("负责人", typeof(string));
                dt.Columns.Add("联系电话", typeof(string));
                dt.Columns.Add("地址", typeof(string));
                int i = 0;
                foreach (supplier s1 in ss)
                {

                    dt.Rows.Add(s1.Type, s1.Supplier_number, s1.Supplier_name, s1.Charge_name, s1.Telephone, s1.Address);
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

        }

        private void button2_Click(object sender, EventArgs e)
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
                            入库单.gongyingshang = data.Rows[i].Cells[2].Value.ToString() + " " + data.Rows[i].Cells[3].Value.ToString();
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
                MessageBox.Show("你的操作有误！");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
