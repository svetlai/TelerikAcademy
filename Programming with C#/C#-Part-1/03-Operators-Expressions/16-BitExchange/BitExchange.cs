namespace BitExchange
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 16.** Bit Exchange (Advanced)
    /// Write a program that exchanges bits `{p, p+1, ..., p+k-1}` with bits `{q, q+1, ..., q+k-1}` of a given 32-bit unsigned integer.
    /// The first and the second sequence of bits may not overlap.
    /// Examples:
    /// | n           |   p  |  q  |  k |      binary representation of n     | binary result                       | result       |
    /// |:-----------:|:----:|:---:|:--:|:-----------------------------------:|-------------------------------------|--------------|
    /// | 1140867093  | 3    | 24  | 3  | 01000100 00000000 01000000 00010101 | 01000010 00000000 01000000 00100101 | 1107312677   |
    /// | 4294901775  | 24   | 3   | 3  | 11111111 11111111 00000000 00001111 | 11111001 11111111 00000000 00111111 | 4194238527   |
    /// | 2369124121  | 2    | 22  | 10 | 10001101 00110101 11110111 00011001 | 01110001 10110101 11111000 11010001 | 1907751121   |
    /// | 987654321   | 2    | 8   | 11 | -                                   | -                                   | overlapping  |
    /// | 123456789   | 26   | 0   | 7  | -                                   | -                                   | out of range |
    /// | 33333333333 | -1   | 0   | 33 | -                                   | -                                   | out of range |
    /// </summary>
    public class BitExchange
    {
        private const int NumberOfIntBits = 32;

        public static void Main()
        {
            Console.WriteLine("Problem 16.** Bit Exchange (Advanced) \nWrite a program that exchanges bits `{p, p+1, ..., p+k-1}` with bits `{q, q+1, ..., q+k-1}` of a given 32-bit unsigned integer. The first and the second sequence of bits may not overlap.");

            Console.WindowWidth = 150;

            ulong[] numbers = { 1140867093, 4294901775, 2369124121, 987654321, 123456789, 33333333333 };
            int[] p = { 3, 24, 2, 2, 26, -1 };
            int[] q = { 24, 3, 22, 8, 0, 0 };
            int[] k = { 3, 3, 10, 11, 7, 33 };

            string binaryRepresentation;
            string newNumberAsString;
            ulong newNumber;
            string binaryRepresentationNewNumber;

            Console.WriteLine("{0,15} | {1,5} | {2,5} | {3,5} | {4,35} | {5,35} | {6,10}", "n", "p", "q", "k", "binary representation of n", "binary result", "result");

            for (int i = 0; i < numbers.Length && i < p.Length && i < q.Length && i < k.Length; i++)
            {
                binaryRepresentation = UlongToBinary(numbers[i]); // Convert.ToString((long)numbers[i], 2).PadLeft(numberOfIntBits, '0');

                newNumberAsString = ExchangeBits(numbers[i], p[i], q[i], k[i]);

                if (!ulong.TryParse(newNumberAsString, out newNumber))
                {
                    binaryRepresentationNewNumber = "--";
                }
                else
                {
                    binaryRepresentationNewNumber = UlongToBinary(newNumber);
                }

                Console.WriteLine("{0,15} | {1,5} | {2,5} | {3,5} | {4,35} | {5,35} | {6,10}", numbers[i], p[i], q[i], k[i], binaryRepresentation, binaryRepresentationNewNumber, newNumberAsString);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.WriteLine("Try it Yourself!");

            try
            {
                Console.Write("Enter integer:");
                ulong number = ulong.Parse(Console.ReadLine());
                
                binaryRepresentation = UlongToBinary(number);

                Console.Write("Enter position p (between 0 & {0}):", NumberOfIntBits - 1);
                int firstBitPosition = int.Parse(Console.ReadLine());

                Console.Write("Enter position q (between 0 & {0}):", NumberOfIntBits - 1);
                int secondBitPosition = int.Parse(Console.ReadLine());

                Console.Write("Enter number of bits to be changed (k):");
                int numberOfBitsToChange = int.Parse(Console.ReadLine());

                newNumberAsString = ExchangeBits(number, firstBitPosition, secondBitPosition, numberOfBitsToChange);
                
                if (!ulong.TryParse(newNumberAsString, out newNumber))
                {
                    binaryRepresentationNewNumber = "--";
                }
                else
                {
                    binaryRepresentationNewNumber = UlongToBinary(newNumber);
                }

                Console.WriteLine("{0,15} | {1,5} | {2,5} | {3,5} | {4,35} | {5,35} | {6,10}", number, firstBitPosition, secondBitPosition, numberOfBitsToChange, binaryRepresentation, binaryRepresentationNewNumber, newNumberAsString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static byte GetNthBit(ulong number, int position)
        {
            // shift 1 to the position we need
            int mask = 1 << position;

            // we & with 1 and get the bit: 1&0 -> 0; 1&1 -> 1;
            ulong numberAndMask = number & (ulong)mask;

            // shift back to bit 0
            byte bit = (byte)(numberAndMask >> position);

            return bit;
        }

        public static string ExchangeBits(ulong number, int firstBitPosition, int secondBitPosition, int numberOfBitsToChange)
        {
            if (firstBitPosition < 0 || firstBitPosition > NumberOfIntBits - 1 || secondBitPosition < 0 || secondBitPosition > NumberOfIntBits - 1
                || firstBitPosition + numberOfBitsToChange > NumberOfIntBits - 1 || secondBitPosition + numberOfBitsToChange > NumberOfIntBits - 1)
            {
                return "out of range";
            }

            if (firstBitPosition < secondBitPosition && (firstBitPosition + numberOfBitsToChange) >= secondBitPosition
                || firstBitPosition > secondBitPosition && (secondBitPosition + numberOfBitsToChange) >= firstBitPosition)
            {
                return "overlapping";
            }

            byte firstBit;
            byte secondBit;

            for (int i = 0; i < numberOfBitsToChange; i++)
            {
                firstBit = GetNthBit(number, firstBitPosition);
                secondBit = GetNthBit(number, secondBitPosition);

                // if bits are the same, we get 0, if not, we get 1
                int firstXorSecond = firstBit ^ secondBit;

                // if we xor with 0, then bits are the same and nothing will change 0^0 -> 0; 1^0 -> 1; 
                // if we xor with 1 -> 0^1 -> 1; 1^1 -> 0, so they'll change;
                number = number ^ (ulong)(firstXorSecond << secondBitPosition);
                number = number ^ (ulong)(firstXorSecond << firstBitPosition);

                firstBitPosition++;
                secondBitPosition++;
            }

            return number.ToString();
        }

        /// <summary>
        /// Converts an unsigned long number to a binary string
        /// </summary>
        /// <param name="number"></param>
        /// <returns>String with the number's binary value</returns>
        protected static string UlongToBinary(ulong number)
        {
            int ulongsize = sizeof(ulong) * 4;
            StringBuilder sb = new StringBuilder(ulongsize);

            for (int i = 0; i < ulongsize; i++)
            {
                sb.Insert(0, number & 0x1);
                number >>= 1;
            }

            return sb.ToString();
        }
    }
}
