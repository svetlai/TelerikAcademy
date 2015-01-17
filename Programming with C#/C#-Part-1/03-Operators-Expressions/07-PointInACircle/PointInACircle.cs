namespace PointInACircle
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 7.	Point in a Circle
    /// Write an expression that checks if given point (x,  y) is inside a circle `K({0, 0}, 2)`.
    /// Examples:
    /// |   x  |   y   | inside |
    /// |:----:|:-----:|:------:|
    /// | 0    | 1     | true   |
    /// | -2   | 0     | true   |
    /// | -1   | 2     | false  |
    /// | 1.5  | -1    | true   |
    /// | -1.5 | -1.5  | false  |
    /// | 100  | -30   | false  |
    /// | 0    | 0     | true   |
    /// | 0.2  | -0.8  | true   |
    /// | 0.9  | -1.93 | false  |
    /// | 1    | 1.655 | true   |
    /// </summary>
    public class PointInACircle
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Is point (x, y) in circle K({0 0}, 2)?");
            double radius = 2;
            
            // display examples
            List<Point> points = new List<Point> 
            {
                new Point(0, 1),
                new Point(-2, 0),
                new Point(-1, 2),
                new Point(1.5, -1),
                new Point(1.5, 1.5),
                new Point(100, -30),
                new Point(0, 0),
                new Point(0.2, -0.8),
                new Point(0.9, -1.93),
                new Point(1, 1.655)
            };

            bool isInCircle;

            Console.WriteLine("{0,10} | {1,10} | {2,10}", "x", "y", "inside");

            for (int i = 0; i < points.Count; i++)
            {
                isInCircle = IsPointInCircle(points[i], radius);
                Console.WriteLine("{0,10} | {1,10} | {2,10}", points[i].X, points[i].Y, isInCircle);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.WriteLine("Try it Yourself!");

            try
            {
                Console.Write("Enter x: ");
                double x = double.Parse(Console.ReadLine());

                Console.Write("Enter y: ");
                double y = double.Parse(Console.ReadLine());

                Point point = new Point(x, y);

                Console.WriteLine("{0,10} | {1,10} | {2,10}", point.X, point.Y, IsPointInCircle(point, radius));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal static bool IsPointInCircle(Point point, double radius)
        {
            // Point P(x, y) is inside a circle if x^2 + y^2 < R^2, where R is the radius of the circle; 
            // if x^2 + y^2 = R^2 then the point lies on the circle.
            if ((point.X * point.X) + (point.Y * point.Y) <= radius * radius)
            {
                return true;
            }

            return false;
        }  
    }

    internal struct Point
    {
        private double x;
        private double y;

        internal Point(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }
    }
}
