namespace ImplementStack
{
    using System;

    public class HwStack<T>
    {
        private const int StackSize = 4;

        private T[] stack;
        private int count;

        public HwStack()
        {
            this.stack = new T[StackSize];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T value)
        {
            if (this.Count == this.stack.Length)
            {
                this.ResizeStack(this.stack);
            }

            this.stack[this.Count] = value;
            this.Count += 1;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The stack is empty.");
            }

            T lastElement = this.stack[this.Count - 1];
            this.Count -= 1;

            return lastElement;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The stack is empty.");
            }

            T lastElement = this.stack[this.Count - 1];

            return lastElement;
        }

        public void Clear()
        {
            this.stack = new T[StackSize];
            this.Count = 0;       
        }

        public void ResizeStack(T[] stack)
        {
            T[] newStack = new T[stack.Length * 2];

            for (int i = 0; i < this.stack.Length; i++)
            {
                newStack[i] = this.stack[i];
            }

            stack = newStack;
        }
    }
}
