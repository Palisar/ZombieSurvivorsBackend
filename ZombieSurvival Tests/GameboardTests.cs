
namespace ZombieSurvival_Tests
{
    public class GameboardTests
    {
        private readonly GameBoard board = new GameBoard();
        private readonly Survivor sut = new Survivor("Wham");
        [Fact]
        public void SurvivorAdded_Then_GameHasStarted()
        {
            board.AddSurvivor("Paul");
            board.SurvivorsSpawned.Should().BeTrue();
        }

        [Fact]
        public void LastSurvivorDied_Then_GameIsOver()
        {
            board.AddSurvivor("sur");

            board.RemoveSurvivor(board.Survivors[0]);
            board.GameOverFlag.Should().BeTrue();
        }
    }
}
