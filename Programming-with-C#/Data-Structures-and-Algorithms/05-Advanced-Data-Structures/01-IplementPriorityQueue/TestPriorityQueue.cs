namespace IplementPriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestPriorityQueue
    {
        public static void Main()
        {
            PriorityQueue<int, string> minPriorityQueue = new PriorityQueue<int, string>();
            minPriorityQueue.Enqueue(3, "hello");
            minPriorityQueue.Enqueue(2, "bye");
            minPriorityQueue.Enqueue(1, "good morning");

            Console.WriteLine("Elements enqueued successfully.");

            var peek = minPriorityQueue.Peek();
            var peekValue = minPriorityQueue.PeekValue();

            Console.WriteLine("Peek: {0}", peek);
            Console.WriteLine("PeekValue: {0}", peekValue);

            var dequeue = minPriorityQueue.Dequeue();
            var dequeueValue = minPriorityQueue.DequeueValue();

            Console.WriteLine("Dequeue: {0}", dequeue);
            Console.WriteLine("Dequeue: {0}", dequeueValue);

            // this priority queue uses "inverted" comparer, 
            // so in fact it is max-priority queue
            PriorityQueue<int, string> maxPriorityQueue = new PriorityQueue<int, string>(new MyComparer());
        }
    }
}
