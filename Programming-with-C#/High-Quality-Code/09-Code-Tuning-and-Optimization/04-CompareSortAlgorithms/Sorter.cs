namespace CodeTuning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Sorter
    {
        public static void QuickSort<T>(T[] toSort, int left, int right) where T : IComparable
        {
            int i = left;
            int j = right;
            T pivot = toSort[(left + right) / 2];

            while (i <= j)
            {
                while (toSort[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (toSort[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // swap
                    T temp = toSort[i];
                    toSort[i] = toSort[j];
                    toSort[j] = temp;

                    i++;
                    j--;
                }
            }

            // recursive calls
            if (left < j)
            {
                QuickSort(toSort, left, j);
            }

            if (i < right)
            {
                QuickSort(toSort, i, right);
            }
        }

        public static void SelectionSort<T>(T[] toSort) where T : IComparable
        {
            for (int i = 0; i < toSort.Length - 1; i++)
            {
                // set position of min to the current index of array
                int positionOfMin = i;

                for (int j = i + 1; j < toSort.Length; j++)
                {
                    if (toSort[positionOfMin].CompareTo(toSort[j]) > 0)
                    {
                        // position of min will keep track of the index that min is in, this is needed when a swap happens
                        positionOfMin = j;
                    }
                }

                // if position of min no longer equals i than a smaller value must have been found, so a swap must occur
                if (positionOfMin != i)
                {
                    T temp = toSort[i];
                    toSort[i] = toSort[positionOfMin];
                    toSort[positionOfMin] = temp;
                }
            }
        }

        public static void InsertionSort<T>(T[] toSort) where T : IComparable
        {
            for (int i = 1; i < toSort.Length; i++)
            {
                T index = toSort[i];
                int j = i;
                while ((j > 0) && (toSort[j - 1].CompareTo(index) > 0))
                {
                    toSort[j] = toSort[j - 1];
                    j = j - 1;
                }

                toSort[j] = index;
            }
        }
    }
}
