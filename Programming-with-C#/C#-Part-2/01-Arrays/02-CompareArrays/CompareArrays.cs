namespace CompareArrays
{
    using System;

    /// <summary>
    /// Problem 2. Compare arrays
    /// Write a program that reads two `integer` arrays from the console and compares them element by element.
    /// </summary>
    public class CompareArrays
    {
        public static void Main()
        {
            Console.WriteLine("Problem 2. Compare arrays \nWrite a program that reads two `integer` arrays from the console and compares them element by element.\n");

            Console.Write("Enter a sequence of integer numbers separated by space: ");
            int[] first = ConvertStringOfIntsToArray(Console.ReadLine());

            Console.Write("Enter a sequence of integer numbers separated by space: ");
            int[] second = ConvertStringOfIntsToArray(Console.ReadLine());

            bool areEqual = CompareIntArrays(first, second);
            Console.WriteLine("The two arrays are equal? -> {0}", areEqual);
        }

        public static bool CompareIntArrays(int[] first, int[] second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }
            else
            {
                int len = first.Length;

                for (int i = 0; i < first.Length; i++)
                {
                    if (!first[i].Equals(second[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
