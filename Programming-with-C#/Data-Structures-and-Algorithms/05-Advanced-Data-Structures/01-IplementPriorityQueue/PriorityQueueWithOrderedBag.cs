﻿//namespace PriorityQueueWithOrderedBag
//{
//    public class PriorityQueue<T> where T : IComparable<T>
//    {
//        private OrderedBag<T> queue;

//        public PriorityQueue()
//        {
//            this.queue = new OrderedBag<T>();
//        }

//        public int Count
//        {
//            get { return this.queue.Count; }
//        }

//        public void Enqueue(T element)
//        {
//            this.queue.Add(element);
//        }

//        public T Dequeue()
//        {
//            return this.queue.RemoveFirst();
//        }
//    }
//}