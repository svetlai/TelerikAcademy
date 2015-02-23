namespace StringLength
{
    using System;

    /// <summary>
    /// Problem 6. String length
    /// Write a program that reads from the console a string of maximum `20` characters. If the length of the string is less than `20`, the rest of the characters should be filled with `*`.
    /// Print the result string into the console.
    /// </summary>
    public class StringLength
    {
        private const int TextLength = 20;

        public static void Main()
        {
            DisplayExample();
        }

        public static string ReplaceCharacters(string text)
        {
            if (text.Length > TextLength)
            {
                throw new ArgumentException("The text must be no more than 20 characters long.");
            }

            if (text.Length < TextLength)
            {
                text = text.PadRight(TextLength, '*');
            }

            return text;
        }

        private static void DisplayExample()
        {
            Console.WriteLine("Problem 6. String length \nWrite a program that reads from the console a string of maximum `20` characters. If the length of the string is less than `20`, the rest of the characters should be filled with `*`. \nPrint the result string into the console.\n");
            Console.Write("Enter text: ");

            string text = Console.ReadLine();

            Console.WriteLine(ReplaceCharacters(text));
        }
    }
}
