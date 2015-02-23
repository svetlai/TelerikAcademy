namespace ReplaceTags
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 15. Replace tags
    /// Write a program that replaces in a HTML document given as string all the tags `<a href="…">…</a>` with corresponding tags `[URL=…]…/URL]`.
    /// Example:
    /// | input | output |
    /// |:-----:|:------:|
    /// | `<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>` | `<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>` |
    /// </summary>
    public class ReplaceTags
    {
        public static void Main()
        {
            string text = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
            string replaced = ReplaceAnchorTag(text);

            DisplayExample(text, replaced);
        }

        public static string ReplaceAnchorTag(string text)
        {
            int startIndex = 0;
            int opening = text.IndexOf("<a", startIndex);

            while (opening > -1 && startIndex < text.Length)
            {
                int closing = text.IndexOf(">", opening);

                int linkStart = text.IndexOf("href=\"", startIndex);
                int linkEnd = text.IndexOf('"', linkStart + "href=\"".Length);
                string link = text.Substring(linkStart + "href=\"".Length, linkEnd - (linkStart + "href=\"".Length));

                string newURL = "[URL=" + link + "]";
                string toReplace = text.Substring(opening, closing - opening);

                text = text.Replace(toReplace, newURL);

                startIndex += newURL.Length;
                opening = text.IndexOf("<a", startIndex);
            }

            text = text.Replace("</a>", "[/URL]");

            return text;
        }

        private static void DisplayExample(string text, string replaced)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 15. Replace tags \n Write a program that replaces in a HTML document given as string all the tags `<a href=\"…\">…</a>' with corresponding tags `[URL=…]…/URL]`.\n")
                .AppendLine("Example: ")
                .AppendLine(text)
                .AppendLine(border)
                .AppendLine(replaced);

            Console.Write(print.ToString());
        }
    }
}
