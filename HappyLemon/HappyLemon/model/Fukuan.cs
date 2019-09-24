using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class Fukuan
    {
        private int id;
        private string payfor_zhanghu;
        private string payfor_money;
        private string payfor_way;
        private string mark;
        private string payfor_suppliernumber;
        private string employee_number;
        private DateTime date;
        private string payfor_danjuid;
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Payfor_zhanghu
        {
            set { payfor_zhanghu = value; }
            get { return payfor_zhanghu; }
        }
        public string Payfor_money
        {
            set { payfor_money = value; }
            get { return payfor_money; }
        }
        public string Payfor_way
        {
            set { payfor_way = value; }
            get { return payfor_way; }
        }
        public string Mark
        {
            set { mark = value; }
            get { return mark; }
        }
        public string Payfor_suppliernumber
        {
            set { payfor_suppliernumber = value; }
            get { return payfor_suppliernumber; }
        }
        public string Employee_number
        {
            set { employee_number = value; }
            get { return employee_number; }
        }
        public DateTime Date
        {
            set { date = value; }
            get { return date; }
        }
        public string Payfor_danjuid
        {
            set { payfor_danjuid = value; }
            get { return payfor_danjuid; }
        }
    }
}
