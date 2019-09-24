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
    public partial class 盘点 : Form
    {
        bool chaxun_is;//是否是查询的状态
        int count;
        public 盘点()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            int i = 0;//dataGridView1的行数
            //显示盘点结果
            try
            {
                List<rawmaterial> rs = dao.rawmaterialDaow.find_all();
                if (rs != null)
                {

                    foreach (rawmaterial r in rs)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = r.Rawmaterial_number;
                        dataGridView1.Rows[i].Cells[1].Value = r.Rawmaterial_name;
                        dataGridView1.Rows[i].Cells[2].Value = r.Rawmaterial_type;
                        dataGridView1.Rows[i].Cells[3].Value = r.Rawmaterial_unit;
                        dataGridView1.Rows[i].Cells[4].Value = r.Rawmaterial_count;
                        dataGridView1.Rows[i].Cells[6].Value = "0";
                        i++;
                    }
                }
                count = i;
                dataGridView1.ReadOnly = false;
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    if (c.Index != 5 && c.Index != 6)
                        c.ReadOnly = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                int i = 0;//dataGridView1的行数
                //显示盘点结果
                List<rawmaterial> rs = dao.rawmaterialDaow.find_all();
                if (rs != null)
                {

                    foreach (rawmaterial r in rs)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = r.Rawmaterial_number;
                        dataGridView1.Rows[i].Cells[1].Value = r.Rawmaterial_name;
                        dataGridView1.Rows[i].Cells[2].Value = r.Rawmaterial_type;
                        dataGridView1.Rows[i].Cells[3].Value = r.Rawmaterial_unit;
                        dataGridView1.Rows[i].Cells[4].Value = r.Rawmaterial_count;
                        dataGridView1.Rows[i].Cells[6].Value = "0";
                        i++;
                    }
                }
                count = i;
                dataGridView1.ReadOnly = false;
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    if (c.Index != 5 && c.Index != 6)
                        c.ReadOnly = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("你的错误有误！");
            }
           
        }

        private void chaxun_Click(object sender, EventArgs e)
        {
            try
            {
                chaxun_is = true;
                string time = riqi.Value.ToString().Substring(0, 10);
                string type = comboBox1.Text.ToString();
                dataGridView1.Rows.Clear();
                int i = 0;//dataGridView1的行数
                //显示盘点结果
                List<rawmaterial> rs = dao.rawmaterialDaow.find_all2(type);
                if (rs != null)
                {

                    foreach (rawmaterial r in rs)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = r.Rawmaterial_number;
                        dataGridView1.Rows[i].Cells[1].Value = r.Rawmaterial_name;
                        dataGridView1.Rows[i].Cells[2].Value = r.Rawmaterial_type;
                        dataGridView1.Rows[i].Cells[3].Value = r.Rawmaterial_unit;
                        dataGridView1.Rows[i].Cells[4].Value = r.Rawmaterial_count;
                        dataGridView1.Rows[i].Cells[6].Value = "0";
                        i++;
                    }
                }
                count = i;
                dataGridView1.ReadOnly = false;
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    if (c.Index != 5 && c.Index != 6)
                        c.ReadOnly = true;
                }
                //清空条件
                comboBox1.Text = "";
                chaxun_is = false;
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = count;
                bool wanzheng = true;//是否输入盘点结果
                for (int j = 0; j < i; j++)
                {
                    if (dataGridView1.Rows[j].Cells[5].Value == null)
                    {
                        MessageBox.Show("请输入盘点结果!");
                        wanzheng = false;
                        break;
                    }
                }
                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (wanzheng == true)
                {
                    if (dao.rawmaterialDaow.add_pandian(date))
                    {
                        int id = dao.rawmaterialDaow.find_pandianId(date);
                        inventory_rawmaterial r = new inventory_rawmaterial();
                        for (int j = 0; j < count; j++)
                        {
                            r.Id = id;
                            r.RawMaterial_number = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value);
                            r.System_stock = Convert.ToInt32(dataGridView1.Rows[j].Cells[4].Value);
                            r.Inventory_stock = Convert.ToInt32(dataGridView1.Rows[j].Cells[5].Value);
                            r.Result = Convert.ToString(dataGridView1.Rows[j].Cells[6].Value);
                            dao.rawmaterialDaow.add_pandian(r);
                        }
                        MessageBox.Show("保存成功！");
                        dataGridView1.Rows.Clear();


                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (chaxun_is == false)
                {
                    int i = count;
                    for (int j = 0; j < i; j++)
                    {
                        if (dataGridView1.Rows[j].Cells[5].Value != null)
                        {

                            int pandian = Convert.ToInt32(dataGridView1.Rows[j].Cells[5].Value);//盘点库存
                            int xitong = Convert.ToInt32(dataGridView1.Rows[j].Cells[4].Value);//系统库存

                            if (pandian > xitong)
                            {
                                dataGridView1.Rows[j].Cells[6].Value = "盘盈";
                            }
                            else if (pandian == xitong)
                            {
                                dataGridView1.Rows[j].Cells[6].Value = "盘平";
                            }
                            else
                            {
                                dataGridView1.Rows[j].Cells[6].Value = "盘亏";
                            }

                        }
                    }


                }
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
