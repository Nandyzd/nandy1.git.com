using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class good
    {
        private int id;
        private string good_number;
        private string good_name;
        private string good_type;
        private string good_unit;
        private double good_price;
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
        public string Good_name
        {
            get { return good_name; }
            set { good_name = value; }
        }
       
        public string Good_type
        {
            get { return good_type; }
            set { good_type = value; }
        }
        public string Good_unit
        {
            get { return good_unit; }
            set { good_unit = value; }
        }
        public double Good_price
        {
            get { return good_price; }
            set { good_price = value; }
        }

    }
}
