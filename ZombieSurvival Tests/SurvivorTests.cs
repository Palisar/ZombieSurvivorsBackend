
namespace ZombieSurvival_Tests
{
    public class SurvivorTests
    {
        private readonly Survivor sut;

        public SurvivorTests()
        {
            sut = new Survivor("Paul");
        }
        [Fact]
        public void WhenSurvivorIsWounded_Then_WoundIncreaseBy1()
        {
            sut.Wounded();
            sut.Wounds.Should().Be(1);
        }

        [Fact]
        public void WhenSurvivorWoundsAreGreaterThan2_Then_SurvivorStateBecomesDead()
        {
            sut.Wounded();
            sut.Wounded();
            sut.State.Should().Be(State.Dead);
        }

        [Fact]
        public void WhenSurviorIsWounded3Times_Then_WoundsCountIsStill2()
        {
            sut.Wounded();
            sut.Wounded();
            sut.Wounded();
            sut.Wounds.Should().Be(2);
        }

        [Fact]
        public void WhenSurvivorUsesAction_Then_ActionCountDecreases()
        {
            sut.UseAction();
            sut.ActionCount.Should().Be(2);
        }

        [Fact]
        public void WhenSurvivorUsesAction3TImes_Then_ActionCountStopsAt0()
        {
            sut.UseAction();
            sut.UseAction();
            sut.UseAction();
            sut.UseAction();
            sut.ActionCount.Should().Be(0);
        }
    }
}
