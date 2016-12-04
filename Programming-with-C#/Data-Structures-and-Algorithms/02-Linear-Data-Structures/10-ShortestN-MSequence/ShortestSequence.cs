namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 10. We are given numbers N and M and the following operations:
    /// N = N+1
    /// N = N+2
    /// N = N*2
    /// Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
    /// Example: N = 5, M = 16
    /// Sequence: 5 > 7 > 8 > 16
    /// </summary>
    public class ShortestSequence
    {
        public static void Main()
        {
            PrintShortestSequence(5, 16);         
        }

        public static void PrintShortestSequence(int n, int m)
        {
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);

            while (sequence.Count > 0)
            {
                int current = sequence.Dequeue();

                Console.WriteLine(current);
                
                if (current == m)
                {
                    return;
                }

                current = current + 1;
                sequence.Enqueue(current);
                current = current + 2;
                sequence.Enqueue(current);
                current = current * 2;
                sequence.Enqueue(current);
            }
        }
    }
}
