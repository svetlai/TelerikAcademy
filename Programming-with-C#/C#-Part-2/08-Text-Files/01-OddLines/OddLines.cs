namespace OddLines
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Problem 1. Odd lines
    /// Write a program that reads a text file and prints on the console its odd lines.
    /// </summary>
    public class OddLines
    {
        public static void Main()
        {
            Console.WriteLine("Problem 1. Odd lines \nWrite a program that reads a text file and prints on the console its odd lines.\n");
            
            string path = "../../joke.txt";
            string text = GetOddLinesFromFile(path);

            Console.WriteLine(text);
        }

        public static string GetOddLinesFromFile(string path)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    int lineIndex = 1;
                    string line = reader.ReadLine();

                    while (line != null)
                    {                     
                        //if (lineIndex % 2 != 0)
                        //{
                            sb.AppendLine(line);
                        //}

                        lineIndex++;
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return sb.ToString();
        }
    }
}
