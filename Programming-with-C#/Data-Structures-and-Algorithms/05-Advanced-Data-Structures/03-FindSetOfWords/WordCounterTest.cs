namespace TrieImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class TrieTest
    {
        public static void Main()
        {
            var files = new List<string>();

            for (int i = 0; i < 25000; i++)
			{
                files.Add("../../lorem.txt");
			}

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            TrieNode root = HelperMethods.ProcessWordsFromFile(files);
            int totalWordCount = HelperMethods.CountAllWordsInFile(root);
            int distinctWordCount = HelperMethods.CountDistinctWordsInFile(root);
            var distinctWords = HelperMethods.GetDistinctWords(root);
            var top10Words = HelperMethods.GetTopNWords(10, root);

            Console.WriteLine("Top 10 words:");
            HelperMethods.PrintWordCount(top10Words);

            Console.WriteLine("All words:");
            HelperMethods.PrintWordCount(distinctWords);

            Console.WriteLine();
            Console.WriteLine("{0} words counted", totalWordCount);
            Console.WriteLine("{0} distinct words found", distinctWordCount);
            Console.WriteLine();

            stopWatch.Stop();
            Console.WriteLine("Total time for processing text: {0}", stopWatch.Elapsed);

            Console.WriteLine("Done.");
        }
    }
}
