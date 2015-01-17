namespace ModifyBitAtGivenPosition
{
    using System;

    /// <summary>
    /// Problem 14.	Modify a Bit at Given Position
    /// We are given an integer number `n`, a bit value `v` (v=0 or 1) and a position `p`.
    /// Write a sequence of operators (a few lines of C# code) that modifies `n` to hold the value `v` at the position `p` from the binary representation of `n` while preserving all other bits in `n`.
    /// Examples:
    /// |   n   | binary representation of n |  p  | v |   binary result   | result |
    /// |:-----:|:--------------------------:|:---:|:-:|:-----------------:|--------|
    /// | 5     | 00000000 00000101          | 2   | 0 | 00000000 00000001 | 1      |
    /// | 0     | 00000000 00000000          | 9   | 1 | 00000010 00000000 | 512    |
    /// | 15    | 00000000 00001111          | 1   | 1 | 00000000 00001111 | 15     |
    /// | 5343  | 00010100 11011111          | 7   | 0 | 00010100 01011111 | 5215   |
    /// | 62241 | 11110011 00100001          | 11  | 0 | 11110011 00100001 | 62241  |
    /// </summary>
    public class ModifyBitAtGivenPosition
    {
        public static void Main()
        {
            Console.WriteLine("Problem 14.	Modify a Bit at Given Position \nWe are given an integer number `n`, a bit value `v` (v=0 or 1) and a position `p`. Write a sequence of operators (a few lines of C# code) that modifies `n` to hold the value `v` at the position `p` from the binary representation of `n` while preserving all other bits in `n`.");

            Console.WindowWidth = 100;

            // display examples
            int[] numbers = { 5, 0, 15, 5343, 62241 };
            int[] positions = { 2, 9, 1, 7, 11 };
            int[] bitValues = { 0, 1, 1, 0, 0 };

            string binaryRepresentation;
            int newNumber;
            string binaryRepresentationNewNumber;

            Console.WriteLine("{0,10} | {1,25} | {2,5} | {3,5} | {4,20} | {5,10}", "n", "binary representation", "p", "v", "binary result", "result");

            for (int i = 0; i < numbers.Length && i < positions.Length && i < bitValues.Length; i++)
            {
                binaryRepresentation = Convert.ToString(numbers[i], 2).PadLeft(16, '0');
                newNumber = SetBitAtNthPosition(numbers[i], positions[i], bitValues[i]);
                binaryRepresentationNewNumber = Convert.ToString(newNumber, 2).PadLeft(16, '0');

                Console.WriteLine("{0,10} | {1,25} | {2,5} | {3,5} | {4,20} | {5,10}", numbers[i], binaryRepresentation, positions[i], bitValues[i], binaryRepresentationNewNumber, newNumber);
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

                Console.Write("Enter bit value: ");
                int bitValue = int.Parse(Console.ReadLine());

                binaryRepresentation = Convert.ToString(number, 2).PadLeft(16, '0');

                newNumber = SetBitAtNthPosition(number, position, bitValue);
                binaryRepresentationNewNumber = Convert.ToString(newNumber, 2).PadLeft(16, '0');

                Console.WriteLine("{0,10} | {1,25} | {2,5} | {3,5} | {4,20} | {5,10}", number, binaryRepresentation, position, bitValue, binaryRepresentationNewNumber, newNumber);         
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int SetBitAtNthPosition(int number, int position, int bitValue)
        {
            int mask;
            int result;

            if (bitValue > 1 || bitValue < 0)
            {
                throw new ArgumentException("Bit value must be either 0 or 1.");
            }

            if (bitValue == 0)
            {
                mask = ~(1 << position);
                result = number & mask;
            }
            else
            {
                mask = 1 << position;
                result = number | mask;
            }

            return result;
        }
    }
}
