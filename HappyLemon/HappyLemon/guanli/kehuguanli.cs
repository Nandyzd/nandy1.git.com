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
    public partial class kehuguanli : Form
    {
        public kehuguanli()
        {
            InitializeComponent();
        }
        public static  string number;
        public static int j;
       public  DataTable dt = new DataTable("teble");
       
        private void button1_Click(object sender, EventArgs e)
        {
            guanli.addkehu a = new guanli.addkehu();
            a.k = this;
            
            a.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt1 = new DataTable("teble");
                dt1.Columns.Add("序号", typeof(int));
                dt1.Columns.Add("客户编号", typeof(string));
                dt1.Columns.Add("客户姓名", typeof(String));
                dt1.Columns.Add("客户电话", typeof(string));
                dt1.Columns.Add("客户地址", typeof(String));

                List<kehu> kehus = new List<kehu>();
                kehus = dao.customerDaoz.selectAll(textBox1.Text);
                foreach (kehu k in kehus)
                {

                    dt1.Rows.Add(k.Id, k.Customer_number, k.Customer_name, k.Phone, k.Address);
                }
                dataGridView1.DataSource = dt1;
            }
            catch
            {
                MessageBox.Show("操作有误！");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (e.ColumnIndex == 1)
              {
                int i = e.RowIndex;
                string name = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                  
                string msg = "确定删除吗？";
     
                if((int)MessageBox.Show(msg,"提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation)!=1)
                {
                    return;
                }
                customerDaoz.delete(name);
                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                MessageBox.Show("删除成功！");
            }
            else if (e.ColumnIndex == 0)//修改
            {
                j = e.RowIndex;
                guanli.kehu_update k = new guanli.kehu_update();
                k.number = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value);//获取要修改客户的number
                k.j = j;
                k.n = this;
                k.Show();

            }
        }

        private void kehuguanli_Load(object sender, EventArgs e)
        {
            try
            {

              
                dt.Columns.Add("序号", typeof(string));
                dt.Columns.Add("客户编号", typeof(string));
                dt.Columns.Add("客户姓名", typeof(string));
                dt.Columns.Add("客户电话", typeof(string));
                dt.Columns.Add("客户地址", typeof(string));
              
                List<kehu> kehus = new List<kehu>();
                kehus = dao.customerDaoz.find_all();
                int q = 1;
                foreach (kehu k in kehus)
                {

                    dt.Rows.Add(q, k.Customer_number, k.Customer_name, k.Phone, k.Address);
                    q++;
                }
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("无数据！");
            }

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
