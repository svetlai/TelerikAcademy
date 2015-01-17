namespace Rectangles
{
    /// <summary>
    /// A rectangle object
    /// </summary>
    internal class Rectangle
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
