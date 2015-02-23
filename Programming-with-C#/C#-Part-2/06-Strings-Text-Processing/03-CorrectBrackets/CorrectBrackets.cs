namespace CorrectBrackets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Problem 3. Correct brackets
    /// Write a program to check if in a given expression the brackets are put correctly.
    /// Example of correct expression:_ `((a+b)/5-d)`.
    /// Example of incorrect expression:_ `)(a+b))`.
    /// </summary>
    public class CorrectBrackets
    {
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            string expression = "((a+b)/5-d)";
            bool correctBrackets = AreBracketsCorrect(expression);

            expression = ")(a+b))";
            correctBrackets = AreBracketsCorrect(expression);

            DisplayExample(expression, correctBrackets);
        }

        public static bool AreBracketsCorrect(string expression)
        {
            var queue = new Queue<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    queue.Enqueue(expression[i]);
                }
                else if (expression[i] == ')' && queue.Count > 0)
                {
                    queue.Dequeue();
                }
                else if (expression[i] == ')' && queue.Count == 0)
                {
                    return false;
                }
            }

            return queue.Count == 0 ? true : false;
        }

        private static void DisplayExample(string expression, bool correctBrackets)
        {
            StringBuilder print = new StringBuilder();

            print.AppendLine("Problem 3. Correct brackets \nWrite a program to check if in a given expression the brackets are put correctly.\n");

            // print
            print.AppendLine("Example:")
                .AppendLine(Border)
                .AppendFormat("{0,30} | {1,10}\n", "input", "correct?")
                .AppendFormat("{0,30} | {1,10}\n", "((a+b)/5-d)", AreBracketsCorrect("((a+b)/5-d)"))
                .AppendFormat("{0,30} | {1,10}\n", expression, correctBrackets)
                .AppendLine(Border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter an expression: ");

            expression = Console.ReadLine();
            correctBrackets = AreBracketsCorrect(expression);

            // print
            print.Clear()
                .AppendLine(Border)
                .AppendFormat("{0,30} | {1,10}\n", expression, correctBrackets)
                .AppendLine(Border);

            Console.Write(print.ToString());
        }
    }
}
