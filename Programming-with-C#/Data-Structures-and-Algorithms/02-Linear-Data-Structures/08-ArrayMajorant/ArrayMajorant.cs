namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 8*. The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program to 
    /// find the majorant of given array (if exists). Example:
    /// {2, 2, 3, 3, 2, 3, 4, 3, 3} > 3
    /// </summary>
    public class ArrayMajorant
    {
        public static void Main()
        {
            int[] numbers = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var majorant = FindMajorant(numbers);

            Console.WriteLine(majorant);
        }

        /// <summary>
        /// Finds the majorant in a given array of numbers. 
        /// The method converts the array to a list then sorts it and starts counting the occurances of every integer. 
        /// If at some point the number of occurances becomes larger than n/2 + 1 it returns the current integer.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int? FindMajorant(int[] numbers)
        {
            List<int> numbersList = numbers.ToList();
            numbersList.Sort();

            int? majorant = null;
            int currentNumber;
            int nextNumber;
            int count = 1;
            int max = count;

            for (int i = 0; i < numbersList.Count - 1; i++)
            {
                currentNumber = numbersList[i];
                nextNumber = numbersList[i + 1];

                //TODO: if i > numbersList.Count / 2 + 1 and majorant is still null - return

                if (currentNumber == nextNumber)
                {
                    count++;
                    if (count > max)
                    {
                        max = count;
                    }

                    if (max >= numbersList.Count / 2 + 1)
                    {
                        majorant = currentNumber;
                        return majorant;
                    }
                }
                else
                {
                    count = 1;
                }
            }

            return majorant;
        }
    }
}
