namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 1. Write a program that reads from the console a sequence of positive integer numbers.
    /// The sequence ends when empty line is entered. Calculate and print the sum and average of the elements 
    /// of the sequence. Keep the sequence in List<int>.
    /// </summary>
    public class ListNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Enter positive integer numbers:");
            List<int> sequence = new List<int>();

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int number;
                if (int.TryParse(input, out number) && number > 0)
                {
                    sequence.Add(number);
                }
                else
                {
                    throw new ArgumentException("You must enter a positive integer number!");
                }

                input = Console.ReadLine();
            }

            double sequenceAverage = sequence.Average();
            int sequenceSum = sequence.Sum();

            Console.WriteLine("Sequence average: {0}", sequenceAverage);
            Console.WriteLine("Sequence sum: {0}", sequenceSum);
        }
    }
}
