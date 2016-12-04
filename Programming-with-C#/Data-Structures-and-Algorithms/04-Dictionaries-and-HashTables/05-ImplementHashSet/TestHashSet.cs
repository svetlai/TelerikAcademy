namespace ImplementHashSet
{
    using System;

    /// <summary>
    /// 5. Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the 
    /// elements. Implement all standard set operations like Add(T), Find(T), Remove(T), Count, Clear(), union and 
    /// intersect.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            HwHashSet<string> testSet = new HwHashSet<string>();

            testSet.Add("hello");
            testSet.Add("bye");
            testSet.Add("good morning");

            Console.WriteLine("Elements added successfully.");

            var count = testSet.Count;
            Console.WriteLine("Count: {0}", count);

            foreach (var item in testSet)
            {
                Console.WriteLine("{0}", item);
            }

            testSet.Remove("bye");
            Console.WriteLine("Element removed successfully.");

            var newCount = testSet.Count;
            Console.WriteLine("New count: {0}", testSet.Count);

            var hello = testSet.Find("hello");
            Console.WriteLine("Key found? {0}", hello);

            var helloValue = testSet["hello"];
            Console.WriteLine("testTbale[\"hello\"] - {0}", helloValue);

            var items = testSet.Items;

            foreach (var item in items)
            {
                Console.WriteLine("Items: {0}", item);
            }

            testSet.Clear();
            Console.WriteLine("Count after clear: {0}", testSet.Count);
        }
    }
}

