namespace ExtractSentences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Problem 8. Extract sentences
    /// Write a program that extracts from a given text all sentences containing given **word**.
    /// Example:
    /// The word is:_ **in**
    /// The text is:_ We are living **in** a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it **in** 5 days.
    /// The expected result is:_ We are living in a yellow submarine. We will move out of it in 5 days.
    /// Consider that the sentences are separated by `.` and the words – by **non-letter symbols**.
    /// </summary>
    public class ExtractSentences
    {
        public static void Main()
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string word = "in";
            string result = ExtractSentencesContainingWord(text, word);

            DisplayExample(text, word, result);
        }

        public static string ExtractSentencesContainingWord(string text, string word)
        {
            StringBuilder sb = new StringBuilder();
            List<string> sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var sentence in sentences)
            {
                List<string> words = sentence.Split(new char[] { ' ', ',', '-', ';', ':' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (words.Contains(word))
                {
                    sb.Append(sentence + '.');
                }
            }

            return sb.ToString();
        }

        private static void DisplayExample(string text, string word, string result)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.Append("Problem 8. Extract sentences \nWrite a program that extracts from a given text all sentences containing given **word**.\n");

            // example
            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendLine(text)
                .AppendFormat("Word: {0}\n", word)
                .AppendLine(border)
                .AppendLine(result)
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
