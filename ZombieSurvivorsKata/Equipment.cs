using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata
{
    public class Equipment
    {
        public Equipment(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
