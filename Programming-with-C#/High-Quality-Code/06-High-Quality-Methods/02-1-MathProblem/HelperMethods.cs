namespace MathProblem
{
    using System;

    public static class HelperMethods
    {
        public static decimal Pow(int baseNumber, int power)
        {
            decimal result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= baseNumber;
            }

            return result;
        }

        public static string[] ReadInput()
        {
            return Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void PrintResult(string inNumeralSystem, int sum)
        {
            Console.WriteLine("{0} = {1}", inNumeralSystem, sum);
        }
    }
}
