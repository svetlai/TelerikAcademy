namespace CountWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Problem 13. Count words
    /// Write a program that reads a list of words from the file `words.txt` and finds how many times each of the words is contained in another file `test.txt`.
    /// The result should be written in the file `result.txt` and the words should be sorted by the number of their occurrences in descending order.
    /// Handle all possible exceptions in your methods.
    /// </summary>
    public class CountWords
    {
        private static readonly char[] Separators = new char[] { ' ', ',', '!', '?', ':', ';', '(', ')', '[', ']', '.' };

        public static void Main()
        {
            Console.WriteLine("Problem 13. Count words \nWrite a program that reads a list of words from the file `words.txt` and finds how many times each of the words is contained in another file `test.txt`. \nThe result should be written in the file `result.txt` and the words should be sorted by the number of their occurrences in descending order. \nHandle all possible exceptions in your methods.\n");
            
            string wordsPath = "../../words.txt";
            var wordsList = GetWordsToRemove(wordsPath);

            string textPath = "../../test.txt";
            var count = CountWordsInFile(textPath, wordsList);

            string outputPath = "../../result.txt";
            WriteResult(outputPath, count);
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

        public static Dictionary<string, int> CountWordsInFile(string path, List<string> wordsList)
        {
            var wordsCount = new Dictionary<string, int>();
            try
            {
                string contents = File.ReadAllText(path);
                string[] words = contents.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (wordsList.Contains(word))
                    {
                        if (!wordsCount.ContainsKey(word))  // for case insensitive add .ToLower();
                        {
                            wordsCount.Add(word, 0);
                        }

                        wordsCount[word]++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return wordsCount;
        }

        public static void WriteResult(string outputPath, Dictionary<string, int> wordsCount)
        {
            var words = wordsCount.OrderByDescending(w => w.Value);

            try
            {
                var writer = new StreamWriter(outputPath);
                using (writer)
                {
                    foreach (var word in words)
                    {
                        writer.WriteLine(word.Key + " " + word.Value + " times");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("File was written successfully at {0}.", new FileInfo(outputPath).FullName);
        }
    }
}
