using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata
{
    public abstract class BaseSkill
    {
        public string Name { get; }
        public string Description { get; }

        public BaseSkill(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void ApplySkill();
    }
}
