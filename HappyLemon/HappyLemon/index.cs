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
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void 购货订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchaseOrder p = new purchaseOrder();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 购货单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchaseReturn1 p = new purchaseReturn1();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 采购明细表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchaseDetail2 p = new purchaseDetail2();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 销货订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           purchaseSale p = new purchaseSale();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 销货明细表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saleDetail p = new saleDetail();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 盘点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            盘点 p = new 盘点();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            入库单 p = new 入库单();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 出库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            出库单 p = new 出库单();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 历史查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            盘点查询 p = new 盘点查询();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 历史查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            入库单查询 p = new 入库单查询();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 历史查询ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            出库单查询 p = new 出库单查询();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kehuguanli p = new kehuguanli();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 供应商管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guanli.gongyingshangguanli p = new guanli.gongyingshangguanli();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guanli.shangpingguanli p = new guanli.shangpingguanli();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 员工管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guanli.yuangongguanli p = new guanli.yuangongguanli();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 原材料管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guanli.rawmaterialguanli p = new guanli.rawmaterialguanli();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 收款单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShoukuanDan p = new ShoukuanDan();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 付款单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FukuanDan p = new FukuanDan();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 退款单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TuikuanDan p = new TuikuanDan();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 收款明细表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShoukuanSchedule p = new ShoukuanSchedule();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 付款明细表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FukuanSchedule p = new FukuanSchedule();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 退款明细表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TuikuanSchedule p = new TuikuanSchedule();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 利润表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfitStatement p = new ProfitStatement();
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            p.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(p);
            p.Show();
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
