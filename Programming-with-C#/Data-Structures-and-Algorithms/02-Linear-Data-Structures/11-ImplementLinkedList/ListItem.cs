namespace ImplementLinkedList
{
    using System;

    public class ListItem<T>
    {
        private T value;
        private ListItem<T> next;

        internal ListItem(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value { get; set; }

        public ListItem<T> Next { get; set; }

        //public ListItem<T> Previous { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
