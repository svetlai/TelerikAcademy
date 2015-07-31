namespace Methods.HelperMethods
{
    using System;

    public static class Printer
    {
        public static void PrintAsNumber(object number, string format)
        {
            double parsedNumber;

            if (!double.TryParse(number.ToString(), out parsedNumber))
            {
                throw new ArgumentException("Input number must be one of the numeric types.");
            }

            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentNullException("Format cannot be left blank.");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Unknown format: \"{0}\". Format must be \"f\", \"%\" or \"r\"", format);
            }
        }
    }
}
