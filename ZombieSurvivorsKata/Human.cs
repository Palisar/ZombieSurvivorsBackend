using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata
{
    public enum State
    {
        Alive,
        Dead,
        Infected
    }
    public abstract class Human
    {
        protected Human(string name)
        {
            this.Name = name;
            this.Wounds = 0;
        }

        public string Name { get; }
        public int Wounds { get; set; }

        public abstract State State { get; set; }
    }
}
