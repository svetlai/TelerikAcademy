namespace MatrixClass
{
    public interface IMatrix
    {
        int Rows { get; }

        int Cols { get; }

        int this[int rowIndex, int colIndex] { get; set; }

        string ToString();
    }
}
