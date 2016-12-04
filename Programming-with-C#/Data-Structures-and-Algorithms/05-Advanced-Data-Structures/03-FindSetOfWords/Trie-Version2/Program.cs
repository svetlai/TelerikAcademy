//namespace FindSetofWords
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Diagnostics;
//    using System.IO;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;

//    class Program
//    {
//        static void GenWords(Node n, HashSet<Letter>[] sets, int currentArrayIndex, List<string> wordsFound)
//        {
//            if (currentArrayIndex < sets.Length)
//            {
//                foreach (var edge in n.Edges)
//                {
//                    if (sets[currentArrayIndex].Contains(edge.Key))
//                    {
//                        if (edge.Value.IsTerminal)
//                        {
//                            wordsFound.Add(edge.Value.Word);
//                        }

//                        GenWords(edge.Value, sets, currentArrayIndex + 1, wordsFound);
//                    }
//                }
//            }
//        }

//        static void Main()
//        {
//            const int minArraySize = 3;
//            const int maxArraySize = 4;
//            const int setCount = 10;
//            const bool generateRandomInput = true;

//            var text = "some text is this text some text is this text some text is this text some text is this text some text is this text";
//            string[] splitTet = text.Split(' ');

//            var trie = new Trie(splitTet);   //new Trie(File.ReadAllLines("sowpods.txt"));

//            var watch = new Stopwatch();
//            var trials = 10000;
//            var wordCountSum = 0;
//            var rand = new Random(37);

//            for (int t = 0; t < trials; t++)
//            {
//                HashSet<Letter>[] sets;
//                if (generateRandomInput)
//                {
//                    sets = new HashSet<Letter>[setCount];
//                    for (int i = 0; i < setCount; i++)
//                    {
//                        sets[i] = new HashSet<Letter>();
//                        var size = minArraySize + rand.Next(maxArraySize - minArraySize + 1);
//                        while (sets[i].Count < size)
//                        {
//                            sets[i].Add(Letter.Chars[rand.Next(Letter.Chars.Length)]);
//                        }
//                    }
//                }
//                else
//                {
//                    sets = new HashSet<Letter>[] { 
//                      new HashSet<Letter>(new Letter[] { 'P', 'Q', 'R', 'S' }), 
//                      new HashSet<Letter>(new Letter[] { 'A', 'B', 'C' }), 
//                      new HashSet<Letter>(new Letter[] { 'T', 'U', 'V' }), 
//                      new HashSet<Letter>(new Letter[] { 'M', 'N', 'O' }) };
//                }

//                watch.Start();
//                var wordsFound = new List<string>();
//                for (int i = 0; i < sets.Length - 1; i++)
//                {
//                    GenWords(trie.Root, sets, i, wordsFound);
//                }

//                watch.Stop();
//                wordCountSum += wordsFound.Count;
//                if (!generateRandomInput && t == 0)
//                {
//                    foreach (var word in wordsFound)
//                    {
//                        Console.WriteLine(word);
//                    }
//                }
//            }

//            Console.WriteLine("Elapsed per trial = {0}", new TimeSpan(watch.Elapsed.Ticks / trials));
//            Console.WriteLine("Average word count per trial = {0:0.0}", (float)wordCountSum / trials);
//        }

//        public static IDictionary<string, int> CountWordsOccurances(string text)
//        {
//            string[] words =
//                  text.Split(' ', '.', ',', '-', '?', '!', '–');

//            IDictionary<string, int> occurances = new Dictionary<string, int>();

//            foreach (string word in words)
//            {
//                if (occurances.ContainsKey(word.ToLower()))
//                {
//                    occurances[word.ToLower()]++;
//                }
//                else
//                {
//                    occurances.Add(word.ToLower(), 1);
//                }
//            }

//            return occurances;
//        }

//        public static void PrintWordOccurances(IDictionary<string, int> pairs)
//        {
//            foreach (KeyValuePair<string, int> pair in pairs)
//            {
//                Console.WriteLine("{0}: {1} times", pair.Key, pair.Value);
//            }

//            Console.WriteLine();
//        }
//    }
//}

