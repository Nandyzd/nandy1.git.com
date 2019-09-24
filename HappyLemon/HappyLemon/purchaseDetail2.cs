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
    public partial class purchaseDetail2 : Form
    {
        public purchaseDetail2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void purchaseDetail2_Load(object sender, EventArgs e)
        {
            supplierdao sdao = new supplierdao();
            List<supplier> ss = new List<supplier>();
            ss = sdao.find_all();
            foreach (supplier s in ss)
            {
                comboBox1.Items.Add(s.Supplier_number + " " + s.Supplier_name);
            }
            label6.Text = "0";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable("teble");
                dt.Columns.Add("采购日期", typeof(string));
                dt.Columns.Add("单据号", typeof(string));
                dt.Columns.Add("供应商", typeof(String));
                dt.Columns.Add("商品编号", typeof(string));
                dt.Columns.Add("商品名称", typeof(string));
                dt.Columns.Add("单位", typeof(string));
                dt.Columns.Add("单价", typeof(double));
                dt.Columns.Add("数量", typeof(double));
                dt.Columns.Add("采购金额", typeof(double));
                dt.Columns.Add("备注", typeof(String));
                purchase p = new purchase();
                List<purchase_material> ps = new List<purchase_material>();
                if (comboBox1.Text == "" && textBox1.Text == "")
                {
                    ps = p.selectMaterial_date(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), 0);

                }
                if (comboBox1.Text == "" && textBox1.Text != "")
                {
                    ps = p.selectMaterial_dateandrname(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), textBox1.Text, 0);
                }
                if (comboBox1.Text != "" && textBox1.Text == "")
                {
                    string[] suppliername = comboBox1.Text.Split(' ');
                    ps = p.selectMaterial_dateandsnumber(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), suppliername[0], 0);
                }
                if (comboBox1.Text != "" && textBox1.Text != "")
                {
                    string[] suppliername = comboBox1.Text.Split(' ');
                    ps = p.selectMaterial_dateandrnameandsupplier(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), suppliername[0], textBox1.Text, 0);
                }
                foreach (purchase_material p1 in ps)
                {
                    Console.Write(p1.Danju_id + "姚雅丽呀");
                    rawmaterial r1 = new rawmaterial();
                    rawmaterialdao rdao = new rawmaterialdao();
                    r1 = rdao.selectNumber(p1.RawMaterial_number);
                    supplier s1 = new supplier();
                    supplierdao sdao = new supplierdao();
                    s1 = sdao.selectnumber(p1.Suppliernumber);
                    dt.Rows.Add(p1.Dan_date, p1.Danju_id, s1.Supplier_name, r1.Rawmaterial_number, r1.Rawmaterial_name, p1.Unit, p1.Price, p1.Count, p1.Money, p1.Remark);
                }
                dataGridView1.DataSource = dt;
                double money = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    money +=Convert.ToDouble( dataGridView1.Rows[i].Cells[8].Value);
                }
                label6.Text = money.ToString();
            }
            catch (SystemException)
            {
                MessageBox.Show("操作不当");
            }
        }

        private void dataGridView_heji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
