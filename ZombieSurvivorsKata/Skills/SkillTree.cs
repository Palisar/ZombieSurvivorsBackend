using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorsKata.Data;

namespace ZombieSurvivorsKata.Skills
{
    public class SkillTree
    {
        private Random random = new();
        public SkillTree(SkillDatabase skills)
        {
            PotentialSkills.Add(new ExtraAction());
            for (int i = 0; i < 3; i++)
            {
                int index = random.Next(0, skills.SkillsDatabase.Count);
                PotentialSkills.Add(skills.SkillsDatabase[index]);
                skills.SkillsDatabase.RemoveAt(index);
            }

        }

        public List<object> PotentialSkills { get; set; }

        
    }
}
