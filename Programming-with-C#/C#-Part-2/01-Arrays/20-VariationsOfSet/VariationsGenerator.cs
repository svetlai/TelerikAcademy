namespace VariationsOfSet
{
    using System;

    /// <summary>
    /// Variation - the order of elements matters. Takes some (not all) elements in the set and combines them. (Arrange and pick)
    /// </summary>
    public static class VariationsGenerator
    {
        /// <summary>
        /// Generates variations of variationElementsCount number of unique elements in a set (an array), starting from index startIndex
        /// </summary>
        /// <param name="objects">An array of all elements</param>
        /// <param name="current">A temporary array with variationElementsCount length, storing the indexes of the elements in the objects array, for the current variation</param>
        /// <param name="used">A temporary bool array with totalElements length, set to true when current index is used in a variation, to avoid repetitions</param>
        /// <param name="startIndex">Array index to start from</param>
        /// <param name="totalElements">The count of all elements to variate from (n or objects.Length)</param>
        /// <param name="variationElementsCount">The number of elements to use in each variation (k)</param>
        public static void GenerateVariationsWithoutRepetitions<T>(T[] objects, int[] current, bool[] used, int startIndex, int totalElements, int variationElementsCount)
        {
            if (startIndex >= variationElementsCount)
            {
                // add method for each variation here
                PrintVariations(objects, current);
            }
            else
            {
                for (int i = 0; i < totalElements; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        current[startIndex] = i;
                        GenerateVariationsWithoutRepetitions(objects, current, used, startIndex + 1, totalElements, variationElementsCount);
                        used[i] = false;
                    }
                }
            }
        }

        /// <summary>
        /// Generates variations of variationElementsCount number of non-unique elements (the same element can be used more than once) in a set (an array), starting from index startIndex
        /// </summary>
        /// <param name="objects">An array of all elements</param>
        /// <param name="current">A temporary array with variationElementsCount length, storing indexes in the array of the current variation</param>
        /// <param name="startIndex">Array index to start from</param>
        /// <param name="totalElements">The count of all elements to variate from (n or objects.Length)</param>
        /// <param name="variationElementsCount">The number of elements to use in each variation (k)</param>
        public static void GenerateVariationsWithRepetitions<T>(T[] objects, int[] current, int startIndex, int totalElements, int variationElementsCount)
        {
            if (startIndex >= variationElementsCount)
            {
                // add method for each variation here
                PrintVariations(objects, current);
            }
            else
            {
                for (int i = 0; i < totalElements; i++)
                {
                    current[startIndex] = i;
                    GenerateVariationsWithRepetitions(objects, current, startIndex + 1, totalElements, variationElementsCount);
                }
            }
        }

        /// <summary>
        /// Gets all variations count of elements in a set
        /// </summary>
        /// <param name="totalElements">The number of elements in the set (n)</param>
        /// <param name="variationElementsCount">The number of elements to use in each variation (k)</param>
        /// <param name="withoutRepetitions">Boolean - set to false for variations with repetitions</param>
        /// <returns>All variations count</returns>
        public static int GetVariationsCount(int totalElements, int variationElementsCount, bool withoutRepetitions = true)
        {
            if (withoutRepetitions)
            {
                return CalcFactorial(totalElements) / CalcFactorial(totalElements - variationElementsCount);
            }
            else
            {
                return (int)Math.Pow(totalElements, variationElementsCount);
            }
        }

        private static void PrintVariations<T>(T[] array, int[] current)
        {
            for (int i = 0; i < current.Length; i++)
            {
                string separator = i % 2 == 0 ? ", " : " ";

                Console.Write(array[current[i]] + separator);
            }

            Console.WriteLine();
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
    }
}
