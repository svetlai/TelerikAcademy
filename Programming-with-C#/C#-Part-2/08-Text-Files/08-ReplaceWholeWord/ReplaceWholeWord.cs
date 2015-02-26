namespace ReplaceWholeWord
{
    using System;
    using System.IO;

    /// <summary>
    /// Problem 8. Replace whole word
    /// Modify the solution of the previous problem to replace only **whole words** (not strings).
    /// </summary>
    public class ReplaceWholeWord
    {
        public static void Main()
        {
            Console.WriteLine("Problem 8. Replace whole word \nModify the solution of the previous problem to replace only **whole words** (not strings).\n");
            
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
                            int substringIndex = line.IndexOf(substring);
                            while (substringIndex > -1)    // add .ToLower() for case-insensitive
                            {
                                int prevIndex = substringIndex - 1;
                                int nextIndex = substringIndex + substring.Length;

                                if (prevIndex > -1 && !char.IsLetter(line[prevIndex]) && nextIndex < line.Length && !char.IsLetter(line[nextIndex])
                                    || prevIndex == -1 && nextIndex < line.Length && !char.IsLetter(line[nextIndex])
                                    || prevIndex > -1 && !char.IsLetter(line[prevIndex]) && nextIndex == line.Length
                                    || prevIndex == -1 && nextIndex == line.Length)
                                {
                                    line = line.Replace(substring, replace);
                                }

                                substringIndex = line.IndexOf(substring);
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
