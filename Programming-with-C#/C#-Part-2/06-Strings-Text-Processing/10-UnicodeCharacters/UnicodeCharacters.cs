namespace UnicodeCharacters
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 10. Unicode characters
    /// Write a program that converts a string to a sequence of C# Unicode character literals.
    /// Use format strings.
    /// Example:
    /// | input |       output       |
    /// |:-----:|:------------------:|
    /// | Hi!   | \u0048\u0069\u0021 |
    /// </summary>
    public class UnicodeCharacters
    {
        public static void Main()
        {
            string text = "Hi!";
            string output = ConvertStringToUnicode(text);

            DisplayExample(text, output);
        }

        public static string ConvertStringToUnicode(string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char character in text)
            {
                sb.Append("\\u");
                sb.Append(string.Format("{0:x4}", (int)character));
            }

            return sb.ToString();
        }

        private static void DisplayExample(string text, string output)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 10. Unicode characters \nWrite a program that converts a string to a sequence of C# Unicode character literals. \nUse format strings.\n");

            // example
            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendFormat("{0,20} | {1,20}\n", "input", "output")
                .AppendFormat("{0,20} | {1,20}\n", text, output)
                .AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter short text: ");
            text = Console.ReadLine();

            output = ConvertStringToUnicode(text);

            // print
            print.Clear()
                .AppendLine(border)
                .AppendFormat("{0,20} | {1,20}\n", text, output)
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
