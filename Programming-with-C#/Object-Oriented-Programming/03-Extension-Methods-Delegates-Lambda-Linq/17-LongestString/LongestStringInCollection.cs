namespace LongestString
{
    using System;
    using System.Linq;

    using Helper;

    /// <summary>
    /// Problem 17. Longest string
    /// Write a program to return the string with maximum length from an array of strings.
    /// Use LINQ.
    /// </summary>
    public class LongestStringInCollection
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            string[] testStrings = 
            {
                "hello",
                "hi",
                "bye",
                "goodbye"
            };

            string longest = GetLongestString(testStrings);

            Console.WriteLine("Collection: {0}", string.Join(", ", testStrings));
            Console.WriteLine("Longest: {0}", longest);
        }

        public static string GetLongestString(string[] strings)
        {
            var longest = (from str in strings
                           orderby str.Length descending
                           select str).First();

            // var longest = strings.OrderByDescending(s => s.Length)
            //    .First();
            return longest.ToString();
        }
    }
}
