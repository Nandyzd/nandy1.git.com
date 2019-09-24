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
    public partial class rowClient : Form
    {
        public string[] number = new string[20];
        public DataGridView data = new DataGridView();
        public purchaseSale purchase;
        public int node;
        public string type;//判断是哪个地方传过来的，
        public rowClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "类别" && textBox1.Text == "输入编号/名称")
            {

            }
            else if (comboBox1.Text != "类别" && textBox1.Text == "输入编号/名称" || textBox1.Text == "")
            {
                gooddao p = new gooddao();
                List<good> rs = new List<good>();
                rs = p.selectType(comboBox1.Text);
                Console.Write(rs);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");
                dt.Columns.Add("类别", typeof(string));
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("名称", typeof(String));
                dt.Columns.Add("单位", typeof(string));
                dt.Columns.Add("价格", typeof(double));
                foreach (good r1 in rs)
                {
                    dt.Rows.Add(r1.Good_type, r1.Good_number, r1.Good_name, r1.Good_unit, r1.Good_price);
                }
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "类别" || comboBox1.Text == "" && textBox1.Text != "输入编号/名称")
            {
                gooddao p = new gooddao();
                List<good> rs = new List<good>();
                rs = p.selectNumberOrName(textBox1.Text);
                Console.Write(rs);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");
                dt.Columns.Add("类别", typeof(string));
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("名称", typeof(String));
                dt.Columns.Add("单位", typeof(string));
                dt.Columns.Add("价格", typeof(double));
                foreach (good r1 in rs)
                {
                    dt.Rows.Add(r1.Good_type, r1.Good_number, r1.Good_name, r1.Good_unit, r1.Good_price);
                }
                dataGridView1.DataSource = dt;
            }
            data = dataGridView1;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = node;
            int y = 0;
            Console.WriteLine("逍遥" + node + "yaoyao");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                y++;
                try
                {
                    if (Convert.ToBoolean(this.data.Rows[i].Cells[0].Value) == true)
                    {
                        if (this.type == "销货订单")
                        {
                            number[i] = this.data.Rows[i].Cells[2].Value.ToString();
                            purchase.dataGridView1.Rows[node].Cells[0].Value = this.data.Rows[i].Cells[2].Value;
                            purchase.dataGridView1.Rows[node].Cells[1].Value = this.data.Rows[i].Cells[3].Value.ToString();
                            purchase.dataGridView1.Rows[node].Cells[5].Value = this.data.Rows[i].Cells[5].Value.ToString();
                            purchase.dataGridView1.Rows[node].Cells[3].Value = this.data.Rows[i].Cells[4].Value.ToString();
                            Console.Write(number[i] + "################################3");
                            node++;
                        }
                       
                    }
                }
                catch (SystemException)
                {
                    MessageBox.Show("操作有误！");
                }
            }

            this.Close();
        }

        private void rowClient_Load(object sender, EventArgs e)
        {
            gooddao p = new gooddao();
            List<good> rs = new List<good>();
            rs = p.find_all1();
            Console.Write(rs);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table_New");

            dt.Columns.Add("类别", typeof(string));
            dt.Columns.Add("编号", typeof(string));
            dt.Columns.Add("名称", typeof(String));
            dt.Columns.Add("单位", typeof(string));
            dt.Columns.Add("价格", typeof(double));
            int i = 0;
            foreach (good r1 in rs)
            {

                dt.Rows.Add(r1.Good_type, r1.Good_number, r1.Good_name, r1.Good_unit, r1.Good_price);
                i++;
            }
            dataGridView1.DataSource = dt;
            data = dataGridView1;
        }
    }
}
