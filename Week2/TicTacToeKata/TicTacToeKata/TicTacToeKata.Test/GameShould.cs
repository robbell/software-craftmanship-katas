using NUnit.Framework;
using TicTacToeKata.Src;

namespace TicTacToeKata.Test
{
    [TestFixture]
    public class GameShould
    {
        [Test]
        public void NotAllowOToGoFirst()
        {
            var game = new Game();

            Assert.That(game.PlaceO(), Is.EqualTo(MoveResult.NotYourTurn));
        }
    }
}
