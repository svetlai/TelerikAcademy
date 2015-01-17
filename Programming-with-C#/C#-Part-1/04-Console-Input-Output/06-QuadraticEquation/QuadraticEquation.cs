namespace QuadraticEquation
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 6.	Quadratic Equation
    /// Write a program that reads the coefficients `a`, `b` and `c` of a quadratic equation ax<sup>2</sup> + bx + c = 0 and solves it (prints its real roots).
    /// Examples:
    /// |   a  |  b  |  c  |     roots     |
    /// |:----:|:---:|:---:|---------------|
    /// | 2    | 5   | -3  | x1=-3; x2=0.5 |
    /// | -1   | 3   | 0   | x1=3; x2=0    |
    /// | -0.5 | 4   | -8  | x1=x2=4       |
    /// | 5    | 2   | 8   | no real roots |
    /// </summary>
    public class QuadraticEquation
    {
        public static void Main()
        {
            Console.WriteLine("Problem 6. Quadratic Equation \nWrite a program that reads the coefficients `a`, `b` and `c` of a quadratic equation ax<sup>2</sup> + bx + c = 0 and solves it (prints its real roots).");
            Console.WriteLine();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Read coeffiecients from the console
            double a = 0;
            double b = 0;
            double c = 0;

            try
            {
                Console.Write("Enter coefficient a: ");
                a = double.Parse(Console.ReadLine());

                Console.Write("Enter coefficient b: ");
                b = double.Parse(Console.ReadLine());

                Console.Write("Enter coefficient c: ");
                c = double.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // Solve equation and print result
            string result = SolveQuadraticEquation(a, b, c);

            Console.WriteLine(result);
        }

        public static string SolveQuadraticEquation(double a, double b, double c)
        {
            double discriminant = Math.Sqrt(b * b - 4 * a * c);
            string result;

            if (discriminant > 0)
            {
                double x1 = (-b - discriminant) / (2 * a);
                double x2 = (-b + discriminant) / (2 * a);

                result = string.Format("x1 = {0}; x2 = {1}", x1, x2);
            }
            else if (discriminant == 0)
            {
                double x = (-b) / (2 * a);

                result = string.Format("x1 = x2 = {0}", x);
            }
            else
            {
                result = "no real roots";
            }

            return result;
        }
    }
}
