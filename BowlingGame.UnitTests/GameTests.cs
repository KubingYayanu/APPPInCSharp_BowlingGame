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

        #region Add

        [Test]
        public void Add_TwoThrowsNoMark_ReturnTotalScore9()
        {
            game.Add(5);
            game.Add(4);
            Assert.That(game.Score, Is.EqualTo(9));
        }

        #endregion Add

        #region Score

        [Test]
        public void Score_SimpleFrameAfterSpare_ReturnTotalScoreIs18()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            game.Add(2);
            Assert.That(game.Score, Is.EqualTo(18));
        }

        [Test]
        public void Score_SimpleStrike_ReturnTotalScoreIs28()
        {
            game.Add(10);
            game.Add(3);
            game.Add(6);
            Assert.That(game.Score, Is.EqualTo(28));
        }

        [Test]
        public void Score_PerfectGame_ReturnTotalScoreIs300()
        {
            for (int i = 0; i < 12; i++)
            {
                game.Add(10);
            }
            Assert.That(game.Score, Is.EqualTo(300));
        }

        [Test]
        public void Score_EndOfArray_ReturnTotalScoreIs20()
        {
            for (int i = 0; i < 9; i++)
            {
                game.Add(0);
                game.Add(0);
            }
            game.Add(2);
            game.Add(8);
            game.Add(10);
            Assert.That(game.Score, Is.EqualTo(20));
        }

        [Test]
        public void Score_SampleGame_ReturnTotalScoreIs133()
        {
            game.Add(1);
            game.Add(4);
            game.Add(4);
            game.Add(5);
            game.Add(6);
            game.Add(4);
            game.Add(5);
            game.Add(5);
            game.Add(10);
            game.Add(0);
            game.Add(1);
            game.Add(7);
            game.Add(3);
            game.Add(6);
            game.Add(4);
            game.Add(10);
            game.Add(2);
            game.Add(8);
            game.Add(6);
            Assert.That(game.Score, Is.EqualTo(133));
        }

        [Test]
        public void Score_AlmostPerfectGame_ReturnTotalScoreIs299()
        {
            for (int i = 0; i < 11; i++)
            {
                game.Add(10);
            }
            game.Add(9);
            Assert.That(game.Score, Is.EqualTo(299));
        }

        [Test]
        public void Score_Frame10Spare_ReturnTotalScoreIs270()
        {
            for (int i = 0; i < 9; i++)
            {
                game.Add(10);
            }
            game.Add(9);
            game.Add(1);
            game.Add(1);
            Assert.That(game.Score, Is.EqualTo(270));
        }

        #endregion Score

        #region ScoreForFrame

        [Test]
        public void ScoreForFrame_Frame1NoMark_ReturnFrameScore9()
        {
            game.Add(5);
            game.Add(4);
            Assert.That(game.ScoreForFrame(1), Is.EqualTo(9));
        }

        [Test]
        public void ScoreForFrame_Frame2NoMark_ReturnFrameScoreIs18()
        {
            game.Add(5);
            game.Add(4);
            game.Add(7);
            game.Add(2);
            Assert.That(game.ScoreForFrame(2), Is.EqualTo(18));
        }

        [Test]
        public void ScoreForFrame_Frame1AfterSimpleSpare_ReturnFrameScoreIs13()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            Assert.That(game.ScoreForFrame(1), Is.EqualTo(13));
        }

        [Test]
        public void ScoreForFrame_Frame2AfterSimpleSpare_ReturnFrameScoreIs18()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            game.Add(2);
            Assert.That(game.ScoreForFrame(2), Is.EqualTo(18));
        }

        [Test]
        public void ScoreForFrame_Frame1AfterSimpleStrike_ReturnFrameScoreIs19()
        {
            game.Add(10);
            game.Add(3);
            game.Add(6);
            Assert.That(game.ScoreForFrame(1), Is.EqualTo(19));
        }

        #endregion ScoreForFrame

        #region CurrentFrame

        [Test]
        public void CurrentFrame_OneThrowNoMark_ReturnCurrentFrameIs1()
        {
            game.Add(5);
            Assert.That(game.CurrentFrame, Is.EqualTo(1));
        }

        [Test]
        public void CurrentFrame_TwoThrowsNoMark_ReturnCurrentFrameIs1()
        {
            game.Add(5);
            game.Add(4);
            Assert.That(game.CurrentFrame, Is.EqualTo(2));
        }

        [Test]
        public void CurrentFrame_FourThrowsNoMark_ReturnCurrentFrameIs2()
        {
            game.Add(5);
            game.Add(4);
            game.Add(7);
            game.Add(2);
            Assert.That(game.CurrentFrame, Is.EqualTo(3));
        }

        [Test]
        public void CurrentFrame_SimpleSpare_ReturnCurrentFrameIs2()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            Assert.That(game.CurrentFrame, Is.EqualTo(2));
        }

        [Test]
        public void CurrentFrame_SimpleFrameAfterSpare_ReturnCurrentFrameIs3()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            game.Add(2);
            Assert.That(game.CurrentFrame, Is.EqualTo(3));
        }

        [Test]
        public void CurrentFrame_SimpleStrike_ReturnCurrentFrameIs3()
        {
            game.Add(10);
            game.Add(3);
            game.Add(6);
            Assert.That(game.CurrentFrame, Is.EqualTo(3));
        }

        [Test]
        public void CurrentFrame_PerfectGame_ReturnCurrentFrameIs10()
        {
            for (int i = 0; i < 12; i++)
            {
                game.Add(10);
            }
            Assert.That(game.CurrentFrame, Is.EqualTo(11));
        }

        #endregion CurrentFrame
    }
}