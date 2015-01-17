namespace ExtractBitFromInteger
{
    using System;

    /// <summary>
    /// Problem 12.	Extract Bit from Integer
    /// Write an expression that extracts from given integer `n` the value of given bit at index `p`.
    /// Examples:
    /// |   n   | binary representation |  p  | bit @ p |
    /// |:-----:|:---------------------:|:---:|:-------:|
    /// | 5     | 00000000 00000101     | 2   | 1       |
    /// | 0     | 00000000 00000000     | 9   | 0       |
    /// | 15    | 00000000 00001111     | 1   | 1       |
    /// | 5343  | 00010100 11011111     | 7   | 1       |
    /// | 62241 | 11110011 00100001     | 11  | 0       |
    /// </summary>
    public class ExtractBitFromInteger
    {
        public static void Main()
        {
            Console.WriteLine("Problem 12.	Extract Bit from Integer \nWrite an expression that extracts from given integer `n` the value of given bit at index `p`.");

            // display examples
            int[] numbers = { 5, 0, 15, 5343, 62241 };
            int[] positions = { 2, 9, 1, 7, 11 };
           
            string binaryRepresentation;
            int bit;

            Console.WriteLine("{0,10} | {1,25} | {2,10} | {3,10}", "n", "binary representation", "p", "bit @ p");

            for (int i = 0; i < numbers.Length && i < positions.Length; i++)
            {
                binaryRepresentation = Convert.ToString(numbers[i], 2).PadLeft(16, '0');
                bit = ExtractNthBit(numbers[i], positions[i]);
                Console.WriteLine("{0,10} | {1,25} | {2,10} | {3,10}", numbers[i], binaryRepresentation, positions[i], bit);
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
                bit = ExtractNthBit(number, position);

                Console.WriteLine("{0,10} | {1,25} | {2,10} | {3,10}", number, binaryRepresentation, position, bit);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int ExtractNthBit(int number, int position)
        {
            int mask = 1 << position;
            int numberAndMask = number & mask;
            int bit = numberAndMask >> position;

            return bit;
        }
    }
}
