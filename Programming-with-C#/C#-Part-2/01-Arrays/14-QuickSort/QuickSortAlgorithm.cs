namespace QuickSortAlgorithm
{
    using System;

    /// <summary>
    /// Problem 14. Quick sort
    /// Write a program that sorts an array of strings using the [Quick sort](http://en.wikipedia.org/wiki/Quicksort) algorithm.
    /// </summary>
    public class QuickSortAlgorithm
    {
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 14. Quick sort \nWrite a program that sorts an array of strings using the [Quick sort](http://en.wikipedia.org/wiki/Quicksort) algorithm.\n");

            Console.Write("Enter a sequence of integer numbers separated by space: ");

            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());
            QuickSort(input, 0, input.Length - 1);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30}", "sorted");
            Console.WriteLine("{0,30}", string.Join(" ", input));
            Console.WriteLine(Border);
        }

        public static void QuickSort(int[] toSort, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = toSort[(left + right) / 2];

            while (i <= j)
            {
                while (toSort[i] < pivot)
                {
                    i++;
                }

                while (toSort[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    // swap
                    int temp = toSort[i];
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

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
