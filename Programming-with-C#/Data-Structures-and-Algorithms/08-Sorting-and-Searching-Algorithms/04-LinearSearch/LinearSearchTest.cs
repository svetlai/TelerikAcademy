namespace LinearSearch
{
    using System;
    using System.Collections.Generic;

    public class LinearSearchTest
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 3, 56, 4, 23, 4, 67, 5 };

            var indexFound = SortableCollection.LinearSearch(numbers, 23);

            Console.WriteLine("Found: {0}", indexFound);
        }
    }
}
