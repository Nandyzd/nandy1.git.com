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
    public partial class rawmaterialguanli : Form
    {
        public rawmaterialguanli()
        {
            InitializeComponent();
        }
        public static string number;
        public static int j;
        public DataTable dt = new DataTable("teble");
       
        private void rawmaterialguanli_Load(object sender, EventArgs e)
        {
            try
            {
                Console.Write("!!商品22222222222222");
                dt.Columns.Add("序号", typeof(string));
                dt.Columns.Add("原材料编号", typeof(string));
                dt.Columns.Add("原材料姓名", typeof(string));
                dt.Columns.Add("原材料类型", typeof(string));
                dt.Columns.Add("原材料数量", typeof(string));
                dt.Columns.Add("原材料数量单位", typeof(string));
                Console.Write("!!商品");
                List<model.rawmaterial> kehus = new List<model.rawmaterial>();
                Console.Write("!!!!333333333333339999999999!");
                kehus = dao.rawmaterialDaoz.find_all();
                int q = 1;
                Console.Write("!!!!33333333333333333333333333!");
                if (kehus == null)
                {
                    MessageBox.Show("没有数据！");
                }
                else
              {

                    foreach (rawmaterial k in kehus)
                    {

                        dt.Rows.Add(q, k.Rawmaterial_number, k.Rawmaterial_name, k.Rawmaterial_type, k.Rawmaterial_count, k.Rawmaterial_unit);
                        q++;
                    }
                    dataGridView1.DataSource = dt;
                }
            }
            catch
            {
                MessageBox.Show("操作又有有误！");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int i = e.RowIndex;
                string name = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);

                string msg = "确定删除吗？";

                if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                {
                    return;
                }
                rawmaterialDaoz.delete(name);
                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                
            }
            else if (e.ColumnIndex == 0)//修改
            {
               j = e.RowIndex;
                guanli.rawmaterial_update k = new guanli.rawmaterial_update();
                k.number = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value);//获取要修改客户的number
                k.j = j;
                k.s = this;
               k.Show();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt1 = new DataTable("teble");
                dt1.Columns.Add("序号", typeof(string));
                dt1.Columns.Add("原材料编号", typeof(string));
                dt1.Columns.Add("原材料姓名", typeof(string));
                dt1.Columns.Add("原材料类型", typeof(string));
                dt1.Columns.Add("原材料数量", typeof(string));
                dt1.Columns.Add("原材料数量单位", typeof(string));
                List<rawmaterial> kehus = new List<rawmaterial>();
                Console.Write("!!!!供应商");
                kehus = dao.rawmaterialDaoz.selectAll(textBox1.Text);
                foreach (rawmaterial k in kehus)
                {
                    dt1.Rows.Add(k.Id, k.Rawmaterial_number, k.Rawmaterial_name, k.Rawmaterial_type, k.Rawmaterial_count, k.Rawmaterial_unit);
                }
                dataGridView1.DataSource = dt1;
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guanli.addrawmaterial asp = new guanli.addrawmaterial();
            asp.s = this;
            asp.Show();
        }
    }
}
