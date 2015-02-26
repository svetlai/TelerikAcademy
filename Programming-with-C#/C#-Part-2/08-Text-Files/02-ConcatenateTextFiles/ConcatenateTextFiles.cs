namespace ConcatenateTextFiles
{
    using System;
    using System.IO;

    /// <summary>
    /// Problem 2. Concatenate text files
    /// Write a program that concatenates two text files into another text file.
    /// </summary>
    public class ConcatenateTextFiles
    {
        public static void Main()
        {
            Console.WriteLine("Problem 2. Concatenate text files \nWrite a program that concatenates two text files into another text file.\n");

            string filePathOutput = "../../concatenated.txt";
            string[] filePaths = 
            { 
                "../../joke.txt", 
                "../../another-joke.txt", 
            };

            ConcatenateFiles(filePaths, filePathOutput);
        }

        public static void ConcatenateFiles(string[] files, string filePathOutput)
        {
            try
            {
                using (var output = File.Create(filePathOutput))
                {
                    foreach (var filePath in files)
                    {
                        using (var input = File.OpenRead(filePath))
                        {
                            input.CopyTo(output);
                        }
                    }
                }

                Console.WriteLine("Files concatenated successfuly at {0}", new FileInfo(filePathOutput).FullName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
