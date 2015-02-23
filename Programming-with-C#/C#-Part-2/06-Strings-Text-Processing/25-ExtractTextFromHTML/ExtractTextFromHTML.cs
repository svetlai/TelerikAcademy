namespace ExtractTextFromHTML
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Problem 25. Extract text from HTML
    /// Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
    /// Example input:
    /// <html>
    /// <head><title>News</title></head>
    /// <body><p><a href="http://academy.telerik.com">Telerik
    /// Academy</a>aims to provide free real-world practical
    /// training for young people who want to turn into
    /// skilful .NET software engineers.</p></body>
    /// </html>
    /// Output:
    /// Title: News
    /// Text: Telerik Academy aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.
    /// </summary>
    public class ExtractTextFromHTML
    {
        private const string TitleTagOpen = "<title>";
        private const string TitleTagClose = "</title>";
        private static bool isTitleTag = false;

        public static void Main()
        {
            string input = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.</p></body></html>";
            var parsed = ExtractTextFromTags(input);

            DisplayExample(input, parsed);
        }

        public static Dictionary<string, string> ExtractTextFromTags(string text)
        {
            StringBuilder sbTitle = new StringBuilder();
            StringBuilder sbText = new StringBuilder();

            var result = new Dictionary<string, string>();
            char currentSymbol;

            for (int i = 0; i < text.Length; i++)
            {
                currentSymbol = text[i];

                if (currentSymbol == '<')
                {
                    string tag = GetTag(text, i);
                    ProcessTag(tag);

                    i += tag.Length - 1;
                }
                else
                {
                    if (!isTitleTag)
                    {
                        sbText.Append(currentSymbol);
                    }
                    else if (isTitleTag)
                    {
                        sbTitle.Append(currentSymbol);
                    }
                }
            }

            result.Add("Title", sbTitle.ToString());
            result.Add("Text", sbText.ToString());

            return result;
        }

        private static void ProcessTag(string tag)
        {
            switch (tag)
            {
                case TitleTagOpen:
                    isTitleTag = true;
                    break;
                case TitleTagClose:
                    isTitleTag = false;
                    break;
            }
        }

        private static string GetTag(string line, int startIndex)
        {
            int endIndex = line.IndexOf('>', startIndex + 1);

            return line.Substring(startIndex, endIndex - startIndex + 1);
        }

        private static void DisplayExample(string text, Dictionary<string, string> result)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 25. Extract text from HTML \nWrite a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.")
                .AppendLine("Example: ")
                .AppendLine(text)
                .AppendLine(border);

            foreach (var line in result)
            {
                print.AppendFormat("{0}: {1}\n", line.Key, line.Value);
            }

            print.AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
