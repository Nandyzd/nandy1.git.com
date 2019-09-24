using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class inventory//盘点表
    {
        private int id;

        public int Id//盘点Id
        {
            get { return id; }
            set { id = value; }
        }
        private int date;//盘点日期

        public int Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
