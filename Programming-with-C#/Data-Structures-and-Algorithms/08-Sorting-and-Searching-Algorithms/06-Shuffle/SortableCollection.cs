namespace Shuffle
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection
    {
        static Random random = new Random();
        public static void Shuffle(List<int> numbers)
        {
            for (int i = numbers.Count; i > 1 ; i--)
            {
                int j = random.Next(i);
                int temp = numbers[j];
                numbers[j] = numbers[i - 1];
                numbers[i - 1] = temp;
            }
        }
    }
}
