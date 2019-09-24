using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class purchaseDanju
    {
        private int id;
        private DateTime date;
        private string danju;
        private string emplyee_id;
        private double money;
        private string remark;
        private string supplier_number;
        private int status;
        public int Id
        {
            set { id=value;}
            get { return id; }
        }
        public DateTime Date
        {
            set { date = value; }
            get { return date; }
        }
        public string Danju
        {
            set { danju = value; }
            get { return danju; }
        }
        public string Emploee_id
        {
            set { emplyee_id = value; }
            get { return emplyee_id; }
        }
        public double Money
        {
            set { money = value; }
            get { return money; }
        }
        public string Remark
        {
            set { remark = value; }
            get { return remark; }
        }
        public string Supplier_number
        {
            set { supplier_number = value; }
            get { return supplier_number; }
        }
        public int Status
        {
            set { status = value; }
            get { return status; }
        }
    }
}
