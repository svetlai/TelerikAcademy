namespace LettersCount
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Problem 21. Letters count
    /// Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.
    /// </summary>
    public class LettersCount
    {
        public static void Main()
        {
            string text = "These templates provide a starting point...";
            var letters = CountLetters(text);

            DisplayExample(text, letters);
        }

        public static Dictionary<char, int> CountLetters(string text)
        {
            var letters = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (!letters.ContainsKey(text[i]))   // for case insensitive add .ToLower();
                    {
                        letters.Add(text[i], 0);
                    }

                    letters[text[i]]++;
                }              
            }

            return letters;
        }

        private static void DisplayExample(string text, Dictionary<char, int> letters)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 21. Letters count \nWrite a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.\n")
                .AppendLine("Example: ")
                .AppendLine(text)
                .AppendLine(border);

            foreach (var letter in letters)
            {
                print.AppendLine(letter.Key + ": " + letter.Value + " times");
            }

            print.AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            print.Clear();

            Console.Write("Try it yourself! \nEnter short text: ");
            text = Console.ReadLine();

            letters = CountLetters(text);

            foreach (var letter in letters)
            {
                print.AppendLine(letter.Key + ": " + letter.Value + " times");
            }

            Console.Write(print.ToString());
        }
    }
}
