namespace _9.IsoscelesTriangle
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 8. Isosceles Triangle
    /// Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
    ///    ©
    ///   © ©
    ///  ©   ©
    /// © © © ©
    /// Note: The © symbol may be displayed incorrectly at the console so you may need to change the console character encoding to UTF-8 and assign a Unicode-friendly font in the console.
    /// Note: Under old versions of Windows the © symbol may still be displayed incorrectly, regardless of how much effort you put to fix it.
    /// </summary>
    public class IsoscelesTriangle
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // using a simple string
            string triangle = @"   ©
  © ©
 ©   ©
© © © ©";

            Console.WriteLine(triangle);

            Console.WriteLine(new string('-', 40));

            char copyright = '\u00A9';
            int count = 9;

            // using loop for middle rows
            PrintTriangle(copyright, count, ' ');

            Console.WriteLine(new string('-', 40));

            // using nested loops for rows and cols
            PrintTriangle(copyright, count);

            Console.WriteLine(new string('-', 40));
        }

        public static void PrintTriangle(char symbol, int symbolsCount, char fill)
        {
            // symbolsCount = 1 + (totalRows - 2) * 2 + totalRows --> 1 on the first row, totalRows count on the last row and 2 symbols on every middle row
            int totalRows = (symbolsCount + 3) / 3;
            int fillCount = 1;
            string innerPadding;
            string leftPadding = new string(' ', totalRows - 1);

            // first row
            Console.WriteLine("{0}{1}", leftPadding, symbol);

            // middle rows
            for (int row = 1; row < totalRows - 1; row++)
            {
                leftPadding = new string(' ', totalRows - 1 - row);
                innerPadding = new string(fill, fillCount);

                Console.WriteLine("{0}{1}{2}{1}", leftPadding, symbol, innerPadding);
                fillCount += 2;
            }

            // last row
            for (int i = 0; i < totalRows; i++)
            {
                Console.Write("{0}{1}", symbol, ' ');
            }

            Console.WriteLine();
        }

        public static void PrintTriangle(char symbol, int symbolsCount)
        {
            int totalRows = (symbolsCount + 3) / 3;
            string leftPadding;

            for (int row = 1; row <= totalRows; row++)
            {
                leftPadding = new string(' ', totalRows - row);
                Console.Write(leftPadding);

                for (int col = 0; col < row; col++)
                {
                    if (row < totalRows)
                    {
                        if (col == (row - 1) || col == 0)
                        {
                            Console.Write("{0}{1}", symbol, ' ');
                        }
                        else
                        {
                            Console.Write("{0}{0}", ' ');
                        }
                    }
                    else
                    {
                        Console.Write("{0}{1}", symbol, ' ');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
