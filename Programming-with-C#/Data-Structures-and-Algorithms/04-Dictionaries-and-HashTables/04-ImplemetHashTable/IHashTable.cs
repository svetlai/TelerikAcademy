namespace ImplemetHashTable
{
    interface IHashTable<K, V>
    {
        void Add(K key, V value);

        bool Find(K key);

        bool Remove(K key);

        int Count { get; }

        void Clear();

        V this[K key] { get; }

        K[] Keys { get; }
    }
}
