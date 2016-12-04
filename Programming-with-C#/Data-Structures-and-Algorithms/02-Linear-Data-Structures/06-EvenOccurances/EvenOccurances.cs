namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program that removes from given sequence all numbers that occur odd number of times. Example:
    /// {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} > {5, 3, 3, 5}
    /// </summary>
    public class EvenOccurances
    {
        public static void Main()
        {
            List<int> sequenceList = new List<int>()
            {
                1, 2, 3, 3, 2
            };

            List<int> evenOccurances = RemoveOddOccurances(sequenceList);
            Console.WriteLine(string.Join(", ", evenOccurances));
        }

        /// <summary>
        /// Removes odd number of occurances from a given list of integers. Adds every integer as a key in a dictionary.
        /// and sets the value as a number of its occurances in the list. It then adds all even occurances to a new list
        /// rather than removing them since adding to a list is faster than removing from it.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static List<int> RemoveOddOccurances(List<int> numbers)
        {
            Dictionary<int, int> occurancesCount = new Dictionary<int, int>();
                
            foreach (var item in numbers) 
            {
                if (occurancesCount.ContainsKey(item))
                {
                    occurancesCount[item]++;
                }
                else
                {
                    occurancesCount.Add(item, 1);
                }
            }

            List<int> evenOccurances = new List<int>();

            foreach (var item in numbers)
            {
                if (occurancesCount[item] % 2 == 0)
                {
                    evenOccurances.Add(item);
                }
            }

            return evenOccurances;
        }
    }
}
