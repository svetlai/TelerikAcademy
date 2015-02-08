namespace CombinationsOfSet
{
    using System;

    /// <summary>
    /// Combination - the order doesn't matter. Takes some (or all) elements in the set and combines them. (Pick)
    /// </summary>
    public static class CombinationsGenerator
    {
        /// <summary>
        /// Generates combinations of combinationElementsCount number of unique elements in a set (an array), starting from index startIndex
        /// </summary>
        /// <typeparam name="T">Any data type</typeparam>
        /// <param name="objects">An array of all elements</param>
        /// <param name="current">A temporary array with combinationElementsCount length, storing the indexes of the elements in the objects array, for the current combination</param>
        /// <param name="currentIndex">Current index - the same as startIndex at the beginning</param>
        /// <param name="startIndex">Array index to start from</param>
        /// <param name="totalElements">The count of all elements to combine (n or objects.Length)</param>
        /// <param name="combinationElementsCount">The number of elements to use in each combination (k)</param>
        public static void GenerateCombinationsWithoutRepetitions<T>(T[] objects, int[] current, int currentIndex, int startIndex, int totalElements, int combinationElementsCount)
        {
            if (currentIndex >= combinationElementsCount)
            {
                PrintCombinations(objects, current);
            }
            else
            {
                for (int i = startIndex; i < totalElements; i++)
                {
                    current[currentIndex] = i;
                    GenerateCombinationsWithoutRepetitions(objects, current, currentIndex + 1, i + 1, totalElements, combinationElementsCount);
                }
            }
        }

        /// <summary>
        /// Generates variations of combinationElementsCount number of non-unique elements (the same element can be used more than once) in a set (an array), starting from index startIndex     
        /// </summary>
        /// <typeparam name="T">Any data type</typeparam>
        /// <param name="objects">An array of all elements</param>
        /// <param name="current">A temporary array with combinationElements length, storing the indexes of the elements in the objects array, for the current combination</param>
        /// <param name="currentIndex">Current index - the same as startIndex at the beginning</param>
        /// <param name="startIndex">Array index to start from</param>
        /// <param name="totalElements">The count of all elements to combine (n or objects.Length)</param>
        /// <param name="combinationElementsCount">The number of elements to use in each combination (k)</param>
        public static void GenerateCombinationsWithRepetitions<T>(T[] objects, int[] current, int currentIndex, int startIndex, int totalElements, int combinationElementsCount)
        {
            if (currentIndex >= combinationElementsCount)
            {
                PrintCombinations(objects, current);
            }
            else
            {
                for (int i = startIndex; i < totalElements; i++)
                {
                    current[currentIndex] = i;
                    GenerateCombinationsWithRepetitions(objects, current, currentIndex + 1, i, totalElements, combinationElementsCount);
                }
            }
        }

        /// <summary>
        /// Gets all combinations count of elements in a set
        /// </summary>
        /// <param name="totalElements">The number of elements in the set (n)</param>
        /// <param name="combinationElementsCount">The number of elements to use in each variation (k)</param>
        /// <param name="withoutRepetitions">Boolean - set to false for variations with repetitions</param>
        /// <returns>All variations count</returns>
        public static int GetCombinationsCount(int totalElements, int combinationElementsCount, bool withoutRepetitions = true)
        {
            if (withoutRepetitions)
            {
                return CalcFactorial(totalElements) / (CalcFactorial(totalElements - combinationElementsCount) * CalcFactorial(combinationElementsCount));
            }
            else
            {
                return CalcFactorial(totalElements + (combinationElementsCount - 1)) / (CalcFactorial(totalElements - 1) * CalcFactorial(combinationElementsCount));
            }
        }

        private static void PrintCombinations<T>(T[] objects, int[] current)
        {
            for (int i = 0; i < current.Length; i++)
            {
                string separator = i % 2 == 0 ? ", " : " ";

                Console.Write(objects[current[i]] + separator);
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
