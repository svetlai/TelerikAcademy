namespace ImplemetHashTable
{
    public class KeyValuePair<K, V> : System.Collections.IEnumerable
    {
        private K key;
        private V value;

        public KeyValuePair(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public K Key 
        { 
            get
            {
                return this.key;
            }
        }

        public V Value
        {
            get
            {
                return this.value;
            }
        }

        public System.Collections.Generic.IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var value in this)
            {
                yield return value;
            }           
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
