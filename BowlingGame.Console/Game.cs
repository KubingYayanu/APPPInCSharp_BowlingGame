namespace BowlingGame.Console
{
    public class Game
    {
        private int currentFrame = 1;
        private bool IsFirstThrow = true;
        private Scorer scorer = new Scorer();

        public int Score => ScoreForFrame(currentFrame);

        public void Add(int pins)
        {
            scorer.AddThrow(pins);
            AdjustCurrentFrame(pins);
        }

        public int ScoreForFrame(int theFrame)
        {
            return scorer.ScoreForFrame(theFrame);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
            {
                AdvanceFrame();
            }
            else
            {
                IsFirstThrow = false;
            }
        }

        private void AdvanceFrame()
        {
            currentFrame++;
            if (currentFrame > 10)
            {
                currentFrame = 10;
            }
        }

        private bool Strike(int pins)
        {
            return IsFirstThrow && pins == 10;
        }

        private bool LastBallInFrame(int pins)
        {
            return Strike(pins) || !IsFirstThrow;
        }
    }
}