namespace CombinationsOfSet
{
    using System;

    /// <summary>
    /// Problem 21.* Combinations of set
    /// Write a program that reads two numbers `N` and `K` and generates all the combinations of `K` distinct elements from the set [`1..N`].
    /// Example:
    /// | N | K |                                          result                                           |
    /// |:-:|:-:|:-----------------------------------------------------------------------------------------:|
    /// | 5 | 2 | `{1, 2}` <br> `{1, 3}` <br> `{1, 4}` <br> `{1, 5}` <br> `{2, 3}` <br> `{2, 4}` <br> `{2, 5}` <br> `{3, 4}` <br> `{3, 5}` <br> `{4, 5}` |
    /// </summary>
    public class CombinationsOfSet
    {
        public static void Main()
        {
            Console.WriteLine("Problem 21.* Combinations of set \nWrite a program that reads two numbers `N` and `K` and generates all the combinations of `K` distinct elements from the set [`1..N`].");

            // display examples
            Console.WriteLine("Example: ");
            Console.WriteLine("Combinations without repetitions: ");

            int[] array = { 1, 2, 3 };
            int n = array.Length;
            int k = 2;
            int[] current = new int[k];

            CombinationsGenerator.GenerateCombinationsWithoutRepetitions<int>(array, current, 0, 0, n, k);
            int combinationsCount = CombinationsGenerator.GetCombinationsCount(n, k);
            Console.WriteLine("Combinations count: {0}", combinationsCount);

            // Console.WriteLine("Combinations with repetitions: ");
            // CombinationsGenerator.GenerateCombinationsWithRepetitions<int>(array, current, 0, 0, n, k);
            // combinationsCount = CombinationsGenerator.GetCombinationsCount(n, k, false);
            // Console.WriteLine("Combinations count: {0}", combinationsCount);
        }
    }
}
