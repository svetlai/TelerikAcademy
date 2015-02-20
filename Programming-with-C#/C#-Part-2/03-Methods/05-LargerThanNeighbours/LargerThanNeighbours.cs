namespace LargerThanNeighbours
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 5. Larger than neighbours
    /// Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).
    /// </summary>
    public class LargerThanNeighbours
    {
        private const string InvalidFormatMsg = "Input was not in the correct format or range.";
        private const string IndexOutOfRangeMsg = "Index was out of range. Please select an index between 0 and the total length of the array.";

        public static void Main()
        {
            int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            int position = 3;
            bool larger = IsLargerThanNeighbours(array, position);

            DisplayExample(array, position, larger);
        }

        public static bool IsLargerThanNeighbours(int[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeMsg);
            }

            if (array.Length == 1)
            {
                return true;
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

        private static void DisplayExample(int[] array, int position, bool larger)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 5. Larger than neighbours \nWrite a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).\n");

            // print
            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,10} | {2}", "input", "position", "result"))
                .AppendLine(string.Format("{0,30} | {1,10} | {2}", string.Join(" ", array), position, larger))
                .AppendLine(border);

            Console.WriteLine(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");
            array = ConvertStringOfIntsToArray(Console.ReadLine());

            Console.Write("Enter a position: ");
            position = int.Parse(Console.ReadLine());
            larger = IsLargerThanNeighbours(array, position);

            // print
            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,10} | {2}", string.Join(" ", array), position, larger))
                .AppendLine(border);

            Console.WriteLine(print.ToString());
        }
    }
}
