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
using MySql.Data.MySqlClient;
using HappyLemon.Util;
namespace HappyLemon.guanli
{
    public partial class good_update : Form
    {
        public good_update()
        {
            InitializeComponent();
        }
        public shangpingguanli s;
        public string number;
        public int j;
        private void good_update_Load(object sender, EventArgs e)
        {
            Console.Write("！！！！！" + number);
            model.good r  = dao.goodDaoz.select(number);
            Number.Text = r.Good_number;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                if (Type.Text == "")
                {
                    MessageBox.Show("类型不能为空！");
                }
                else if (Unit.Text == "")
                {
                    MessageBox.Show("数量不能为空！");
                }
                else if (Price.Text == "")
                {
                    MessageBox.Show("单价不能为空！");
                }
            
                else
                {


                    string msg = "确定修改吗？";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                    {
                        return;
                    }
                    goodDaoz c = new goodDaoz();
                    c.update_good(number, Name1.Text, Type.Text, Unit.Text, double.Parse(Price.Text));
                    s.dataGridView1.Rows[j].Cells[4].Value = Name1.Text;
                    s.dataGridView1.Rows[j].Cells[5].Value = Type.Text;
                    s.dataGridView1.Rows[j].Cells[6].Value = Unit.Text;
                    s.dataGridView1.Rows[j].Cells[7].Value = Price.Text;
                    MessageBox.Show("已修改！");
                    this.Close();
                }

            }

        private void button2_Click(object sender, EventArgs e)
        {
            Name1.Text="";
            Type.Text="";
             Unit.Text="";
            Price.Text="";
        }
            
        }
    }

