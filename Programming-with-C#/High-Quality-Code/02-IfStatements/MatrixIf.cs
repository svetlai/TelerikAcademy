namespace IfStatements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MatrixIf
    {
        private const int MIN_X = 0;
        private const int MIN_Y = 0;
        private const int MAX_X = 100;
        private const int MAX_Y = 100;

        private static bool CheckCell(int x, int y)
        {
            bool shouldNotVisitCell = true;
            bool isValidCurrentX = (x >= MIN_X && x <= MAX_X);
            bool isValidCurrentY = (y >= MIN_Y && y <= MAX_Y);

            if (!(isValidCurrentX || isValidCurrentY))
            {
                shouldNotVisitCell = false;
            }

            return shouldNotVisitCell;
        }

        public static void VisitCell(int x, int y)
        {
            if (CheckCell(x, y))
            {
                Console.WriteLine("Cell: {0}, {1} visited.", x, y);
            }
        }
    }
}
