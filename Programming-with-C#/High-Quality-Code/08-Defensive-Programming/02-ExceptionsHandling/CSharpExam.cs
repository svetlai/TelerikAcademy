namespace DefensiveProgramming
{
    using System;

    using DefensiveProgramming.Contracts;

    public class CSharpExam : IExam
    {
        private const int MinScore = 0;
        private const int MaxScore = 100;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < MinScore || value > MaxScore)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Score must be between {0} and {1}.", MinScore, MaxScore));
                }

                this.score = value;
            }
        }

        public ExamResult Check()
        {
            {
                return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
            }
        }
    }
}