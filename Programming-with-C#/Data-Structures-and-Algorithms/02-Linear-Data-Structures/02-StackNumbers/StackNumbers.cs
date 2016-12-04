namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 2. Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.
    /// </summary>
    public class StackNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Enter integer numbers:");
            Stack<int> numbers = new Stack<int>();

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int number;
                if (int.TryParse(input, out number))
                {
                    numbers.Push(number);
                }
                else
                {
                    throw new ArgumentException("You must enter an integer number!");
                }

                input = Console.ReadLine();
            }

            while (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Pop());
            }

            ////Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
