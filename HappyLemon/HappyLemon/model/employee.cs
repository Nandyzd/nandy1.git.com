using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class employee
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string employee_number;

        public string Employee_number
        {
            get { return employee_number; }
            set { employee_number = value; }
        }
        private string employee_name;

        public string Employee_name
        {
            get { return employee_name; }
            set { employee_name = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

    }
}
