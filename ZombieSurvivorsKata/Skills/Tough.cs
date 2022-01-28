using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata.Skills
{
    public class Tough : BaseSkill
    {
        public Tough() : base("Tough", "Makes you tougher to hit ")
        {
        }

        public override void ApplySkill(Survivor survivor)
        {
            if (!IsActive)
            {
                survivor.WoundsToDeath++;
                IsActive = true;
            }
        }
    }
}
