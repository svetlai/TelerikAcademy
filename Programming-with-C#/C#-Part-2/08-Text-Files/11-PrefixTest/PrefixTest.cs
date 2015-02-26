namespace PrefixTest
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Problem 11. Prefix "test"
    /// Write a program that deletes from a text file all words that start with the prefix `test`.
    /// Words contain only the symbols `0…9`, `a…z`, `A…Z`, `_`.
    /// </summary>
    public class PrefixTest
    {
        public static void Main()
        {
            string path = "../../joke.txt";

            DeletePrefixTest(path);
        }

        public static void DeletePrefixTest(string path)
        {
            try
            {
                string contents = File.ReadAllText(path);
                string[] words = contents.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(w => !w.StartsWith("test")).ToArray();

                contents = string.Join(" ", words);

                File.WriteAllText(path, contents);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }          

            Console.WriteLine("File was written successfully at {0}.", new FileInfo(path).FullName);
        }
    }
}
