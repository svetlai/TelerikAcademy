namespace MathProblem
{
    using System.Collections.Generic;
    using System.Text;

    public static class NumeralSystemMethods
    {
        private const string NumeralSystemDigits = "abcdefghijklmnopqrs";
        private const int NumeralSystemBase = 19;

        public static List<int> ConvertTo19th(string numeralSystemNumber)
        {
            var result = new List<int>();
            StringBuilder currentDigit = new StringBuilder();

            for (int i = 0; i < numeralSystemNumber.Length; i++)
            {
                currentDigit.Append(numeralSystemNumber[i]);

                if (NumeralSystemDigits.Contains(currentDigit.ToString()))
                {
                    int index = NumeralSystemDigits.IndexOf(currentDigit.ToString());
                    result.Add(index);
                    currentDigit.Clear();
                }
            }

            return result;
        }

        public static decimal ConvertNumeralSystemToDecimal(int baseOfSystem, List<int> number)
        {
            decimal result = 0;
            for (int i = number.Count - 1, j = 0; i >= 0 && j < number.Count; i--, j++)
            {
                int index = number[i];
                result += index * HelperMethods.Pow(baseOfSystem, j);
            }

            return result;
        }

        public static string ConvertDecimalToNumeralSystem(int decimalNumber)
        {
            StringBuilder sb = new StringBuilder();

            do
            {
                decimal reminder = decimalNumber % NumeralSystemBase;
                sb.Insert(0, NumeralSystemDigits[(int)reminder]);
                decimalNumber = decimalNumber / NumeralSystemBase;
            }
            while (decimalNumber != 0);

            return sb.ToString();
        }
    }
}
