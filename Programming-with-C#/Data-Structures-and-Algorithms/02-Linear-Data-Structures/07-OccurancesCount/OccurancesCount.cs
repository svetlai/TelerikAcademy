namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 7. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    /// Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    /// 2 > 2 times
    /// 3 > 4 times
    /// 4 > 3 times
    /// </summary>
    public class OccurancesCount
    {
        public static void Main()
        {
            int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            //Using a dictionary
            Dictionary<int, int> occurancesDict = CountOccurancesWithDict(numbers);
            Console.WriteLine(string.Join(", ", occurancesDict));

            //Using an array
            int[] occurances = CountOccurances(numbers);
            PrintOccurances(occurances);
        }

        /// <summary>
        /// Returns the number of occurances of an integer in an array. Uses the indexes of an array to count all 
        /// occurances and then a dictionary to separate those that occur more than 0 times.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static Dictionary<int, int> CountOccurancesWithDict(int[] numbers)
        {
            int[] occurances = new int[1001];

            foreach (var number in numbers)
            {
                occurances[number]++;
            }

            Dictionary<int, int> allOccurances = new Dictionary<int, int>();

            for (int i = 0; i < occurances.Length; i++)
            {
                if (occurances[i] != 0)
                {
                    allOccurances.Add(i, occurances[i]);
                }
            }

            return allOccurances;
        }

        //Alternative without a dictionary
        public static int[] CountOccurances(int[] numbers)
        {
            int[] occurances = new int[1001];

            foreach (var number in numbers)
            {
                occurances[number]++;
            }

            return occurances;
        }

        public static void PrintOccurances(int[] occurances)
        {
            for (int i = 0; i < occurances.Length; i++)
            {
                if (occurances[i] != 0)
                {
                    Console.WriteLine(i + " " + occurances[i]);
                }
            }
        }
    }
}
