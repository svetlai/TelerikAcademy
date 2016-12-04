namespace TrieImplementation
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// http://stackoverflow.com/questions/12190326/parsing-one-terabyte-of-text-and-efficiently-counting-the-number-of-occurrences
    /// </summary>
    public class TrieNode : IComparable<TrieNode>
    {
        private char character;
        public int wordCount;
        private TrieNode nodeParent = null;
        private ConcurrentDictionary<char, TrieNode> children = null;

        public TrieNode(TrieNode parent, char character)
        {
            this.character = character;
            this.wordCount = 0;
            this.nodeParent = parent;
            this.children = new ConcurrentDictionary<char, TrieNode>();
        }

        public void AddWord(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (char.IsLetter(key))
                {
                    if (!this.children.ContainsKey(key))
                    {
                        this.children.TryAdd(key, new TrieNode(this, key));
                    }

                    this.children[key].AddWord(word, index + 1);
                }
                else
                {
                    // not a letter! retry with next char
                    this.AddWord(word, index + 1);
                }
            }
            else
            {
                if (nodeParent != null) // empty words should never be counted
                {
                    lock (this)
                    {
                        this.wordCount++;
                    }
                }
            }
        }

        public int GetCount(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (!this.children.ContainsKey(key))
                {
                    return -1;
                }

                return this.children[key].GetCount(word, index + 1);
            }
            else
            {
                return this.wordCount;
            }
        }

        public void GetTopCounts(ref List<TrieNode> mostCounted, ref int distinctWordCount, ref int totalWordCount)
        {
            if (wordCount > 0)
            {
                distinctWordCount++;
                totalWordCount += this.wordCount;
            }

            if (wordCount > mostCounted[0].wordCount)
            {
                mostCounted[0] = this;
                mostCounted.Sort();
            }

            foreach (char key in children.Keys)
            {
                this.children[key].GetTopCounts(ref mostCounted, ref distinctWordCount, ref totalWordCount);
            }
        }

        public override string ToString()
        {
            if (nodeParent == null)
            {
                return string.Empty;
            }
            else
            {
                return nodeParent.ToString() + this.character;
            }
        }

        public int CompareTo(TrieNode other)
        {
            return this.wordCount.CompareTo(other.wordCount);
        }
    }
}
