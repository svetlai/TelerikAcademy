namespace Abstraction.Models
{
    using System;

    using Abstraction.Common;

    public class Circle : Figure
    {
        private double radius;

        public Circle()
        {
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                Validator.ValidateRadius(value, "Radius");
                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
