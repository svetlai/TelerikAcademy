namespace ReadTree
{
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node()
        {
            this.Children = new List<Node<T>>();
        }

        public Node(T value)
            : this()
        {
            this.Value = value;
        }

        public List<Node<T>> Children { get; set; }

        public T Value { get; set; }

        public bool HasParent { get; set; }

        public void AddChild(Node<T> child)
        {
            child.HasParent = true;
            Children.Add(child);
        }

        public int NumberOfChildren
        {
            get
            {
                return this.Children.Count;
            }
        }

        public Node<T> GetChild(int index)
        {
            return this.Children[index];
        }
    }
}
