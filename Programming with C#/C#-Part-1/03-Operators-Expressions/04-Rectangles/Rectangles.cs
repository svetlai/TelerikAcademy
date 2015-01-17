namespace Rectangles
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 4.	Rectangles
    /// Write an expression that calculates rectangleâ€™s perimeter and area by given width and height.
    /// Examples:
    /// | width | height | perimeter | area |
    /// |:-----:|:------:|:---------:|:----:|
    /// | 3     | 4      | 14        | 12   |
    /// | 2.5   | 3      | 11        | 7.5  |
    /// | 5     | 5      | 20        | 25   |
    /// </summary>
    public class Rectangles
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // display examples
            List<Rectangle> rectangles = new List<Rectangle> 
            {
                new Rectangle(3, 4),
                new Rectangle(2.5, 3),
                new Rectangle(5, 5)
            };

            double area;
            double perimeter;

            Console.WriteLine("{0,5} | {1,6} | {2,10} | {3,5}", "width", "height", "perimeter", "area");

            for (int i = 0; i < rectangles.Count; i++)
            {
                area = CalculateRectangleArea(rectangles[i].Width, rectangles[i].Height);
                perimeter = CalculateRectanglePerimeter(rectangles[i].Width, rectangles[i].Height);

                Console.WriteLine("{0,5} | {1,6} | {2,10} | {3,5}", rectangles[i].Width, rectangles[i].Height, perimeter, area);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.WriteLine("Try it Yourself!");

            try
            {
                Console.Write("Enter width: ");
                double width = double.Parse(Console.ReadLine());

                Console.Write("Enter height: ");
                double height = double.Parse(Console.ReadLine());

                area = CalculateRectangleArea(width, height);
                perimeter = CalculateRectanglePerimeter(width, height);

                Console.WriteLine("{0,5} | {1,6} | {2,10} | {3,5}", width, height, perimeter, area);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Calculates a rectangle's area
        /// </summary>
        /// <param name="width">Double</param>
        /// <param name="height">Double</param>
        /// <returns>Double</returns>
        public static double CalculateRectangleArea(double width, double height)
        {
            if (height == null || width == null)
            {
                throw new ArgumentNullException("You need to specify both width and height.");
            }

            double area = height * width;

            return area;
        }

        /// <summary>
        /// Calculates a rectangle's perimeter
        /// </summary>
        /// <param name="width">Double</param>
        /// <param name="height">Double</param>
        /// <returns>Double</returns>
        public static double CalculateRectanglePerimeter(double width, double height)
        {
            if (height == null || width == null)
            {
                throw new ArgumentNullException("You need to specify both width and height.");
            }

            double parameter = 2 * (height + width);

            return parameter;
        }
    }
}
