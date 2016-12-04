namespace TrieImplementation
{
    using System;
    using System.Collections.Generic;

    public static class HelperMethods
    {
        public static TrieNode ProcessWordsFromFile(IEnumerable<string> files)
        {
            TrieNode root = new TrieNode(null, '?');
         
            foreach (string path in files)
            {
                FileUtils.AddWordsFromFile(path, root);
            }

            return root;
        }

        public static int CountAllWordsInFile(TrieNode root)
        {
            int distinctWordCount = 0;
            int totalWordCount = 0;
            var list = new List<TrieNode>
            {
                new TrieNode(null, '?'),
            };

            root.GetTopCounts(ref list, ref distinctWordCount, ref totalWordCount);

            return totalWordCount;
        }

        public static int CountDistinctWordsInFile(TrieNode root)
        {
            int distinctWordCount = 0;
            int totalWordCount = 0;
            var list = new List<TrieNode>
            {
                new TrieNode(null, '?'),
            };

            root.GetTopCounts(ref list, ref distinctWordCount, ref totalWordCount);

            return distinctWordCount;
        }

        public static List<TrieNode> GetTopNWords(int N, TrieNode root)
        {
            List<TrieNode> topNNodes = new List<TrieNode>();

            for (var i = 0; i < N; i++)
            {
                topNNodes.Add(new TrieNode(null, '?'));
            }

            int distinctWordCount = 0;
            int totalWordCount = 0;
            root.GetTopCounts(ref topNNodes, ref distinctWordCount, ref totalWordCount);
            topNNodes.Reverse();

            return topNNodes;
        }

        public static List<TrieNode> GetDistinctWords(TrieNode root)
        {
            List<TrieNode> distinctWords = new List<TrieNode>();
            int distinctWordsCount = CountDistinctWordsInFile(root);

            for (var i = 0; i < distinctWordsCount; i++)
            {
                distinctWords.Add(new TrieNode(null, '?'));
            }

            int distinctWordCount = 0;
            int totalWordCount = 0;
            root.GetTopCounts(ref distinctWords, ref distinctWordCount, ref totalWordCount);

            return distinctWords;
        }

        public static void PrintWordCount(List<TrieNode> wordList, bool desc = true)
        {
            if (desc)
            {
                wordList.Reverse();
            }

            foreach (TrieNode node in wordList)
            {
                Console.WriteLine("{0} - {1} times", node.ToString(), node.wordCount);
            }

            Console.WriteLine();
        }
    }
}
