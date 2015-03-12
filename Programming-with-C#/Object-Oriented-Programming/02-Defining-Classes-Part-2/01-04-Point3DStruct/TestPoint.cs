namespace Point3DStruct
{
    using System;
    using System.IO;

    using Helper;

    /// <summary>
    /// Problem 1. Structure
    ///   Create a structure `Point3D` to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
    ///   Implement the `ToString()` to enable printing a 3D point.
    /// Problem 2. Static read-only field
    ///   Add a `private static read-only` field to hold the start of the coordinate system – the point O{0, 0, 0}.
    ///   Add a static property to return the point O.
    /// Problem 3. Static class
    ///   Write a `static class` with a `static method` to calculate the distance between two points in the 3D space.
    /// Problem 4. Path
    ///   Create a class `Path` to hold a sequence of points in the 3D space.
    ///   Create a static class `PathStorage` with static methods to save and load paths from a text file.
    ///   Use a file format of your choice.
    /// </summary>
    public class TestPoint
    {
        private const string PathToFile = "../../points.txt";

        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            Path path3D = CreateNewPath();

            SavePathToFile(path3D);

            Path pathFromFile = LoadPathFromFile();

            Console.Write("Path from file:\n{0}", pathFromFile.ToString());
        }

        private static Path CreateNewPath()
        {
            Path path = new Path();

            path.Add(Point3D.O);
            path.Add(new Point3D(1, 1, 1));
            path.Add(new Point3D(2, 2, 2));

            return path;
        }

        private static void SavePathToFile(Path path)
        {
            try
            {
                var writer = new StreamWriter(PathToFile);
                PathStorage.SavePath(path, writer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Path saved successfully.");
        }

        private static Path LoadPathFromFile()
        {
            Path pathFromFile = new Path();
            try
            {
                var reader = new StreamReader(PathToFile);
                pathFromFile = PathStorage.LoadPath(reader);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return pathFromFile;
        }
    }
}
