using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata
{
    public class Survivor : Human
    {
        public Survivor(string name) : base(name)
        {
            State = State.Alive;
            ActionCount = 3;
            ActionsPerTurn = 3;
        }

        public sealed override State State { get; set; }
        public int ActionsPerTurn { get; }
        public int ActionCount { get; set; }

        public void Wounded()
        {
            if (this.Wounds < 2)
            {
                Wounds++;
            }
            if (this.Wounds == 2)
            {
                State = State.Dead;
            }
        }

        public void UseAction()
        {
            //TODO : Implement later on
            if (ActionCount > 0)
            {
                ActionCount--;
            }
        }
    }
}
