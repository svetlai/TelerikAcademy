namespace BishopPath
{
    using System.Collections.Generic;

    public class BishopPathMain
    {
        public static void Main()
        {
            long[,] matrix = HelperMethods.GetMatrix();
            List<string[]> moves = HelperMethods.GetMoves();

            long sum = BishopPathSolution.GetMovesSum(matrix, moves);
            HelperMethods.PrintResult(sum);
        }
    }
}