namespace NestedLoops
{
    using System;

    /// <summary>
    /// 1.Write a recursive program that simulates the execution of n nested loops from 1 to n.
    /// </summary>
    public class NestedLoops
    {
        public static void Main()
        {
            int n = 4;
            GetLoops(0, 1, n, new int[n]);
        }

        private static void GetLoops(int startIndex, int startValue, int endValue, int[] loops)
        {
            if (startIndex == loops.Length)
            {
                Console.WriteLine(string.Join(" ", loops));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                loops[startIndex] = i;
                GetLoops(startIndex + 1, startValue, endValue, loops);
            }
        }
    }
}
