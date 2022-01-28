using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorsKata.Skills
{
    public class ExtraFreeMoveAction : BaseSkill
    {
        public ExtraFreeMoveAction() : base("+1 Free Move Action", "Allows 1 free movement action per turn")
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
