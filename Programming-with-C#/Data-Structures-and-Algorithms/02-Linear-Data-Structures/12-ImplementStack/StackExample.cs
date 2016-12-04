namespace ImplementStack
{
    using System;

    /// <summary>
    /// 12. Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to 
    /// add / insert a new element).
    /// </summary>
    public class StackExample
    {
        public static void Main()
        {
            HwStack<int> stack = new HwStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine("Count: {0}", stack.Count);
            Console.WriteLine("Peek at last element: {0}", stack.Peek());
            Console.WriteLine("Pop last element: {0}",  stack.Pop());
            Console.WriteLine("Peek at last element: {0}", stack.Peek());
            Console.WriteLine("Count: {0}", stack.Count);
        }
    }
}
