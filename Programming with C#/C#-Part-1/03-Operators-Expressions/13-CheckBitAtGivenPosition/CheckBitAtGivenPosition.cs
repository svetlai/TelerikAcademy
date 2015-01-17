namespace CheckBitAtGivenPosition
{
    using System;

    /// <summary>
    /// Problem 13.	Check a Bit at Given Position
    /// Write a Boolean expression that returns if the bit at position `p` (counting from `0`, starting from the right) in given integer number `n`, has value of 1.
    /// Examples:
    /// |   n   | binary representation of n |  p  | bit @ p == 1 |
    /// |:-----:|:--------------------------:|:---:|:------------:|
    /// | 5     | 00000000 00000101          | 2   | true         |
    /// | 0     | 00000000 00000000          | 9   | false        |
    /// | 15    | 00000000 00001111          | 1   | true         |
    /// | 5343  | 00010100 11011111          | 7   | true         |
    /// | 62241 | 11110011 00100001          | 11  | false        |
    /// </summary>
    public class CheckBitAtGivenPosition
    {
        public static void Main()
        {
            Console.WriteLine("Problem 13.	Check a Bit at Given Position \nWrite a Boolean expression that returns if the bit at position `p` (counting from `0`, starting from the right) in given integer number `n`, has value of 1.");

            // display examples
            int[] numbers = { 5, 0, 15, 5343, 62241 };
            int[] positions = { 2, 9, 1, 7, 11 };

            string binaryRepresentation;
            bool isBitOne;

            Console.WriteLine("{0,10} | {1,25} | {2,10} | {3,10}", "n", "binary representation", "p", "bit @ p");

            for (int i = 0; i < numbers.Length && i < positions.Length; i++)
            {
                binaryRepresentation = Convert.ToString(numbers[i], 2).PadLeft(16, '0');
                isBitOne = IsNthBitOne(numbers[i], positions[i]);

                Console.WriteLine("{0,10} | {1,25} | {2,10} | {3,10}", numbers[i], binaryRepresentation, positions[i], isBitOne);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.WriteLine("Try it Yourself!");

            try
            {
                Console.Write("Enter integer: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Enter bit position: ");
                int position = int.Parse(Console.ReadLine());

                binaryRepresentation = Convert.ToString(number, 2).PadLeft(16, '0');
                isBitOne = IsNthBitOne(number, position);

                Console.WriteLine("{0,10} | {1,25} | {2,10} | {3,10}", number, binaryRepresentation, position, isBitOne);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static bool IsNthBitOne(int number, int position)
        {
            int mask = 1 << position;
            int numberAndMask = number & mask;
            int bit = numberAndMask >> position;

            if (bit == 1)
            {
                return true;
            }

            return false;
        }
    }
}
