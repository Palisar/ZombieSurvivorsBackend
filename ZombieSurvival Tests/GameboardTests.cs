
namespace ZombieSurvival_Tests
{
    public class GameboardTests
    {
        static GameLog _log = new GameLog();
        private GameBoard _board = new GameBoard(_log);
        private Survivor sut = new Survivor("Wham", _log);
        [Fact]
        public void SurvivorAdded_Then_GameHasStarted()
        {
            _board.AddSurvivor("Paul");
            _board.SurvivorsSpawned.Should().BeTrue();
        }

        [Fact]
        public void LastSurvivorDied_Then_GameIsOver()
        {
            _board.AddSurvivor("sur");

            _board.RemoveSurvivor(_board.Survivors[0]);
            _board.GameOverFlag.Should().BeTrue();
        }
    }
}
