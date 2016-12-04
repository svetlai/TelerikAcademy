namespace SelectionSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class SelectionSorter
    {
        public static void Sort(List<int> numbers)
        {
            int n = numbers.Count;
            
            for (int i = 0; i < n; i++)
            {
                int minIndex = i;
                for (int j = 0; j < n; j++)
                {
                    //use < for descending order
                    if (numbers[j] > numbers[minIndex])
                    {
                        minIndex = j;
                        int swap = numbers[i];
                        numbers[i] = numbers[minIndex];
                        numbers[minIndex] = swap;
                    }
                }
            }
        }
    }
}
