using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class temp2
    {
           private string rawmaterial_number;//编号
        private string rawmaterial_name;//名称
        private string rawmaterial_type;//类型
        private string rawmaterial_unit;//单位
        private string rawMaterial_supplier;
        private double rawMaterial_count;
        private string mark;
        private double rawMaterial_danjia;
        private double rawMaterial_money;
        private string danju_number;//单据号

       
        public string Rawmaterial_number
        {
            get { return rawmaterial_number; }
            set { rawmaterial_number = value; }
        }
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

      

        public string  RawMaterial_supplier
        {
            get { return rawMaterial_supplier; }
            set { rawMaterial_supplier = value; }
        }
       

        public double RawMaterial_count
        {
            get { return rawMaterial_count; }
            set { rawMaterial_count = value; }
        }
       

        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
    

        public double RawMaterial_danjia
        {
            get { return rawMaterial_danjia; }
            set { rawMaterial_danjia = value; }
        }

     
        public double RawMaterial_money
        {
            get { return rawMaterial_money; }
            set { rawMaterial_money = value; }
        }

        

        public string Danju_number
        {
            get { return danju_number; }
            set { danju_number = value; }
        }
        

    }

    
}
