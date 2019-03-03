using System;

namespace BowlingGame.Console
{
    public class Frame
    {
        private int score;

        public int Score => score;

        public void Add(int pins)
        {
            score += pins;
        }
    }
}