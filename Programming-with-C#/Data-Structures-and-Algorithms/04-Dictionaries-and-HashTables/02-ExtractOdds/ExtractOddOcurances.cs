namespace ExtractOdds
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 2. Write a program that extracts from a given sequence of strings all elements that present in it odd number 
    /// of times. Example:
    /// {C#, SQL, PHP, PHP, SQL, SQL } > {C#, SQL}
    /// </summary>
    public class ExtractOddOcurances
    {
        public static void Main()
        {
            string[] sequence = {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            IDictionary<string, int> occurances = CountOccurances(sequence);
            PrintOdds(occurances);
        }

        public static IDictionary<string, int> CountOccurances(string[] sequence)
        {
            IDictionary<string, int> occurances = new Dictionary<string, int>();

            foreach (string member in sequence)
            {
                if (occurances.ContainsKey(member))
                {
                    occurances[member]++;
                }
                else
                {
                    occurances.Add(member, 1);
                }
            }

            return occurances;
        }

        public static void PrintOdds(IDictionary<string, int> pairs)
        {
            foreach (KeyValuePair<string, int> pair in pairs)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.Write("{0}, ", pair.Key);
                }
            }

            Console.WriteLine();
        }
    }
}
