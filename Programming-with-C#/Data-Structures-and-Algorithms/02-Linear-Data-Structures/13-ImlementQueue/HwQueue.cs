namespace ImlementQueue
{
    using System;
    using System.Collections.Generic;    

    public class LinkedQueue<T>
    {
        private LinkedList<T> linkedQueue;
        
        public LinkedQueue()
        {
            this.linkedQueue = new LinkedList<T>();
            this.Count = 0;
        }

        public int Count { get; set; }

        public void Enqueue(T value)
        {
            this.linkedQueue.AddLast(value);
            this.Count += 1;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The queue is empty.");
            }

            T firstElement = this.linkedQueue.First.Value;
            
            this.linkedQueue.RemoveFirst();

            this.Count -= 1;

            return firstElement;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The queue is empty.");
            }

            T firstElement = this.linkedQueue.First.Value;

            return firstElement;
        }

        public void Clear()
        {
            while (this.linkedQueue.First != null)
            {
                this.linkedQueue.RemoveFirst();
                this.Count = 0;
            }
        }
    }
}
