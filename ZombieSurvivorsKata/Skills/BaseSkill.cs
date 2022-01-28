using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata
{
    public abstract class BaseSkill
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public BaseSkill(string name, string description)
        {
            Name = name;
            Description = description;
            IsActive = false;
        }
        public bool IsActive { get; set; }
        public abstract void ApplySkill(Survivor survivor);
    }
}
