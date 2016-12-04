namespace WcfServiceSubstringOccurances
{
    public class ServiceSubstringOccurances : IServiceSubstringOccurances
    {
        public int CountSubstringOccurances(string substring, string text)
        {
            int count = 0;
            int currentIndex = 0;

            if (substring != "")
            {
                while ((currentIndex = text.IndexOf(substring, currentIndex)) != -1)
                {
                    currentIndex += substring.Length;
                    ++count;
                }
            }

            return count;
        }
    }
}
