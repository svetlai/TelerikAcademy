namespace ReverseString
{
    using System;

    /// <summary>
    /// Problem 2. Reverse string
    /// Write a program that reads a string, reverses it and prints the result at the console.
    /// Example:
    /// |  input | output |
    /// |:------:|:------:|
    /// | sample | elpmas |
    /// </summary>
    public class StringReverse
    {
        public static void Main()
        {
            DisplayExample();
        }

        public static string ReverseString(string text)
        {
            char[] textAsArray = text.ToCharArray();
            Array.Reverse(textAsArray);

            return new string(textAsArray);
        }

        private static void DisplayExample()
        {
            Console.WriteLine("Problem 2. Reverse string \nWrite a program that reads a string, reverses it and prints the result at the console.\n");

            Console.Write("Enter a string to reverse: ");

            string text = Console.ReadLine();
            string reversed = ReverseString(text);

            Console.WriteLine("Reversed: {0}", reversed);
        }
    }
}
