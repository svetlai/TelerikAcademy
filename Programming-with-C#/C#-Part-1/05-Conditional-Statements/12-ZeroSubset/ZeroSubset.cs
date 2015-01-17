namespace ZeroSubset
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 12.* Zero Subset
    /// We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.
    /// Assume that repeating the same subset several times is not a problem.
    /// Examples:
    /// numbers	    |   result
    /// 3 -2 1 1 8	|   -2 + 1 + 1 = 0
    /// 3 1 -7 35 22|	no zero subset
    /// 1 3 -4 -2 -1|	1 + -1 = 0
    ///             |   1 + 3 + -4 = 0
    ///             |   3 + -2 + -1 = 0
    /// 1 1 1 -1 -1	|   1 + -1 = 0
    ///             |   1 + 1 + -1 + -1 = 0
    /// 0 0 0 0 0	|   0 + 0 + 0 + 0 + 0 = 0
    /// Hint: you may check for zero each of the 32 subsets with 32 if statements.
    /// </summary>
    public class ZeroSubset
    {
        private const int NumbersCount = 5;

        private static int[] numbers = new int[NumbersCount];
        private static int sum = 0;
        private static int[] selectedSubsets = new int[numbers.Length];
        private static bool hasZeroSubset = false;

        public static void Main()
        {
            Console.WriteLine("Problem 12.* Zero Subset \nWe are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.\n");

            // read input numbers from the console and add them to an array
            Console.WriteLine("Enter five numbers:");

            for (int i = 0; i < 5; i++)
            {
                Console.Write("{0}: ", i + 1);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            CurrentSum(0, 0, 0);

            if (hasZeroSubset == false)
            {
                Console.WriteLine("no zero subsets");
            }
        }

        public static void Print(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (i < count - 1)
                {
                    Console.Write("{0} + ", selectedSubsets[i]);
                }
                else
                {
                    Console.WriteLine("{0} = {1}", selectedSubsets[i], sum);
                }
            }
        }

        // Using Толя's approach: http://stackoverflow.com/questions/14575931/sum-of-k-elements-in-array-that-equates-to-n
        public static void CurrentSum(int sumSoFar, int numsUsed, int startIndex)
        {
            if (sumSoFar == sum)
            {
                // this if is nessecary only if the targeted sum is 0
                if (numsUsed > 0)
                {
                    hasZeroSubset = true;
                }

                Print(numsUsed);
            }

            if (startIndex >= numbers.Length)
            {
                return;
            }

            for (int i = startIndex; i < numbers.Length; i++)
            {
                // Include i'th number
                selectedSubsets[numsUsed] = numbers[i];
                CurrentSum(sumSoFar + numbers[i], numsUsed + 1, i + 1);
            }
        }
    }
}
