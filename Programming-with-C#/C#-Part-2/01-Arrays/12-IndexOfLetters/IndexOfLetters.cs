namespace IndexOfLetters
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 12. Index of letters
    /// Write a program that creates an array containing all letters from the alphabet (`A-Z`).
    /// Read a word from the console and print the index of each of its letters in the array.
    /// </summary>
    public class IndexOfLetters
    {
        private const int AllLettersCount = 26;

        public static void Main()
        {
            DisplayExample();
        }

        public static char[] GetAlphabetCapitalLetters()
        {
            char[] letters = new char[AllLettersCount];

            for (int i = 65, j = 0; i <= 90 && j < AllLettersCount; i++, j++)
            {
                letters[j] = Convert.ToChar(i);
            }

            return letters;
        }

        private static void DisplayExample()
        {
            Console.WriteLine("Problem 12. Index of letters \nWrite a program that creates an array containing all letters from the alphabet (`A-Z`). \nRead a word from the console and print the index of each of its letters in the array.\n");

            char[] letters = GetAlphabetCapitalLetters();

            Console.Write("Please enter a word: ");
            string inputWord = Console.ReadLine();

            List<int> letterIndexes = new List<int>();

            for (int i = 0; i < inputWord.Length; i++)
            {
                int letterIndex = Array.IndexOf(letters, Convert.ToChar(inputWord[i].ToString().ToUpper()));
                letterIndexes.Add(letterIndex);
            }

            Console.WriteLine("Indexes: [{0}]", string.Join(", ", letterIndexes));
        }
    }
}
