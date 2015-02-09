namespace QuickSortAlgorithm
{
    using System;

    /// <summary>
    /// Problem 14. Quick sort
    /// Write a program that sorts an array of strings using the [Quick sort](http://en.wikipedia.org/wiki/Quicksort) algorithm.
    /// </summary>
    public class QuickSortAlgorithm
    {
        private const string TextCharacters = ",.!?'\"\\/(){}[]-_;: ";
        private static readonly string Border = new string('-', 60);
  
        public static void Main()
        {
            Console.WriteLine("Problem 14. Quick sort \nWrite a program that sorts an array of strings using the [Quick sort](http://en.wikipedia.org/wiki/Quicksort) algorithm.\n");

            Console.WriteLine("Enter a sequence of strings separated by space or press enter to test with a sample input (sample input: grapes pinaple orange banana mango apple): ");

            string[] input;
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                input = new string[] { "grapes", "pinaple", "orange", "banana", "mango", "apple" };
            }
            else
            {
                input = Console.ReadLine().Split(TextCharacters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            QuickSort(input, 0, input.Length - 1);

            Console.WriteLine(Border);
            Console.WriteLine("{0,50}", "sorted");
            Console.WriteLine("{0,50}", string.Join(" ", input));
            Console.WriteLine(Border);
        }

        public static void QuickSort(string[] toSort, int left, int right)
        {
            int i = left;
            int j = right;
            string pivot = toSort[(left + right) / 2];

            while (i <= j)
            {
                while (toSort[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (toSort[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // swap
                    string temp = toSort[i];
                    toSort[i] = toSort[j];
                    toSort[j] = temp;

                    i++;
                    j--;
                }
            }

            // recursive calls
            if (left < j)
            {
                QuickSort(toSort, left, j);
            }

            if (i < right)
            {
                QuickSort(toSort, i, right);
            }
        }
    }
}
