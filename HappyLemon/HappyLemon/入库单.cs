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
    public partial class 入库单 : Form
    {
        public static string gongyingshang;//供应商；
        public List<string> gongying=new List<string>();//选择所有的供应商
        public bool state = false;//初始化界面
        public List<int> had=new List<int>();//记录原材料表中已有材料的dataGridView的行号
        public DataGridViewTextBoxEditingControl CellEdit = null;
        public double sum=0;//入库的总金额

        
        public 入库单()
        {
            InitializeComponent();
            String time = DateTime.Now.ToString("yyyyMMddHHmmss");
            label10.Text = time;
            state = true;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
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
                    for (int k = 0; k < 8; k++)
                    {//列号
                        if (dataGridView2.Rows[j].Cells[k].Value == null)
                        {

                            wanzheng = false;


                        }
                    }
                }
                if (wanzheng == false)
                {
                    MessageBox.Show("请输入完整!");

                }
                else
                {
                    for (int j = 0; j < dataGridView2.RowCount - 1; j++)//向数据库写入
                    {
                        model.inventory_rawmaterial inr = new model.inventory_rawmaterial();
                        model.rawmaterial raw = new model.rawmaterial();
                        raw.Rawmaterial_number = dataGridView2.Rows[j].Cells[0].Value.ToString();
                        raw.Rawmaterial_name = dataGridView2.Rows[j].Cells[1].Value.ToString();
                        raw.Rawmaterial_type = dataGridView2.Rows[j].Cells[2].Value.ToString();
                        raw.Rawmaterial_unit = dataGridView2.Rows[j].Cells[3].Value.ToString();
                        string cou = dataGridView2.Rows[j].Cells[5].Value.ToString();
                        raw.Rawmaterial_count = double.Parse(cou);

                        model.instock_rawmaterial ins = new model.instock_rawmaterial();
                        ins.RawMaterial_number = dataGridView2.Rows[j].Cells[0].Value.ToString();
                        ins.RawMaterial_count = double.Parse(cou);
                        string danjia = dataGridView2.Rows[j].Cells[6].Value.ToString();
                        ins.RawMaterial_danjia = double.Parse(danjia);
                        ins.RawMaterial_money = ins.RawMaterial_count * ins.RawMaterial_danjia;
                        ins.RawMaterial_supplier = gongying[j];
                        if (dataGridView2.Rows[j].Cells[8].Value == null)
                        {
                            ins.Mark = "";
                        }
                        else
                        {
                            ins.Mark = dataGridView2.Rows[j].Cells[8].Value.ToString();
                        }
                        ins.Danju_number = label10.Text;

                        model.instock_order or = new model.instock_order();
                        or.Danju_number = label10.Text;
                        or.Date = dateTimePicker1.Text;
                        if (had.Contains(j) == true)//增加数量
                        {
                            if (dao.rawmaterialDaow.update_rawmaterialCount(raw) == false)
                            {
                                MessageBox.Show("保存失败！");
                                baocun = false;
                            }
                        }
                        else
                        {
                            if (dao.rawmaterialDaow.add_rawmaterial(raw) == false)
                            {
                                MessageBox.Show("保存失败！");
                                baocun = false;
                            }
                        }
                        if (dao.rawmaterialDaow.add_instock(ins) == false)
                        {
                            MessageBox.Show("保存失败！");
                            baocun = false;
                        }
                        if (dao.rawmaterialDaow.add_instockOrder(or) == false)
                        {
                            MessageBox.Show("保存失败！");
                            baocun = false;
                        }

                    }
                    if (baocun == true)
                    {
                        MessageBox.Show("保存成功！");
                        dataGridView2.Rows.Clear();
                        sum = 0;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("你的操作有误！");
            }
        }

        private void panel2入库_Paint(object sender, PaintEventArgs e)
        {

        }

     
        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Form g = new 供应商();
                g.ShowDialog();
                string[] sArray = gongyingshang.Split(' ');
                dataGridView2.CurrentRow.Cells[4].Value = sArray[1];
                gongying.Add(sArray[0]);
            } 
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (state == true)//输入时，初始化界面完成，输入商品编号时，如果原材料表中有此原材料，则输出原材料的其他信息
                {
                    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                    {
                        string number = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                        model.rawmaterial r = dao.rawmaterialDaow.find_oneRawmaterial(number);
                        if (r != null)
                        {
                            dataGridView2.CurrentRow.Cells[1].Value = r.Rawmaterial_name;
                            dataGridView2.CurrentRow.Cells[2].Value = r.Rawmaterial_type;
                            dataGridView2.CurrentRow.Cells[3].Value = r.Rawmaterial_unit;
                            had.Add(e.RowIndex);
                        }

                    }
                    if (dataGridView2.Rows[e.RowIndex].Cells[5].Value != null && dataGridView2.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        string danjia = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                        string shuliang = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                        double money = double.Parse(danjia) * double.Parse(shuliang);
                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = money;

                    }
                }
                }catch(Exception){
                    MessageBox.Show("你的操作有误！");
                }
               

            }
           

            

            

            
         

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)//让数量，单价，金额列只能输入数字和.
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
            if ((this.dataGridView2.CurrentCellAddress.X ==5) || (this.dataGridView2.CurrentCellAddress.X == 6) || (this.dataGridView2.CurrentCellAddress.X == 7))//获取当前处于活动状态的单元格索引
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9'||e.KeyChar=='.')) e.Handled = true;
                if (e.KeyChar == '\b') e.Handled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            sum = 0;
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void 入库单_Load(object sender, EventArgs e)
        {

        }
           
    }
}
