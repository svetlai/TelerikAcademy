namespace MathProblem
{
    public class MathProblemSolution
    {
        public static void Solve(string[] numbers)
        {
            int sum = Sum(numbers);
            string inNumeralSystem = NumeralSystemMethods.ConvertDecimalToNumeralSystem(sum);
            HelperMethods.PrintResult(inNumeralSystem, sum);
        }

        private static int Sum(string[] numbers)
        {
            int sum = 0;
            decimal inDecimal = 0;

            foreach (var number in numbers)
            {
                var numIn19th = NumeralSystemMethods.ConvertTo19th(number);
                inDecimal = NumeralSystemMethods.ConvertNumeralSystemToDecimal(19, numIn19th);
                sum += (int)inDecimal;
            }

            return sum;
        }
    }
}
