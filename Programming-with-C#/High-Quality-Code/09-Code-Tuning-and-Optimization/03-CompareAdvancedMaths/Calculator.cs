namespace CodeTuning
{
    using System;

    public class Calculator
    {
        public static void SqureRoot(dynamic number)
        {
            var a = (double)number;
            var result = Math.Sqrt(a);
        }

        public static void NaturalLogarithm(dynamic number)
        {
            var a = (double)number;
            var result = Math.Log(a);
        }

        public static void Sinus(dynamic number)
        {
            var a = (double)number;
            var result = Math.Sin(a);
        }
    }
}
