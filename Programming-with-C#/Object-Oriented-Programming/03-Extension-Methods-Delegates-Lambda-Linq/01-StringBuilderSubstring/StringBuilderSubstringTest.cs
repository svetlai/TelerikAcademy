namespace StringBuilderSubstring
{
    using System;
    using System.Text;

    using Helper;

    /// <summary>
    /// Problem 1. StringBuilder.Substring
    /// Implement an extension method `Substring(int index, int length)` for the class `StringBuilder` that returns new `StringBuilder` and has the same functionality as `Substring` in the class `String`.
    /// </summary>
    public class StringBuilderSubstringTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestStringBuilderSubstring();
        }

        public static void TestStringBuilderSubstring()
        {
            var sb = new StringBuilder();

            sb.Append("Some random text.");
            Console.WriteLine(sb);

            sb = sb.Substring(5);
            Console.WriteLine(sb);

            sb = sb.Substring(0, 6);
            Console.WriteLine(sb);
        }
    }
}
