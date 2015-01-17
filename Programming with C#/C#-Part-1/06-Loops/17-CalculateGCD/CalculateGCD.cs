namespace CalculateGCD
{
    using System;

    /// <summary>
    /// Problem 17.* Calculate GCD
    /// Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
    /// Use the Euclidean algorithm (find it in Internet).
    /// Examples:
    /// a	b	GCD(a, b)
    /// 3	2	1
    /// 60	40	20
    /// 5	-15	5
    /// </summary>
    public class CalculateGCD
    {
        public static void Main()
        {
            Console.WriteLine("Problem 17.* Calculate GCD \nWrite a program that calculates the greatest common divisor (GCD) of given two integers a and b. \nUse the Euclidean algorithm (find it in Internet).\n");

            Console.Write("Please enter an integer number: ");

            int a;
            if (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            Console.Write("Please enter another integer number: ");

            int b;
            if (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            Console.WriteLine("GCD: {0}", CalculateGCDOfTwoNumbers(a, b));
        }

        /// <summary>
        /// Calculates the GCD of two integers using the Euclidean algorithm
        /// </summary>
        /// <param name="a">An integer number</param>
        /// <param name="b">An integer number</param>
        /// <returns>An integer number, holding the GCD</returns>
        public static int CalculateGCDOfTwoNumbers(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return Math.Max(a, b);
        }
    }
}
