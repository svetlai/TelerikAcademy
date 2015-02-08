namespace MaximalSequence
{
    using System;
    using System.Linq;

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
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Maximal sequence \nWrite a program that finds the **maximal sequence** of equal elements in an array.");

            // display examples
            Console.WriteLine("Example:");
            int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
            int[] maximalSequence = GetMaximalSequence(array);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", "input", "result");
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", array), string.Join(" ", maximalSequence));
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");
            
            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());         
            int[] result = GetMaximalSequence(input);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", result));
            Console.WriteLine(Border);
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
    }
}
