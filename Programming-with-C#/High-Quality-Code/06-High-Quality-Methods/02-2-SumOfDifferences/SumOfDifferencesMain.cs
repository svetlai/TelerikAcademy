namespace SumOfDifferences
{
    public class SumOfDifferencesMain
    {
        public static void Main()
        {
            string input = HelperMethods.GetUserInput();
            decimal result = SumOfDifferencesSolution.Solve(input);
            HelperMethods.PrintResult(result);
        }
    }
}