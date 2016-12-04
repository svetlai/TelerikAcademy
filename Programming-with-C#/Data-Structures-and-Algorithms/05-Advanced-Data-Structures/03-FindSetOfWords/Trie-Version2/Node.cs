namespace FindSetofWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Node
    {
        public string Word;

        public bool IsTerminal { get { return Word != null; } }

        public Dictionary<Letter, Node> Edges = new Dictionary<Letter, Node>();
    }
}
