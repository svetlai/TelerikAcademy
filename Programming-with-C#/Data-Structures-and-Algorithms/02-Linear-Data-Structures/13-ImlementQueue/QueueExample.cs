namespace ImlementQueue
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 13. Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing different 
    /// data types in the queue.
    /// </summary>
    public class QueueExample
    {
        public static void Main()
        {
            LinkedQueue<int> linkedQueue = new LinkedQueue<int>();

            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(2);
            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(4);

            Console.WriteLine("Count: {0}", linkedQueue.Count);
            Console.WriteLine("Peek at first element: {0}", linkedQueue.Peek());
            Console.WriteLine("Dequeue first element: {0}", linkedQueue.Dequeue());
            Console.WriteLine("Peek at first element: {0}", linkedQueue.Peek());
            Console.WriteLine("Count: {0}", linkedQueue.Count);

            linkedQueue.Clear();
            Console.WriteLine("Count after Clear(): {0}", linkedQueue.Count);
        }
    }
}
