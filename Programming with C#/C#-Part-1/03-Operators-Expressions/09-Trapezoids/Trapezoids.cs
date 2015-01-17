namespace Trapezoids
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 9. Trapezoids
    /// Write an expression that calculates trapezoid's area by given sides `a` and `b` and height `h`.
    /// Examples:
    /// |   a   |   b   |   h   |    area   |
    /// |:-----:|:-----:|:-----:|:---------:|
    /// | 5     | 7     | 12    | 72        |
    /// | 2     | 1     | 33    | 49.5      |
    /// | 8.5   | 4.3   | 2.7   | 17.28     |
    /// | 100   | 200   | 300   | 45000     |
    /// | 0.222 | 0.333 | 0.555 | 0.1540125 |
    /// </summary>
    public class Trapezoids
    {
        public static void Main()
        {
            Console.WriteLine("Problem 9. Trapezoids \nWrite an expression that calculates trapezoid's area by given sides `a` and `b` and height `h`.");

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // display examples
            List<Trapezoid> trapezoids = new List<Trapezoid>
            {
                new Trapezoid(5, 7, 12),
                new Trapezoid(2, 1, 33),
                new Trapezoid(8.5, 4.3, 2.7),
                new Trapezoid(100, 200, 300),
                new Trapezoid(0.222, 0.333,  0.555),
            };

            double area;

            Console.WriteLine("{0,10} | {1,10} | {2,10} | {3,10}", "a", "b", "h", "area");

            for (int i = 0; i < trapezoids.Count; i++)
            {
                area = CalculateArea(trapezoids[i].SideA, trapezoids[i].SideB, trapezoids[i].Height);
                Console.WriteLine("{0,10} | {1,10} | {2,10} | {3,10}", trapezoids[i].SideA, trapezoids[i].SideB, trapezoids[i].Height, area);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.WriteLine("Try it Yourself!");

            try
            {
                Console.Write("Enter side a: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Enter side b: ");
                double b = double.Parse(Console.ReadLine());

                Console.Write("Enter height: ");
                double height = double.Parse(Console.ReadLine());

                area = CalculateArea(a, b, height);
                Console.WriteLine("{0,10} | {1,10} | {2,10} | {3,10}", a, b, height, area);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static double CalculateArea(double sideA, double sideB, double height)
        {
            if (sideA == null || sideB == null || height == null)
            {
                throw new ArgumentNullException("You need to specify both sides plus height.");
            }

            double area = ((sideA + sideB) / 2) * height;

            return area;
        }
    }
}
