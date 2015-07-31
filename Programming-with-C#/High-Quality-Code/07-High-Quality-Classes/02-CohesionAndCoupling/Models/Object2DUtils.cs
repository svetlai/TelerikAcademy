namespace CohesionAndCoupling.Models
{
    using System;

    public class Object2DUtils : Utils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance2D = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance2D;
        }

        public static double CalcDiagonalXY(double distance2D)
        {
            double distance = distance2D;
            return distance;
        }

        public static double CalcDiagonalXZ(double distance2D)
        {
            double distance = distance2D;
            return distance;
        }

        public static double CalcDiagonalYZ(double distance2D)
        {
            double distance = distance2D;
            return distance;
        }
    }
}
