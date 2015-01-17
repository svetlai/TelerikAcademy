namespace PointInsideCircleOutsideRectangle
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 10.	Point Inside a Circle & Outside of a Rectangle
    /// Write an expression that checks for given point (x, y) if it is within the circle `K({1, 1}, 1.5)` and out of the rectangle `R(top=1, left=-1, width=6, height=2)`.
    /// Examples:
    /// |   x  |   y  | inside K & outside of R |
    /// |:----:|:----:|:-----------------------:|
    /// | 1    | 2    | yes                     |
    /// | 2.5  | 2    | no                      |
    /// | 0    | 1    | no                      |
    /// | 2.5  | 1    | no                      |
    /// | 2    | 0    | no                      |
    /// | 4    | 0    | no                      |
    /// | 2.5  | 1.5  | no                      |
    /// | 2    | 1.5  | yes                     |
    /// | 1    | 2.5  | yes                     |
    /// | -100 | -100 | no                      |
    /// </summary>
    public class PointInsideCircleOutsideRectangle
    {
        public static void Main()
        {
            Console.WriteLine("Problem 10.	Point Inside a Circle & Outside of a Rectangle \nWrite an expression that checks for given point (x, y) if it is within the circle `K({1, 1}, 1.5)` and out of the rectangle `R(top=1, left=-1, width=6, height=2)`.");

            // display examples
            List<Point> points = new List<Point> 
            {
                new Point(1, 2),
                new Point(2.5, 2),
                new Point(0, 1),
                new Point(2.5, 1),
                new Point(2, 0),
                new Point(4, 0),
                new Point(2.5, 1.5),
                new Point(2, 1.5),
                new Point(1, 2.5),
                new Point(-100, -100)
            };

            // circle
            Point circleCenter = new Point(1, 1);
            double radius = 1.5;

            // rectangle
            Point topLeftCorner = new Point(-1, 1);
            double width = 6;
            double height = 2;

            bool isInCircle;
            bool isInRectangle;
            string isTrue;

            Console.WriteLine("{0,10} | {1,10} | {2,10}", "x", "y", "inside K & outside of R");

            for (int i = 0; i < points.Count; i++)
            {
                isInCircle = IsPointInCircle(points[i], radius, circleCenter);
                isInRectangle = IsPointInRectangle(points[i], topLeftCorner, width, height);

                isTrue = isInCircle && !isInRectangle ? "yes" : "no";

                Console.WriteLine("{0,10} | {1,10} | {2,10}", points[i].X, points[i].Y, isTrue);
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

                isInCircle = IsPointInCircle(point, radius, circleCenter);
                isInRectangle = IsPointInRectangle(point, topLeftCorner, width, height);
                isTrue = isInCircle && !isInRectangle ? "yes" : "no";

                Console.WriteLine("{0,10} | {1,10} | {2,10}", point.X, point.Y, isTrue);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal static bool IsPointInCircle(Point point, double radius, Point circleCenter)
        {
            // Point P(x, y) is inside a circle if x^2 + y^2 < R^2, where R is the radius of the circle; 
            // if x^2 + y^2 = R^2 then the point lies on the circle.
            if (((point.X - circleCenter.X) * (point.X - circleCenter.X)) + ((point.Y - circleCenter.Y) * (point.Y - circleCenter.Y)) <= radius * radius)
            {
                return true;
            }

            return false;
        }

        internal static bool IsPointInRectangle(Point point, Point topLeftCorner, double width, double height)
        {
            double ax = topLeftCorner.X;
            double by = topLeftCorner.Y;
            double cx = ax + width;
            double dy = by - height;

            if (point.X >= ax && point.X <= cx
                && point.Y <= by && point.Y >= dy)
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
