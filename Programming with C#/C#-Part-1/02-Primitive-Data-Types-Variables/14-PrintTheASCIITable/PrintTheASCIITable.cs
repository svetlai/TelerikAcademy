namespace PrintTheASCIITable
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 14.* Print the ASCII Table
    /// Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).
    /// Note: Some characters have a special purpose and will not be displayed as expected. You may skip them or display them differently.
    /// Note: You may need to use for-loops (learn in Internet how).
    /// </summary>
    public class PrintTheASCIITable
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            int asciiSymbolsCount = 255;
            char currentSymbol;

            for (int i = 0; i <= asciiSymbolsCount; i++)
            {
                currentSymbol = (char)i;

                if (char.IsControl(currentSymbol))
                {
                    Console.WriteLine("{0} --> control ", i);
                }
                else
                {
                    Console.WriteLine("{0} --> {1} ", i, currentSymbol);
                }
            }
        }
    }
}
