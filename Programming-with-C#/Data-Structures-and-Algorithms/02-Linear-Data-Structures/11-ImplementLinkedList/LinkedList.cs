namespace ImplementLinkedList
{
    using System;

    public class HwLinkedList<T> : System.Collections.Generic.IEnumerable<T>
    {
        private ListItem<T> head;

        public HwLinkedList()
        {
        }

        public HwLinkedList(ListItem<T> head)
        {
            this.Head = head;
            //this.Tail = this.Head;
        }

        public ListItem<T> Head
        {
            get
            {
                return this.head;
            }

            set
            {
                this.head = value;
            }
        }

        ////public ListItem<T> Tail { get; set; }

        public void AddFirst(T value)
        {
            if (this.Head == null)
            {
                this.Head = new ListItem<T>(value);
                ////this.Tail = this.Head;
            }
            else
            {
                var newNode = new ListItem<T>(value);
                newNode.Next = this.Head;
                this.Head = newNode;
            }
        }

        public void RemoveFirst()
        {
            this.Head = this.Head.Next;
        }

        public int Count()
        {
            int count = 1;
            ListItem<T> next = this.Head;

            while (next.Next != null)
            {
                next = next.Next;
                count += 1;
            }

            return count;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            var node = this.Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        public System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        ////In order for this to work, we need the last element.
        public void AddLast(T value)
        {
            throw new NotImplementedException();

            //var newNode = new ListItem<T>(value);

            //if (this.Head == null && this.Tail == null)
            //{
            //    this.Head = newNode;
            //    this.Tail = newNode;
            //}
            //else
            //{
            //    this.Tail.Next = newNode;
            //    newNode.Previous = this.Tail;
            //    this.Tail = newNode;
            //}
        }

        public void AddBefore(T value)
        {
            throw new NotImplementedException();
        }

        public void AddAfter(T value)
        {
            throw new NotImplementedException();
        }

        public void RemoveLast()
        {
            throw new NotImplementedException();
        }
    }
}
