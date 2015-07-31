namespace Methods.HelperMethods
{
    using System;

    public static class MathHelper
    {
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("All sides must be positive.");
            }

            if ((sideA + sideB <= sideC) || (sideB + sideC <= sideA) || (sideA + sideC <= sideB))
            {
                throw new ArgumentException("The sum of any two triangle sides must be bigger than the third.");
            }

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - sideA) *
                (semiperimeter - sideB) * (semiperimeter - sideC));

            return area;
        }

        public static string ConvertDigitToString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("The input must be a an integer number between 0 and 9");
            }
        }

        public static int FindMaxInt(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Parameter cannot be null or empty!");
            }

            int max = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    max = elements[i];
                }
            }

            return max;
        }
    }
}
