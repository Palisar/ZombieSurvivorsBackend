using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata.Skills
{
    public class Sniper : BaseSkill
    {
        public Sniper() : base("Sniper", "Increased range something")
        {
        }

        public override void ApplySkill(Survivor survivor)
        {
            if (!IsActive)
            {
                IsActive = true;
            }
        }
    }
}
