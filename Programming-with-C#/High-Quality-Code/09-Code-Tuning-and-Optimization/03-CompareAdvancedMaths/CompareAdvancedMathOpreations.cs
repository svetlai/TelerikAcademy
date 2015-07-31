namespace CodeTuning
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class CompareAdvancedMathOpreations
    {
        public static void Main()
        {
            CompareOperations();
        }

        private static void CompareOperations()
        {
            var testResults = new StringBuilder();

            testResults.AppendLine("For 1 000 000 operations:");

            // float
            testResults.AppendLine("Tests for float");
            testResults.AppendLine("Add: " + MeasureTime(() => Calculator.SqureRoot(4.0f)));
            testResults.AppendLine("Subtract: " + MeasureTime(() => Calculator.NaturalLogarithm(3.1f)));
            testResults.AppendLine("Increment: " + MeasureTime(() => Calculator.Sinus(3.1f)));
            testResults.AppendLine("----------");

            // double
            testResults.AppendLine("Tests for double");
            testResults.AppendLine("Add: " + MeasureTime(() => Calculator.SqureRoot(4.0)));
            testResults.AppendLine("Subtract: " + MeasureTime(() => Calculator.NaturalLogarithm(3.1)));
            testResults.AppendLine("Increment: " + MeasureTime(() => Calculator.Sinus(3.1)));
            testResults.AppendLine("----------");

            // decimal
            testResults.AppendLine("Tests for decimal");
            testResults.AppendLine("Add: " + MeasureTime(() => Calculator.SqureRoot(4.0m)));
            testResults.AppendLine("Subtract: " + MeasureTime(() => Calculator.NaturalLogarithm(3.1m)));
            testResults.AppendLine("Increment: " + MeasureTime(() => Calculator.Sinus(3.1m)));
            testResults.AppendLine("----------");

            Console.WriteLine(testResults.ToString());
        }

        private static string MeasureTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                action();
            }

            stopwatch.Stop();

            var time = stopwatch.Elapsed;

            return "Total time used: " + time;
        }
    }
}
