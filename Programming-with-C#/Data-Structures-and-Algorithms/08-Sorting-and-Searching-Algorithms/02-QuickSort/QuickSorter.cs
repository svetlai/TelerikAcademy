namespace QuickSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class QuickSorter
    {
        public static void Sort(List<int> numbers, int left, int right)
        {
            if (numbers == null || numbers.Count <= 1)
            {
                return;
            }

            if (left < right)
            {
                int pivotIndex = Partition(numbers, left, right);

                if (pivotIndex > 1)
                {
                    Sort(numbers, left, pivotIndex - 1);
                }

                if (pivotIndex + 1 < right)
                {
                    Sort(numbers, pivotIndex + 1, right);
                }
            }
        }

        private static int Partition(List<int> numbers, int left, int right)
        {
            int pivot = numbers[left];

            while (true)
            {
                while (numbers[left] < pivot)
                {
                    left++;
                }

                while (numbers[right] > pivot)
                {
                    right--;
                }

                if (numbers[right] == pivot && numbers[left] == pivot)
                {
                    left++;
                }

                if (left < right)
                {
                    int swap = numbers[left];
                    numbers[left] = numbers[right];
                    numbers[right] = swap;
                }
                else
                {
                    return right;
                }
            }

        }
    }
}
