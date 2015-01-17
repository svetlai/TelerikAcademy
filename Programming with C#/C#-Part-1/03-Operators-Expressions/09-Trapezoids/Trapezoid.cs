namespace Trapezoids
{
    internal class Trapezoid
    {
        public Trapezoid(double sideA, double sideB, double height)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.Height = height;
        }

        public double SideA { get; set; }

        public double SideB { get; set; }

        public double Height { get; set; }
    }
}
