namespace HashTableImplementation
{
    using System.Collections;
    using System.Collections.Generic;
    /// <summary>
    /// Implementation of <see cref="IDictionary"/> interface
    /// using hash table. Collisions are resolved by chaining.
    /// </summary>
    /// <typeparam name="K">Type of the keys</typeparam>
    /// <typeparam name="V">Type of the values</typeparam>
    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int DefaultCapacity = 2;
        private const float DefaultLoadFactor = 0.75f;
        private List<KeyValuePair<K, V>>[] table;
        private float loadFactor;
        private int threshold;
        private int size;
        private int initialCapacity;

        public HashTable()
            : this(DefaultCapacity, DefaultLoadFactor)
        {
        }

        private HashTable(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.table = new List<KeyValuePair<K, V>>[capacity];
            this.loadFactor = loadFactor;
            unchecked
            {
                this.threshold =
                (int)(capacity * this.loadFactor);
            }
        }

        public void Clear()
        {
            if (this.table != null)
            {
                this.table =
                      new List<KeyValuePair<K, V>>[initialCapacity];
            }
            this.size = 0;
        }

        private List<KeyValuePair<K, V>> FindChain(K key, bool createIfMissing)
        {
            int index = key.GetHashCode();
            index = index % this.table.Length;

            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new List<KeyValuePair<K, V>>();
            }

            return this.table[index] as List<KeyValuePair<K, V>>;
        }

        public V Get(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                foreach (KeyValuePair<K, V> entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }
            }

            return default(V);
        }

        public V this[K key]
        {
            get
            {
                return this.Get(key);
            }

            set
            {
                this.Set(key, value);
            }
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public V Set(K key, V value)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                KeyValuePair<K, V> entry = chain[i];

                if (entry.Key.Equals(key))
                {
                    // Key found -> replace its value with the new value
                    KeyValuePair<K, V> newEntry = new KeyValuePair<K, V>(key, value);
                    chain[i] = newEntry;

                    return entry.Value;
                }
            }

            chain.Add(new KeyValuePair<K, V>(key, value));

            if (size++ >= threshold)
            {
                this.Expand();
            }

            return default(V);
        }

        /// <summary>
        /// Expands the underling table
        /// </summary>
        private void Expand()
        {
            int newCapacity = 2 * this.table.Length;
            List<KeyValuePair<K, V>>[] oldTable = this.table;
            this.table = new List<KeyValuePair<K, V>>[newCapacity];
            this.threshold = (int)(newCapacity * this.loadFactor);

            foreach (List<KeyValuePair<K, V>> oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (KeyValuePair<K, V> keyValuePair in oldChain)
                    {
                        List<KeyValuePair<K, V>> chain = FindChain(keyValuePair.Key, true);
                        chain.Add(keyValuePair);
                    }
                }
            }
        }

        public bool Remove(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    KeyValuePair<K, V> entry = chain[i];

                    if (entry.Key.Equals(key))
                    {
                        // Key found -> remove it
                        chain.RemoveAt(i);

                        return true;
                    }
                }
            }
            return false;
        }

        IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            foreach (List<KeyValuePair<K, V>> chain in this.table)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<K, V> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
    }
}