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
    public partial class saleDetail : Form
    {
        public saleDetail()
        {
            InitializeComponent();
        }

        private void saleDetail_Load(object sender, EventArgs e)
        {
            customerdao sdao = new customerdao();
            List<customer> ss = new List<customer>();
            ss = sdao.find_all();
            foreach (customer s in ss)
            {
                comboBox1.Items.Add(s.Customer_number + " " + s.Customer_name);
                Console.WriteLine("加油");
            }
            label6.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable("teble");
                dt.Columns.Add("销售日期", typeof(string));
                dt.Columns.Add("单据号", typeof(string));
                dt.Columns.Add("客户", typeof(String));
                dt.Columns.Add("商品编号", typeof(string));
                dt.Columns.Add("商品名称", typeof(string));
                dt.Columns.Add("单位", typeof(string));
                dt.Columns.Add("单价", typeof(double));
                dt.Columns.Add("数量", typeof(double));
                dt.Columns.Add("销售金额", typeof(double));
                dt.Columns.Add("备注", typeof(String));
                sale p = new sale();
                List<sale_good> ps = new List<sale_good>();
                if (comboBox1.Text == "" && textBox1.Text == "")
                {
                    ps = p.selectMaterial_date(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));

                }
                if (comboBox1.Text == "" && textBox1.Text != "")
                {
                    ps = p.selectMaterial_dateandrname(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), textBox1.Text);
                }
                if (comboBox1.Text != "" && textBox1.Text == "")
                {
                    string[] suppliername = comboBox1.Text.Split(' ');
                    ps = p.selectMaterial_dateandsnumber(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), suppliername[0]);
                }
                if (comboBox1.Text != "" && textBox1.Text != "")
                {
                    string[] suppliername = comboBox1.Text.Split(' ');
                    ps = p.selectMaterial_dateandrnameandsupplier(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), suppliername[0], textBox1.Text);
                }
                foreach (sale_good p1 in ps)
                {
                    Console.Write(p1.Danju_id + "姚雅丽呀");
                    good r1 = new good();
                    gooddao rdao = new gooddao();
                    r1 = rdao.selectNumber(p1.Good_number);
                    customer s1 = new customer();
                    customerdao sdao = new customerdao();
                    s1 = sdao.selectnumber(p1.Customernumber);
                    dt.Rows.Add(p1.Dan_date, p1.Danju_id, s1.Customer_name, r1.Good_number, r1.Good_name, p1.Unit, p1.Price, p1.Count, p1.Money, p1.Remark);
                }
                dataGridView1.DataSource = dt;
                double money = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    money += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                }
                label6.Text = money.ToString();
            }
            catch (SystemException)
            {
                MessageBox.Show("操作不当");
            }
        }
    }
}
