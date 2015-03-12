namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    using Helper;

    /// <summary>
    /// Problem 2. IEnumerable extensions
    /// Implement a set of extension methods for `IEnumerable<T>` that implement the following group functions: sum, product, min, max, average.
    /// </summary>
    public class IEnumerableExtensionsTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestIEnumerableExtionsions();
        }

        public static void TestIEnumerableExtionsions()
        {
            var testCollection = new List<int>() { 1, 2, 3, 4, 5 };

            long sum = testCollection.Sum<int>();
            long product = testCollection.Product<int>();
            int min = testCollection.Min<int>();
            int max = testCollection.Max<int>();
            int average = testCollection.Average<int>();

            Console.WriteLine("Collection: {0}", testCollection.ToStringExtended<int>());
            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine("Product: {0}", product);
            Console.WriteLine("Min: {0}", min);
            Console.WriteLine("Max: {0}", max);
            Console.WriteLine("Average: {0}", average);
        }
    }
}
