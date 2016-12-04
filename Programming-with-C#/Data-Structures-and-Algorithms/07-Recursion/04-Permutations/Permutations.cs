namespace Permutations
{
    using System;

    /// <summary>
    /// 4.Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n.
    // Example:
    // n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
    /// </summary>
    public class Permutations
    {
        public static void Main()
        {
            int n = 3;
            GetPerm(0, 1, n, new int[n], new bool[n]);
        }

        private static void GetPerm(int startIndex, int startValue, int endValue, int[] perm, bool[] isUsed)
        {
            if (startIndex == perm.Length)
            {
                Console.Write("({0}), ", string.Join(" ", perm));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                if (!isUsed[i - 1])
                {
                    perm[startIndex] = i;
                    isUsed[i - 1] = true;
                    GetPerm(startIndex + 1, startValue, endValue, perm, isUsed);
                    isUsed[i - 1] = false;
                }
            }
        }
    }
}
