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
    public partial class ProfitStatement : Form
    {
        public ProfitStatement()
        {
            InitializeComponent();
        }

        private void ProfitStatement_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
                DataTable dt = new DataTable("table");

                dt.Columns.Add("收款金额", typeof(string));
                dt.Columns.Add("退款金额", typeof(string));
                dt.Columns.Add("成本", typeof(string));
                dt.Columns.Add("利润总额", typeof(string));
             
              
                ZijinDao p = new ZijinDao();
             int ps;
                 int fs;
                 int ts;
                 int profitmoney;

              
                    ps = p.selectGet_date1(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
                   fs = p.selectPayfor_date1(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
                 ts = p.selectTuikuan_date1(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text));
             profitmoney=ps+ts-fs;
          
              
                   
                    dt.Rows.Add(ps,ts,fs,profitmoney);

                
                dataGridView1.DataSource = dt;
                
            }
            catch(SystemException)
            {
               MessageBox.Show("操作不当");
            }

            }
           
            
        
    }
}
