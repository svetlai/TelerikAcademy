namespace PrintLongSequence
{
    using System;

    /// <summary>
    /// Problem 16.* Print Long Sequence
    /// Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
    /// You might need to learn how to use loops in C# (search in Internet).
    /// </summary>
    public class PrintLongSequence
    {
        public static void Main()
        {
            const int Count = 1000 + 2;

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
        }
    }
}
