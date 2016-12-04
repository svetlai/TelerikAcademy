namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 3. Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an 
    /// increasing order.
    /// </summary>
    public class SortedList
    {
        public static void Main()
        {
            Console.WriteLine("Enter positive integer numbers:");
            List<int> sequence = new List<int>();

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int number;
                if (int.TryParse(input, out number))
                {
                    sequence.Add(number);
                }
                else
                {
                    throw new ArgumentException("You must enter a positive integer number!");
                }

                input = Console.ReadLine();
            }

            sequence.Sort();

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
