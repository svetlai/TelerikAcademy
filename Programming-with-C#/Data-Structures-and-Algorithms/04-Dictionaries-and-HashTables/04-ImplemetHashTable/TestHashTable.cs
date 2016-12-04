namespace ImplemetHashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 4. Implement the data structure "hash table" in a class HashTable<K,T>. Keep the data in array of lists of 
    /// key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16. When the hash table load 
    /// runs over 75%, perform resizing to 2 times larger capacity. Implement the following methods and properties: 
    /// Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys. Try to make the hash table 
    /// to support iterating over its elements with foreach.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            HashTable<string, int> testTbale = new HashTable<string, int>();

            testTbale.Add("hello", 1);
            testTbale.Add("bye", 2);
            testTbale.Add("good morning", 2);

            Console.WriteLine("Elements added successfully.");

            var count = testTbale.Count;
            Console.WriteLine("Count: {0}", count);

            foreach (var pair in testTbale)
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }

            testTbale.Remove("bye");
            Console.WriteLine("Element removed successfully.");

            var newCount = testTbale.Count;
            Console.WriteLine("New count: {0}", testTbale.Count);

            var hello = testTbale.Find("hello");
            Console.WriteLine("Key found? {0}", hello);

            var helloValue = testTbale["hello"];
            Console.WriteLine("testTbale[\"hello\"] - {0}", helloValue);

            var keys = testTbale.Keys;

            foreach (var key in keys)
            {
                Console.WriteLine("Keys: {0}", key);
            }

            testTbale.Clear();
            Console.WriteLine("Count after clear: {0}", testTbale.Count);


        }
    }
}
