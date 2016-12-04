namespace ReadTree
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 1. You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), 
    /// each in the range (0..N-1). Example:
    /*
7
2 4
3 2
5 0
3 5
5 6
5 1
    */
    /// </summary>
    public class FindNodes
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var nodes = new List<Node<int>>(N);

            for (int i = 0; i < N; i++)
            {
                nodes.Add(new Node<int>(i));
            }

            for (int i = 1; i < N; i++)
            {
                string pairOfNodes = Console.ReadLine();
                var nodesPairParts = pairOfNodes.Split(' ');

                int parentId = int.Parse(nodesPairParts[0]);
                int childId = int.Parse(nodesPairParts[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            //1. Find the root node

            var root = FindTreeRoot(nodes);
            Console.WriteLine("Tree root: {0}", root.Value);

            //2. Find all leaf nodes

            var leaves = FindTreeLeaves(nodes);

            foreach (var leaf in leaves)
            {
                Console.WriteLine("Tree leaf: {0}", leaf.Value);
            }

            //3. Find all middle nodes

            var middleNodes = FindMiddleNodes(nodes);

            foreach (var node in middleNodes)
            {
                Console.WriteLine("Tree middle node: {0}", node.Value);
            }

            //4. Find the longest path in the tree

            int longestPath = FindLongestPath(root);
            Console.WriteLine("Longest path in tree: {0}", longestPath);

            //5.* Find all paths in the tree with given sum S of their nodes

            const int sum = 6;
            TraverseTree(root, sum);

            //Console.WriteLine("Path with sum {0}: {1}", sum, sumPath);

            //6.* Find all subtrees with given sum S of their nodes
        }

        public static Node<int> FindTreeRoot(List<Node<int>> nodes)
        {
            if (nodes.Count == 0)
            {
                throw new ArgumentNullException("The tree has no nodes.");
            }

            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentNullException("The tree has no root.");
        }

        public static List<Node<int>> FindTreeLeaves(List<Node<int>> nodes)
        {
            var leaves = new List<Node<int>>();

            if (nodes.Count == 0)
            {
                throw new ArgumentNullException("The tree has no nodes.");
            }

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leaves.Add(node);
                }
            }

            return leaves;
        }

        public static List<Node<int>> FindMiddleNodes(List<Node<int>> nodes)
        {
            var middleNodes = new List<Node<int>>();

            if (nodes.Count == 0)
            {
                throw new ArgumentNullException("The tree has no nodes.");
            }

            foreach (var node in nodes)
            {
                if (node.Children.Count > 0 && node.HasParent == true)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        public static int FindLongestPath(Node<int> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("The tree has no nodes.");
            }

            if (root.Children.Count == 0)
            {
                return 0;
            }

            int longestPath = 0;

            foreach (var node in root.Children)
            {
                longestPath = Math.Max(longestPath, FindLongestPath(node) + 1);
            }

            return longestPath;
        }

        public static int FindPathsWithGivenSum(Node<int> root, int S)
        {
            if (root == null)
            {
                throw new ArgumentNullException("The tree has no nodes.");
            }

            if (root.Children.Count == 0)
            {
                return 0;
            }

            int path = 0;

            foreach (var node in root.Children)
            {
                path = Math.Max(path, FindLongestPath(node) + 1);

                if (path == S)
                {
                    return path;
                }
            }


            throw new ArgumentException("There's no path equal to that sum.");

            //foreach (var node in root.Children)
            //{
            //    List<int> subtree = new List<int>();
            //    subtree.Add(node.Value);
            //    FindPathsWithGivenSum(node, S);

            //    foreach (var child in node.Children)
            //    {
            //        subtree.Add(child.Value);
            //    }

            //    int sum = 0;
            //    foreach (var item in subtree)
            //    {
            //        sum += item;
            //    }

            //    if (sum == S)
            //    {
            //        foreach (var item in subtree)
            //        {
            //            Console.WriteLine(item);
            //        }

            //        Console.WriteLine("------");
            //    }
            //}
        }

        //BFS
        public static void TraverseTree(Node<int> root, int S)
        {
            Queue<Node<int>> subtree = new Queue<Node<int>>();
            subtree.Enqueue(root);

            while (subtree.Count > 0)
            {
                Node<int> currentNode = subtree.Dequeue();
                Console.WriteLine(currentNode.Value);

                List<Node<int>> children = currentNode.Children;
                foreach (var child in children)
                {
                    subtree.Enqueue(child);
                }
            }
        }

        public static List<Node<int>> FindSubtreesWithGivenSum(List<Node<int>> nodes)
        {
            throw new NotImplementedException();
        }
    }
}
