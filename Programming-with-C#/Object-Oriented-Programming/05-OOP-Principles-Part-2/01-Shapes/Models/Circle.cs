namespace Shapes.Models
{
    using System;

    public class Circle : Shape
    {
        public Circle(double radius)
            : base(radius, radius)
        {
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Width * this.Height;
        }
    }
}
