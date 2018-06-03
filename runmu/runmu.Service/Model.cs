using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace runmu.Business
{
    public class Model
    {
        string name;
        string alias;
        string qq;
        string email;
        int teacherId;
        double price;


        public string Name { get => name; set => name = SetString(value); }
        public string Alias { get => alias; set => alias = SetString(value); }
        public string Qq { get => qq; set => qq = SetString(value); }
        public string Email { get => email; set => email = SetString(value); }
        public double Price { get => price; set => price = value; }
        public int TeacherId { get => teacherId; set => teacherId = value; }

        private string SetString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "-";
            }
            return value;
        }    
    }
}
