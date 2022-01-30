using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorsKata.Data;
using ZombieSurvivorsKata.Skills;

namespace ZombieSurvival_Tests
{
    public class SkillTreeTests
    {
        private SkillDatabase skills = new();
        [Fact]
        public void CreateNewSkillTree_Then_SkilltreeIsPopulated()
        {
            SkillTree tree = new(skills);
            tree.YellowSkill.Should().BeEquivalentTo(new ExtraAction());
        }
    }
}
