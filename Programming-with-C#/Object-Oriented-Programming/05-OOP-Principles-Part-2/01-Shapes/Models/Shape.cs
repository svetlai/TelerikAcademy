namespace Shapes.Models
{
    using System;

    using Shapes.Contracts;

    public abstract class Shape : ICalculate
    {
        private const string NegativeSideExceptionMsg = "Value must be positive.";

        private double width;
        private double height;

        protected Shape(double width, double height)
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

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NegativeSideExceptionMsg);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NegativeSideExceptionMsg);
                }

                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
