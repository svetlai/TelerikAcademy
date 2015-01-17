namespace DevelopmentEnvironments
{
    using System;
    using System.IO;

    /// <summary>
    /// Problem 12. Development Environments
    /// Perform a research (e.g. in Google or Wikipedia) and provide a short list with popular development environments (IDEs) like Visual Studio.
    /// Write in a text file called “list-of-IDEs.txt” at least five IDEs along with 2-3 sentences about each of them. Use English.
    /// </summary>
    public class DevelopmentEnvironments
    {
        public static void Main()
        {
            const string FilePath = "../../list-of-IDEs.txt";

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
