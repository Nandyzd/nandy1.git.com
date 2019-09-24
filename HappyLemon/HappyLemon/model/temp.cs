using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class temp//临时存储信息的表
    {
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
        private string rawmaterial_name;//名称
        private string rawmaterial_type;//类型
        private string rawmaterial_unit;//单位
        public string Rawmaterial_name
        {
            get { return rawmaterial_name; }
            set { rawmaterial_name = value; }
        }
        public string Rawmaterial_type
        {
            get { return rawmaterial_type; }
            set { rawmaterial_type = value; }
        }
       
        public string Rawmaterial_unit
        {
            get { return rawmaterial_unit; }
            set { rawmaterial_unit = value; }
        }
    }
}
