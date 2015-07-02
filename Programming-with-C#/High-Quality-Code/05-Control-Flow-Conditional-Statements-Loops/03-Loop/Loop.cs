namespace ControlFlow
{
    using System;

    public class Loop
    {
        public static void Main()
        {
            int[] numbers = new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
            };

            int expectedValue = 11;
            FindValue(numbers, expectedValue);
        }

        public static void FindValue(int[] array, int expectedValue)
        {
            int divider = 10;

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);

                if ((i % divider == 0) && (array[i] == expectedValue))
                {
                    Console.WriteLine("Value Found");
                    break;
                }
            }
        }
    }
}
