namespace FirstLargerThanNeighbours
{
    using System;

    /// <summary>
    /// Problem 6. First larger than neighbours
    /// Write a method that returns the index of the first element in array that is larger than its neighbours, or `-1`, if there�s no such element.
    /// Use the method from the previous exercise.
    /// </summary>
    public class FirstLargerThanNeighbours
    {
        private const string InvalidFormatMsg = "Input was not in the correct format.";
        private const string IndexOutOfRangeMsg = "Index was out of range. Please select an index between 0 and the total length of the array.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 6. First larger than neighbours \nWrite a method that returns the index of the first element in array that is larger than its neighbours, or `-1`, if there�s no such element. \nUse the method from the previous exercise.\n");

            Console.WriteLine("Example:");
            int[] array = { 1, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            int larger = FindFirstLargerThanNeighbours(array);

            // print
            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,10}", "input", "result");
            Console.WriteLine("{0,30} | {1,10}", string.Join(" ", array), larger);
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            array = ConvertStringOfIntsToArray(Console.ReadLine());
            larger = FindFirstLargerThanNeighbours(array);

            // print
            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,10}", string.Join(" ", array), larger);
            Console.WriteLine(Border);
        }

        public static int FindFirstLargerThanNeighbours(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (IsLargerThanNeighbours(array, i))
                {
                    return i;
                }
            }

            return -1;
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
