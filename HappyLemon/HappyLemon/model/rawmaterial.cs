using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLemon.model
{
    class rawmaterial
    {
        private int id;
        private string rawmaterial_number;
        private string rawmaterial_name;
        private string rawmaterial_type;
        private double rawmaterial_count;
        private string rawmaterial_unit;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Rawmaterial_number
        {
            get { return rawmaterial_number; }
            set { rawmaterial_number = value; }
        }
        public string Rawmaterial_name
        {
            get { return rawmaterial_name; }
            set { rawmaterial_name = value; }
        }
        public string Rawmaterial_type
        {
            get { return rawmaterial_type; }
            set { rawmaterial_type = value; }
        }
        public double Rawmaterial_count
        {
            get { return rawmaterial_count; }
            set { rawmaterial_count = value; }
        }
        public string Rawmaterial_unit
        {
            get { return rawmaterial_unit; }
            set { rawmaterial_unit = value; }
        }
    }
}
