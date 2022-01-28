using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata.Skills
{
    public class ExtraMeleeDie : BaseSkill
    {
        public ExtraMeleeDie() : base("+1 Melee Die", "Increase the amount of attack die for a melee weapon by 1")
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
