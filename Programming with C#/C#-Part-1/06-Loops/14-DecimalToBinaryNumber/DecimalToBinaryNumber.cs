namespace DecimalToBinaryNumber
{
    using System;

    /// <summary>
    /// Problem 14. Decimal to Binary Number
    /// Using loops write a program that converts an integer number to its binary representation.
    /// The input is entered as long. The output should be a variable of type string.
    /// Do not use the built-in .NET functionality.
    /// Examples:
    /// decimal	binary
    /// 0	0
    /// 3	11
    /// 43691	1010101010101011
    /// 236476736	1110000110000101100101000000
    /// </summary>
    public class DecimalToBinaryNumber
    {
        public static void Main()
        {
            Console.WriteLine("Problem 14. Decimal to Binary Number \nUsing loops write a program that converts an integer number to its binary representation. \nThe input is entered as long. The output should be a variable of type string. \nDo not use the built-in .NET functionality.\n");
            
            Console.Write("Please enter a decimal integer number: ");

            long asDecimal;
            if (!long.TryParse(Console.ReadLine(), out asDecimal))
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            string result = string.Empty;
            
            // decimal to binary: 
            // 5 = 5 / 2 = 2 reminder 1; 
            // 2 / 2 = 1 reminder 0; 
            // 1 / 2 = 0 reminder 1 = 101 (reversed);
            while (asDecimal > 0)
            {
                result += asDecimal % 2;
                asDecimal = asDecimal / 2;
            }

            // reverse result
            char[] binary = result.ToCharArray();
            Array.Reverse(binary);
            result = new string(binary);
            
            Console.WriteLine("Binary: {0}", result);
        }
    }
}
