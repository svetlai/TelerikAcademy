namespace OrderWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Problem 24. Order words
    /// Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
    /// </summary>
    public class OrderWords
    {
        public static void Main()
        {
            DisplayExample();
        }

        public static void PrintWords(List<string> words)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var word in words)
            {
                sb.AppendLine(word);
            }

            Console.Write(sb.ToString());
        }

        public static List<string> SortWordsAlphabetically(List<string> words)
        {
            return words.OrderBy(w => w).ToList();
        }

        public static List<string> ConvertStringToList(string text)
        {
            return text.Split(new char[] { ' ' }, StringSplitOptions.None).ToList();
        }

        private static void DisplayExample()
        {
            Console.WriteLine("Problem 24. Order words \nWrite a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.\n");

            // example
            Console.WriteLine("Example: ");
            string words = "orange apple pear pineapple melon";
            Console.WriteLine(words);
            Console.WriteLine(new string('-', 60));
            var listOfWords = ConvertStringToList(words);
            var sorted = SortWordsAlphabetically(listOfWords);
            PrintWords(sorted);
            Console.WriteLine(new string('-', 60));

            // test with your input
            Console.Write("Try it yourself! \nEnter words, separated by space: ");
            words = Console.ReadLine();
            Console.WriteLine(new string('-', 60));
            listOfWords = ConvertStringToList(words);
            sorted = SortWordsAlphabetically(listOfWords);
            PrintWords(sorted);
            Console.WriteLine(new string('-', 60));
        }
    }
}
