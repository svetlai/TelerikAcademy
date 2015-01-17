namespace BitsExchange
{
    using System;

    /// <summary>
    /// Problem 15.* Bits Exchange
    /// Write a program that exchanges bits `3`, `4` and `5` with bits `24`, `25` and `26` of given 32-bit unsigned integer.
    /// Examples:
    /// |      n     |      binary representation of n     |            binary result            |   result   |
    /// |:----------:|:-----------------------------------:|:-----------------------------------:|:----------:|
    /// | 1140867093 | 01000100 00000000 01000000 00010101 | 01000010 00000000 01000000 00100101 | 1107312677 |
    /// | 255406592  | 00001111 00111001 00110010 00000000 | 00001000 00111001 00110010 00111000 | 137966136  |
    /// | 4294901775 | 11111111 11111111 00000000 00001111 | 11111001 11111111 00000000 00111111 | 4194238527 |
    /// | 5351       | 00000000 00000000 00010100 11100111 | 00000100 00000000 00010100 11000111 | 67114183   |
    /// | 2369124121 | 10001101 00110101 11110111 00011001 | 10001011 00110101 11110111 00101001 | 2335569705 |
    /// </summary>
    public class BitsExchange
    {
        public static void Main()
        {
            Console.WriteLine("Problem 15.* Bits Exchange \nWrite a program that exchanges bits `3`, `4` and `5` with bits `24`, `25` and `26` of given 32-bit unsigned integer.");

            Console.WindowWidth = 100;

            // display examples
            uint[] numbers = { 1140867093, 255406592, 4294901775, 5351, 2369124121 };

            byte bit3;
            byte bit24;
            byte bit4;
            byte bit25;
            byte bit5;
            byte bit26;

            string binaryRepresentation;
            uint newNumber;
            string binaryRepresentationNewNumber;

            Console.WriteLine("{0,10} | {1,35} | {2,35} | {3,10}", "n", "binary representation of n", "binary result", "result");

            for (int i = 0; i < numbers.Length; i++)
            {
                binaryRepresentation = Convert.ToString(numbers[i], 2).PadLeft(32, '0');

                bit3 = GetNthBit(numbers[i], 3);
                bit24 = GetNthBit(numbers[i], 24);
                bit4 = GetNthBit(numbers[i], 4);
                bit25 = GetNthBit(numbers[i], 25);
                bit5 = GetNthBit(numbers[i], 5);
                bit26 = GetNthBit(numbers[i], 26);

                newNumber = ExchangeBits(numbers[i], bit3, bit24, 3, 24);
                newNumber = ExchangeBits(newNumber, bit4, bit25, 4, 25);
                newNumber = ExchangeBits(newNumber, bit5, bit26, 5, 26);

                binaryRepresentationNewNumber = Convert.ToString(newNumber, 2).PadLeft(32, '0');

                Console.WriteLine("{0,10} | {1,35} | {2,35} | {3,10}", numbers[i], binaryRepresentation, binaryRepresentationNewNumber, newNumber);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.WriteLine("Try it Yourself!");

            try
            {
                Console.Write("Enter integer: ");
                uint number = uint.Parse(Console.ReadLine());
                binaryRepresentation = Convert.ToString(number, 2).PadLeft(32, '0');

                bit3 = GetNthBit(number, 3);
                bit24 = GetNthBit(number, 24);
                bit4 = GetNthBit(number, 4);
                bit25 = GetNthBit(number, 25);
                bit5 = GetNthBit(number, 5);
                bit26 = GetNthBit(number, 26);

                newNumber = ExchangeBits(number, bit3, bit24, 3, 24);
                newNumber = ExchangeBits(newNumber, bit4, bit25, 4, 25);
                newNumber = ExchangeBits(newNumber, bit5, bit26, 5, 26);

                binaryRepresentationNewNumber = Convert.ToString(newNumber, 2).PadLeft(32, '0');

                Console.WriteLine("{0,10} | {1,35} | {2,35} | {3,10}", number, binaryRepresentation, binaryRepresentationNewNumber, newNumber);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static byte GetNthBit(uint number, int position)
        {
            // shift 1 to the position we need
            int mask = 1 << position;

            // we & with 1 and get the bit: 1&0 -> 0; 1&1 -> 1;
            uint numberAndMask = (uint)(number & mask);

            // shift back to bit 0
            byte bit = (byte)(numberAndMask >> position);

            return bit;
        }

        public static uint ExchangeBits(uint number, byte firstBit, byte secondBit, int firstBitPosition, int secondBitPosition)
        {
            // if bits are the same, we get 0, if not, we get 1
            int firstXorSecond = firstBit ^ secondBit;

            // if we xor with 0, then bits are the same and nothing will change 0^0 -> 0; 1^0 -> 1; 
            // if we xor with 1 -> 0^1 -> 1; 1^1 -> 0, so they'll change;
            number = (uint)(number ^ (firstXorSecond << secondBitPosition));
            number = (uint)(number ^ (firstXorSecond << firstBitPosition));

            return number;
        }
    }
}
