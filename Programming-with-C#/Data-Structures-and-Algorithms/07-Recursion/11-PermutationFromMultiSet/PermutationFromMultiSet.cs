namespace PermutationFromMultiSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 11.* Write a program to generate all permutations with repetitions of given multi-set. For example the
    /// multi-set {1, 3, 5, 5} has the following 12 unique permutations:
    ///
    /// { 1, 3, 5, 5 } { 1, 5, 3, 5 }
    /// { 1, 5, 5, 3 } { 3, 1, 5, 5 }
    /// { 3, 5, 1, 5 } { 3, 5, 5, 1 }
    /// { 5, 1, 3, 5 } { 5, 1, 5, 3 }
    /// { 5, 3, 1, 5 } { 5, 3, 5, 1 }
    /// { 5, 5, 1, 3 } { 5, 5, 3, 1 }
    /// Ensure your program efficiently avoids duplicated permutations.
    /// Test it with { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.
    /// </summary>
    public class PermutationFromMultiSet
    {
        public static void Main()
        {
            int[] set = { 1, 3, 5, 5 };

            // int[] set = { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            var unique = new Dictionary<int, int>();
            for (int i = 0; i < set.Length; i++)
            {
                if (unique.ContainsKey(set[i]))
                {
                    unique[set[i]]++;
                }
                else
                {
                    unique[set[i]] = 1;
                }
            }

            int[] keys = unique.Select(x => x.Key).ToArray();
            GetPerm(new int[set.Length], unique, keys, 0);
        }

        private static void GetPerm(int[] comb, Dictionary<int, int> unique, int[] keys, int index)
        {
            if (index == comb.Length)
            {
                Console.WriteLine("{{{0}}}", string.Join(", ", comb));
                return;
            }

            for (int i = 0; i < keys.Length; i++)
            {
                if (unique[keys[i]] > 0)
                {
                    comb[index] = keys[i];
                    unique[keys[i]]--;
                    GetPerm(comb, unique, keys, index + 1);
                    unique[keys[i]]++;
                }
            }
        }
    }
}
