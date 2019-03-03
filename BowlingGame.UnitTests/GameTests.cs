using BowlingGame.Console;
using NUnit.Framework;

namespace BowlingGame.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void Add_OneThrowNoMark_Return5()
        {
            game.Add(5);
            Assert.That(game.Score, Is.EqualTo(5));
        }

        [Test]
        public void Add_TwoThrowsNoMark_Return9()
        {
            game.Add(5);
            game.Add(4);
            Assert.That(game.Score, Is.EqualTo(9));
        }

        [Test]
        public void Add_OneFrameNoMark_Return9()
        {
            game.Add(5);
            game.Add(4);
            Assert.That(game.ScoreForFrame(1), Is.EqualTo(9));
        }

        [Test]
        public void Add_TwoFramesNoMark_Return18()
        {
            game.Add(5);
            game.Add(4);
            game.Add(7);
            game.Add(2);
            Assert.That(game.ScoreForFrame(2), Is.EqualTo(18));
        }

        [Test]
        public void Add_SimpleSpare_Return13()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            Assert.That(game.ScoreForFrame(1), Is.EqualTo(13));
        }
    }
}