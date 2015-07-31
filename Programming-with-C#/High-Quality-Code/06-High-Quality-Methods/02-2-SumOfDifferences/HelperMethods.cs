namespace SumOfDifferences
{
    using System;

    public static class HelperMethods
    {
        public static string GetUserInput()
        {
            return Console.ReadLine();
        }

        public static decimal[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), decimal.Parse);
        }

        public static void PrintResult(decimal result)
        {
            Console.WriteLine(result);
        }
    }
}
