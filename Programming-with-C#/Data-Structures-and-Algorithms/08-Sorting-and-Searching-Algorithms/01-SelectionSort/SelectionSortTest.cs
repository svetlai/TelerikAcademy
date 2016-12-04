namespace SelectionSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSortTest
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 3, 56, 4, 23, 4, 67, 5 };

            SelectionSorter.Sort(numbers);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
