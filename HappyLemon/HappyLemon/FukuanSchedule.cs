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
    public partial class FukuanSchedule : Form
    {
        public FukuanSchedule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable("table");

                dt.Columns.Add("付款日期", typeof(string));
                dt.Columns.Add("单据号", typeof(string));
                dt.Columns.Add("付款金额", typeof(string));
                dt.Columns.Add("结算方式", typeof(string));
                dt.Columns.Add("备注", typeof(string));
                dt.Columns.Add("供应商", typeof(string));

                ZijinDao p = new ZijinDao();
                List<Fukuan> ps = new List<Fukuan>();

                if (comboBox1.Text == "")
                {
                    ps = p.selectPayfor_date(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
                    Console.Write("寇肖萌");
                }

                if (comboBox1.Text != "")
                {
                    string[] suppliername = comboBox1.Text.Split(' ');
                    ps = p.selectPayfor_dateandkehuname(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), suppliername[0]);
                }
                foreach (Fukuan fu in ps)
                {
                    supplier s1 = new supplier();
                    supplierdao sdao = new supplierdao();
                    Console.WriteLine(fu.Payfor_suppliernumber);
                    s1 = sdao.selectNumber(fu.Payfor_suppliernumber);
                    Console.WriteLine(fu.Payfor_money);
                    Console.WriteLine(fu.Payfor_way);
                    Console.WriteLine(fu.Mark);
                    Console.WriteLine(s1.Supplier_name);
                    Console.WriteLine(fu.Date);
                    Console.WriteLine(fu.Payfor_danjuid);
                    dt.Rows.Add(fu.Date, fu.Payfor_danjuid, fu.Payfor_money, fu.Payfor_way, fu.Mark, s1.Supplier_name);

                }
                dataGridView1.DataSource = dt;

             }
            catch (SystemException)
            {
                MessageBox.Show("操作不当");
            }
        }

        private void FukuanSchedule_Load(object sender, EventArgs e)
        {
            supplierdao sdao = new supplierdao();
            List<supplier> ss = new List<supplier>();
            ss = sdao.find_all();
            foreach (supplier s in ss)
            {
                comboBox1.Items.Add(s.Supplier_number + " " + s.Supplier_name);
            }
            
        }
    }
}
