namespace SortByStringLength
{
    using System;
    using System.Linq;

    /// <summary>
    /// Problem 5. Sort by string length
    /// You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
    /// </summary>
    public class SortByStringLength
    {
        private const string TextCharacters = ",.!?'\"\\/(){}[]-_;: ";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 5. Sort by string length \nYou are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).\n");

            // read input
            Console.WriteLine("Enter a sequence of strings separated by space or press enter to test with a sample input (sample input: orange pinaple pear watermelon mango apple): ");

            string[] input;
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                input = new string[] { "orange", "pinaple", "pear", "watermelon", "mango", "apple" };
            }
            else
            {
                input = Console.ReadLine().Split(TextCharacters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            string[] sorted = SortByLength(input);

            // print
            Console.WriteLine(Border);
            Console.WriteLine("Input: {0}", string.Join(" ", input));
            Console.WriteLine(Border);
            Console.WriteLine("Sorted: {0}", string.Join(" ", sorted));
            Console.WriteLine(Border);
        }

        public static string[] SortByLength(string[] input)
        {
            string[] sorted = input
                .OrderBy(x => x.Length)
                .ToArray();

            return sorted;
        }
    }
}
