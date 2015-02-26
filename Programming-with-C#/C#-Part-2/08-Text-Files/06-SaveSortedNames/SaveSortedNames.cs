namespace SaveSortedNames
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Problem 6. Save sorted names
    /// Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
    /// Example:
    /// |  input.txt | output.txt |
    /// |:----------:|:----------:|
    /// | Ivan <br> Peter <br> Maria <br> George | George <br> Ivan <br> Maria <br> Peter |
    /// </summary>
    public class SaveSortedNames
    {
        public static void Main()
        {
            Console.WriteLine("Problem 6. Save sorted names \nWrite a program that reads a text file containing a list of strings, sorts them and saves them to another text file.\n");

            string inputPath = "../../names.txt";
            string outputPath = "../../sorted.txt";

            SortNamesInFile(inputPath, outputPath);
        }

        public static void SortNamesInFile(string inputPath, string outputPath)
        {
            var names = new List<string>();

            var reader = new StreamReader(inputPath);
            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    names.Add(line);
                    line = reader.ReadLine();
                }
            }

            names.Sort();

            var writer = new StreamWriter(outputPath, true);
            using (writer)
            {
                foreach (var name in names)
                {
                    writer.WriteLine(name);
                }
            }

            Console.WriteLine("File was written successfully at {0}.", new FileInfo(outputPath).FullName);
        }
    }
}
