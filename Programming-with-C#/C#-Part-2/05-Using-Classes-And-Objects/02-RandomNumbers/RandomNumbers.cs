namespace RandomNumbers
{
    using System;

    /// <summary>
    /// Problem 2. Random numbers
    /// Write a program that generates and prints to the console `10` random values in the range [`100, 200`].
    /// </summary>
    public class RandomNumbers
    {
        private static Random random = new Random();

        public static void Main()
        {
            Console.WriteLine("Problem 2. Random numbers \nWrite a program that generates and prints to the console `10` random values in the range [`100, 200`].");
            
            const int RandomCount = 10;

            int min = 100;
            int max = 200;

            for (int i = 0; i < RandomCount; i++)
            {
                int randomNumber = GenerateRandomInteger(min, max);
                Console.WriteLine(randomNumber);
            }
        }

        public static int GenerateRandomInteger(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
