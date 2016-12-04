namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 5. Write a program that removes from given sequence all negative numbers.
    /// </summary>
    public class PositiveSequence
    {
        public static void Main()
        {
            LinkedList<int> linkedSequence = new LinkedList<int>();
            
            linkedSequence.AddLast(1);
            linkedSequence.AddLast(-2);
            linkedSequence.AddLast(3);
            linkedSequence.AddLast(-4);
            linkedSequence.AddLast(-2);
            linkedSequence.AddLast(3);
            linkedSequence.AddLast(2);

            List<int> sequenceList = new List<int>()
            {
                1, -2, 3, -4, -2, 3, 2
            };

            Console.WriteLine("Sequence before removing negatives:");
            Console.WriteLine(string.Join(", ", linkedSequence));

            LinkedList<int> positiveSequence = RemoveNegatives(linkedSequence);
            //List<int> positiveSequence = RemoveNegativesList(sequenceList);

//Test which one is faster:

            //Stopwatch stopwatch = Stopwatch.StartNew();

            //for (int i = 0; i < 10000000; i++)
            //{
            //    LinkedList<int> testPositiveSequence = RemoveNegatives(linkedSequence);
            //}

            //stopwatch.Stop();
            //Console.WriteLine("Elapsed time: {0} ms", stopwatch.ElapsedMilliseconds);

            //Stopwatch stopwatchList = Stopwatch.StartNew();
            //for (int i = 0; i < 10000000; i++)
            //{
            //    List<int> testPositiveSequenceList = RemoveNegativesList(sequenceList);
            //}

            //stopwatchList.Stop();
            //Console.WriteLine("Elapsed time: {0} ms", stopwatchList.ElapsedMilliseconds);

            Console.WriteLine("New sequence:");
            Console.WriteLine(string.Join(", ", positiveSequence));
        }

        public static LinkedList<int> RemoveNegatives(LinkedList<int> numbers)
        {
            var node = numbers.First;

            while (node != null)
            {
                var next = node.Next;

                if (node.Value < 0)
                {
                    numbers.Remove(node);
                }

                node = next;
            }

            return numbers;
        }

        public static List<int> RemoveNegativesList(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                }
            }
            
            return numbers;
        }   
    }
}
