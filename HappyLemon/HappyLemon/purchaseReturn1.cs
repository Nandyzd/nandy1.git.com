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
    public partial class purchaseReturn1 : Form
    {
        public string[] number1;
        public DataGridView datagridView = new DataGridView();
        public purchaseReturn1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool b = true;
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("请填写信息");
                b = false;
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {


                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        MessageBox.Show("编号不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[1].Value == null)
                    {
                        MessageBox.Show("商品名称不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[3].Value == null)
                    {
                        MessageBox.Show("单位不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[4].Value == null)
                    {
                        MessageBox.Show("数量不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[5].Value == null)
                    {
                        MessageBox.Show("单价不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[6].Value == null)
                    {
                        MessageBox.Show("金额不能为空");
                        b = false;
                    }
                    else if (supplier_text.Text == "")
                    {
                        MessageBox.Show("请选择供应商");
                        b = false;
                    }
                }
            }
            if (b == false)
            {

            }
            else
            {
                purchase dao = new purchase();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    purchase_material p = new purchase_material();
                    Console.Write(dataGridView1.Rows[i].Cells[0].Value + "lallalalaalalalalalalla");
                    p.RawMaterial_number = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    p.Suppliernumber = supplier_text.Text;
                    p.Dan_date = Convert.ToDateTime(dateTimePicker1.Text);

                    p.Unit = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    p.Count = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    p.Price = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    p.Money = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                    if (dataGridView1.Rows[i].Cells[7].Value == null)
                    {
                        p.Remark = " ";
                    }
                    else
                    {
                        p.Remark = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    }
                    p.Status = 1;
                    dao.addpurchase(p);

                }
                MessageBox.Show("保存成功");

            }
        }

        private void purchaseReturn1_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“lemonDataSet.supplier”中。您可以根据需要移动或删除它。
            //panel1.Visible = false;
            //自动生成单据
            purchase p = new purchase();
            int P_Int_newBillCode = p.selectMaxdanjuid() + 1;//记录单据编号中的数字码
            textBox1.Text = DateTime.Now.ToString("yyyyMMdd") + "HappyLemon" + P_Int_newBillCode;




            rawmaterial r1 = new rawmaterial();
            rawmaterialdao dao = new rawmaterialdao();
            //int index=this.purchaseTable.Rows.Add();
            //Console.Write(number1[0]);
            if (number1 == null)
            {

            }
            else
            {
                foreach (string i in number1)
                {

                    r1 = dao.selectNumber(i);
                    if (r1 == null)
                    {
                    }
                    else
                    {
                        int index = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[index].Cells[0].Value = r1.Rawmaterial_number;
                        this.dataGridView1.Rows[index].Cells[1].Value = r1.Rawmaterial_name;
                        this.dataGridView1.Rows[index].Cells[3].Value = r1.Rawmaterial_unit;
                    }

                }
            }
            dataGridView1.Focus();//使表格获得鼠标焦点
            supplier_text.Focus();//使供应商文本框成为焦点

           
        }

        private void search_history_Click(object sender, EventArgs e)
        {
            purchase p = new purchase();
            List<purchaseDanju> ps = new List<purchaseDanju>();
            try
            {
                Console.Write(Convert.ToDateTime(dateTimePicker2.Text));
                if (textBox2.Text == "请输入单据号" || textBox2.Text == "")
                {
                    DataTable dt = new DataTable("teble");
                    dt.Columns.Add("订单日期", typeof(string));
                    dt.Columns.Add("单据编号", typeof(string));
                    dt.Columns.Add("供应商", typeof(String));
                    dt.Columns.Add("总金额", typeof(double));
                    dt.Columns.Add("操作人", typeof(String));
                    dt.Columns.Add("备注", typeof(String));
                    ps = p.selectdate(Convert.ToDateTime(dateTimePicker2.Text), Convert.ToDateTime(dateTimePicker3.Text), 1);
                    foreach (purchaseDanju p1 in ps)
                    {
                        employ e1 = new employ();
                        employeedao edao = new employeedao();
                        e1 = edao.selectid(p1.Emploee_id);
                        supplier s1 = new supplier();
                        supplierdao sdao = new supplierdao();
                        s1 = sdao.selectnumber(p1.Supplier_number);
                        dt.Rows.Add(p1.Date, p1.Danju, s1.Supplier_name, p1.Money, e1.Employee_name, p1.Remark);
                    }
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    DataTable dt = new DataTable("teble");
                    dt.Columns.Add("订单日期", typeof(string));
                    dt.Columns.Add("单据编号", typeof(string));
                    dt.Columns.Add("供应商", typeof(String));
                    dt.Columns.Add("总金额", typeof(double));
                    dt.Columns.Add("操作人", typeof(String));
                    dt.Columns.Add("备注", typeof(String));
                    ps = p.selectdateAndNum_Supp(textBox2.Text, 1);
                    foreach (purchaseDanju p1 in ps)
                    {
                        employ e1 = new employ();
                        employeedao edao = new employeedao();
                        e1 = edao.selectid(p1.Emploee_id);
                        supplier s1 = new supplier();
                        supplierdao sdao = new supplierdao();
                        s1 = sdao.selectnumber(p1.Supplier_number);
                        dt.Rows.Add(p1.Date, p1.Danju, s1.Supplier_name, p1.Money, e1.Employee_name, p1.Remark);
                    }
                    dataGridView2.DataSource = dt;
                }
            }
            catch (SystemException)
            {
                MessageBox.Show("操作有误");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = this.dataGridView2.CurrentRow.Index;
                Console.Write(dataGridView2.Rows[r].Cells[1].Value.ToString());
                DataTable dt = new DataTable("teble");
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("名称", typeof(string));
                dt.Columns.Add("单位", typeof(String));
                dt.Columns.Add("数量", typeof(double));
                dt.Columns.Add("单价", typeof(double));
                dt.Columns.Add("金额", typeof(double));
                dt.Columns.Add("备注", typeof(String));
                purchase p = new purchase();
                List<purchase_material> ps = new List<purchase_material>();
                ps = p.selectMaterial_danhao(dataGridView2.Rows[r].Cells[1].Value.ToString(), 1);
                foreach (purchase_material p1 in ps)
                {
                    rawmaterial r1 = new rawmaterial();
                    rawmaterialdao rdao = new rawmaterialdao();
                    r1 = rdao.selectNumber(p1.RawMaterial_number);
                    dt.Rows.Add(p1.RawMaterial_number, r1.Rawmaterial_name, p1.Unit, p1.Count, p1.Price, p1.Money, p1.Remark);
                }
                dataGridView2.DataSource = dt;
            }
            catch (SystemException)
            {

                MessageBox.Show("操作有误");
            }      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supplier_suoyin su = new supplier_suoyin();
            su.purchase_return = this;
            //Console.Write("lalallaal");
            su.type = "购货退货单";
            su.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee_purchase su = new employee_purchase();
            su.purchase_return = this;
            //Console.Write("lalallaal");
            su.type = "购货退货单";
            su.ShowDialog();
        }
        private void dataGridView_CellStateChange(object sender, DataGridViewCellCancelEventArgs e)
        {
            double money = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                money += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
            label9.Text = money.ToString();
            label9.Focus();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    rawMaterial r = new rawMaterial();
                    r.purchase_return = this;
                    r.node = dataGridView1.Rows.Count - 1;
                    Console.Write("lalallaal");
                    r.type = "购货退货单";
                    r.ShowDialog();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            bool b = true;
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("请填写信息");
                b = false;
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {


                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        MessageBox.Show("编号不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[1].Value == null)
                    {
                        MessageBox.Show("商品名称不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[3].Value == null)
                    {
                        MessageBox.Show("单位不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[4].Value == null)
                    {
                        MessageBox.Show("数量不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[5].Value == null)
                    {
                        MessageBox.Show("单价不能为空");
                        b = false;
                    }
                    else if (dataGridView1.Rows[i].Cells[6].Value == null)
                    {
                        MessageBox.Show("金额不能为空");
                        b = false;
                    }
                    else if (textBox1.Text == "")
                    {
                        MessageBox.Show("请选择供应商");
                        b = false;
                    }
                    else if (textBox3.Text == "")
                    {
                        MessageBox.Show("操作人不能为空！");
                    }
                }
            }
            if (b == false)
            {

            }
            else
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("是否确认保存？", "提交", messButton);
                if (dr == DialogResult.OK)
                {
                    string[] supplier = supplier_text.Text.Split(' ');
                    string[] employer = textBox3.Text.Split(' ');
                    try
                    {
                        purchase dao = new purchase();
                        double mm = Convert.ToDouble(label9.Text);
                        dao.addDanju(Convert.ToDateTime(dateTimePicker1.Text), textBox1.Text, employer[0], mm, textBox4.Text, supplier[0], 1);

                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            purchase_material p = new purchase_material();
                            Console.Write(dataGridView1.Rows[i].Cells[0].Value + "lallalalaalalalalalalla");
                            p.RawMaterial_number = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            p.Suppliernumber = supplier[0];
                            p.Dan_date = Convert.ToDateTime(dateTimePicker1.Text);
                            Console.Write("这是一个人" + p.Suppliernumber + "这是一个人");
                            p.Unit = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            p.Count = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                            p.Price = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                            //Console.Write("这是一个人" + p.Price + "这是一个人");
                            p.Money = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                            if (dataGridView1.Rows[i].Cells[7].Value == null)
                            {
                                p.Remark = "";
                            }
                            else
                            {
                                p.Remark = dataGridView1.Rows[i].Cells[7].Value.ToString();

                            }

                            p.Status = 1;
                            p.Danju_id = textBox1.Text;
                            // Console.Write("这是一个人" + p.Danju_id + "这是一个人");
                            dao.addpurchase(p);

                        }
                        MessageBox.Show("保存成功");

                    }
                    catch (SystemException)
                    {
                        MessageBox.Show("操作有误");
                    }
                }
                else
                {

                }
            }
        }

        private void historybutton_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            double money = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                money += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
            label9.Text = money.ToString();
            label9.Focus();
        }
    }
}
