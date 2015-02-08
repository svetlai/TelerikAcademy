namespace AllocateArray
{
    using System;

    /// <summary>
    /// Problem 1. Allocate array
    /// Write a program that allocates array of `20` integers and initializes each element by its index multiplied by `5`.
    /// Print the obtained array on the console.
    /// </summary>
    public class AllocateArray
    {
        public static void Main()
        {
            Console.WriteLine("Problem 1. Allocate array \nWrite a program that allocates array of `20` integers and initializes each element by its index multiplied by `5`. \nPrint the obtained array on the console.\n");

            int[] array = new int[20];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 5;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
