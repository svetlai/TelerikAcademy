namespace PrintASequence
{
    using System;

    /// <summary>
    /// Problem 9. Print a Sequence
    /// Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
    /// </summary>
    public class PrintSequence
    {
        public static void Main()
        {
            const int Count = 10 + 2;

            for (int i = 2; i < Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("{0} ", i);
                }
                else
                {
                    Console.Write("{0} ", -i);
                }
            }

            Console.WriteLine();
        }
    }
}
