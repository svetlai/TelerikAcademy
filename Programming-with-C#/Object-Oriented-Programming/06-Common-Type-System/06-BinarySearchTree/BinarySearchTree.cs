namespace BinarySearchTreeImplementation
{
    using System;
    using System.Text;

    public class BinarySearchTree<T> where T : IComparable
    {
        private TreeNode<T> root;
        private int count;

        public BinarySearchTree()
        {
            this.Root = null;
        }

        public BinarySearchTree(T rootValue)
        {
            this.Root = new TreeNode<T>(rootValue);
            this.Count = 1;
        }

        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }

            set
            {
                this.root = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public void Add(T value)
        {
            if (!this.Contains(value))
            {
                var root = this.Root;
                this.Insert(ref root, value);
                this.Root = root;
            }
        }

        public bool Contains(T value)
        {
            return this.Contains(this.Root, value);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            this.Display(this.Root, " ", ref sb);
            return sb.ToString();
        }

        private void Insert(ref TreeNode<T> rootNode, T value)
        {
            if (rootNode == null)
            {
                var newNode = new TreeNode<T>(value);
                rootNode = newNode;
                this.Count++;
            }
            else if (value.CompareTo(rootNode.Value) < 0)
            {
                var tempNode = rootNode.Left;
                this.Insert(ref tempNode, value);
                rootNode.Left = tempNode;
            }
            else
            {
                var tempNode = rootNode.Right;
                this.Insert(ref tempNode, value);
                rootNode.Right = tempNode;
            }
        }

        private bool Contains(TreeNode<T> rootNode, T value)
        {
            if (rootNode == null)
            {
                return false;
            }
            else if (rootNode.Value.CompareTo(value) == 0)
            {
                return true;
            }
            else if (value.CompareTo(rootNode.Value) < 0)
            {
                return this.Contains(rootNode.Left, value);
            }
            else if (value.CompareTo(rootNode.Value) >= 0)
            {
                return this.Contains(rootNode.Right, value);
            }

            return false;
        }

        private void Display(TreeNode<T> rootNode, string separator, ref StringBuilder sb)
        {
            if (rootNode != null)
            {
                this.Display(rootNode.Left, separator, ref sb);
                sb.Append(rootNode.ToString() + separator);
                this.Display(rootNode.Right, separator, ref sb);
            }
        }
    }
}
