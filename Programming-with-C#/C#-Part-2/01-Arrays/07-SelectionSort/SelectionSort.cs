namespace SelectionSortAlgorithm
{
    using System;

    /// <summary>
    /// Problem 7. Selection sort
    /// **Sorting** an array means to arrange its elements in increasing order. Write a program to sort an array.
    /// Use the [Selection sort](http://en.wikipedia.org/wiki/Selection_sort) algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
    /// </summary>
    public class SelectionSortAlgorithm
    {
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 7. Selection sort \n**Sorting** an array means to arrange its elements in increasing order. Write a program to sort an array. \nUse the [Selection sort](http://en.wikipedia.org/wiki/Selection_sort) algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.\n");
            
            Console.Write("Enter a sequence of integer numbers separated by space: ");

            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());
            int[] sorted = SelectionSort(input);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", "input", "result");
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", sorted));
            Console.WriteLine(Border);
        }

        public static int[] SelectionSort(int[] array)
        {
            int[] sorted = (int[])array.Clone();

            for (int i = 0; i < sorted.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < sorted.Length; j++)
                {
                    if (sorted[j] <= sorted[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    int temp = sorted[i];
                    sorted[i] = sorted[min];
                    sorted[min] = temp;
                }
            }

            return sorted;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
