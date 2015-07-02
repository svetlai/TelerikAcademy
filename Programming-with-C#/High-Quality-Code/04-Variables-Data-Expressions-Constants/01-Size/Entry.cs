namespace UsingVariables
{
    using System;

    public class Entry
    {
        public static void Main()
        {
            Shape shape = new Shape(1, 2);
            Console.WriteLine("Width: {0}, Height: {1}", shape.Width, shape.Height);

            shape = Shape.GetRotatedShape(shape, 0.5);
            Console.WriteLine("Width: {0}, Height: {1}", shape.Width, shape.Height);
        }
    }
}
