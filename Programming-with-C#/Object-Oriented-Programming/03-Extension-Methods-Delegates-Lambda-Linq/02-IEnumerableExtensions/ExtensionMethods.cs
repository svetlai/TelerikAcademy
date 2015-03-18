namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ExtensionMethods
    {
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            T sum = default(T);

            foreach (var item in collection)
            {
                sum += item;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            T product = 1;

            foreach (var item in collection)
            {
                product *= item;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> collection)
        {
            T min = decimal.MaxValue;

            foreach (var item in collection)
            {
                min = item < min ? item : min;
            }

            return (T)min;
        }

        public static T Max<T>(this IEnumerable<T> collection)
        {
            T max = decimal.MinValue;

            foreach (var item in collection)
            {
                max = item > max ? item : max;
            }

            return (T)max;
        }

        public static T Average<T>(this IEnumerable<T> collection)
        {
            T sum = default(T);
            int count = 0;

            foreach (var item in collection)
            {
                count++;
                sum += item;
            }

            return (T)(sum / count);
        }

        public static string ToStringExtended<T>(this IEnumerable<T> collection)
        {
            return string.Join(", ", collection);
        }
    }
}
