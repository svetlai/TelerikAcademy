namespace ProgrammingLanguages
{
    using System;
    using System.IO;

    /// <summary>
    /// Problem 11. Programming Languages
    /// Perform a research (e.g. in Google or Wikipedia) and provide a short list with information about the most popular programming languages. 
    /// How similar are they to C#? How do they differ from C#?
    /// Write in a text file called “programming-languages.txt” at least five languages along with 2-3 sentences about each of them. Use English.
    /// </summary>
    public class ProgrammingLanguages
    {
        public static void Main()
        {
            const string FilePath = "../../programming-languages.txt";

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
