namespace ParseURL
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Problem 12. Parse URL
    /// Write a program that parses an URL address given in the format: `[protocol]://[server]/[resource]` and extracts from it the `[protocol]`, `[server]` and `[resource]` elements.
    /// Example:
    /// |                 URL                  |                                     Information                                     |
    /// |:------------------------------------:|:----------------------------------------------------------------------------------------:|
    /// | `http://telerikacademy.com/Courses/Courses/Details/212` | [protocol] = `http` <br> [server] = `telerikacademy.com` <br> [resource] = `/Courses/Courses/Details/212` |
    /// </summary>
    public class ParseURL
    {
        public static void Main()
        {
            string url = "http://telerikacademy.com/Courses/Courses/Details/212";
            var result = ParseURLAddress(url);

            DisplayExample(url, result);
        }

        public static Dictionary<string, string> ParseURLAddress(string url)
        {
            int protocolEndIndex = url.IndexOf(':');
            string protocol = url.Substring(0, protocolEndIndex);

            int serverStartIndex = url.IndexOf("://", protocolEndIndex) + "://".Length;
            int serverEndIndex = url.IndexOf('/', serverStartIndex + 1);

            string server = url.Substring(serverStartIndex, serverEndIndex - serverStartIndex);

            int resourceStartIndex = serverEndIndex;

            string resource = url.Substring(resourceStartIndex, url.Length - resourceStartIndex);

            return new Dictionary<string, string> 
            {
                { "[protocol]", protocol },
                { "[server]", server },
                { "[resource]", resource }
            };
        }

        private static void DisplayExample(string url, Dictionary<string, string> result)
        {
            StringBuilder print = new StringBuilder();

            print.AppendLine("Problem 12. Parse URL \nWrite a program that parses an URL address given in the format: `[protocol]://[server]/[resource]` and extracts from it the `[protocol]`, `[server]` and `[resource]` elements.\n");

            print.AppendLine("Example: ")
                .AppendLine(url);

            foreach (var item in result)
            {
                print.AppendLine(item.Key + " = " + item.Value);
            }

            Console.Write(print.ToString());
        }
    }
}
