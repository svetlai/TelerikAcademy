namespace RemoveWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Problem 12. Remove words
    /// Write a program that removes from a text file all words listed in given another text file.
    /// Handle all possible exceptions in your methods.
    /// </summary>
    public class RemoveWords
    {
        private static readonly char[] Separators = new char[] { ' ', ',', '!', '?', ':', ';', '(', ')', '[', ']', '.' };

        public static void Main()
        {
            Console.WriteLine("Problem 12. Remove words \nWrite a program that removes from a text file all words listed in given another text file. \nHandle all possible exceptions in your methods.\n");
            
            string wordsPath = "../../words.txt";
            var list = GetWordsToRemove(wordsPath);

            string path = "../../joke.txt";
            RemoveListedWords(path, list);
        }

        public static List<string> GetWordsToRemove(string path)
        {
            var words = new List<string>();

            try
            {
                words = File.ReadAllLines(path).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return words;
        }

        public static void RemoveListedWords(string path, List<string> words)
        {
            try
            {
                string contents = File.ReadAllText(path);
                string[] splitText = contents.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(w => !words.Contains(w.Trim(Separators))).ToArray();

                contents = string.Join(" ", splitText);

                File.WriteAllText(path, contents);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("File was written successfully at {0}.", new FileInfo(path).FullName);
        }
    }
}
