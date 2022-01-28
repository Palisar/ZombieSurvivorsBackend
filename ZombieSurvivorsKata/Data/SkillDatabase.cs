using ZombieSurvivorsKata;
using ZombieSurvivorsKata.Skills;

namespace ZombieSurvivorsKata.Data
{
    public class SkillDatabase
    {
        public SkillDatabase()
        {
            SkillsDatabase.Add(new ExtraFreeMoveAction());
            SkillsDatabase.Add(new ExtraMeleeDie());
            SkillsDatabase.Add(new ExtraRangedDie());
            SkillsDatabase.Add(new Hoard());
            SkillsDatabase.Add(new Sniper());
            SkillsDatabase.Add(new Tough());
        }

        public List<BaseSkill> SkillsDatabase;
    }
}
