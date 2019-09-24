using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class outstock_rawmaterial
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string  rawMaterial_number;

        public  string RawMaterial_number
        {
            get { return rawMaterial_number; }
            set { rawMaterial_number = value; }
        }
        private string rawMaterial_supplier;

        public string  RawMaterial_supplier
        {
            get { return rawMaterial_supplier; }
            set { rawMaterial_supplier = value; }
        }
        private double rawMaterial_count;

        public double RawMaterial_count
        {
            get { return rawMaterial_count; }
            set { rawMaterial_count = value; }
        }
        private string mark;

        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        private double rawMaterial_danjia;

        public double RawMaterial_danjia
        {
            get { return rawMaterial_danjia; }
            set { rawMaterial_danjia = value; }
        }

        private double rawMaterial_money;

        public double RawMaterial_money
        {
            get { return rawMaterial_money; }
            set { rawMaterial_money = value; }
        }

        private string danju_number;//单据号

        public string Danju_number
        {
            get { return danju_number; }
            set { danju_number = value; }
        }
        

    }
}
