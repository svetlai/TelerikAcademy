namespace NumberComparer
{
    using System;

    /// <summary>
    /// Problem 4. Number Comparer
    /// Write a program that gets two numbers from the console and prints the greater of them.
    /// Try to implement this without if statements.
    /// Examples:
    /// a	b	greater
    /// 5	6	6
    /// 10	5	10
    /// 0	0	0
    /// -5	-2	-2
    /// 1.5	1.6	1.6
    /// </summary>
    public class NumberComparer
    {
        public static void Main()
        {
            Console.WriteLine("Problem 4. Number Comparer \nWrite a program that gets two numbers from the console and prints the greater of them. Try to implement this without if statements.");
            Console.WriteLine();

            int first = 0;
            int second = 0;

            try
            {
                Console.Write("Enter the first integer number: ");
                first = int.Parse(Console.ReadLine());

                Console.Write("Enter the second integer number: ");
                second = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            int greater = Math.Max(first, second);
            //int greater = first > second ? first : second;

            Console.WriteLine("The greater of the two numbers is: {0}", greater);
        }
    }
}
