namespace MergeSort
{
    using System.Collections.Generic;

    public class MergeSorter
    {
        public static void Sort(List<int> numbers, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                Sort(numbers, left, mid);
                Sort(numbers, mid + 1, right);
                MergeArray(numbers, left, mid, right);
            }
        }

        private static void MergeArray(List<int> numbers, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];

            int i = left;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= right)
            {
                if (numbers[i] < numbers[j])
                {
                    temp[k] = numbers[i];
                    k++;
                    i++;
                }
                else
                {
                    temp[k] = numbers[j];
                    k++;
                    j++;
                }
            }

            while (i <= mid)
            {
                temp[k] = numbers[i];
                k++;
                i++;
            }

            while (j <= right)
            {
                temp[k] = numbers[j];
                k++;
                j++;
            }

            k = 0;
            i = left;

            while(k < temp.Length && i <= right)
            {
                numbers[i] = temp[k];
                i++;
                k++;
            }
        }
    }
}
