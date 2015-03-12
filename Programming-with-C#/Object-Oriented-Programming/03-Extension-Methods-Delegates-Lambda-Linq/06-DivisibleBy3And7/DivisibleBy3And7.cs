namespace DivisibleBy3And7
{
    using System;
    using System.Linq;

    using Helper;

    /// <summary>
    /// Problem 6. Divisible by 7 and 3
    /// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. 
    /// Rewrite the same with LINQ.
    /// </summary>
    public class DivisibleBy3And7
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestDivisibleMethods();
        }

        public static int[] GetDivisibleByThreeAndSevenLambda(int[] numbers)
        {
            return numbers.Where(n => n % 21 == 0)
                .ToArray();
        }

        public static int[] GetDivisibleByThreeAndSevenLINQ(int[] numbers)
        {
            var divisible = from number in numbers
                            where number % 21 == 0
                            select number;

            return divisible.ToArray();
        }

        public static void TestDivisibleMethods()
        {
            int[] numbers = { 1, 2, 3, 7, 21, 35, 4 };

            var divisibleLambda = GetDivisibleByThreeAndSevenLambda(numbers);
            var divisibleLINQ = GetDivisibleByThreeAndSevenLINQ(numbers);

            Console.WriteLine("Numbers: {0}", string.Join(", ", numbers));
            Console.WriteLine("Using extension methods: {0}", string.Join(", ", divisibleLambda));
            Console.WriteLine("Using LiNQ: {0}", string.Join(", ", divisibleLINQ));
        }
    }
}
