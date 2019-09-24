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
    public partial class 盘点查询 : Form
    {
        public 盘点查询()
        {
            InitializeComponent();
        }

        private void chaxun_Click(object sender, EventArgs e)
        {
            try
            {
                string time = riqi.Value.ToString("yyyy-MM-dd");
                string type = comboBox1.Text;
                bool lingkucun = lingkecun.Checked;
                string name = shangpin.Text;
                dataGridView1.Rows.Clear();
                List<temp> temps = rawmaterialDaow.find_inventory2(time, type, lingkucun, name);
                int i = 0;
                if (temps != null)
                {
                    foreach (temp r in temps)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = r.RawMaterial_number;
                        dataGridView1.Rows[i].Cells[1].Value = r.Rawmaterial_name;
                        dataGridView1.Rows[i].Cells[2].Value = r.Rawmaterial_type;
                        dataGridView1.Rows[i].Cells[3].Value = r.Rawmaterial_unit;
                        dataGridView1.Rows[i].Cells[4].Value = r.System_stock;
                        dataGridView1.Rows[i].Cells[5].Value = r.Inventory_stock;
                        dataGridView1.Rows[i].Cells[6].Value = r.Result;
                        i++;
                    }
                }

                //清空条件
                comboBox1.Text = "";
                lingkecun.Checked = false;
                shangpin.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pandian_Paint(object sender, PaintEventArgs e)
        {
        
        }
    }
}
