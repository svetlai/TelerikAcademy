namespace FirstLargerThanNeighbours
{
    using System;
    using System.Text;

    using LargerThanNeighbours;

    /// <summary>
    /// Problem 6. First larger than neighbours
    /// Write a method that returns the index of the first element in array that is larger than its neighbours, or `-1`, if there�s no such element.
    /// Use the method from the previous exercise.
    /// </summary>
    public class FirstLargerThanNeighbours
    {
        private const string InvalidFormatMsg = "Input was not in the correct format.";
        private const string IndexOutOfRangeMsg = "Index was out of range. Please select an index between 0 and the total length of the array.";

        public static void Main()
        {
            int[] array = { 1, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            int larger = FindFirstLargerThanNeighbours(array);

            DisplayExample(array, larger);
        }

        public static int FindFirstLargerThanNeighbours(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (LargerThanNeighbours.IsLargerThanNeighbours(array, i))
                {
                    return i;
                }
            }

            return -1;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        private static void DisplayExample(int[] array, int larger)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 6. First larger than neighbours \nWrite a method that returns the index of the first element in array that is larger than its neighbours, or `-1`, if there�s no such element. \nUse the method from the previous exercise.\n");

            // print
            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,10}", "input", "result"))
                .AppendLine(string.Format("{0,30} | {1,10}", string.Join(" ", array), larger))
                .AppendLine(border);

            Console.WriteLine(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            array = ConvertStringOfIntsToArray(Console.ReadLine());
            larger = FindFirstLargerThanNeighbours(array);

            // print
            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,10}", string.Join(" ", array), larger))
                .AppendLine(border);

            Console.WriteLine(print.ToString());
        }
    }
}
