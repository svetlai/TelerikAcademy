namespace Point3DStruct
{
    public struct Point3D
    {
        private static readonly Point3D StartPoint;

        static Point3D()
        {
            StartPoint = new Point3D(0, 0, 0);
        }

        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;          
        }

        public static Point3D O
        {
            get
            {
                return StartPoint;
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public override string ToString()
        {
            return string.Format("Point({0}, {1}, {2})", this.X, this.Y, this.Z);
        }
    }
}
