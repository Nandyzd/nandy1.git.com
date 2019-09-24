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
    public partial class 出库单查询 : Form
    {
        public 出库单查询()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string time = dateTimePicker1.Text;
                string number = textBox1.Text;
                string type = comboBox1.Text;
                dataGridView2.Rows.Clear();
                List<temp2> temps = rawmaterialDaow.find_outstock(time, type, number);
                int i = 0;
                if (temps != null)
                {
                    foreach (temp2 r in temps)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = r.Danju_number;
                        dataGridView2.Rows[i].Cells[1].Value = r.Rawmaterial_number;
                        dataGridView2.Rows[i].Cells[2].Value = r.Rawmaterial_name;
                        dataGridView2.Rows[i].Cells[3].Value = r.Rawmaterial_type;
                        dataGridView2.Rows[i].Cells[4].Value = r.Rawmaterial_unit;
                        dataGridView2.Rows[i].Cells[5].Value = r.RawMaterial_supplier;
                        dataGridView2.Rows[i].Cells[6].Value = r.RawMaterial_count;
                        dataGridView2.Rows[i].Cells[7].Value = r.RawMaterial_danjia;
                        dataGridView2.Rows[i].Cells[8].Value = r.RawMaterial_money;
                        dataGridView2.Rows[i].Cells[9].Value = r.Mark;
                        i++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }

        }

        private void 出库单查询_Load(object sender, EventArgs e)
        {

        }
    }
}
