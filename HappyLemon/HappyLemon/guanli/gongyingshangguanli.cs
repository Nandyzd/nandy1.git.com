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
    public partial class gongyingshangguanli : Form
    {
        public gongyingshangguanli()
        {
            InitializeComponent();
        }
        public static string number;
        public static int j;
        public DataTable dt = new DataTable("teble");
        public DataTable dt1 = new DataTable("teble");

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
                supplierDaoz.delete(number);
                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
               
            }
            else if (e.ColumnIndex == 0)//修改
            {
                j = e.RowIndex;
                guanli.supplier_update k = new guanli.supplier_update();
                k.number = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value);//获取要修改客户的number
                k.j = j;
                k.g = this;
                k.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guanli.addsupplier a = new guanli.addsupplier();
            a.k = this;
            a.Show();

            
        }

        private void gongyingshangguanli_Load(object sender, EventArgs e)
        {
            try
            {


                dt.Columns.Add("序号", typeof(string));
                dt.Columns.Add("供应商编号", typeof(string));
                dt.Columns.Add("供应商姓名", typeof(string));
                dt.Columns.Add("负责人姓名", typeof(string));
                dt.Columns.Add("电话", typeof(string));
                 dt.Columns.Add("地址", typeof(string));
                dt.Columns.Add("类型", typeof(string));
                Console.Write("!!供应商");
                List<model.supplier> kehus = new List<model.supplier>();
                kehus = dao.supplierDaoz.find_all();
                int q = 1;
                foreach (supplier k in kehus)
                {

                    dt.Rows.Add(q, k.Supplier_number, k.Supplier_name, k.Charge_name, k.Telephone,k.Address,k.Type);
                    q++;
                }
                dataGridView1.DataSource = dt;
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

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("序号", typeof(string));
                dt2.Columns.Add("供应商编号", typeof(string));
                dt2.Columns.Add("供应商姓名", typeof(string));
                dt2.Columns.Add("负责人姓名", typeof(string));
                dt2.Columns.Add("电话", typeof(string));
                dt2.Columns.Add("地址", typeof(string));
                dt2.Columns.Add("类型", typeof(string));
                List<supplier> kehus = new List<supplier>();
                Console.Write("!!!!供应商");
                kehus = dao.supplierDaoz.selectAll(textBox1.Text);
                foreach (supplier k in kehus)
                {

                    dt2.Rows.Add(k.Id, k.Supplier_number, k.Supplier_name, k.Charge_name, k.Telephone,k.Address,k.Type);
                }
                dataGridView1.DataSource = dt2;
            }
            catch
            {
                
            }
        }
    }
}
