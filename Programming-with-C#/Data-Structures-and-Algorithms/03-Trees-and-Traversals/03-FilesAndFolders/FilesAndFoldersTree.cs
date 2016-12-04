namespace FilesAndFolders
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// 3. Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } 
    /// and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. Implement 
    /// a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. 
    /// Use recursive DFS traversal.
    /// </summary>
    public class FilesAndFoldersTree
    {
        public static void Main()
        {
            //NOTE: I've changed the path since not all folders in C:\WINDOWS are accessible. This one will show all exe files in my homework solution directory.
            string directoryPathString = @"../../../";

            Folder root = CreateRootFolder(directoryPathString);

            CreateFileTree(root);

            PrintTree(root, "");
            Console.WriteLine();

            long sumFileSizesInRoot = SumFileSizes(root, 2);
            Console.WriteLine("Size of root subtree with depth of 2: {0}", sumFileSizesInRoot);
        }

        public static Folder CreateRootFolder(string directoryPath)
        {
            return new Folder(directoryPath);
        }

        public static void CreateFileTree(Folder rootFolder)
        {
            AddChildFoldersToDirectory(rootFolder);
            AddFilesToDirectory(rootFolder);

            for (int i = 0; i < rootFolder.ChildFolders.Length; i++)
            {
                Folder folder = rootFolder.ChildFolders[i];
                CreateFileTree(folder);
            }
        }

        private static void AddChildFoldersToDirectory(Folder directory)
        {
            List<Folder> directoryFolders = new List<Folder>();

            var folders = Directory.GetDirectories(directory.Name);

            foreach (var item in folders)
            {
                Folder folder = new Folder(item.ToString());
                directoryFolders.Add(folder);
            }

            directory.ChildFolders = directoryFolders.ToArray();
        }

        private static void AddFilesToDirectory(Folder directory)
        {
            List<File> directoryFiles = new List<File>();
            string[] files = Directory.GetFiles(directory.Name);

            foreach (var item in files)
            {
                var fileInfo = new FileInfo(item);
                long size = fileInfo.Length;

                File file = new File(item.ToString(), size);
                directoryFiles.Add(file);
            }

            directory.Files = directoryFiles.ToArray();
        }

        //DFS
        public static void PrintTree(Folder root, string spaces)
        {
            Console.WriteLine(spaces + root.Name);
            foreach (var folder in root.ChildFolders)
            {
                PrintTree(folder, spaces + " ");
            }

            foreach (var file in root.Files)
            {
                Console.WriteLine(spaces + " " + file.Name);
            }
        }

        public static long SumFileSizes(Folder root, int depth)
        {
            long sum = 0;
            foreach (var file in root.Files)
            {
                sum += file.Size;
            }

            if (depth == 0)
            {
                return sum;
            }

            foreach (var folder in root.ChildFolders)
            {
                sum += SumFileSizes(folder, depth - 1);
            }

            return sum;
        }
    }
}
