namespace QuickSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class QuickSortTest
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 3, 56, 4, 23, 4, 67, 5 };

            QuickSorter.Sort(numbers, 0, numbers.Count - 1);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
