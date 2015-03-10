namespace Point3DStruct
{
    using System;

    public static class Point3DHelper
    {
        public static double CalculateDistance(Point3D first, Point3D second)
        {
            // http://en.wikipedia.org/wiki/Euclidean_distance
            double distance = Math.Sqrt(
                ((first.X - second.X) * (first.X - second.X)) 
                + ((first.Y - second.Y) * (first.Y - second.Y))
                + ((first.Z - second.Z) * (first.Z - second.Z)));

            return distance;
        }
    }
}
