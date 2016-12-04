namespace FindSetofWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Trie
    {
        public Node Root = new Node();

        public Trie(string[] words)
        {
            for (int w = 0; w < words.Length; w++)
            {
                var word = words[w];
                var node = Root;

                for (int len = 1; len <= word.Length; len++)
                {
                    var letter = word[len - 1];
                    Node next;
                    if (!node.Edges.TryGetValue(letter, out next))
                    {
                        next = new Node();
                        if (len == word.Length)
                        {
                            next.Word = word;
                        }

                        node.Edges.Add(letter, next);
                    }

                    node = next;
                }
            }
        }
    }
}
