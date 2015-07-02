namespace IfStatements
{
    using System;

    public class MatrixIf
    {
        private const int MinX = 0;
        private const int MinY = 0;
        private const int MaxX = 100;
        private const int MaxY = 100;    

        public static void VisitCell(int x, int y)
        {
            if (CheckCell(x, y))
            {
                Console.WriteLine("Cell: {0}, {1} visited.", x, y);
            }
        }

        private static bool CheckCell(int x, int y)
        {
            bool shouldNotVisitCell = true;
            bool isValidCurrentX = x >= MinX && x <= MaxX;
            bool isValidCurrentY = y >= MinY && y <= MaxY;

            if (!(isValidCurrentX || isValidCurrentY))
            {
                shouldNotVisitCell = false;
            }

            return shouldNotVisitCell;
        }
    }
}
