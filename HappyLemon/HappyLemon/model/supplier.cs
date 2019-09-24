using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class supplier
    {
        private int id;
        private string supplier_number;
        private string supplier_name;
        private string charge_name;
        private string telephone;
        private string address;
        private string type;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Supplier_number
        {
            get { return supplier_number; }
            set { supplier_number = value ; }
        }
        public string Supplier_name
        {
            get { return supplier_name; }
            set { supplier_name = value; }
        }
        public string Charge_name
        {
            get { return charge_name; }
            set { charge_name = value; }
        }
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
