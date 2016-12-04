namespace WordOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 3. Write a program that counts how many times each word from given text file words.txt appears in it. 
    /// The character casing differences should be ignored. The result words should be ordered by their number of 
    /// occurrences in the text. Example:
    /// This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
	/// is > 2
	/// the > 2
	/// this > 3
	/// text > 6
    /// </summary>
    public class WordOccurancesCount
    {
        public static void Main()
        {
            string text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            IDictionary<string, int> occurances = CountWordsOccurances(text);
            IDictionary<string, int> sorted = SortWordOccurances(occurances);
            PrintWordOccurances(sorted);
        }

        public static IDictionary<string, int> CountWordsOccurances(string text)
        {
            string[] words =
                  text.Split(' ', '.', ',', '-', '?', '!', '–');

            IDictionary<string, int> occurances = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (occurances.ContainsKey(word.ToLower()))
                {
                    occurances[word.ToLower()]++;
                }
                else
                {
                    occurances.Add(word.ToLower(), 1);
                }
            }

            return occurances;
        }

        public static IDictionary<string, int> SortWordOccurances(IDictionary<string, int> occurances)
        {
            IDictionary<string, int> sorted = new Dictionary<string, int>();

            var sortedEntries = 
                (from entry in occurances 
                 orderby entry.Value ascending 
                 select entry);

            foreach (var entry in sortedEntries)
            {
                sorted.Add(entry);
            }

            return sorted;
        }

        public static void PrintWordOccurances(IDictionary<string, int> pairs)
        {
            foreach (KeyValuePair<string, int> pair in pairs)
            {
                    Console.WriteLine("{0}: {1} times", pair.Key, pair.Value);
            }

            Console.WriteLine();
        }
    }
}
