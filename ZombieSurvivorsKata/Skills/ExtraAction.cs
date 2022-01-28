using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata.Skills
{
    public class ExtraAction : BaseSkill
    {
        public ExtraAction() : base("+1 Action", "Increases the number of actions you can use per turn")
        {
        }

        public override void ApplySkill(Survivor survivor)
        {
            if (IsActive) return;
            survivor.ActionCount++;
            IsActive = true;
        }
    }
}
