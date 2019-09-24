using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class purchase_material
    {
        private int id;
        private string rawMaterial_number;
        private string suppliernumber;
        private string unit;
        private double count;
        private double price;
        private double money;
        private string remark;
        private DateTime dan_date;
        private int status;
        private string danju_id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string RawMaterial_number
        {
            get { return rawMaterial_number; }
            set { rawMaterial_number = value; }
        }
        public string Suppliernumber
        {
            get { return suppliernumber; }
            set { suppliernumber = value; }
        }
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        public double Count
        {
            get { return count; }
            set { count = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public double Money
        {
            get { return money; }
            set { money = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        public DateTime Dan_date
        {
            get { return dan_date; }
            set { dan_date = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Danju_id
        {
            get { return danju_id; }
            set { danju_id = value; }
        }
    }
}
