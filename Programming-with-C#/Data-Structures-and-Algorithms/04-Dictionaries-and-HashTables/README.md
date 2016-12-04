1. Write a program that counts in a given array of `double` values the number of occurrences of each value. Use `Dictionary<TKey,TValue>`.
    
    >Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    
    >-2.5 -> 2 times
    
    >3 -> 4 times
    
    >4 -> 3 times

2. Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:

    > {C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}

3. Write a program that counts how many times each word from given text file `words.txt` appears in it. The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text. Example:

    `This is the TEXT. Text, text, text – THIS TEXT! Is this the text?`

	>is -> 2
    
	>the -> 2
    
	>this -> 3
    
	>text -> 6

4. Implement the data structure `hash table` in a class `HashTable<K,T>`. Keep the data in array of lists of key-value pairs (`LinkedList<KeyValuePair<K,T>>[]`) with initial capacity of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity. Implement the following methods and properties:

    * `Add(key, value)`
    * `Find(key)->value`
    * `Remove(key)`
    * `Count`
    * `Clear()`
    * `this[]`
    * `Keys`
    
    Try to make the hash table to support iterating over its elements with `foreach`.
    
    Write unit tests for your class.
    
5. Implement the data structure `set` in a class `HashedSet<T>` using your class `HashTable<K,T>` to hold the elements. Implement all standard set operations like 
    
    * `Add(T)`
    * `Contains(T) -> true/false`
    * `Remove(T)`
    * `Count`
    * `Clear()`
    * `union and`
    * `intersect`
    
    Write unit tests for your class.
