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
    
    public partial class FukuanDan : Form
    {
        public string[] number1;
        public FukuanDan()
        {
            InitializeComponent();
            
        }
        public FukuanDan(string[] number)
        {
            InitializeComponent();
            number1 = number;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            supplier_suoyin1 su = new supplier_suoyin1();
            su.fukuan = this;
            Console.Write("lalallaal");
            su.type = "付款单";
            su.ShowDialog();
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
                        MessageBox.Show("结算账户不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[1].Value == null)
                    {
                        MessageBox.Show("付款金额不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[2].Value == null)
                    {
                        MessageBox.Show("结算方式不能为空");
                        b = false;
                    }
                    else if (textBox1.Text == null)
                    {
                        MessageBox.Show("供应商不能为空");
                        b = false;
                    }
                    else if (textBox2.Text == null)
                    {
                        MessageBox.Show("操作人不能为空");
                        b = false;
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
                   string[] supplier1 = textBox1.Text.Split(' ');
                   string[] employer = textBox2.Text.Split(' ');
                    try
                    {
                       ZijinDao dao = new ZijinDao();
                        for(int i=0;i<dataGridView1.Rows.Count-1;i++)
                        {
                            Fukuan p = new Fukuan();
                            Console.Write(dataGridView1.Rows[i].Cells[0].Value + "lallalalaalalalalalalla");
                            p.Payfor_zhanghu = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            p.Payfor_money = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            p.Payfor_way = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            if(dataGridView1.Rows[i].Cells[3].Value==null)
                            {
                                p.Mark = "";
                            }
                            else
                            {
                                p.Mark = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            }
                            p.Payfor_suppliernumber = supplier1[0];
                            p.Employee_number = employer[0];
                            p.Date = Convert.ToDateTime(dateTimePicker1.Text);
                            p.Payfor_danjuid = textBox3.Text;
                            dao.addFukuandan(p);
                        }
                        MessageBox.Show("保存成功");
                    }
                    catch(SystemException)
                    {
                        MessageBox.Show("操作有误");
                    }
                }
                else
                {

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            employee_zijin su = new employee_zijin();
            su.fukuan = this;
            Console.Write("lalallaal");
            su.type = "付款单";
            su.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void FukuanDan_Load(object sender, EventArgs e)
        {
            ZijinDao p = new ZijinDao();
            int P_Int_newBillCode = p.selectMaxpayfor_moneyid() + 1;//记录收款表中的数字码
            textBox3.Text = DateTime.Now.ToString("yyyyMMdd") + P_Int_newBillCode + "HappyLemon";
        }
    }
}
