namespace Shapes.Models
{
    public class Triangle : Shape
    {
        public Triangle(double baseSide, double height)
            : base(baseSide, height)
        {
        }

        public override double CalculateSurface()
        {
            return (this.Width * this.Height) / 2; 
        }
    }
}
