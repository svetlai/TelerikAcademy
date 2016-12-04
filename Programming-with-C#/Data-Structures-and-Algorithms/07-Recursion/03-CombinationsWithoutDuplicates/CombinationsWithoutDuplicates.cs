namespace CombinationsWithoutDuplicates
{
    using System;

    /// <summary>
    /// 3. Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set.
    // Example: n=4, k=2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
    /// </summary>
    public class CombinationsWithoutDuplicates
    {
        public static void Main()
        {
            int n = 4;
            int k = 2;
            GetCombNoDuplicates(0, 1, n, new int[k]);
        }

        private static void GetCombNoDuplicates(int startIndex, int startValue, int endValue, int[] comb)
        {
            if (startIndex == comb.Length)
            {
                Console.Write("({0}), ", string.Join(" ", comb));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                comb[startIndex] = i;
                GetCombNoDuplicates(startIndex + 1, i + 1, endValue, comb);
            }
        }
    }
}
