namespace StringBuilderSubstring
{
    using System.Text;

    public static class ExtensionMethods
    {
        public static StringBuilder Substring(this StringBuilder sb, int startIndex)
        {
            string str = sb.ToString();
            str = str.Substring(startIndex);
            sb.Clear()
                .Append(str);

            return sb;
        }

        public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
        {
            string str = sb.ToString();
            str = str.Substring(startIndex, length);
            sb.Clear()
                .Append(str);

            return sb;
        }
    }
}
