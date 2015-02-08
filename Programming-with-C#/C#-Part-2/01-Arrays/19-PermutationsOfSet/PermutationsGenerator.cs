namespace PermutationsOfSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Permutation - the order matters. Takes all elements int the set and combines them. (Arrange)
    /// </summary>
    public static class PermutationsGenerator
    {
        /// <summary>
        /// Generates permutations of elements in an array of unique elements, starting from index startIndex
        /// </summary>
        /// <typeparam name="T">Any data type</typeparam>
        /// <param name="objects">An array of all elements</param>
        /// <param name="startIndex">Array index to start from</param>
        public static void GeneratePermutationsWithoutRepetitions<T>(T[] objects, int startIndex)
        {
            if (startIndex >= objects.Length)
            {
                // add method for each permutation here
                Print(objects);
            }
            else
            {
                GeneratePermutationsWithoutRepetitions<T>(objects, startIndex + 1);
                for (int i = startIndex + 1; i < objects.Length; i++)
                {
                    Swap(ref objects[startIndex], ref objects[i]);
                    GeneratePermutationsWithoutRepetitions<T>(objects, startIndex + 1);
                    Swap(ref objects[startIndex], ref objects[i]);
                }
            }
        }

        /// <summary>
        /// Generates permutations of elements in an array of non-unique elements, starting from index startIndex
        /// </summary>
        /// <typeparam name="T">Any data type</typeparam>
        /// <param name="objects">An array of all elements</param>
        /// <param name="startIndex">Array index to start from</param>
        /// <param name="elementsCount">Count of all elements to count (objects.Length if all)</param>
        public static void GeneratePermutationsWithRepetitions<T>(int[] objects, int startIndex, int elementsCount)
        {
            // add method for each permutation here
            Print(objects);

            for (int left = elementsCount - 2; left >= startIndex; left--)
            {
                for (int right = left + 1; right < elementsCount; right++)
                {
                    if (objects[left] != objects[right])
                    {
                        Swap(ref objects[left], ref objects[right]);
                        GeneratePermutationsWithRepetitions<T>(objects, left + 1, elementsCount);
                    }
                }

                // Undo all modifications done by the previous recursive calls and swaps
                var firstElement = objects[left];
                for (int i = left; i < elementsCount - 1; i++)
                {
                    objects[i] = objects[i + 1];
                }

                objects[elementsCount - 1] = firstElement;
            }
        }

        /// <summary>
        /// Gets permutations count
        /// </summary>
        /// <param name="elementsCount">Count of all elements in the sequence (arr.Length)</param>
        /// <param name="withoutRepetitions">True if all elements are unique, false if otherwise</param>
        /// <param name="repetitionsCounts">An array of integers, holding the number of repetitions of each repeating element in the sequence </param>
        /// <returns></returns>
        public static int GetPermutationsCount<T>(int elementsCount, bool withoutRepetitions = true, T[] array = null)
        {
            if (withoutRepetitions)
            {
                return CalcFactorial(elementsCount);
            }
            else
            {               
                if (array == null)
                {
                    throw new ArgumentNullException("Repetitions counts cannot be null.");
                }

                int[] repetitionsCounts = GetRepetitionsCount(array);

                int divisor = 1;
                for (int i = 0; i < repetitionsCounts.Length; i++)
                {
                    divisor *= CalcFactorial(repetitionsCounts[i]);
                }

                return CalcFactorial(elementsCount) / divisor;
            }
        }

        /// <summary>
        /// Gets all counts of all repetitive elements in an array with non-unique elements
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        private static int[] GetRepetitionsCount<T>(T[] objects)
        {
            List<int> repetitions = new List<int>();
            T[] repetitiveCopy = (T[])objects.Clone();

            while (repetitiveCopy.Length > 0)
            {
                var mostFrequent = GetMostFrequentNumber(repetitiveCopy);
                repetitions.Add(mostFrequent.Value);
                repetitiveCopy = repetitiveCopy.Select(x => x)
                    .Where(x => !x.Equals(mostFrequent.Key))
                    .ToArray();
            }

            return repetitions.ToArray();
        }

        /// <summary>
        /// Gets the most frequent element in an array
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        private static KeyValuePair<T, int> GetMostFrequentNumber<T>(T[] objects)
        {
            T[] sorted = (T[])objects.Clone();
            Array.Sort(sorted);

            T currentElement = objects[0];
            T mostFrequent = currentElement;
            int count = 1;
            int maxCount = 1;

            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i].Equals(currentElement))
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        mostFrequent = currentElement;
                    }
                }
                else
                {
                    count = 1;
                    currentElement = sorted[i];
                }
            }

            return new KeyValuePair<T, int>(mostFrequent, maxCount);
        }

        private static int CalcFactorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
