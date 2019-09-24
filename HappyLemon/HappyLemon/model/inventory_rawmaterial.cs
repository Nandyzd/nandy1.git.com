using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class inventory_rawmaterial//盘点商品表
    {
        private int id;//从inventory表里读出的id

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string rawMaterial_number;//商品编号

        public string RawMaterial_number
        {
            get { return rawMaterial_number; }
            set { rawMaterial_number = value; }
        }
        private int system_stock;//系统库存

        public int System_stock
        {
            get { return system_stock; }
            set { system_stock = value; }
        }
        private int inventory_stock;//盘点库存

        public int Inventory_stock
        {
            get { return inventory_stock; }
            set { inventory_stock = value; }
        }
        private string result;//盘点结果

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

    }
}
