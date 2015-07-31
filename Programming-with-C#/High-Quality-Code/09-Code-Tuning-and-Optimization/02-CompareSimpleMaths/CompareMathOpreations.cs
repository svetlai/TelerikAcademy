namespace CodeTuning
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class CompareMathOpreations
    {
        public static void Main()
        {
            CompareOperations();
        }

        private static void CompareOperations()
        {
            var testResults = new StringBuilder();

            // int
            testResults.AppendLine("For 1 000 000 operations:");
            testResults.AppendLine("Tests for int");
            testResults.AppendLine("Add: " + MeasureTime(() => Calculator.Add(1, 2)));
            testResults.AppendLine("Subtract: " + MeasureTime(() => Calculator.Subtract(1, 2)));
            testResults.AppendLine("Increment: " + MeasureTime(() => Calculator.Increment(1)));
            testResults.AppendLine("Multiply: " + MeasureTime(() => Calculator.Multiply(1, 2)));
            testResults.AppendLine("Divide: " + MeasureTime(() => Calculator.Divide(1, 2)));
            testResults.AppendLine("----------");

            // long
            testResults.AppendLine("Tests for long");
            testResults.AppendLine("Add: " + MeasureTime(() => Calculator.Add(1L, 2L)));
            testResults.AppendLine("Subtract: " + MeasureTime(() => Calculator.Subtract(1L, 2L)));
            testResults.AppendLine("Increment: " + MeasureTime(() => Calculator.Increment(1L)));
            testResults.AppendLine("Multiply: " + MeasureTime(() => Calculator.Multiply(1L, 2L)));
            testResults.AppendLine("Divide: " + MeasureTime(() => Calculator.Divide(1L, 2L)));
            testResults.AppendLine("----------");

            // float
            testResults.AppendLine("Tests for float");
            testResults.AppendLine("Add: " + MeasureTime(() => Calculator.Add(0.1f, 0.2f)));
            testResults.AppendLine("Subtract: " + MeasureTime(() => Calculator.Subtract(0.1f, 0.2f)));
            testResults.AppendLine("Increment: " + MeasureTime(() => Calculator.Increment(0.1f)));
            testResults.AppendLine("Multiply: " + MeasureTime(() => Calculator.Multiply(0.1f, 0.2f)));
            testResults.AppendLine("Divide: " + MeasureTime(() => Calculator.Divide(0.1f, 0.2f)));
            testResults.AppendLine("----------");

            // double
            testResults.AppendLine("Tests for double");
            testResults.AppendLine("Add: " + MeasureTime(() => Calculator.Add(0.1, 0.2)));
            testResults.AppendLine("Subtract: " + MeasureTime(() => Calculator.Subtract(0.1, 0.2)));
            testResults.AppendLine("Increment: " + MeasureTime(() => Calculator.Increment(0.1)));
            testResults.AppendLine("Multiply: " + MeasureTime(() => Calculator.Multiply(0.1, 0.2)));
            testResults.AppendLine("Divide: " + MeasureTime(() => Calculator.Divide(0.1, 0.2)));
            testResults.AppendLine("----------");

            // decimal
            testResults.AppendLine("Tests for decimal");
            testResults.AppendLine("Add: " + MeasureTime(() => Calculator.Add(0.1m, 0.2m)));
            testResults.AppendLine("Subtract: " + MeasureTime(() => Calculator.Subtract(0.1m, 0.2m)));
            testResults.AppendLine("Increment: " + MeasureTime(() => Calculator.Increment(0.1m)));
            testResults.AppendLine("Multiply: " + MeasureTime(() => Calculator.Multiply(0.1m, 0.2m)));
            testResults.AppendLine("Divide: " + MeasureTime(() => Calculator.Divide(0.1m, 0.2m)));
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
