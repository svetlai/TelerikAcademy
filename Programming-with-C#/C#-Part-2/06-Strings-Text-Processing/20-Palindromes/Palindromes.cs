namespace Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Problem 20. Palindromes
    /// Write a program that extracts from a given text all palindromes, e.g. `ABBA`, `lamal`, `exe`.
    /// </summary>
    public class Palindromes
    {
        private static readonly char[] Separators = new char[] { ' ', ',', '!', '?', ':', ';', '(', ')', '[', ']', '-', '_', '.' };

        public static void Main()
        {
            string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. abba Lorem Ipsum has been the exe, industry's standard dummy mum text ever since lamal the 1500s, when an unknown printer took a galley oho, of type and scrambled it to make a ty";
            var words = ExtractPalindromes(text);

            DisplayExample(text, words);
        }

        public static List<string> ExtractPalindromes(string text)
        {
            var palindromes = new List<string>();
            string[] words = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                string reversed = ReverseString(word);

                if (word == reversed)
                {
                    palindromes.Add(word);
                }
            }

            return palindromes;
        }

        private static string ReverseString(string toReverse)
        {
            char[] stringAsChars = toReverse.ToCharArray();
            Array.Reverse(stringAsChars);

            return new string(stringAsChars);
        }

        private static void DisplayExample(string text, List<string> words)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 20. Palindromes \nWrite a program that extracts from a given text all palindromes, e.g. `ABBA`, `lamal`, `exe`.\n")
                .AppendLine("Example: ")
                .AppendLine(text)
                .AppendLine(border);

            foreach (var word in words)
            {
                print.AppendLine(word);
            }

            print.AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
