namespace ForbiddenWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Problem 9. Forbidden words
    /// We are given a string containing a list of forbidden words and a text containing some of these words.
    /// Write a program that replaces the forbidden words with asterisks.
    /// Example text: Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
    /// Forbidden words:_ `PHP`, `CLR`, `Microsoft`
    /// The expected result:_ `********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***`.
    /// </summary>
    public class ForbiddenWords
    {
        public static void Main()
        {         
            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            List<string> forbiddenWords = new List<string> { "PHP", "CLR", "Microsoft" };

            string replaced = AddCensorship(text, forbiddenWords);

            DisplayExample(text, forbiddenWords, replaced);
        }

        public static string AddCensorship(string text, List<string> forbiddenWords)
        {
            foreach (var word in forbiddenWords)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            return text;
        }

        private static void DisplayExample(string text, List<string> forbiddenWords, string replaced)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 9. Forbidden words \nWe are given a string containing a list of forbidden words and a text containing some of these words. \nWrite a program that replaces the forbidden words with asterisks.\n");
            
            // example
            print.AppendLine("Example:")
                .AppendLine(text)
                .AppendLine(border)
                .AppendFormat("Forbidden words: {0}\n", string.Join(", ", forbiddenWords))
                .AppendLine(border)
                .AppendLine(replaced);

            Console.WriteLine(print.ToString());
        }
    }
}
