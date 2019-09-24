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
    public partial class addrawmaterial : Form
    {
        public rawmaterialguanli s;
        public addrawmaterial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Number.Text == "")
            {
                MessageBox.Show("原材料编码不能为空！");
            }
            else if (Name1.Text == "")
            {
                MessageBox.Show("原材料名称不能为空！");
            }

            else if (Type.Text == "")
            {
                MessageBox.Show("类型不能为空！");
            }
            else if (Count.Text == "")
            {
                MessageBox.Show("数量不能为空！");
            }
            else if (Unit.Text == "")
            {
                MessageBox.Show("数量单位不能为空！");
            }
            else
            {
                string number = Number.Text;
                string name = Name1.Text;
                string type = Type.Text;
                string unit = Unit.Text;
                double count = double.Parse(Count.Text);
                rawmaterialDaoz c = new rawmaterialDaoz();

                string msg = "确定添加吗？";

                if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                {
                    return;
                }
                c.addRawmaterial(number, name, type,count,unit);
                Console.Write(c.su + "!!");
                if (c.su == 0)
                {
                    
                }
                else
                {
                    int node = s.dataGridView1.Rows.Count;
                    s.dt.Rows.Add(node + 1, number, name, type,count,unit);
                    s.dataGridView1.DataSource = s.dt;
                    this.Close();
                }
            }
        }

        private void addrawmaterial_Load(object sender, EventArgs e)
        {

        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Number.Text="";
            Name1.Text="";
             Type.Text="";
             Unit.Text="";
           Count.Text="";
        }
    }
}
