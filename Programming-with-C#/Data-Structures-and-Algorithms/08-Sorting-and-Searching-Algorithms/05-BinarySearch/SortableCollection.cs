namespace BinarySearch
{
    using System.Collections.Generic;

    public class SortableCollection
    {
        public static int BinarySearch(List<int> numbers, int searchedValue)
        {
            int left = 0;
            int right = numbers.Count - 1;
            int mid = 0;

            while (left < right)
            {
                mid = left + (right - left) / 2;

                if (searchedValue == numbers[mid])
                {
                    return mid;
                }
                else if (searchedValue < numbers[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
    }
}
