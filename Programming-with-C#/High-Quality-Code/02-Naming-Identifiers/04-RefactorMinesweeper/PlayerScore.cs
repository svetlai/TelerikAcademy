namespace Minesweeper
{
    using System;

    public class PlayerScore
    {
        private const string EmptyNameExcMsg = "Name cannot be empty.";

        private string name;
        private int score;

        public PlayerScore()
        {
        }

        public PlayerScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyNameExcMsg);
                }

                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                this.score = value;
            }
        }
    }
}
