namespace ImplementHashSet
{
    using ImplemetHashTable;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class HwHashSet<V> : IEnumerable
    {
        HashTable<V, byte> hashTable;

        public HwHashSet()
        {
            this.hashTable = new HashTable<V, byte>();
        }

        public void Add(V value)
        {
            this.hashTable.Add(value, 0);
        }

        public bool Find(V value)
        {
            return this.hashTable.Find(value);
        }

        public bool Remove(V value)
        {
            return this.hashTable.Remove(value);
        }

        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public IEnumerable<V> Items
        {
            get
            {
                return this.hashTable.Keys;
            }
        }

        public V this[V index]
        {
            get
            {
                return this.hashTable.FindKey(index);
            }

            set
            {
                this.Add(index);
            }
        }

        public HwHashSet<V> Union(HwHashSet<V> otherSet)
        {
            IEnumerable<V> union = this.Items.Union(otherSet.Items);
            HwHashSet<V> newSet = new HwHashSet<V>();

            foreach (var item in union)
            {
                newSet.Add(item);
            }

            return newSet;
        }

        public HwHashSet<V> Intersect(HwHashSet<V> otherSet)
        {
            IEnumerable<V> intersect = this.Items.Intersect(otherSet.Items);
            HwHashSet<V> newSet = new HwHashSet<V>();

            foreach (var item in intersect)
            {
                newSet.Add(item);
            }

            return newSet;
        }

        public IEnumerator<V> GetEnumerator()
        {
            foreach (var pair in this.hashTable)
            {
                if (pair != null)
                {
                    yield return pair.Key;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int HashKey(V key)
        {
            var hash = key.GetHashCode();
            hash %= hashTable.Capacity - 1;
            hash = Math.Abs(hash);

            return hash;
        }

    }
}
