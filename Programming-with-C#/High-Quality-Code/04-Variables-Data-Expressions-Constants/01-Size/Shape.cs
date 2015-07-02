namespace UsingVariables
{
    using System;

    public class Shape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width must be a positive number.");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height must be positive number.");
                }
                else
                {
                    this.height = value;
                }
            }
        }

        public static Shape GetRotatedShape(Shape shape, double angleOfRotation)
        {
            double cosRotation = Math.Abs(Math.Cos(angleOfRotation));
            double sinRotation = Math.Abs(Math.Sin(angleOfRotation));

            double rotatedWidth = (cosRotation * shape.Width) + (sinRotation * shape.Height);
            double rotatedHeight = (sinRotation * shape.Width) + (cosRotation * shape.Height);

            return new Shape(rotatedWidth, rotatedHeight);
        }
    }
}
