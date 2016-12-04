namespace ImplementLinkedList
{
    using System;
    //using System.Collections.Generic;

    /// <summary>
    /// 11. Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) 
    /// and NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement 
    /// (of type ListItem<T>).
    /// </summary>
    public class LinkedListExample
    {
        public static void Main()
        {
            HwLinkedList<int> list = new HwLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddFirst(4);

            var head = list.Head;
            Console.WriteLine("Head: {0}", head.ToString());

            int count = list.Count();
            Console.WriteLine("Elements count: {0}", count);

            Console.WriteLine("All elements:");

            Console.WriteLine(string.Join(", ", list));

            list.RemoveFirst();

            Console.WriteLine("All elements after removing the first one:");

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
