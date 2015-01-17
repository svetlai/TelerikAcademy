namespace ExtractBitThree
{
    using System;
    using System.Collections;

    /// <summary>
    /// Problem 11.	Bitwise: Extract Bit #3
    /// Using bitwise operators, write an expression for finding the value of the bit `#3` of a given unsigned integer.
    /// The bits are counted from right to left, starting from bit `#0`.
    /// The result of the expression should be either `1` or `0`.
    /// Examples:
    /// |   n   | binary representation | bit #3 |
    /// |:-----:|:---------------------:|:------:|
    /// | 5     | 00000000 00000101     | 0      |
    /// | 0     | 00000000 00000000     | 0      |
    /// | 15    | 00000000 00001111     | 1      |
    /// | 5343  | 00010100 11011111     | 1      |
    /// | 62241 | 11110011 00100001     | 0      |
    /// </summary>
    public class ExtractBitThree
    {
        public static void Main()
        {
            Console.WriteLine("Problem 11.	Bitwise: Extract Bit #3 \nUsing bitwise operators, write an expression for finding the value of the bit `#3` of a given unsigned integer. The bits are counted from right to left, starting from bit `#0`. The result of the expression should be either `1` or `0`.");

            // display examples
            int[] numbers = { 5, 0, 15, 5343, 62241 };
            int position = 3;

            string binaryRepresentation;
            byte thirdBit;

            Console.WriteLine("{0,10} | {1,25} | {2,10}", "n", "binary representation", "bit #3");

            for (int i = 0; i < numbers.Length; i++)
            {
                binaryRepresentation = Convert.ToString(numbers[i], 2).PadLeft(16, '0');
                thirdBit = ExtractNthBit(numbers[i], position);
                Console.WriteLine("{0,10} | {1,25} | {2,10}", numbers[i], binaryRepresentation, thirdBit);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.Write("Try it Yourself! \nEnter a positive integer number: ");

            string line = Console.ReadLine();

            while (line != string.Empty)
            {
                try
                {
                    uint input = uint.Parse(line);
                    binaryRepresentation = Convert.ToString(input, 2).PadLeft(16, '0');

                    Console.WriteLine("{0,10} | {1,25} | {2,10}", input, binaryRepresentation, ExtractNthBit((int)input, position));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("Enter a positive integer number: ");
                line = Console.ReadLine();
            }
        }

        public static byte ExtractNthBit(int number, int position)
        {
            int mask = 1 << position;        // 00000000 00100000
            int numberAndMask = number & mask;  // 00000000 00100000
            int bit = numberAndMask >> position;  // 00000000 00000001

            if (bit == 1)
            {
                return 1;
            }

            return 0;
        }
    }
}
