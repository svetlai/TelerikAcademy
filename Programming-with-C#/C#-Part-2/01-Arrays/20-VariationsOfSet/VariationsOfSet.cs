namespace VariationsOfSet
{
    using System;

    /// <summary>
    /// Problem 20.* Variations of set
    /// Write a program that reads two numbers `N` and `K` and generates all the variations of `K` elements from the set [`1..N`].
    /// Example:
    /// | N | K |                                      result                                      |
    /// |:-:|:-:|:--------------------------------------------------------------------------------:|
    /// | 3 | 2 | `{1, 1}` <br> `{1, 2}` <br> `{1, 3}` <br> `{2, 1}` <br> `{2, 2}` <br> `{2, 3}` <br> `{3, 1}` <br> `{3, 2}` <br> `{3, 3}` |
    /// </summary>
    public class VariationsOfSet
    {
        public static void Main()
        {
            Console.WriteLine("Problem 20.* Variations of set \nWrite a program that reads two numbers `N` and `K` and generates all the variations of `K` elements from the set [`1..N`].");
            
            // display examples
            Console.WriteLine("Example: ");
            Console.WriteLine("Variations without repetitions: ");

            int[] array = { 1, 2, 3 };
            int n = array.Length;
            int k = 2;
            int[] current = new int[k];
            bool[] used = new bool[array.Length];

            VariationsGenerator.GenerateVariationsWithoutRepetitions<int>(array, current, used, 0, n, k);
            int variationsCount = VariationsGenerator.GetVariationsCount(n, k);
            Console.WriteLine("Variations count: {0}", variationsCount);

            Console.WriteLine("Variations with repetitions: ");

            VariationsGenerator.GenerateVariationsWithRepetitions<int>(array, current, 0, n, k);
            variationsCount = VariationsGenerator.GetVariationsCount(n, k, false);
            Console.WriteLine("Variations count: {0}", variationsCount);
        }
    }
}
