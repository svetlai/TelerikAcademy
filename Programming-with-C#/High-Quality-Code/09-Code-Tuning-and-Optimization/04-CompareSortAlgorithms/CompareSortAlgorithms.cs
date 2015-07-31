namespace CodeTuning
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class CompareSortAlgorithms
    {
        public static void Main()
        {
            CompareAlgorithms();
        }

        private static void CompareAlgorithms()
        {
            var testResults = new StringBuilder();
            int length = 1000;
            int[] intArray = RandomGenerator.GetRandomIntArray(length);
            double[] doubleArray = RandomGenerator.GetRandomDoubleArray(length);
            string[] stringArray = RandomGenerator.GetRandomStringArray(length);

            testResults.AppendLine(string.Format("For {0} elements:", length));

            // int
            testResults.AppendLine("Tests for int");
            testResults.AppendLine("QuickSort: " + MeasureTime(() => Sorter.QuickSort<int>(intArray.Clone() as int[], 0, intArray.Length - 1)));
            testResults.AppendLine("SelectionSort: " + MeasureTime(() => Sorter.SelectionSort<int>(intArray.Clone() as int[])));
            testResults.AppendLine("InsertionSort: " + MeasureTime(() => Sorter.InsertionSort<int>(intArray.Clone() as int[])));
            testResults.AppendLine("----------");

            // double
            testResults.AppendLine("Tests for double");
            testResults.AppendLine("QuickSort: " + MeasureTime(() => Sorter.QuickSort<double>(doubleArray.Clone() as double[], 0, doubleArray.Length - 1)));
            testResults.AppendLine("SelectionSort: " + MeasureTime(() => Sorter.SelectionSort<double>(doubleArray.Clone() as double[])));
            testResults.AppendLine("InsertionSort: " + MeasureTime(() => Sorter.InsertionSort<double>(doubleArray.Clone() as double[])));
            testResults.AppendLine("----------");

            // string
            testResults.AppendLine("Tests for string");
            testResults.AppendLine("QuickSort: " + MeasureTime(() => Sorter.QuickSort<string>(stringArray.Clone() as string[], 0, stringArray.Length - 1)));
            testResults.AppendLine("SelectionSort: " + MeasureTime(() => Sorter.SelectionSort<string>(stringArray.Clone() as string[])));
            testResults.AppendLine("InsertionSort: " + MeasureTime(() => Sorter.InsertionSort<string>(stringArray.Clone() as string[])));
            testResults.AppendLine("----------");

            Array.Sort(intArray);

            // sorted
            testResults.AppendLine("Tests for sorted");
            testResults.AppendLine("QuickSort: " + MeasureTime(() => Sorter.QuickSort(intArray, 0, intArray.Length - 1)));
            testResults.AppendLine("SelectionSort: " + MeasureTime(() => Sorter.SelectionSort(intArray)));
            testResults.AppendLine("InsertionSort: " + MeasureTime(() => Sorter.InsertionSort(intArray)));
            testResults.AppendLine("----------");

            Array.Reverse(intArray);

            // reversed
            testResults.AppendLine("Tests for sorted in reversed order");
            testResults.AppendLine("QuickSort: " + MeasureTime(() => Sorter.QuickSort<int>(intArray, 0, intArray.Length - 1)));
            testResults.AppendLine("SelectionSort: " + MeasureTime(() => Sorter.SelectionSort(intArray)));
            testResults.AppendLine("InsertionSort: " + MeasureTime(() => Sorter.InsertionSort(intArray)));
            testResults.AppendLine("----------");

            Console.WriteLine(testResults.ToString());
        }
        
        private static string MeasureTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            action();

            stopwatch.Stop();

            var time = stopwatch.Elapsed;

            return "Total time used: " + time;
        }
    }
}
