namespace CountOccurances
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 1. Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
    /// Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    /// -2.5 > 2 times
    /// 3 > 4 times
    /// 4 > 3 times
    /// </summary>
    class CountNumberOccurances
    {
        static void Main()
        {
            double[] numbers = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5};

            IDictionary<double, int> occurances = CountOccurances(numbers);

            foreach (KeyValuePair<double, int> pair in occurances)
            {
                Console.WriteLine("{0} : {1} times", pair.Key, pair.Value);
            }         
        }

        public static IDictionary<double, int> CountOccurances(double[] numbers)
        {
            IDictionary<double, int> occurances = new Dictionary<double, int>();

            foreach (int number in numbers)
            {
                if (occurances.ContainsKey(number))
                {
                    occurances[number]++;
                }
                else
                {
                    occurances.Add(number, 1);
                }
            }

            return occurances;
        }
    }
}
