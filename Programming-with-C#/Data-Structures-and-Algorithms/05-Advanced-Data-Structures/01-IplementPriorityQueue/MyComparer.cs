namespace IplementPriorityQueue
{
    using System.Collections.Generic;

    class MyComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            // "inverted" comparison
            // direct comparison of integers should return x - y
            return y - x;
        }
    }

}
