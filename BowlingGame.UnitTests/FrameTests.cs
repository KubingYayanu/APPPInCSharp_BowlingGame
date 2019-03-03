using BowlingGame.Console;
using NUnit.Framework;

namespace BowlingGame.UnitTests
{
    [TestFixture]
    public class FrameTests
    {
        [Test]
        public void Score_NoThrows_Return0()
        {
            var frame = new Frame();
            Assert.That(frame.Score, Is.EqualTo(0));
        }

        [Test]
        public void Add_OneThrowNoMark_Return5()
        {
            var frame = new Frame();
            frame.Add(5);
            Assert.That(frame.Score, Is.EqualTo(5));
        }
    }
}