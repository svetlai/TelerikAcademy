namespace CohesionAndCoupling.Models
{
    using System;

    public class Object3DUtils : Utils
    {
        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance3D = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance3D;
        }

        public static double CalcDiagonalXYZ(double distance3D)
        {
            double distance = distance3D;
            return distance;
        }
    }
}
