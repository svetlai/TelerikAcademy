namespace CompareCharArrays
{
    using System;

    /// <summary>
    /// Problem 3. Compare char arrays
    /// Write a program that compares two `char` arrays lexicographically (letter by letter).
    /// </summary>
    public class CompareCharArrays
    {
        public static void Main()
        {
            Console.WriteLine("Problem 3. Compare char arrays \nWrite a program that compares two `char` arrays lexicographically (letter by letter).\n");

            Console.Write("Enter a random character sequence: ");
            char[] first = Console.ReadLine().ToCharArray();

            Console.Write("Enter a random character sequence: ");
            char[] second = Console.ReadLine().ToCharArray();

            bool areEqual = CompareArraysOfChars(first, second);

            Console.WriteLine("The two arrays are equal? -> {0}", areEqual);
        }

        public static bool CompareArraysOfChars(char[] first, char[] second)
        {
            if (first.Length != second.Length || first.Length < 1 || second.Length < 1)
            {
                return false;
            }
            else
            {
                int len = first.Length;

                for (int i = 0; i < len; i++)
                {
                    if (!first[i].Equals(second[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
