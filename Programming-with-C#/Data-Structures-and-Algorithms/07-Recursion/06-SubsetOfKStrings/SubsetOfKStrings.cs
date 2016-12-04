namespace SubsetOfKStrings
{
    using System;

    /// <summary>
    /// 6. Write a program for generating and printing all subsets of k strings from given set of strings.
    // Example: s = {test, rock, fun}, k=2 -> (test rock),  (test fun),  (rock fun)
    /// </summary>
    public class SubsetOfKStrings
    {
        public static void Main()
        {
            string[] set = { "test", "rock", "fun" };
            int k = 2;
            GetCombNoDuplicates(0, 0, set, new string[k]);
        }

        private static void GetCombNoDuplicates(int startIndex, int startIndexSet, string[] set, string[] comb)
        {
            if (startIndex == comb.Length)
            {
                Console.Write("({0}), ", string.Join(" ", comb));
                return;
            }

            for (int i = startIndexSet; i < set.Length; i++)
            {
                comb[startIndex] = set[i];
                GetCombNoDuplicates(startIndex + 1, i + 1, set, comb);
            }
        }
    }
}
