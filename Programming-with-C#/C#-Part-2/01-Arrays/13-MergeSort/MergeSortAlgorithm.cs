namespace MergeSortAlgorithm
{
    using System;

    /// <summary>
    /// Problem 13.* Merge sort
    /// Write a program that sorts an array of integers using the [Merge sort](http://en.wikipedia.org/wiki/Merge_sort) algorithm.
    /// </summary>
    public class MergeSortAlgorithm
    {
        public static void Main()
        {
            DisplayExample();
        }

        public static void MergeSort(int[] toSort, int startIndex, int endIndex)
        {
            int mid;

            if (endIndex > startIndex)
            {
                mid = (endIndex + startIndex) / 2;
                MergeSort(toSort, startIndex, mid);
                MergeSort(toSort, mid + 1, endIndex);
                Merge(toSort, startIndex, mid + 1, endIndex);
            }
        }

        private static void Merge(int[] toSort, int left, int mid, int right)
        {
            // Merge procedure takes O(n) time
            int[] temp = new int[toSort.Length];
            int leftEnd = mid - 1;
            int currentPosition = left;
            int lengthOfInput = right - left + 1;

            // selecting smaller element from left sorted array or right sorted array and placing them in temp array.
            while ((left <= leftEnd) && (mid <= right))
            {
                if (toSort[left] <= toSort[mid])
                {
                    temp[currentPosition] = toSort[left];
                    currentPosition++;
                    left++;
                }
                else
                {
                    temp[currentPosition] = toSort[mid];
                    currentPosition++;
                    mid++;
                }
            }

            // placing remaining element in temp from left sorted array
            while (left <= leftEnd)
            {
                temp[currentPosition] = toSort[left];
                currentPosition++;
                left++;
            }

            // placing remaining element in temp from right sorted array
            while (mid <= right)
            {
                temp[currentPosition] = toSort[mid];
                currentPosition++;
                mid++;
            }

            // placing temp array to toSort
            for (int i = 0; i < lengthOfInput; i++)
            {
                toSort[right] = temp[right];
                right--;
            }
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        private static void DisplayExample()
        {
            Console.WriteLine("Problem 13.* Merge sort \nWrite a program that sorts an array of integers using the [Merge sort](http://en.wikipedia.org/wiki/Merge_sort) algorithm.\n");

            Console.Write("Enter a sequence of integer numbers separated by space: ");

            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());
            MergeSort(input, 0, input.Length - 1);

            string border = new string('-', 60);

            Console.WriteLine(border);
            Console.WriteLine("{0,30}", "sorted");
            Console.WriteLine("{0,30}", string.Join(" ", input));
            Console.WriteLine(border);
        }
    }
}
