namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 4. Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the 
    /// result as new List<int>. Write a program to test whether the method works correctly.
    /// </summary>
    public class LongestSequence
    {
        public static void Main()
        {
            List<int> sequence = new List<int>()
            {
                1, 2, 2, 4, 3, 3, 3, 5, 5
            };

            List<int> longest = GetLongestEqualSubsequence(sequence);
            ////List<int> longest = GetLongestEqualSubsequenceWithLinq(testList);

            Console.WriteLine("Initial sequence: ");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine("Longest subsequence of equals: ");
            Console.WriteLine(string.Join(", ", longest));
        }

        ////NOTE: This method works only for the first longest sequence it comes across.
        public static List<int> GetLongestEqualSubsequence(List<int> numbers)
        {
            List<int> longestEqualSubsequence = new List<int>();
            int currentNumber;
            int nextNumber;
            int seqStart = 0;
            int seqLength = 1;
            int max = seqLength;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                currentNumber = numbers[i];
                nextNumber = numbers[i + 1];
                
                if (currentNumber == nextNumber)
                {
                    seqLength++;
                    if (seqLength > max)
                    {
                        max = seqLength;
                        seqStart = currentNumber;
                    }
                }
                else
                {
                    seqLength = 1;
                }
            }

            for (int i = 0; i < max; i++)
            {
                longestEqualSubsequence.Add(seqStart);
            }

            return longestEqualSubsequence;
        }

        ////A shorter solution with Linq. Source: http://stackoverflow.com/questions/13745241/
        public static List<int> GetLongestEqualSubsequenceWithLinq(List<int> numbers)
        {
            List<int> longestEqualSubsequence = new List<int>();

            longestEqualSubsequence = numbers.Select((n, i) => new { Value = n, Index = i })
                .OrderBy(s => s.Value)
                .Select((o, i) => new { Value = o.Value, Diff = i - o.Index })
                .GroupBy(s => new { s.Value, s.Diff })
                .OrderByDescending(g => g.Count())
                .First()
                .Select(f => f.Value)
                .ToList();

            return longestEqualSubsequence;
        }
    }
}
