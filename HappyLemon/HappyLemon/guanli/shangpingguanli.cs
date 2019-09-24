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

namespace HappyLemon.guanli
{
    public partial class shangpingguanli : Form
    {
        public shangpingguanli()
        {
            InitializeComponent();
        }
        public static string number;
        public static int j;
        public DataTable dt = new DataTable("teble");
       
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            guanli.addgood asp = new guanli.addgood();
            asp.s = this;
            asp.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int i = e.RowIndex;
                string number = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);

                string msg = "确定删除吗？";

                if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                {
                    return;
                }
                goodDaoz.delete(number);
                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);

            }
            else if (e.ColumnIndex == 0)//修改
            {
                j = e.RowIndex;
                guanli.good_update k = new guanli.good_update();
                k.number = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value);//获取要修改客户的number
                k.j = j;
                k.s = this;
                k.Show();

            }
        }

        private void shangpingguanli_Load(object sender, EventArgs e)
        {

            try
            {
                 
                dt.Columns.Add("序号", typeof(string));
                dt.Columns.Add("商品编号", typeof(string));
                dt.Columns.Add("商品姓名", typeof(string));
                dt.Columns.Add("商品类型", typeof(string));
                dt.Columns.Add("商品数量", typeof(string));
                dt.Columns.Add("商品单价", typeof(string));
                Console.Write("!!商品");
                List<model.good> kehus = new List<model.good>();
                kehus = dao.goodDaoz.find_all();
                int q = 1;
                if(kehus==null)
                {
                    MessageBox.Show("没有数据！");
                }
                else
                {

                
                  foreach (good k in kehus)
                   {

                    dt.Rows.Add(q, k.Good_number, k.Good_name, k.Good_type, k.Good_unit, k.Good_price);
                    q++;
                    }
                dataGridView1.DataSource = dt;
                }
            }
            catch
            {
                MessageBox.Show("操作有误！");
            }
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt1 = new DataTable("teble");
                dt1.Columns.Add("序号", typeof(string));
                dt1.Columns.Add("商品编号", typeof(string));
                dt1.Columns.Add("商品姓名", typeof(string));
                dt1.Columns.Add("商品类型", typeof(string));
                dt1.Columns.Add("商品数量", typeof(string));
                dt1.Columns.Add("商品单价", typeof(string));
                List<good> kehus = new List<good>();
                Console.Write("!!!!供应商");
                kehus = dao.goodDaoz.selectAll(textBox1.Text);
                foreach (good k in kehus)
                {

                    dt1.Rows.Add(k.Id, k.Good_number, k.Good_name, k.Good_type, k.Good_unit, k.Good_type);
                }
                dataGridView1.DataSource = dt1;
            }
            catch
            {

            }
        }
    }
}
