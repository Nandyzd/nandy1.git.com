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
namespace HappyLemon.guanli
{
    public partial class dataview : Form
    {
        public dataview()
        {
            InitializeComponent();
        }

        private void dataview_Load(object sender, EventArgs e)
        {
            List<kehu> kehus = new List<kehu>();
            kehus = dao.customerDaoz.find_all();
            if (kehus != null)
            {

                foreach (kehu k in kehus)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = k.Id;
                    this.dataGridView1.Rows[index].Cells[1].Value = k.Customer_number;
                    this.dataGridView1.Rows[index].Cells[2].Value = k.Customer_name;
                    this.dataGridView1.Rows[index].Cells[3].Value = k.Phone;
                    this.dataGridView1.Rows[index].Cells[4].Value = k.Address;
                }
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    }
}
