namespace CirclePerimeterAndArea
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 3. Circle Perimeter and Area
    /// Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.
    /// Examples:
    /// r	perimeter	area
    /// 2	12.57	12.57
    /// 3.5	21.99	38.48
    /// </summary>
    public class CirclePerimeterAndArea
    {
        public static void Main()
        {
            Console.WriteLine("Problem 3. Circle Perimeter and Area \nWrite a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.");
            Console.WriteLine();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            try
            {
                Console.Write("Enter circle radius: ");
                double radius = double.Parse(Console.ReadLine());

                double area = CalculateCircleArea(radius);
                double perimeter = CalculateCirclePerimeter(radius);

                Console.WriteLine("Area: {0: 0.00} \nPerimeter: {1: 0.00}", area, perimeter);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static double CalculateCircleArea(double radius)
        {
            double area = Math.PI * (radius * radius);

            return area;
        }

        public static double CalculateCirclePerimeter(double radius)
        {
            double perimeter = 2 * Math.PI * radius;

            return perimeter;
        }
    }
}
