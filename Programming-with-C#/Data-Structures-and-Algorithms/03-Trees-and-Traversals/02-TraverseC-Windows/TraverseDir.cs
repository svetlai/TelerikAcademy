namespace TraverseCWindows
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// 2. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display 
    /// all files matching the mask *.exe. Use the class System.IO.Directory.
    /// </summary>
    public class TraverseDir
    {
        public static void Main()
        {
            List<string> files = new List<string>();

            //NOTE: I've changed the path since not all folders in C:\WINDOWS are accessible. This one will show all exe files in my homework solution directory.
            string directoryPathString = @"../../../";
            string fileExtension = "*.exe";

            TraverseDirectory(files, directoryPathString, fileExtension);
            foreach (var file in files)
            {
                Console.WriteLine(file.ToString());
            }
        }

        /// <summary>
        /// Source: http://support.microsoft.com/kb/303974
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void TraverseDirectory(List<string> files, string directoryPath, string fileExtension)
        {
            string[] directories = Directory.GetDirectories(directoryPath);

            foreach (var directory in directories)
            {
                files.AddRange(Directory.GetFiles(directory, fileExtension));
                TraverseDirectory(files, directory, fileExtension);
            }
        }
    }
}
