namespace CombinationWithDuplicates
{
    using System;

    /// <summary>
    /// 2.Write a recursive program for generating and printing all the combinations with duplicates of k elements
    // from n-element set. Example:
    // n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
    /// </summary>
    public class CombinationWithDuplicates
    {
        public static void Main()
        {
            int n = 3;
            int k = 2;
            GetCombDuplicates(0, 1, n, new int[k]);
        }

        private static void GetCombDuplicates(int startIndex, int startValue, int endValue, int[] comb)
        {
            if (startIndex == comb.Length)
            {
                Console.Write("({0}), ", string.Join(" ", comb));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                comb[startIndex] = i;
                GetCombDuplicates(startIndex + 1, i, endValue, comb);
            }
        }
    }
}
