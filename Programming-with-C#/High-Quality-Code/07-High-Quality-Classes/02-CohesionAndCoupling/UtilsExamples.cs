namespace CohesionAndCoupling
{
    using System;

    using CohesionAndCoupling.Models;

    public class UtilsExamples
    {
        public static void Main()
        {
            TestFilenameUtils();
            TestDimensionUtils();
        }

        public static void TestFilenameUtils() 
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));
        }

        public static void TestDimensionUtils()
        {
            Console.WriteLine("Distance in the 2D space = {0:f2}", Object2DUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Object3DUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Utils.Width = 3;
            Utils.Height = 4;
            Utils.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", Object3DUtils.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Object3DUtils.CalcDiagonalXYZ(Object3DUtils.CalcDistance3D(5, 2, -1, 3, -6, 4)));
            Console.WriteLine("Diagonal XY = {0:f2}", Object2DUtils.CalcDiagonalXY(Object2DUtils.CalcDistance2D(1, -2, 3, 4)));
            Console.WriteLine("Diagonal XZ = {0:f2}", Object2DUtils.CalcDiagonalXZ(Object2DUtils.CalcDistance2D(5, 2, -6, 4)));
            Console.WriteLine("Diagonal YZ = {0:f2}", Object2DUtils.CalcDiagonalYZ(Object2DUtils.CalcDistance2D(-1, 3, -6, 4)));
        }
    }
}
