namespace WordDictionary
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 14. Word dictionary
    /// A dictionary is stored as a sequence of text lines containing words and their explanations.
    /// Write a program that enters a word and translates it by using the dictionary.
    /// Sample dictionary:
    /// |   input   |                  output                  |
    /// |:---------:|:----------------------------------------:|
    /// | .NET      | platform for applications from Microsoft |
    /// | CLR       | managed execution environment for .NET   |
    /// | namespace | hierarchical organization of classes     |
    /// </summary>
    public class WordDictionary
    {
        public static void Main()
        {
            var sampleDictionary = new Dictionary<string, string> 
            {
                { ".NET".ToLower(), "platform for applications from Microsoft" },
                { "CLR".ToLower(), "managed execution environment for .NET" },
                { "namespace".ToLower(), "hierarchical organization of classes" }
            };

            string word = ".NET";
            string result = TranslateWord(word, sampleDictionary);

            DisplayExample(word, sampleDictionary, result);
        }

        public static string TranslateWord(string word, Dictionary<string, string> wordDictionary)
        {
            if (wordDictionary.ContainsKey(word.ToLower()))
            {
                return wordDictionary[word.ToLower()];
            }

            return "Word was not found.";
        }

        private static void DisplayExample(string word, Dictionary<string, string> wordDictionary, string result)
        {
            Console.WriteLine("Problem 14. Word dictionary \nA dictionary is stored as a sequence of text lines containing words and their explanations. \nWrite a program that enters a word and translates it by using the dictionary.\n");
            
            Console.WriteLine("Example: ");
            Console.WriteLine("{0}: {1}", word, result);

            Console.Write("\nTry it yourself! \nEnter a word: ");
            word = Console.ReadLine();

            result = TranslateWord(word, wordDictionary);

            Console.WriteLine("{0}: {1}", word, result);
        }
    }
}
