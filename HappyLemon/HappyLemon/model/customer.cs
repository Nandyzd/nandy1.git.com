using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class customer
    {
        private int id;
        private string customer_number;
        private string customer_name;
        private string charge_name;
        private string phone;
        private string address;
        private string type;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Customer_number
        {
            get { return customer_number; }
            set { customer_number = value; }
        }
        public string Customer_name
        {
            get { return customer_name; }
            set { customer_name = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

    }
}
