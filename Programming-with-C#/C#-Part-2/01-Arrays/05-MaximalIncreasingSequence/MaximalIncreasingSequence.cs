namespace MaximalIncreasingSequence
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 5. Maximal increasing sequence
    /// Write a program that finds the maximal increasing sequence in an array.
    /// Example:
    /// |          input          | result  |
    /// |-------------------------|---------|
    /// | 3, **2, 3, 4**, 2, 2, 4 | 2, 3, 4 |
    /// </summary>
    public class MaximalIncreasingSequence
    {
        public static void Main()
        {
            int[] input = { 3, 2, 3, 4, 2, 2, 4 };
            int[] maximalSequence = GetMaximalIncreasingSequence(input);

            DisplayExample(input, maximalSequence);
        }

        public static int[] GetMaximalIncreasingSequence(int[] array)
        {
            int currentElement = array[0];
            int lastElement = currentElement;
            int count = 1;
            int max = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (currentElement + 1 == array[i])
                {
                    count++;

                    if (count > max)
                    {
                        max = count;
                        lastElement = array[i];
                    }
                }
                else
                {
                    count = 1;
                }

                currentElement = array[i];
            }

            int[] sequence = new int[max];

            for (int i = max - 1; i >= 0; i--)
            {
                sequence[i] = lastElement;
                lastElement--;
            }

            // alternative: 
            // int[] sequence = Enumerable.Range(-lastElement, max).Select(i => i * -1).Reverse().ToArray();
            return sequence;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        private static void DisplayExample(int[] input, int[] maximalSequence)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            Console.WriteLine("Problem 5. Maximal increasing sequence \nWrite a program that finds the maximal increasing sequence in an array.");

            // display examples
            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,15}", "input", "result"))
                .AppendLine(string.Format("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", maximalSequence)))
                .AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            input = ConvertStringOfIntsToArray(Console.ReadLine());
            maximalSequence = GetMaximalIncreasingSequence(input);

            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", maximalSequence)))
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
