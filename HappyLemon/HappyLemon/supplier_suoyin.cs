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
    public partial class supplier_suoyin : Form
    {
        public DataGridView data = new DataGridView();
        public purchaseOrder purchase;
        public purchaseReturn1 purchase_return;
        public string type;
        public supplier_suoyin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void supplier_suoyin_Load(object sender, EventArgs e)
        {
            supplierdao s= new supplierdao();
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

                dt.Rows.Add(s1.Type, s1.Supplier_number, s1.Supplier_name, s1.Charge_name, s1.Telephone,s1.Address);
                i++;
            }
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn co in dataGridView1.Columns)
            {
                if (co.Index != 0)
                    co.ReadOnly = true;
            }
            data = dataGridView1;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                x++;
                try
                {
                    if (Convert.ToBoolean(this.data.Rows[i].Cells[0].Value) == true)
                    {
                        if (this.type == "购货订单")
                        {
                            purchase.supplier_text.Text = data.Rows[i].Cells[2].Value.ToString() + " " + data.Rows[i].Cells[3].Value.ToString();
                            this.Close();
                        }
                        else if (this.type == "购货退货单")
                        {
                            purchase_return.supplier_text.Text = data.Rows[i].Cells[2].Value.ToString() + " " + data.Rows[i].Cells[3].Value.ToString();
                            this.Close();
                        }
                    }
                }
                catch (SystemException)
                {
                    MessageBox.Show("只能选择一个供应商！");
                }
                
            }
            if (x == data.Rows.Count)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "类别" && textBox1.Text == "输入编号/名称")
            {

            }
            else if (comboBox1.Text != "类别" && textBox1.Text == "输入编号/名称")
            {
                supplierdao p = new supplierdao();
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
                supplierdao p = new supplierdao();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
