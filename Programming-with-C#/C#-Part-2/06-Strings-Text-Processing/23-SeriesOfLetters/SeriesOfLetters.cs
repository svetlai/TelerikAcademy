namespace SeriesOfLetters
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 23. Series of letters
    /// Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
    /// Example:
    /// |          input          |  output  |
    /// |:-----------------------:|:--------:|
    /// | aaaaabbbbbcdddeeeedssaa | abcdedsa |
    /// </summary>
    public class SeriesOfLetters
    {
        public static void Main()
        {
            string input = "aaaaabbbbbcdddeeeedssaa";
            string output = ReplaceSeriesOfLetters(input);

            DisplayExample(input, output);
        }

        public static string ReplaceSeriesOfLetters(string text)
        {
            StringBuilder sb = new StringBuilder();
            char currentSymbol = text[0];
            sb.Append(currentSymbol);

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != currentSymbol)
                {
                    sb.Append(text[i]);
                }

                currentSymbol = text[i];
            }

            return sb.ToString();
        }

        private static void DisplayExample(string input, string output)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 23. Series of letters \nWrite a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.\n")
                .AppendLine("Example: ")
                .AppendFormat("{0,30} | {1}\n", "input", "output")
                .AppendFormat("{0,30} | {1}\n", input, output)
                .AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter short text: ");
            input = Console.ReadLine();
            output = ReplaceSeriesOfLetters(input);

            print.Clear()
                .AppendLine(border)
                .AppendFormat("{0,30} | {1}\n", input, output)
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
