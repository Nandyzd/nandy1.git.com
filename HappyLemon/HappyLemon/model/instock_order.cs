using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class instock_order
    {
        private int instock_id;//入库商品的id

        public int Instock_id
        {
            get { return instock_id; }
            set { instock_id = value; }
        }
        private string date;//储存日期

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string danju_number;//单据号

        public string Danju_number
        {
            get { return danju_number; }
            set { danju_number = value; }
        }
    }
}
