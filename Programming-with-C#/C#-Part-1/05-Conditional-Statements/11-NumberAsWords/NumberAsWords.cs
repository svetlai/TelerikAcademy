namespace NumberAsWords
{
    using System;
    using System.Text;

    /// <summary>
    /// 11. Problem 11.* Number as Words
    /// Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.
    /// Examples:
    /// numbers	number as words
    /// 0	Zero
    /// 9	Nine
    /// 10	Ten
    /// 12	Twelve
    /// 19	Nineteen
    /// 25	Twenty five
    /// 98	Ninety eight
    /// 98	Ninety eight
    /// 273	Two hundred and seventy three
    /// 400	Four hundred
    /// 501	Five hundred and one
    /// 617	Six hundred and seventeen
    /// 711	Seven hundred and eleven
    /// 999	Nine hundred and ninety nine
    /// </summary>
    public class NumberAsWords
    {
        public static void Main()
        {
            Console.WriteLine("11. Problem 11.* Number as Words \nWrite a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.\n");

            Console.Write("Enter a number between 0 and 999: ");
            string line = Console.ReadLine();

            while (line != string.Empty)
            {
                int number;
                if (!int.TryParse(line, out number))
                {
                    Console.WriteLine("Invalid format."); // throw new FormatException();
                    return;
                }
                else
                {
                    Console.WriteLine(GetNumberName(number));
                }

                Console.Write("Enter a number between 0 and 999: ");
                line = Console.ReadLine();
            }
        }

        /// <summary>
        /// Returns a string with a single digit's name
        /// </summary>
        /// <param name="digit">A digit between 0 and 9</param>
        /// <returns>A string with a single digit's name</returns>
        public static string GetDigitName(int digit)
        {
            var digName = string.Empty;

            switch (digit)
            {
                case 0: 
                    digName = "Zero"; 
                    break;
                case 1: 
                    digName = "One"; 
                    break;
                case 2: 
                    digName = "Two"; 
                    break;
                case 3: 
                    digName = "Three"; 
                    break;
                case 4: 
                    digName = "Four"; 
                    break;
                case 5: 
                    digName = "Five"; 
                    break;
                case 6: 
                    digName = "Six"; 
                    break;
                case 7: 
                    digName = "Seven"; 
                    break;
                case 8: 
                    digName = "Eight"; 
                    break;
                case 9: 
                    digName = "Nine"; 
                    break;
            }

            return digName;
        }

        /// <summary>
        /// Returns a string with the name of a number between 0 and 999
        /// </summary>
        /// <param name="number">An integer number between 0 and 999</param>
        /// <returns>String with number name</returns>
        public static string GetNumberName(int number)
        {
            StringBuilder sb = new StringBuilder();

            if (number > 999 || number < 0)
            {
                throw new ArgumentException("Number must be between 0 and 999.");
            }

            // separate digits for the ones, the tens and the hundreds
            int digit1 = number % 10;
            int digit10 = (number / 10) % 10;
            int digit100 = (number / 100) % 10;

            // 0 - 9
            if (digit10 == 0 && digit100 == 0)
            {
                sb.Append(GetDigitName(digit1));
                // Console.Write(GetDigitName(digit1));
            }

            // hundreds
            if (digit100 != 0)
            {
                sb.Append(GetDigitName(digit100) + " Hundred ");
                // Console.Write(GetDigitName(digit100) + " Hundred ");

                if (digit1 != 0 || digit10 != 0)
                {
                    sb.Append("and ");
                    // Console.Write("and ");
                }
            }

            // tens
            if (digit10 != 0)
            {
                if (digit10 == 1)
                {
                    // 10 - 19
                    switch (digit1)
                    {
                        case 0:
                            sb.Append("Ten");
                            //Console.Write("Ten"); 
                            break;
                        case 1:
                            sb.Append("Eleven");
                            //Console.Write("Eleven"); 
                            break;
                        case 2:
                            sb.Append("Twelve");
                            //Console.Write("Twelve"); 
                            break;
                        case 3:
                            sb.Append("Thirteen");
                            //Console.Write("Thirteen"); 
                            break;
                        case 5:
                            sb.Append("Fifteen");
                            //Console.Write("Fifteen"); 
                            break;
                        case 8:
                            sb.Append("Eighteen");
                            //Console.Write("Eighteen"); 
                            break;
                        default:
                            sb.Append(GetDigitName(digit1) + "teen");
                            //Console.Write(GetDigitName(digit1) + "teen"); 
                            break;
                    }
                }
                else
                {
                    // 20-90
                    switch (digit10)
                    {
                        case 2:
                            sb.Append("Twenty");
                            //Console.Write("Twenty"); 
                            break;
                        case 3:
                            sb.Append("Thirty");
                            //Console.Write("Thirty"); 
                            break;
                        case 5:
                            sb.Append("Fifty");
                            //Console.Write("Fifty"); 
                            break;
                        case 8:
                            sb.Append("Eighty");
                            //Console.Write("Eighty"); 
                            break;
                        default:
                            sb.Append(GetDigitName(digit10) + "ty");
                            //Console.Write(GetDigitName(digit10) + "ty"); 
                            break;
                    }
                }
            }

            // adds last digit if over 20
            if (digit1 != 0 && digit10 != 1 && digit100 != 0
                || digit1 != 0 && digit10 != 1 && digit10 != 0)
            {
                sb.Append(string.Format(" {0}", GetDigitName(digit1)));
                //Console.Write(" {0}", GetDigitName(digit1));
            }

            return sb.ToString();
        }
    }
}
