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
    public partial class rawmaterial_update : Form
    {
        public rawmaterial_update()
        {
            InitializeComponent();
        }
        public rawmaterialguanli s;
        public string number;
        public int j;
        private void rawmaterial_update_Load(object sender, EventArgs e)
        {
            Console.Write("！！！！！" + number);
            model.rawmaterial r = dao.rawmaterialDaoz.select(number);
            Number.Text = r.Rawmaterial_number;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Name1.Text="";
            Type.Text="";
            Count.Text="";
           Unit.Text="";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if(Name1.Text=="")
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


                    string msg = "确定修改吗？";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                    {
                        return;
                    }
                    rawmaterialDaoz c = new rawmaterialDaoz();
                    c.update_rawmaterial(number, Name1.Text, Type.Text,double.Parse(Count.Text),Unit.Text);
                    s.dataGridView1.Rows[j].Cells[4].Value = Name1.Text;
                    s.dataGridView1.Rows[j].Cells[5].Value = Type.Text;
                    s.dataGridView1.Rows[j].Cells[6].Value = Count.Text;
                    s.dataGridView1.Rows[j].Cells[7].Value = Unit.Text;
                    MessageBox.Show("已修改！");
                    this.Close();
                }

            }
        }
    }
