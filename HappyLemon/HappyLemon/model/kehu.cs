using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyLemon.Util;

namespace HappyLemon.model
{
    class kehu
    {
        public  int id;//客户编码

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public  string customer_number;//客户编码

        public string Customer_number
        {
            get { return customer_number; }
            set { customer_number = value; }
        }
        public string customer_name;//客户姓名

        public string Customer_name
        {
            get { return customer_name; }
            set { customer_name = value; }
        }
        public  string phone;//客户手机号

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public  string address;//客户地址

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
