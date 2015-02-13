﻿namespace LargerThanNeighbours
{
    using System;

    /// <summary>
    /// Problem 5. Larger than neighbours
    /// Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).
    /// </summary>
    public class LargerThanNeighbours
    {
        private const string InvalidFormatMsg = "Input was not in the correct format or range.";
        private const string IndexOutOfRangeMsg = "Index was out of range. Please select an index between 0 and the total length of the array.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 5. Larger than neighbours \nWrite a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).\n");

            Console.WriteLine("Example:");
            int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            int position = 3;
            bool larger = IsLargerThanNeighbours(array, position);

            // print
            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,10} | {2}", "input", "position", "result");
            Console.WriteLine("{0,30} | {1,10} | {2}", string.Join(" ", array), position, larger);
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");
            array = ConvertStringOfIntsToArray(Console.ReadLine());

            Console.Write("Enter a position: ");
            position = int.Parse(Console.ReadLine());
            larger = IsLargerThanNeighbours(array, position);

            // print
            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,10} | {2}", string.Join(" ", array), position, larger);
            Console.WriteLine(Border);
        }

        public static bool IsLargerThanNeighbours(int[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeMsg);
            }

            if (index == 0 && array[index] > array[index + 1] 
                || index == (array.Length - 1) && array[index] > array[index - 1]
                || array[index] > array[index + 1] && array[index] > array[index - 1])
            {
                return true;
            }

            return false;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
