namespace SortThreeNumbersWithNestedIfs
{
    using System;

    /// <summary>
    /// Problem 7. Sort 3 Numbers with Nested Ifs
    /// Write a program that enters 3 real numbers and prints them sorted in descending order.
    /// Use nested `if` statements.
    /// Note: Don't use arrays and the built-in sorting functionality.
    /// Examples:
    /// | a    | b    | c    |     result     |
    /// |------|------|------|=--------------=|
    /// | 5    | 1    | 2    | 5 2 1          |
    /// | -2   | -2   | 1    | 1 -2 -2        |
    /// | -2   | 4    | 3    | 4 3 -2         |
    /// | 0    | -2.5 | 5    | 5 0 -2.5       |
    /// | -1.1 | -0.5 | -0.1 | -0.1 -0.5 -1.1 |
    /// | 10   | 20   | 30   | 30 20 10       |
    /// | 1    | 1    | 1    | 1 1 1          |
    /// </summary>
    public class SortThreeNumbersWithNestedIfs
    {
        public static void Main()
        {
            Console.WriteLine("Problem 7. Sort 3 Numbers with Nested Ifs \nWrite a program that enters 3 real numbers and prints them sorted in descending order. \nUse nested `if` statements.\n");

            double a = 0;
            double b = 0;
            double c = 0;
            double swap;

            try
            {
                Console.Write("Enter an integer number a: ");
                a = double.Parse(Console.ReadLine());

                Console.Write("Enter a second integer number b: ");
                b = double.Parse(Console.ReadLine());

                Console.Write("Enter a third integer number c: ");
                c = double.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            if (a >= b)
            {
                if (a >= c)
                {
                    if (b < c)
                    {
                        // a, c, b
                        swap = b;
                        b = c;
                        c = swap;

                        Console.WriteLine("{0}, {1}, {2}", a, b, c);
                    }
                    else
                    {
                        // a, b, c
                        Console.WriteLine("{0}, {1}, {2}", a, b, c);
                    }
                }
                else
                {
                    // a >= b && a < c : c, a,  b
                    swap = a;
                    a = c;
                    c = b;
                    b = swap;

                    Console.WriteLine("{0}, {1}, {2}", a, b, c);
                }
            }
            else
            {
                // a < b
                if (b >= c)
                {
                    if (a <= c)
                    {
                        // b, c, a
                        swap = a;
                        a = b;
                        b = c;
                        c = swap;

                        Console.WriteLine("{0}, {1}, {2}", a, b, c);
                    }
                    else
                    {
                        // b, a, c
                        swap = a;
                        a = b;
                        b = swap;

                        Console.WriteLine("{0}, {1}, {2}", a, b, c);
                    }
                }
                else
                {
                    // b < c : c, b, a
                    swap = a;
                    a = c;
                    c = swap;
                    Console.WriteLine("{0}, {1}, {2}", a, b, c);
                }
            }
        }
    }
}
