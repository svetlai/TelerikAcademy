namespace ImplemetHashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, V> : IHashTable<K, V>, System.Collections.IEnumerable
    {
        const int initalCapacity = 16;
        private List<List<KeyValuePair<K, V>>> table;
        private int elementsCount;

        public HashTable()
        {
            this.table = new List<List<KeyValuePair<K, V>>>(initalCapacity);

            //For some reason without this loop adding elements gives an ArgumentOutOfRange exception.
            for (int i = 0; i < initalCapacity; i++)
            {
                this.table.Add(new List<KeyValuePair<K, V>>());
            }
        }

        public HashTable(int capacity)
        {
            this.table = new List<List<KeyValuePair<K, V>>>(capacity);
        }

        public void Add(K key, V value)
        {
            int hash = HashKey(key);
            
            this.table[hash] = new List<KeyValuePair<K, V>>();

            ////added to the constructor
            //if (this.table[hash] == null)
            //{
            //    this.table[hash] = new List<KeyValuePair<K, V>>();
            //}

            if (this.table[hash].Any(k => k.Key.Equals(key)))
            {
                throw new ArgumentException("Key already exists.");
            }

            this.table[hash].Add(new KeyValuePair<K, V>(key, value));          
            this.elementsCount++;

            if (elementsCount >= initalCapacity * 0.75)
            {
                this.Resize();
            }
        }

        public bool Find(K key)
        {
            var hash = HashKey(key);

            if (this.table[hash] == null)
            {
                return false;
            }

            var chain = this.table[hash];

            return chain.Any(p => p.Key.Equals(key));
        }

        public bool Remove(K key)
        {
            if (this.Find(key))
            {
                var hash = HashKey(key);
                var chain = this.table[hash];
                var toRemove = chain.First(k => k.Key.Equals(key));

                chain.Remove(toRemove);

                this.elementsCount -= 1;

                return true;
            }

            return false;
        }

        public int Count
        {
            get
            {
                return this.elementsCount;
            }
            
        }

        public int Capacity
        {
            get
            {
                return this.table.Capacity;
            }

        }

        public void Clear()
        {
            this.table = new List<List<KeyValuePair<K, V>>>(initalCapacity);
            this.elementsCount = 0;
        }

        public V this[K key]
        {
            get
            {
                if (!this.Find(key))
                {
                    throw new ArgumentException("No such key.");
                }

                var hash = HashKey(key);
                var chain = this.table[hash];

                V valueToReturn = chain.First(k => k.Key.Equals(key)).Value;

                return valueToReturn;
    
            }

            set
            {
                this.Add(key, value);
            }
        }

        public K[] Keys
        {
            get
            {
                var keys = new List<K>(this.elementsCount);

                foreach (var chain in this.table)
                {
                    foreach (var pair in chain)
                    {
                        keys.Add(pair.Key);
                    }                 
                }

                return keys.ToArray();
            }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var chain in this.table)
            {
                if (chain != null)
                {
                    foreach (var pair in chain)
                    {
                        yield return pair;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % this.elementsCount;
            return Math.Abs(position);
        }

        public K FindKey(K key)
        {
            if (!this.Find(key))
            {
                throw new ArgumentException("No such key.");
            }

            var hash = HashKey(key);

            var chain = this.table[hash];

            return chain.First(p => p.Key.Equals(key)).Key;
        }

        private int HashKey(K key)
        {
            var hash = key.GetHashCode();
            hash %= this.table.Capacity - 1;
            hash = Math.Abs(hash);

            return hash;
        }

        private void Resize()
        {
            var chachedTable = this.table;

            this.table = new List<List<KeyValuePair<K, V>>>(this.table.Capacity * 2);

            this.elementsCount = 0;

            foreach (var chain in chachedTable)
            {
                if (chain != null)
                {
                    foreach (var pair in chain)
                    {
                        //using our Add method;
                        this.Add(pair.Key, pair.Value);
                    }
                }
            }
        }
    }
}
