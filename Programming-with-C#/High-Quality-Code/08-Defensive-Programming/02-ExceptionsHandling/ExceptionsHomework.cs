namespace DefensiveProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DefensiveProgramming.Contracts;

    public class ExceptionsHomework
    {
        public static void Main()
        {
            try
            {
                var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 4, 2);
                Console.WriteLine(string.Join(" ", subarr));

                var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 1, 4);
                Console.WriteLine(string.Join(" ", allarr));

                var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(string.Join(" ", emptyarr));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine(ExtractEnding("I love C#", 2));
                Console.WriteLine(ExtractEnding("Nakov", 4));
                Console.WriteLine(ExtractEnding("beer", 4));
                Console.WriteLine(ExtractEnding("Hi", 100));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                int number = 0;
                Console.WriteLine("{0} is prime? {1}", number, CheckPrime(number));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            List<IExam> peterExams = new List<IExam>()
            {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);

            try
            {
                double peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr.Length == 0 || arr == null)
            {
                throw new ArgumentException("The given array has no elements or is null.");
            }

            if (startIndex < 0 || startIndex >= arr.Length)
            {
                throw new ArgumentOutOfRangeException("Start index must be within the array.");
            }

            if (count > arr.Length || count + startIndex > arr.Length)
            {
                throw new ArgumentException("The sum of startIndex and count cannot exceed the array length.");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException("The given string is either empty or null.");
            }

            if (count < 0 || count > str.Length)
            {
                throw new ArgumentOutOfRangeException("Count must be between 0 and the string length.");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            if (number < 1 || number > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The number must be between 1 and int.MaxValue.");
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
