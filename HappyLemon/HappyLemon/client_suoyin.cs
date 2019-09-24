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
    public partial class client_suoyin : Form
    {
        public DataGridView data = new DataGridView();
        public purchaseSale purchase;
       
        public string type;
        public client_suoyin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (textBox1.Text == "输入编号/名称")
            {
                customerdao p = new customerdao();
                List<customer> rs = new List<customer>();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("姓名", typeof(string));
                dt.Columns.Add("联系电话", typeof(string));
                dt.Columns.Add("地址", typeof(string));
               
                customer s1=new customer();
                    dt.Rows.Add(s1.Customer_number, s1.Customer_name, s1.Phone, s1.Address);
                dataGridView1.DataSource = dt;
            }
            else if (textBox1.Text != "输入编号/名称")
            {
                customerdao p = new customerdao();
                List<customer> rs = new List<customer>();
                rs = p.selectNumberOrName(textBox1.Text);
                Console.Write(rs);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("姓名", typeof(string));
                dt.Columns.Add("联系电话", typeof(string));
                dt.Columns.Add("地址", typeof(string));
                int i = 0;
                foreach (customer s1 in rs)
                {

                    dt.Rows.Add(s1.Customer_number, s1.Customer_name, s1.Phone, s1.Address);
                    i++;
                }
                dataGridView1.DataSource = dt;
            }
            data = dataGridView1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

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
                        if (this.type == "销货订单")
                        {
                            purchase.supplier_text.Text = data.Rows[i].Cells[1].Value.ToString() + " " + data.Rows[i].Cells[2].Value.ToString();
                            this.Close();
                        }
                       
                    }
                }
                catch (SystemException)
                {
                    MessageBox.Show("只能选择一个客户！");
                }

            }
            if (x == data.Rows.Count)
            {
                this.Close();
            }
        }

        private void client_suoyin_Load(object sender, EventArgs e)
        {
            customerdao s = new customerdao();
            List<customer> ss = new List<customer>();
            ss = s.find_all();
            Console.Write(ss);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table_New");
            dt.Columns.Add("编号", typeof(string));
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("联系电话", typeof(string));
            dt.Columns.Add("地址", typeof(string));
            int i = 0;
            foreach (customer s1 in ss)
            {

                dt.Rows.Add(s1.Customer_number, s1.Customer_name,  s1.Phone, s1.Address);
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
    }
}
