namespace DefensiveProgramming
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class AssertionsHomework
    {
        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }

        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array cannot be null.");
            Debug.Assert(arr.Length > 0, "The array must have at least 1 element.");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array cannot be null.");
            Debug.Assert(value != null, "Value cannot be null.");

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array cannot be null.");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "The startIndex must be within the array.");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "The endIndex must be within the array.");
            Debug.Assert(startIndex <= endIndex, "Starting index must not be larger than endIndex.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    Debug.Assert(midIndex >= startIndex && midIndex <= endIndex, "midIndex must be between startIndex and endIndex");
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array cannot be null.");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "The startIndex must be within the array.");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "The endIndex must be within the array.");
            Debug.Assert(startIndex <= endIndex, "Starting index is must be smaller than endIndex.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(minElementIndex >= startIndex && minElementIndex <= endIndex, "minElementIndex must be between startIndex and endIndex");
            
            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "X cannot be null");
            Debug.Assert(y != null, "Y cannot be null");

            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}