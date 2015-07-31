namespace CodeTuning
{
    public class Calculator
    {
        public static void Add(dynamic firstNumber, dynamic secondNumber)
        {
            var a = firstNumber;
            var b = secondNumber;
            var result = a + b;
        }

        public static void Subtract(dynamic firstNumber, dynamic secondNumber)
        {
            var a = firstNumber;
            var b = secondNumber;
            var result = a - b;
        }

        public static void Increment(dynamic firstNumber)
        {
            var a = firstNumber;
            var result = a++;
        }

        public static void Multiply(dynamic firstNumber, dynamic secondNumber)
        {
            var a = firstNumber;
            var b = secondNumber;
            var result = a * b;
        }

        public static void Divide(dynamic firstNumber, dynamic secondNumber)
        {
            var a = firstNumber;
            var b = secondNumber;
            var result = a / b;
        }
    }
}
