namespace BowlingGame.Console
{
    public class Game
    {
        private int score;
        private int[] throws = new int[21];
        private int currentThrow;
        private int currentFrame = 1;
        private bool IsFirstThrow = true;

        public int Score => ScoreForFrame(CurrentFrame - 1);

        public int CurrentFrame => currentFrame;

        public void Add(int pins)
        {
            throws[currentThrow++] = pins;
            score += pins;

            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (IsFirstThrow)
            {
                //Strike
                if (pins == 10)
                {
                    currentFrame++;
                }
                else
                    IsFirstThrow = false;
            }
            else
            {
                IsFirstThrow = true;
                currentFrame++;
            }

            if (currentFrame > 11)
            {
                currentFrame = 11;
            }
        }

        public int ScoreForFrame(int theFrame)
        {
            int ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                int firstThrow = throws[ball++];
                //Strike
                if (firstThrow == 10)
                {
                    score += 10 + throws[ball] + throws[ball + 1];
                }
                else
                {
                    int secondThrow = throws[ball++];
                    int frameScore = firstThrow + secondThrow;

                    //Spare
                    if (frameScore == 10)
                    {
                        score += frameScore + throws[ball];
                    }
                    else
                        score += frameScore;
                }
            }

            return score;
        }
    }
}