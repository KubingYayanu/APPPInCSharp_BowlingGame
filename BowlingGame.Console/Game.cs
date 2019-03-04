namespace BowlingGame.Console
{
    public class Game
    {
        private int score;
        private int[] throws = new int[21];
        private int currentThrow;
        private int currentFrame = 1;
        private bool IsFirstThrow = true;

        public int Score => ScoreForFrame(CurrentFrame -1);

        public int CurrentFrame => currentFrame;

        public void Add(int pins)
        {
            throws[currentThrow++] = pins;
            score += pins;

            AdjustCurrentFrame();
        }

        private void AdjustCurrentFrame()
        {
            if (IsFirstThrow)
            {
                IsFirstThrow = false;
            }
            else
            {
                IsFirstThrow = true;
                currentFrame++;
            }
        }

        public int ScoreForFrame(int theFrame)
        {
            int ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                int firstThrow = throws[ball++];
                int secondThrow = throws[ball++];
                int frameScore = firstThrow + secondThrow;

                if (frameScore == 10)
                {
                    score += frameScore + throws[ball];
                }
                else
                    score += frameScore;
            }

            return score;
        }
    }
}