namespace BinarySearchTreeImplementation
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T> : ICloneable where T : IComparable
    {
        private T value;
        private IList<TreeNode<T>> children;
        private bool hasParent;
        private TreeNode<T> left;
        private TreeNode<T> right;

        public TreeNode()
        {
            this.Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value)
            : this()
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public IList<TreeNode<T>> Children
        {
            get
            {
                return this.children;
            }

            private set
            {
                this.children = value;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }

            set
            {
                this.hasParent = value;
            }
        }

        public TreeNode<T> Left
        {
            get
            {
                return this.left;
            }

            set
            {
                this.left = value;

                if (value != null)
                {
                    this.AddChild(this.left);
                }
            }
        }

        public TreeNode<T> Right
        {
            get
            {
                return this.right;
            }

            set
            {
                this.right = value;

                if (value != null)
                {
                    this.AddChild(this.right);
                }
            }
        }

        public int NumberOfChildren
        {
            get
            {
                return this.Children.Count;
            }
        }

        public static bool operator ==(TreeNode<T> first, TreeNode<T> second)
        {
            if ((object)first == null && (object)second == null)
            {
                return true;
            }
            else if ((object)first == null || (object)second == null)
            {
                return false;
            }
            else
            {
                return first.Equals(second);
            }
        }

        public static bool operator !=(TreeNode<T> first, TreeNode<T> second)
        {
            if ((object)first == null && (object)second == null)
            {
                return false;
            }
            else if ((object)first == null || (object)second == null)
            {
                return true;
            }
            else
            {
                return !first.Equals(second);
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            child.HasParent = true;
            this.Children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.Children[index];
        }

        public object Clone()
        {
            TreeNode<T> clone = new TreeNode<T>();
            if (this.Value is ICloneable)
            {
                clone.Value = (T)(IComparable)((ICloneable)this.Value).Clone();
            }
            else
            {
                clone.Value = this.Value;
            }

            if (this.Left != null)
            {
                clone.Left = (TreeNode<T>)this.Left.Clone();
            }

            if (this.Right != null)
            {
                clone.Right = (TreeNode<T>)this.Right.Clone();
            }

            return clone;
        }

        public override bool Equals(object obj)
        {
            var otherNode = obj as TreeNode<T>;
            if ((object)otherNode == null)
            {
                return false;
            }
       
            return this.Value.CompareTo(otherNode.Value) == 0;
        }

        public override int GetHashCode()
        {
            int n = 1;
            int.TryParse(this.Value.ToString(), out n);
            return base.GetHashCode() ^ n * DateTime.Now.Millisecond;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}