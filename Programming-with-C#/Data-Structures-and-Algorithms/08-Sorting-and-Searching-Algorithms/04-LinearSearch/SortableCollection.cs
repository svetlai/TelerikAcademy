namespace LinearSearch
{
    using System.Collections.Generic;

    public class SortableCollection
    {
        public static int LinearSearch(List<int> numbers, int searchedValue)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (searchedValue == numbers[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
