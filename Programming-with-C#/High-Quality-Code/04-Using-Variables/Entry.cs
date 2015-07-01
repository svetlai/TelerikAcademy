namespace UsingVariables
{
    using System;

    public class Entry
    {
        public static void Main()
        {
            // shape example
            Shape shape = new Shape(1, 2);
            Console.WriteLine("Width: {0}, Height: {1}", shape.Width, shape.Height);

            shape = Shape.GetRotatedShape(shape, 0.5);
            Console.WriteLine("Width: {0}, Height: {1}", shape.Width, shape.Height);

            // staticstics example
            double[] numbers = new double[]
            {
                1, 2, 3
            };
            int count = numbers.Length;

            Statistics.PrintStatistics(numbers, count);
        }
    }
}
