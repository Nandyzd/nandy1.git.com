using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class sale_good
    {
        private int id;
        private string good_number;
        private string customernumber;
        private string unit;
        private double count;
        private double price;
        private double money;
        private string remark;
        private DateTime dan_date;
       
        private string danju_id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Good_number
        {
            get { return good_number; }
            set { good_number = value; }
        }
        public string Customernumber
        {
            get { return customernumber; }
            set { customernumber = value; }
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
        public string Danju_id
        {
            get { return danju_id; }
            set { danju_id = value; }
        }
    }
}
