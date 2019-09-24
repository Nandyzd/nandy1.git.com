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
    public partial class purchaseSale : Form
    {
        public purchaseSale()
        {
            InitializeComponent();
        }
        public string[] number1;
        public DataGridView datagridView = new DataGridView();
        public purchaseSale(string []number)
        {
           InitializeComponent();
           number1 = number;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“lemonDataSet.customer”中。您可以根据需要移动或删除它。
            //panel1.Visible = false;
            //自动生成单据
            sale p = new sale();
            int P_Int_newBillCode = p.selectMaxdanjuid() + 1;//记录单据编号中的数字码
            textBox1.Text = DateTime.Now.ToString("yyyyMMdd") + "HappyLemon_sale" + P_Int_newBillCode;
          //  label9.Focus();
            panel1.Visible = false;



            good r1 = new good();
            gooddao dao = new gooddao();
            //int index=this.purchaseTable.Rows.Add();
            //Console.Write(number1[0]);
            if (number1 == null)
            {

            }
            else
            {
                foreach (string i in number1)
                {

                    r1 = dao.selectNumber(i);
                    if (r1 == null)
                    {
                    }
                    else
                    {
                        int index = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[index].Cells[0].Value = r1.Good_number;
                        this.dataGridView1.Rows[index].Cells[1].Value = r1.Good_name;
                        this.dataGridView1.Rows[index].Cells[3].Value = r1.Good_unit;
                        this.dataGridView1.Rows[index].Cells[5].Value = r1.Good_price;
                    }

                }
            }
            dataGridView1.Focus();//使表格获得鼠标焦点
            supplier_text.Focus();//使供应商文本框成为焦点


            //datagridview2
        }

        private void 销货_Opening(object sender, CancelEventArgs e)
        {
            MessageBox.Show("fg");
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip6_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

      

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    rowClient r = new rowClient();
                    r.purchase = this;
                    r.node = dataGridView1.Rows.Count - 1;
                    Console.Write("lalallaal");
                    r.type = "销货订单";
                    r.ShowDialog();
                }
            }
        }
        private void dataGridView_CellStateChange(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            double money = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                money += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
           // label9.Text = money.ToString();
            label10.Focus();
        }
        private void 购货单ToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void 销货订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 销货明细表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            bool b = true;
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("请填写信息");
                b = false;
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {


                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        MessageBox.Show("编号不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[1].Value == null)
                    {
                        MessageBox.Show("商品名称不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[3].Value == null)
                    {
                        MessageBox.Show("单位不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[4].Value == null)
                    {
                        MessageBox.Show("数量不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[5].Value == null)
                    {
                        MessageBox.Show("单价不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[6].Value == null)
                    {
                        MessageBox.Show("金额不能为空");
                        b = false;
                    }
                    else if (textBox1.Text == "")
                    {
                        MessageBox.Show("请选择供应商");
                        b = false;
                    }
                    else if (textBox3.Text == "")
                    {
                        MessageBox.Show("销售人员不能为空！");
                    }
                }
            }
            if (b == false)
            {

            }
            else
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("是否确认保存？", "提交", messButton);
                if (dr == DialogResult.OK)
                {
                    string[] customer = supplier_text.Text.Split(' ');
                    string[] employer = textBox3.Text.Split(' ');
                   
                        sale dao = new sale();
                        double mm = Convert.ToDouble(label10.Text);
                        
                        dao.addDanju(Convert.ToDateTime(dateTimePicker1.Text), textBox1.Text, employer[0], mm, textBox4.Text, customer[0]);
                       
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            sale_good p = new sale_good();
                            Console.Write(dataGridView1.Rows[i].Cells[0].Value + "lallalalaalalalalalalla");
                            p.Good_number = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            p.Customernumber = customer[0];
                            p.Dan_date = Convert.ToDateTime(dateTimePicker1.Text);
                            Console.Write("这是一个人" + p.Customernumber + "这是一个人");
                            p.Unit = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            p.Count = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                            p.Price = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                            Console.Write("这是一个人" + p.Price + "这是一个人");
                            p.Money = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                            if (dataGridView1.Rows[i].Cells[7].Value == null)
                            {
                                p.Remark = "";
                            }
                            else
                            {
                                p.Remark = dataGridView1.Rows[i].Cells[7].Value.ToString();

                            }

                           
                            p.Danju_id = textBox1.Text;
                            // Console.Write("这是一个人" + p.Danju_id + "这是一个人");
                            dao.addsale(p);

                        }
                        MessageBox.Show("保存成功");

                    
                   
                }
                else
                {

                }
            }
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client_suoyin su = new client_suoyin();
            su.purchase = this;
            //Console.Write("lalallaal");
            su.type = "销货订单";
            su.ShowDialog();
        }

        private void historybutton_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void supplier_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            employee_purchase su = new employee_purchase();
            su.sale = this;
            Console.Write("lalallaal");
            su.type = "销货订单";
            su.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            double money = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                money += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
            label10.Text = money.ToString();
            label10.Focus();
        }
      

        private void search_history_Click(object sender, EventArgs e)
        {
            sale p = new sale();
            List<saleDanju> ps = new List<saleDanju>();
           
                Console.Write(Convert.ToDateTime(dateTimePicker2.Text));
                if (textBox2.Text == "" )
                {
                    DataTable dt = new DataTable("teble");
                    dt.Columns.Add("订单日期", typeof(string));
                    dt.Columns.Add("单据编号", typeof(string));
                    dt.Columns.Add("客户", typeof(String));
                    dt.Columns.Add("总金额", typeof(double));
                    dt.Columns.Add("操作人", typeof(String));
                    dt.Columns.Add("备注", typeof(String));
                    Console.Write("11");
                    ps = p.selectdate(Convert.ToDateTime(dateTimePicker2.Text), Convert.ToDateTime(dateTimePicker3.Text));
                    Console.Write("12");
                    foreach (saleDanju p1 in ps)
                    {
                        employ e1 = new employ();
                        employeedao edao = new employeedao();
                        e1 = edao.selectid(p1.Emploee_id);
                        customer s1 = new customer();
                        customerdao sdao = new customerdao();
                        s1 = sdao.selectnumber(p1.Customer_number);
                        dt.Rows.Add(p1.Date, p1.Danju, s1.Customer_name, p1.Money, e1.Employee_name, p1.Remark);
                        Console.WriteLine(p1.Customer_number+"谢谢");
                    }
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    DataTable dt = new DataTable("teble");
                    dt.Columns.Add("订单日期", typeof(string));
                    dt.Columns.Add("单据编号", typeof(string));
                    dt.Columns.Add("顾客", typeof(String));
                    dt.Columns.Add("总金额", typeof(double));
                    dt.Columns.Add("操作人", typeof(String));
                    dt.Columns.Add("备注", typeof(String));
                    ps = p.selectdateAndNum_Supp(textBox2.Text);
                    foreach (saleDanju p1 in ps)
                    {
                        employ e1 = new employ();
                        employeedao edao = new employeedao();
                        e1 = edao.selectid(p1.Emploee_id);
                        customer s1 = new customer();
                        customerdao sdao = new customerdao();
                        s1 = sdao.selectnumber(p1.Customer_number);
                        dt.Rows.Add(p1.Date, p1.Danju, s1.Customer_name, p1.Money, e1.Employee_name, p1.Remark);
                    }
                    dataGridView2.DataSource = dt;
                }
            
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.Write("1");
            try
            {
                int r = this.dataGridView2.CurrentRow.Index;
                Console.Write("2");
                Console.Write(dataGridView2.Rows[r].Cells[1].Value.ToString());
                DataTable dt = new DataTable("teble");
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("名称", typeof(string));
                dt.Columns.Add("单位", typeof(String));
                dt.Columns.Add("数量", typeof(double));
                dt.Columns.Add("单价", typeof(double));
                dt.Columns.Add("金额", typeof(double));
                dt.Columns.Add("备注", typeof(String));
                sale p = new sale();
                List<sale_good> ps = new List<sale_good>();
                Console.Write("3");
                ps = p.selectMaterial_danhao(dataGridView2.Rows[r].Cells[1].Value.ToString());
                foreach (sale_good p1 in ps)
                {
                    good r1 = new good();
                    gooddao rdao = new gooddao();
                    r1 = rdao.selectNumber(p1.Good_number);
                    dt.Rows.Add(p1.Good_number, r1.Good_name, p1.Unit, p1.Count, p1.Price, p1.Money, p1.Remark);
                }
                dataGridView2.DataSource = dt;
            }
            catch (SystemException)
            {

                MessageBox.Show("操作有误");
            }     
        }

        private void dataGridView_CellStateChange(object sender, DataGridViewCellEventArgs e)
        {
            double money = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                money += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
            //label10.Text = money.ToString();
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellCancelEventArgs e)
        {
            double money = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                money += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
            label10.Text = money.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
