namespace BinarySearch
{
    using System;

    /// <summary>
    /// Problem 4. Binary search
    /// Write a program, that reads from the console an array of `N` integers and an integer `K`, sorts the array and using the method `Array.BinSearch()` finds the largest number in the array which is &#8804; `K`.
    /// </summary>
    public class BinarySearch
    {
        private const string FormatExceptionMessage = "Input not in the correct format or range.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 4. Binary search \nWrite a program, that reads from the console an array of `N` integers and an integer `K`, sorts the array and using the method `Array.BinSearch()` finds the largest number in the array which is <= `K`.\n");

            // read input from the console
            Console.Write("Enter a sequence of integer numbers separated by space: ");

            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());

            Console.Write("Enter an integer number k: ");

            int k;
            if (!int.TryParse(Console.ReadLine(), out k))
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            Array.Sort(input);

            // search for the number k; if not found decrease with 1 while a number is found or index 0 is reached
            int searchedIndex = -1;
            int searchedValue = k;
            while (searchedIndex < 0 && searchedValue >= input[0])
            {
                searchedIndex = Array.BinarySearch(input, searchedValue);
                searchedValue--;
            }

            // print result
            Console.WriteLine(Border);

            if (searchedIndex > -1)
            {
                Console.WriteLine("The largest number <= {0} is {1}.", k, input[searchedIndex]);
            }
            else
            {
                Console.WriteLine("No number <= {0} was found.", k);
            }

            Console.WriteLine(Border);
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
