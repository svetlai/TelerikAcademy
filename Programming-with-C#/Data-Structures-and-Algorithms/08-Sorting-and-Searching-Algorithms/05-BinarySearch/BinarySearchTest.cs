namespace BinarySearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BinarySearchTest
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 3, 56, 4, 23, 4, 67, 5 };

            var indexFound = SortableCollection.BinarySearch(numbers, 23);

            Console.WriteLine("Found: {0}", indexFound);
        }
    }
}
