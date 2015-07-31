namespace Methods.HelperMethods
{
    using System;

    using Methods.Models;

    public static class PointHelper
    {
        public static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            double squareDistanceX = (secondPoint.X - firstPoint.X) * (secondPoint.X - firstPoint.X);
            double squareDistanceY = (secondPoint.Y - firstPoint.Y) * (secondPoint.Y - firstPoint.Y);
            double distance = Math.Sqrt(squareDistanceX + squareDistanceY);

            return distance;
        }

        public static DistanceType FindDistanceType(Point firstPoint, Point secondPoint)
        {
            DistanceType distanceType;

            if (firstPoint.Y == secondPoint.Y)
            {
                distanceType = DistanceType.Horizontal;
            }
            else if (firstPoint.X == secondPoint.X)
            {
                distanceType = DistanceType.Vertical;
            }
            else
            {
                distanceType = DistanceType.Other;
            }

            return distanceType;
        }
    }
}
