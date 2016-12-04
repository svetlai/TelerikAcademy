namespace HashTableImplementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface that defines basic methods needed
    /// for a class which maps keys to values.
    /// </summary>
    /// <typeparam name="K">Key type</typeparam>
    /// <typeparam name="V">Value type</typeparam>
    public interface IHashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {

        /// <summary>
        /// Adds the specified value by the specified
        /// key to the dictionary. If the key already
        /// exists its value is replaced with the
        /// new value and the old value is returned.
        /// </summary>
        /// <param name="key">Key for the new value</param>
        /// <param name="value">Value to be mapped
        /// with that key</param>
        /// <returns>the old value for the specified
        /// key or null if the key does not exist</returns>
        /// <exception cref="NullReferenceException">
        /// If Key is null</exception>
        V Set(K key, V value);

        ///<summary>
        /// Finds the value mapped by specified key.
        ///</summary>
        /// <param name="key">key for which the value
        /// is needed.</param>
        /// <returns>value for the specified key if present,
        /// or null if there is no value with such key</returns>
        V Get(K key);

        /// <summary>
        /// Gets or sets the value of the entry in the
        /// dictionary identified by the Key specified.
        /// </summary>
        /// <remarks>A new entry will be created if the
        /// value is set for a key that is not currently
        /// in the Dictionary</remarks>
        /// <param name="key">Key to identify the entry
        /// in the Dictionary</param>
        /// <returns>Value of the entry in the Dictionary
        /// identified by the Key provided</returns>
        V this[K key] { get; set; }

        /// <summary>
        /// Removes an element in the Dictionary
        /// identified by a specified key.
        /// </summary>
        /// <param name="key">Key to identify the
        /// element in the Dictionary to be removed</param>
        /// <returns></returns>
        bool Remove(K key);

        /// <summary>
        /// Get a value indicating the number of
        /// entries in the Dictionary
        /// </summary>
        /// <returns></returns>
        int Count { get; }

        /// <summary>
        /// Removes all the elements from the dictionary.
        /// </summary>
        void Clear();
    }
}
