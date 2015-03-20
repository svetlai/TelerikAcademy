namespace BinarySearchTreeImplementation
{
    using System;
    using System.Text;

    using Helper;

    public class BinarySearchTreeTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestBinarySearchTree();
        }

        private static void TestBinarySearchTree()
        {
            var sb = new StringBuilder();

            var tree = new BinarySearchTree<int>(15);

            for (int i = 0; i < 30; i++)
            {
                tree.Add(i);
            }

            var clonedNode = (TreeNode<int>)tree.Root.Clone();

            sb.AppendLine(tree.ToString())
                .AppendLine("Tree root: " + tree.Root.ToString())
                .AppendLine("Tree contains 7? " + tree.Contains(7).ToString())
                .AppendLine("Cloned root: " + clonedNode.ToString())
                .AppendLine("Cloned Equals root? " + (clonedNode.Equals(tree.Root)).ToString())
                .AppendLine("Cloned == root? " + (clonedNode == tree.Root).ToString())
                .AppendLine("Cloned != root? " + (clonedNode != tree.Root).ToString());

            Console.Write(sb.ToString());
        }
    }
}
