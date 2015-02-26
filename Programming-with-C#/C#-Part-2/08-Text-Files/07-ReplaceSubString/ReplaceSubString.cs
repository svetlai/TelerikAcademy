namespace ReplaceSubString
{
    using System;
    using System.IO;

    /// <summary>
    /// Problem 7. Replace sub-string
    /// Write a program that replaces all occurrences of the sub-string `start` with the sub-string `finish` in a text file.
    /// Ensure it will work with large files (e.g. `100 MB`).
    /// </summary>
    public class ReplaceSubString
    {
        public static void Main()
        {
            string inputPath = "../../to-replace.txt";
            string outputPath = "../../replaced.txt";

            string sub = "start";
            string replace = "finish";

            ReplaceSubstringInFile(sub, replace, inputPath, outputPath);
        }

        public static void ReplaceSubstringInFile(string substring, string replace, string inputPath, string outputPath)
        {
            try
            {
                var reader = new StreamReader(inputPath);
                using (reader)
                {
                    string line = reader.ReadLine();

                    var writer = new StreamWriter(outputPath);
                    using (writer)
                    {
                        while (line != null)
                        {
                            while (line.IndexOf(substring) > -1)    // add .ToLower() for case-insensitive
                            {
                                line = line.Replace(substring, replace);
                            }

                            writer.WriteLine(line);
                            line = reader.ReadLine();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("File was written successfully at {0}.", new FileInfo(outputPath).FullName);
        }
    }
}
