namespace CodeTuning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RandomGenerator
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static Random random = new Random();

        public static string GetRandomString(int length)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int index = GetRandomNumberInRange(0, Alphabet.Length - 1);
                sb.Append(Alphabet[index]);
            }

            return sb.ToString();
        }

        public static int GetRandomNumberInRange(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public static int[] GetRandomIntArray(int elementsCount)
        {
            int[] array = new int[elementsCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }

            return array;
        }

        public static double[] GetRandomDoubleArray(int elementsCount)
        {
            double[] array = new double[elementsCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.NextDouble();
            }

            return array;
        }

        public static string[] GetRandomStringArray(int elementsCount)
        {
            string[] array = new string[elementsCount];

            for (int i = 0; i < array.Length; i++)
            {
                int stringLength = GetRandomNumberInRange(2, 10);
                array[i] = GetRandomString(stringLength);
            }

            return array;
        }
    }
}
