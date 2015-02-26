namespace LineNumbers
{
    using System;
    using System.IO;

    /// <summary>
    /// Problem 3. Line numbers
    /// Write a program that reads a text file and inserts line numbers in front of each of its lines.
    /// The result should be written to another text file.
    /// </summary>
    public class LineNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 3. Line numbers \nWrite a program that reads a text file and inserts line numbers in front of each of its lines. \nThe result should be written to another text file.\n");

            string inputPath = "../../joke.txt";
            string outputPath = "../../with-lines.txt";

            InsertLineNumbersIntoTextFile(inputPath, outputPath);
        }

        public static void InsertLineNumbersIntoTextFile(string inputPath, string outputPath)
        {
            var reader = new StreamReader(inputPath);
            try
            {
                using (reader)
                {
                    int lineIndex = 1;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        var writer = new StreamWriter(outputPath, true);
                        using (writer)
                        {
                            writer.WriteLine("{0}. {1}", lineIndex, line);
                        }

                        lineIndex++;
                        line = reader.ReadLine();
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
