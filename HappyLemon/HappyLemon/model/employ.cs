using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class employ
    {
        private int id;
        private string employee_number;
        private string employee_name;
        private string phone;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Employee_number
        {
            get { return employee_number; }
            set { employee_number = value; }
        }
        public string Employee_name
        {
            get { return employee_name; }
            set { employee_name = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}
