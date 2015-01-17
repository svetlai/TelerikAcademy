namespace CSharpAndDotNetDifferences
{
    using System;
    using System.IO;

    /// <summary>
    /// Problem 13. C# and .NET Differences
    /// Describe the difference between C# and .NET Framework in 2-3 sentences.
    /// Write your description in a text file called “csharp-and-dot-net-framework.txt”. Use English.
    /// </summary>
    public class CSharpAndDotNet
    {
        public static void Main()
        {
            const string FilePath = "../../csharp-and-dot-net-framework.txt";

            try
            {
                // read text from a file
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string fileContents = sr.ReadToEnd();
                    Console.WriteLine(fileContents);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
