namespace AppearanceCount
{
    using System;

    /// <summary>
    /// Problem 4.  Appearance count
    /// Write a method that counts how many times given number appears in given array.
    /// Write a test program to check if the method is workings correctly.
    /// </summary>
    public class AppearanceCount
    {
        private const string InvalidFormatMsg = "Input was not in the correct format.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 4. Appearance count \nWrite a method that counts how many times given number appears in given array. \nWrite a test program to check if the method is workings correctly.\n");

            Console.WriteLine("Example:");
            int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            int number = 4;
            int count = CountAppearance(array, number);

            // print
            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", "input", "result");
            Console.WriteLine("{0,30} | {1} ({2} times)", string.Join(" ", array), number, count);
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            array = ConvertStringOfIntsToArray(Console.ReadLine());

            Console.Write("Enter a number to search for: ");

            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(InvalidFormatMsg);
                return;
            }

            count = CountAppearance(array, number);

            // print
            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1} ({2} times)", string.Join(" ", array), number, count);
            Console.WriteLine(Border);
        }

        public static int CountAppearance(int[] array, int number)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    count++;
                }
            }

            return count;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
