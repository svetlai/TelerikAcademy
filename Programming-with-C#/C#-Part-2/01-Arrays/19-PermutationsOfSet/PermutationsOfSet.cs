namespace PermutationsOfSet
{
    using System;

    /// <summary>
    /// Problem 19.* Permutations of set
    /// Write a program that reads a number `N` and generates and prints all the permutations of the numbers [`1 ... N`].
    /// Example:
    /// | N |                                  result                                 |
    /// |:-:|:-----------------------------------------------------------------------:|
    /// | 3 | `{1, 2, 3}` <br> `{1, 3, 2}` <br> `{2, 1, 3}` <br> `{2, 3, 1}` <br> `{3, 1, 2}` <br> `{3, 2, 1}` |
    /// </summary>
    public class PermutationsOfSet
    {
        public static void Main()
        {
            Console.WriteLine("Problem 19.* Permutations of set \nWrite a program that reads a number `N` and generates and prints all the permutations of the numbers [`1 ... N`].");
            
            // display examples
            Console.WriteLine("Example: ");
            Console.WriteLine("Permutations without repetitions: ");
            
            int[] noRepetitions = { 1, 2, 3 };
            PermutationsGenerator.GeneratePermutationsWithoutRepetitions<int>(noRepetitions, 0);

            int permutationsCount = PermutationsGenerator.GetPermutationsCount<int>(noRepetitions.Length);
            Console.WriteLine("Permutations count: {0}", permutationsCount);

            Console.WriteLine("Permutations with repetitions: ");
            int[] repetitive = { 3, 5, 3, 5, 5 };
            Array.Sort(repetitive);

            PermutationsGenerator.GeneratePermutationsWithRepetitions<int>(repetitive, 0, repetitive.Length);

            permutationsCount = PermutationsGenerator.GetPermutationsCount<int>(repetitive.Length, false, repetitive);
            Console.WriteLine("Permutations count: {0}", permutationsCount);
        }
    }
}
