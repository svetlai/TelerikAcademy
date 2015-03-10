namespace GenericList
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable
    {
        private const int DefaultCapacity = 4;
        private const string EmptyList = "The list is empty.";
        private const string IndexOutOfRangeExceptionMessage = "Index is out of range.";

        private T[] list;
        private int count;
        private int capacity;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.Count = 0;
            this.Capacity = capacity;
            this.list = new T[capacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                this.capacity = value;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.list[index];
            }

            set
            {
                this.list[index] = value;
            }
        }

        public void Add(T element)
        {
            this.Count++;
            this[this.Count - 1] = element;
            this.Resize();
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeExceptionMessage);
            }

            T[] result = new T[this.Capacity - 1];

            Array.Copy(this.list, 0, result, 0, index);
            Array.Copy(this.list, index + 1, result, index, this.Count - 1 - index);

            this.Count--;
            this.list = result;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeExceptionMessage);
            }

            T[] result = new T[this.Capacity + 1];

            Array.Copy(this.list, 0, result, 0, index);
            Array.Copy(this.list, index, result, index + 1, this.Count - index);
            result[index] = element;

            this.list = result;

            this.Count++;
            this.Resize();           
        }

        public void Clear()
        {
            this.Count = 0;
            this.Capacity = DefaultCapacity;

            this.list = new T[this.Capacity];
        }

        public int Find(T value)
        {
            return Array.IndexOf(this.list, value);
        }

        public T Min()
        {
            T min = this.list[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (this.list[i].CompareTo(min) < 0)
                {
                    min = this.list[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.list[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (this.list[i].CompareTo(max) > 0)
                {
                    max = this.list[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            if (this.Count == 0)
            {
                return EmptyList;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                if (i != this.Count - 1)
                {
                    sb.AppendFormat("{0}, ", this.list[i]);
                }
                else
                {
                    sb.AppendFormat("{0}", this.list[i]);
                }
            }

            return sb.ToString();
        }

        private void Resize()
        {
            if (this.Count >= this.Capacity * 0.75)
            {
                this.Capacity *= 2;
                Array.Resize(ref this.list, this.Capacity);
            }
        }
    }
}
