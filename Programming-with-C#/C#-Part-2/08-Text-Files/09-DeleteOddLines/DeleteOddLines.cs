namespace DeleteOddLines
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Problem 9. Delete odd lines
    /// Write a program that deletes from given text file all odd lines.
    /// The result should be in the same file.
    /// </summary>
    public class DeleteOddLines
    {
        public static void Main()
        {
            Console.WriteLine("Problem 9. Delete odd lines \nWrite a program that deletes from given text file all odd lines. \nThe result should be in the same file.\n");
           
            string path = "../../odd-lines.txt";

            RemoveOddLines(path);
        }

        public static void RemoveOddLines(string path)
        {
            var contents = File.ReadAllLines(path).ToList();

            contents = contents
                .Select((l, i) => new { l, i })
                .Where(x => (x.i + 1) % 2 == 0)
                .Select(x => x.l).ToList();

            File.WriteAllLines(path, contents.ToArray());

            Console.WriteLine("File was written successfully at {0}.", new FileInfo(path).FullName);
        }
    }
}
