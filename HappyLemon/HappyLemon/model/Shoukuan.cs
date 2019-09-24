using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HappyLemon.model
{
    class Shoukuan
    {
        private int id;
        private string get_zhanghu;
        private string get_money;
        private string get_way;
        private string mark;
        private string get_suppliernumber;
        private string employee_number;
        private DateTime date;
        private string get_danjuid;
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Get_zhanghu
        {
            set { get_zhanghu = value; }
            get { return get_zhanghu; }
        }
        public string Get_money
        {
            set { get_money = value; }
            get { return get_money; }
        }
        public string Get_way
        {
            set { get_way = value; }
            get { return get_way; }
        }
        public string Mark
        {
            set { mark = value; }
            get { return mark; }
        }
        public string Get_suppliernumber
        {
            set { get_suppliernumber = value; }
            get { return get_suppliernumber; }
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
        public string Get_danjuid
        {
            set { get_danjuid = value; }
            get { return get_danjuid; }
        }
    }
}
