namespace MaximalSequence
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Problem 4. Maximal sequence 
    /// Write a program that finds the **maximal sequence** of equal elements in an array.
    /// Example:
    /// |              input              | result  |
    /// |---------------------------------|---------|
    /// | 2, 1, 1, 2, 3, 3, **2, 2, 2**, 1 | 2, 2, 2 |
    /// </summary>
    public class MaximalSequence
    {
        public static void Main()
        {
            int[] input = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
            int[] maximalSequence = GetMaximalSequence(input);

            DisplayExample(input, maximalSequence);
        }

        /// <summary>
        /// Gets the maximal sequence of same elements in an array of integers
        /// </summary>
        /// <param name="array">An array of integers</param>
        /// <returns>An array holding the maximal sequence</returns>
        public static int[] GetMaximalSequence(int[] array)
        {
            int currentElement = array[0];
            int bestElement = currentElement;
            int count = 1;
            int max = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (currentElement == array[i])
                {
                    count++;

                    if (count > max)
                    {
                        max = count;
                        bestElement = currentElement;
                    }
                }
                else
                {
                    count = 1;
                    currentElement = array[i];
                }
            }

            return Enumerable.Repeat<int>(bestElement, max).ToArray();
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        private static void DisplayExample(int[] input, int[] maximalSequence)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 4. Maximal sequence \nWrite a program that finds the **maximal sequence** of equal elements in an array.");

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
            maximalSequence = GetMaximalSequence(input);

            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", maximalSequence)))
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
