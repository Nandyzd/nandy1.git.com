using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyLemon
{
    public partial class 出库单 : Form
    {

        public bool state = false;//初始化界面、
        public static string kehu;//客户
        //public List<string> kehu2=new List<string>();
        public static string caozuo=null;//操作人的号
        public DataGridViewTextBoxEditingControl CellEdit = null;
        public List<double> had = new List<double>();//记录原材料表中已有材料的的最大数量
        public 出库单()
        {
            InitializeComponent();
            String time = DateTime.Now.ToString("yyyyMMddHHmmss");
            label10.Text = time;
            state = true;
        }

        private void 出库单_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                bool wanzheng = true;//是否输入完整
                bool baocun = true;
                for (int j = 0; j < dataGridView2.RowCount - 1; j++)//判断是否输入完整
                {
                    for (int k = 0; k < 7; k++)
                    {//列号
                        if (dataGridView2.Rows[j].Cells[k].Value == null)
                        {

                            wanzheng = false;
                        }


                    }
                    if (wanzheng == true)
                    {
                        string cou = dataGridView2.Rows[j].Cells[4].Value.ToString();
                        double max = had[j];
                        if (double.Parse(cou) > max)
                        {
                            MessageBox.Show("超过仓库中的数量！");
                            dataGridView2.Rows[j].Cells[5].Value = max;//清空数量编号  
                            wanzheng = false;
                        }
                    }

                }

                if (caozuo == null)
                {
                    MessageBox.Show("请选择操作人！");
                    wanzheng = false;
                }
                else if (wanzheng == false)
                {
                    MessageBox.Show("请输入完整!");

                }
                else
                {
                    for (int j = 0; j < dataGridView2.RowCount - 1; j++)//向数据库写入
                    {
                        // model.inventory_rawmaterial inr = new model.inventory_rawmaterial();
                        model.rawmaterial raw = new model.rawmaterial();
                        raw.Rawmaterial_number = dataGridView2.Rows[j].Cells[0].Value.ToString();
                        raw.Rawmaterial_name = dataGridView2.Rows[j].Cells[1].Value.ToString();
                        raw.Rawmaterial_type = dataGridView2.Rows[j].Cells[2].Value.ToString();
                        raw.Rawmaterial_unit = dataGridView2.Rows[j].Cells[3].Value.ToString();
                        string cou = dataGridView2.Rows[j].Cells[4].Value.ToString();
                        raw.Rawmaterial_count = double.Parse(cou);

                        model.outstock_rawmaterial ins = new model.outstock_rawmaterial();
                        ins.RawMaterial_number = dataGridView2.Rows[j].Cells[0].Value.ToString();
                        ins.RawMaterial_count = double.Parse(cou);
                        string danjia = dataGridView2.Rows[j].Cells[5].Value.ToString();
                        ins.RawMaterial_danjia = double.Parse(danjia);
                        ins.RawMaterial_money = ins.RawMaterial_count * ins.RawMaterial_danjia;
                        ins.RawMaterial_supplier = caozuo;
                        if (dataGridView2.Rows[j].Cells[7].Value == null)
                        {
                            ins.Mark = "";
                        }
                        else
                        {
                            ins.Mark = dataGridView2.Rows[j].Cells[7].Value.ToString();
                        }
                        ins.Danju_number = label10.Text;

                        model.outstock_order or = new model.outstock_order();
                        or.Danju_number = label10.Text;
                        or.Date = dateTimePicker1.Text;
                        if (dao.rawmaterialDaow.update_rawmaterialCount2(raw) == false)
                        {
                            MessageBox.Show("保存失败！");
                            baocun = false;
                        }
                        if (dao.rawmaterialDaow.add_outstock(ins) == false)
                        {
                            MessageBox.Show("保存失败！");
                            baocun = false;
                        }
                        if (dao.rawmaterialDaow.add_outstockOrder(or) == false)
                        {
                            MessageBox.Show("保存失败！");
                            baocun = false;
                        }

                    }
                    if (baocun == true)
                    {
                        MessageBox.Show("保存成功！");
                        dataGridView2.Rows.Clear();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
        }

      
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (state == true)//输入时，初始化界面完成，输入商品编号时，如果原材料表中有此原材料，则输出原材料的其他信息,如果没有则提示“编号输入错误”
                {
                    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                    {

                        if (dataGridView2.CurrentRow.Cells[0].Value.ToString() != "")
                        {
                            string number = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                            model.rawmaterial r = dao.rawmaterialDaow.find_oneRawmaterial2(number);

                            if (r != null)
                            {
                                dataGridView2.CurrentRow.Cells[1].Value = r.Rawmaterial_name;
                                dataGridView2.CurrentRow.Cells[2].Value = r.Rawmaterial_type;
                                dataGridView2.CurrentRow.Cells[3].Value = r.Rawmaterial_unit;
                                dataGridView2.CurrentRow.Cells[4].Value = r.Rawmaterial_count;
                                had.Add(r.Rawmaterial_count);

                            }
                            else
                            {
                                MessageBox.Show("商品编号输入错误！\n 请重新输入商品编号！");
                                dataGridView2.Rows[e.RowIndex].ReadOnly = true;
                                dataGridView2[e.RowIndex, 0].ReadOnly = false;//除了商品编号其他单元格不可编辑
                                dataGridView2.CurrentRow.Cells[0].Value = "";//清空商品编号   

                            }
                        }


                    }

                    if (dataGridView2.Rows[e.RowIndex].Cells[4].Value != null && dataGridView2.Rows[e.RowIndex].Cells[5].Value != null)
                    {
                        string danjia = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                        string shuliang = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                        double money = double.Parse(danjia) * double.Parse(shuliang);
                        dataGridView2.Rows[e.RowIndex].Cells[6].Value = money;

                    }
                }
            
            }catch(Exception){
                MessageBox.Show("你的操作有误！");
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView2.CurrentCellAddress.X == 4)//获取当前处于活动状态的单元格索引
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress; //绑定事件
            }

        }
        private void Cells_KeyPress(object sender, KeyPressEventArgs e) //自定义事件
        {
            if ((this.dataGridView2.CurrentCellAddress.X == 4) || (this.dataGridView2.CurrentCellAddress.X == 5) || (this.dataGridView2.CurrentCellAddress.X == 6))//获取当前处于活动状态的单元格索引
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.')) e.Handled = true;
                if (e.KeyChar == '\b') e.Handled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Form g = new 员工();
                g.ShowDialog();
                string[] sArray = kehu.Split(' ');
                caozuo = sArray[0];
                button1.Text = sArray[1];
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
        }
    }
}
