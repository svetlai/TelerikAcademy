namespace WordsCount
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Problem 22. Words count
    /// Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.
    /// </summary>
    public class WordsCount
    {
        private static readonly char[] Separators = new char[] { ' ', ',', '!', '?', ':', ';', '(', ')', '[', ']', '-', '_', '.' };

        public static void Main()
        {
            string text = "This is a text text with repetitvie words words a...";
            var words = CountWords(text);

            DisplayExample(text, words);
        }

        public static Dictionary<string, int> CountWords(string text)
        {
            var wordsCount = new Dictionary<string, int>();
            string[] words = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))  // for case insensitive add .ToLower();
                {
                    wordsCount.Add(word, 0);
                }

                wordsCount[word]++;
            }           

            return wordsCount;
        }

        private static void DisplayExample(string text, Dictionary<string, int> words)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 22. Words count \nWrite a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.\n")
                .AppendLine("Example: ")
                .AppendLine(text)
                .AppendLine(border);

            foreach (var word in words)
            {
                print.AppendLine(word.Key + ": " + word.Value + " times");
            }

            print.AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            print.Clear();

            Console.Write("Try it yourself! \nEnter short text: ");
            text = Console.ReadLine();

            words = CountWords(text);

            foreach (var word in words)
            {
                print.AppendLine(word.Key + ": " + word.Value + " times");
            }

            Console.Write(print.ToString());
        }
    }
}
