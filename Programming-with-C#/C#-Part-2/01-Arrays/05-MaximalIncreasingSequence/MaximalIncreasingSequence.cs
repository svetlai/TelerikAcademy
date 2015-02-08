namespace MaximalIncreasingSequence
{
    using System;

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
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 5. Maximal increasing sequence \nWrite a program that finds the maximal increasing sequence in an array.");

            // display examples
            Console.WriteLine("Example:");
            int[] array = { 3, 2, 3, 4, 2, 2, 4 };
            int[] maximalSequence = GetMaximalIncreasingSequence(array);
            
            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", "input", "result");
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", array), string.Join(" ", maximalSequence));
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());
            int[] result = GetMaximalIncreasingSequence(input);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", result));
            Console.WriteLine(Border);
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
    }
}
