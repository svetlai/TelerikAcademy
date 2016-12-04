namespace CountWordOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            return string.Compare(s1, s2, true);
        }
    }

    class Test
    {
        IDictionary<string, int> words = new SortedDictionary<string, int>(new CaseInsensitiveComparer());
    }

    //Винаги, когато два обекта са еднакви (Equals(object) връща true), CompareTo(Е) трябва да връща 0.
           
}
