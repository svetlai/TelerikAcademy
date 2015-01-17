namespace BonusScore
{
    using System;

    /// <summary>
    /// Problem 2. Bonus Score
    /// Write a program that applies bonus score to given score in the range `[1...9]` by the following rules:
    /// If the score is between `1` and `3`, the program multiplies it by `10`.
    /// If the score is between `4` and `6`, the program multiplies it by `100`.
    /// If the score is between `7` and `9`, the program multiplies it by `1000`.
    /// If the score is `0` or more than `9`, the program prints `invalid score`.
    /// Examples:
    /// | score | result        |
    /// |-------|---------------|
    /// | 2     | 20            |
    /// | 4     | 400           |
    /// | 9     | 9000          |
    /// | -1    | invalid score |
    /// | 10    | invalid score |
    /// </summary>
    public class BonusScore
    {
        public static void Main()
        {
            Console.WriteLine("Problem 2. Bonus Score \nWrite a program that applies bonus score to given score in the range `[1...9]` by the following rules: \nIf the score is between `1` and `3`, the program multiplies it by `10`. \nIf the score is between `4` and `6`, the program multiplies it by `100`. \nIf the score is between `7` and `9`, the program multiplies it by `1000`. \nIf the score is `0` or more than `9`, the program prints `invalid score`.\n");

            // display examples
            int[] scores = { 2, 4, 9, -1, 10 };
            string result;

            Console.WriteLine("{0,5} | {1,10}", "score", "result");

            for (int i = 0; i < scores.Length; i++)
            {
                result = ApplyScore(scores[i]);

                Console.WriteLine("{0,5} | {1,10}", scores[i], result);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.Write("Try it yourself! \nEnter a digit between 1 and 9: ");

            try
            {
                int input = int.Parse(Console.ReadLine());
                result = ApplyScore(input);

                Console.WriteLine("{0,5} | {1,10}", input, result);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string ApplyScore(int input)
        {
            int newScore;

            switch (input)
            {
                case 1:
                case 2:
                case 3:
                    newScore = input * 10;
                    break;
                case 4:
                case 5:
                case 6:
                    newScore = input * 100;
                    break;
                case 7:
                case 8:
                case 9:
                    newScore = input * 1000;
                    break;
                default:
                    return "invalid score";
            }

            return newScore.ToString();
        }
    }
}
