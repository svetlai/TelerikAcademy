namespace MaximalSum
{
    using System;
    using System.Linq;

    /// <summary>
    /// Problem 8. Maximal sum
    /// Write a program that finds the sequence of maximal sum in given array.
    /// Example:
    /// |                 input               |    result   |
    /// |-------------------------------------|-------------|
    /// | 2, 3, -6, -1, **2, -1, 6, 4**, -8, 8 | 2, -1, 6, 4 |
    /// Can you do it with only one loop (with single scan through the elements of the array)?
    /// </summary>
    public class MaximalSum
    {
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 8. Maximal sum \nWrite a program that finds the sequence of maximal sum in given array.\n");

            // display examples
            Console.WriteLine("Example:");
            int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            int[] sequenceOfMaxSum = GetSequenceOfMaximalSum(array);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", "input", "result");
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", array), string.Join(" ", sequenceOfMaxSum));
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());
            int[] result = GetSequenceOfMaximalSum(input);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", result));
            Console.WriteLine(Border);
        }
    
        public static int[] GetSequenceOfMaximalSum(int[] array)
        {
            // Kadane's algorithm (http://en.wikipedia.org/wiki/Maximum_subarray_problem)
            int maxSum = int.MinValue;
            int sum = 0;
            
            int startIndex = 0;
            int endIndex = 0;

            if (array.Max() <= 0)
            {
                maxSum = array.Max();
                startIndex = endIndex = Array.IndexOf(array, array.Max());
            }
            else if (array.Min() >= 0)
            {
                maxSum = array.Sum();
                startIndex = 0;
                endIndex = array.Length - 1;
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (sum + array[i] < array[i])
                    {
                        startIndex = i;
                    }
                    else if (sum + array[i] < sum)
                    {
                        endIndex = i - 1;
                    }

                    sum = Math.Max(array[i], sum + array[i]);
                    maxSum = Math.Max(sum, maxSum);
                }
            }          

            int[] sequence = array.Skip(startIndex).Take(endIndex - startIndex + 1).ToArray();
            
            return sequence;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
