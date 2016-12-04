namespace TrieImplementation
{
    using System.IO;

    public static class FileUtils
    {
        public static void AddWordsFromFile(string path, TrieNode trieRoot)
        {
            using (StreamReader sreader = new StreamReader(path))
            {
                string line;
                while ((line = sreader.ReadLine()) != null)
                {
                    string[] words = line.Split();
                    foreach (string word in words)
                    {
                        trieRoot.AddWord(word.Trim());
                    }
                }
            }
        }
    }
}
