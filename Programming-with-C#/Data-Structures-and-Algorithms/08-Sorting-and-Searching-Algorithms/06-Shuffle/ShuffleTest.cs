namespace Shuffle
{
    using System;
    using System.Collections.Generic;

    public class ShuffleTest
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 3, 56, 4, 23, 4, 67, 5 };

			//complexity O(n);
            SortableCollection.Shuffle(numbers);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
