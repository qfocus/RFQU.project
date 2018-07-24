using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runmu.Business
{
    public class Args
    {
        public Args(string name, object value)
        {
            this.name = name;
            this.value = value;
            this.condition = "=";
        }

        public Args(string name, string condition, object value)
        {
            this.name = name;
            this.condition = condition;
            this.value = value;
        }

        string condition;
        string name;
        object value;

        public string Condition { get => condition; set => condition = value; }
        public string Name { get => name; set => name = value; }
        public object Value { get => value; set => this.value = value; }
    }
}
