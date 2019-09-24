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
    public partial class TuikuanSchedule : Form
    {
        public TuikuanSchedule()
        {
            InitializeComponent();
        }

        private void TuikuanSchedule_Load(object sender, EventArgs e)
        {
            supplierdao sdao = new supplierdao();
            List<supplier> ss = new List<supplier>();
            ss = sdao.find_all();
            foreach (supplier s in ss)
            {
                comboBox1.Items.Add(s.Supplier_number + " " + s.Supplier_name);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable("table");

                dt.Columns.Add("退款日期", typeof(string));
                dt.Columns.Add("单据号", typeof(string));
                dt.Columns.Add("退款金额", typeof(string));
                dt.Columns.Add("结算方式", typeof(string));
                dt.Columns.Add("备注", typeof(string));
                dt.Columns.Add("供应商", typeof(string));

                ZijinDao p = new ZijinDao();
                List<Tuikuan> ps = new List<Tuikuan>();

                if (comboBox1.Text == "")
                {
                    ps = p.selectTuikuan_date(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
                    Console.Write("寇肖萌");
                }

                if (comboBox1.Text != "")
                {
                    string[] suppliername = comboBox1.Text.Split(' ');
                    ps = p.selectTuikuan_dateandkehuname(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), suppliername[0]);
                }
                foreach (Tuikuan tui in ps)
                {
                    supplier s1 = new supplier();
                    supplierdao sdao = new supplierdao();
                    Console.WriteLine(tui.Tuikuan_suppliernumber);
                    s1 = sdao.selectNumber(tui.Tuikuan_suppliernumber);
                    Console.WriteLine(tui.Tuikuan_money);
                    Console.WriteLine(tui.Tuikuan_way);
                    Console.WriteLine(tui.Mark);
                    Console.WriteLine(s1.Supplier_name);
                    Console.WriteLine(tui.Date);
                    Console.WriteLine(tui.Tuikuan_danjuid);
                    dt.Rows.Add(tui.Date, tui.Tuikuan_danjuid, tui.Tuikuan_money, tui.Tuikuan_way, tui.Mark, s1.Supplier_name);

                }
                dataGridView1.DataSource = dt;

            }
            catch (SystemException)
            {
                MessageBox.Show("操作不当");
            }
        }
    }
}
