namespace GravitationOnTheMoon
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 2.	Gravitation on the Moon
    /// The gravitational field of the Moon is approximately `17%` of that on the Earth.
    /// Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
    /// Examples:
    /// | weight | weight on the Moon |
    /// |:------:|:------------------:|
    /// | 86     | 14.62              |
    /// | 74.6   | 12.682             |
    /// | 53.7   | 9.129              |
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // display examples
            double[] weights = { 86, 74.6, 53.7 };
            double moonWeight;

            Console.WriteLine("{0,10} | {1,10}", "weight", "weight on the Moon");

            for (int i = 0; i < weights.Length; i++)
            {
                moonWeight = CalculateWeightOnMoon(weights[i]);
                Console.WriteLine("{0,10} | {1,10}", weights[i], moonWeight);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.Write("Try it yourself! \nEnter weight: ");

            string line = Console.ReadLine();

            while (line != string.Empty)
            {
                try
                {
                    double input = double.Parse(line);
                    moonWeight = CalculateWeightOnMoon(input);

                    Console.WriteLine("{0} --> {1}", input, moonWeight);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("Enter weight: ");
                line = Console.ReadLine();
            }
        }

        /// <summary>
        /// Calculates a man's weight on the Moon
        /// </summary>
        /// <param name="weight">Double variable for a man's weight on Earth</param>
        /// <returns>Double - 17% of a man's weight on Earth</returns>
        public static double CalculateWeightOnMoon(double weight)
        {
            return weight * 17 / 100;
        }
    }
}
