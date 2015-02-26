namespace CompareTextFiles
{
    using System;
    using System.IO;

    /// <summary>
    /// Problem 4. Compare text files
    /// Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
    /// Assume the files have equal number of lines.
    /// </summary>
    public class CompareTextFiles
    {
        public static void Main()
        {
            Console.WriteLine("Problem 4. Compare text files \nWrite a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. \nAssume the files have equal number of lines.\n");

            string filePathFirst = "../../joke.txt";
            string filePathSecond = "../../another-joke.txt";

            int[] result = CompareTextFileLines(filePathFirst, filePathSecond);

            Console.WriteLine("The files have {0} equal lines and {1} different lines.", result[0], result[1]);
        }

        public static int[] CompareTextFileLines(string filePathFirst, string filePathSecond)
        {
            int countEqual = 0;
            int countDifferent = 0;

            try
            {
                var firstReader = new StreamReader(filePathFirst);
                using (firstReader)
                {
                    string lineFirst = firstReader.ReadLine();

                    var secondReader = new StreamReader(filePathSecond);
                    using (secondReader)
                    {
                        while (lineFirst != null)
                        {
                            string lineSecond = secondReader.ReadLine();

                            if (lineFirst.Equals(lineSecond))
                            {
                                countEqual++;
                            }
                            else
                            {
                                countDifferent++;
                            }

                            lineFirst = firstReader.ReadLine();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new int[] { countEqual, countDifferent };
        }
    }
}
