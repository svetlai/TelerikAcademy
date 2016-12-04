namespace MergeSort
{
    using System;
    using System.Collections.Generic;

    class MergeSortTest
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 3, 56, 4, 23, 4, 67, 5 };

            MergeSorter.Sort(numbers, 0, numbers.Count - 1);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
