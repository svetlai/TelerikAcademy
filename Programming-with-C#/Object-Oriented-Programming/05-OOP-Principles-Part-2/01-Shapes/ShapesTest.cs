namespace Shapes
{
    using System;
    using System.Text;

    using Helper;
    using Shapes.Models;

    public class ShapesTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestShapes();
        }

        public static void TestShapes()
        {
            double width = 2;
            double height = 3;

            var shapes = new Shape[] 
            {
                new Rectangle(width, height),
                new Triangle(width, height),
                new Circle(width)
            };

            Console.WriteLine("Width: {0}, Height: {1}", width, height);

            foreach (var shape in shapes)
            {
                Console.WriteLine("Shape: {0}, Surface: {1}", shape.GetType(), shape.CalculateSurface());
            }
        }
    }
}
