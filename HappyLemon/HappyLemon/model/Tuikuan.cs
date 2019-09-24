using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class Tuikuan
    {
        private int id;
        private string tuikuan_zhanghu;
        private string tuikuan_money;
        private string tuikuan_way;
        private string mark;
        private string tuikuan_suppliernumber;
        private string employee_number;
        private DateTime date;
        private string tuikuan_danjuid;
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Tuikuan_zhanghu
        {
            set { tuikuan_zhanghu = value; }
            get { return tuikuan_zhanghu; }
        }
        public string Tuikuan_money
        {
            set { tuikuan_money = value; }
            get { return tuikuan_money; }
        }
        public string Tuikuan_way
        {
            set { tuikuan_way = value; }
            get { return tuikuan_way; }
        }
        public string Mark
        {
            set { mark = value; }
            get { return mark; }
        }
        public string Tuikuan_suppliernumber
        {
            set { tuikuan_suppliernumber = value; }
            get { return tuikuan_suppliernumber; }
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
        public string Tuikuan_danjuid
        {
            set { tuikuan_danjuid = value; }
            get { return tuikuan_danjuid; }
        }
    }
}
