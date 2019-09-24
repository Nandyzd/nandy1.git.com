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
    public partial class rawMaterial : Form
    {
        public string[] number=new string[20];
        public DataGridView data = new DataGridView();
        public purchaseOrder purchase;
        public purchaseReturn1 purchase_return;
        public int node;
        public string type;//判断是哪个地方传过来的，
        public rawMaterial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            purchase p = new purchase();
            List<rawmaterial> rs = new List<rawmaterial>();
            rs=p.find_all1();
            Console.Write(rs);
            foreach(rawmaterial r1  in rs)
            {
               Console.Write(r1.Id);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }
        
        private void rawMaterial_Load(object sender, EventArgs e)
        {
            rawmaterialdao p = new rawmaterialdao();
            List<rawmaterial> rs = new List<rawmaterial>();
            rs = p.find_all1();
            Console.Write(rs);
            DataSet ds=new DataSet();
            DataTable dt=new DataTable("Table_New");
           
            dt.Columns.Add("类别", typeof(string));
            dt.Columns.Add("编号", typeof(string));
            dt.Columns.Add("名称", typeof(String));
            dt.Columns.Add("数量", typeof(double));
            dt.Columns.Add("单位", typeof(String));
            int i = 0;
            foreach (rawmaterial r1 in rs)
            {
                
                dt.Rows.Add(r1.Rawmaterial_type, r1.Rawmaterial_number, r1.Rawmaterial_name, r1.Rawmaterial_count, r1.Rawmaterial_unit);
                i++;
            }
            dataGridView1.DataSource = dt;
            data = dataGridView1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "类别" && textBox1.Text == "输入编号/名称")
            {
                
            }
            else if(comboBox1.Text!="类别"&&textBox1.Text == "输入编号/名称")
            {
                rawmaterialdao p = new rawmaterialdao();
                List<rawmaterial> rs = new List<rawmaterial>();
                rs = p.selectType(comboBox1.Text);
                Console.Write(rs);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");
                dt.Columns.Add("类别", typeof(string));
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("名称", typeof(String));
                dt.Columns.Add("数量", typeof(double));
                dt.Columns.Add("单位", typeof(String));
                foreach (rawmaterial r1 in rs)
                {
                    dt.Rows.Add(r1.Rawmaterial_type, r1.Rawmaterial_number, r1.Rawmaterial_name, r1.Rawmaterial_count, r1.Rawmaterial_unit);
                }
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "类别" && textBox1.Text != "输入编号/名称")
            {
                rawmaterialdao p = new rawmaterialdao();
                List<rawmaterial> rs = new List<rawmaterial>();
                rs = p.selectNumberOrName(textBox1.Text);
                Console.Write(rs);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");
                dt.Columns.Add("类别", typeof(string));
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("名称", typeof(string));
                dt.Columns.Add("数量", typeof(double));
                dt.Columns.Add("单位", typeof(String));
                foreach (rawmaterial r1 in rs)
                {
                    dt.Rows.Add(r1.Rawmaterial_type, r1.Rawmaterial_number, r1.Rawmaterial_name, r1.Rawmaterial_count, r1.Rawmaterial_unit);
                }
                dataGridView1.DataSource = dt;
            }
            data = dataGridView1;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                        if (this.type == "购货订单")
                        {
                            number[i] = this.data.Rows[i].Cells[2].Value.ToString();
                            purchase.dataGridView1.Rows[node].Cells[0].Value = this.data.Rows[i].Cells[2].Value;
                            purchase.dataGridView1.Rows[node].Cells[1].Value = this.data.Rows[i].Cells[3].Value.ToString();
                            purchase.dataGridView1.Rows[node].Cells[3].Value = this.data.Rows[i].Cells[5].Value.ToString();
                            purchase.dataGridView1.Rows[node].Cells[4].Value = this.data.Rows[i].Cells[4].Value.ToString();
                            Console.Write(number[i] + "################################3");
                            node++;
                        }
                        else if (this.type == "购货退货单")
                        {
                            number[i] = this.data.Rows[i].Cells[2].Value.ToString();
                            purchase_return.dataGridView1.Rows[node].Cells[0].Value = this.data.Rows[i].Cells[2].Value;
                            purchase_return.dataGridView1.Rows[node].Cells[1].Value = this.data.Rows[i].Cells[3].Value.ToString();
                            purchase_return.dataGridView1.Rows[node].Cells[3].Value = this.data.Rows[i].Cells[5].Value.ToString();
                            purchase_return.dataGridView1.Rows[node].Cells[4].Value = this.data.Rows[i].Cells[4].Value.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
