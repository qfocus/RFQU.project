using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace runmu.Service
{
    public class Teacher
    {
        string name;
        int id;
        string qq;
        string phone;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Qq { get => qq; set => qq = value; }
    }
}
