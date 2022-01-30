using System;
using System.Buffers.Text;
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
            GetBlueSkill(skills);
            YellowSkill = new ExtraAction();
            PopulatePotentialOrangeSkills(skills);
            PopulatePotentialRedSkills(skills);
        }
        public BaseSkill BlueSkill { get; private set; }
        public BaseSkill YellowSkill { get; private set; }

        public BaseSkill OrangeSkill { get; private set; }
        public  BaseSkill RedSkill { get; private set; }
        public BaseSkill[] PotentialOrangeSkills { get; private set; } = new BaseSkill[2];
        public BaseSkill[] PotentialRedSkills { get; private set; } = new BaseSkill[3];

        private void GetBlueSkill(SkillDatabase skills)
        {
            var index = random.Next(0, skills.SkillsDatabase.Count);
            BlueSkill = skills.SkillsDatabase[random.Next(0, skills.SkillsDatabase.Count)];
            skills.SkillsDatabase.RemoveAt(index);
        }

        private void PopulatePotentialOrangeSkills(SkillDatabase skills)
        {
            for (var i = 0; i < PotentialOrangeSkills.Length; i++)
            {
                var index = random.Next(0, skills.SkillsDatabase.Count);
                PotentialOrangeSkills[i] = skills.SkillsDatabase[index];
                skills.SkillsDatabase.RemoveAt(index);
            }
        }

        private void PopulatePotentialRedSkills(SkillDatabase skills)
        {
            for (var i = 0; i < PotentialRedSkills.Length; i++)
            {
                var index = random.Next(0, skills.SkillsDatabase.Count);
                PotentialRedSkills[i] = skills.SkillsDatabase[index];
                skills.SkillsDatabase.RemoveAt(index);
            }
        }
    }
}
