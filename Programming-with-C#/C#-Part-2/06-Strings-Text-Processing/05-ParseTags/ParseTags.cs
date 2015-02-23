namespace ParseTags
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 5. Parse tags
    /// You are given a text. Write a program that changes the text in all regions surrounded by the tags `<upcase>` and `</upcase>` to upper-case.
    /// The tags cannot be nested.
    /// Example: We are living in a `<upcase>`yellow submarine`</upcase>`. We don't have `<upcase>`anything`</upcase>` else.
    /// The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
    /// </summary>
    public class ParseTags
    {
        public static void Main()
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            string newText = ChangeToUpper(text);

            DisplayExample(text, newText);
        }

        public static string ChangeToUpper(string text)
        {
            int startIndex = 0;
            string openingTag = "<upcase>";
            string closingTag = "</upcase>";

            while (startIndex < text.Length - 1)
            {
                int openingIndex = text.IndexOf(openingTag, startIndex);

                if (openingIndex == -1)
                {
                    return "No <upcase> tag found.";
                }

                int closingIndex = text.IndexOf(closingTag, openingIndex + openingTag.Length);

                if (closingIndex == -1)
                {
                    return "No </upcase> tag found.";
                }

                string toUpper = text.Substring(openingIndex + openingTag.Length, closingIndex - (openingIndex + openingTag.Length));

                text = text.Replace(toUpper, toUpper.ToUpper());
                text = text.Remove(closingIndex, closingTag.Length);
                text = text.Remove(openingIndex, openingTag.Length);
                
                startIndex = closingIndex + 1;
            }

            return text;
        }

        private static void DisplayExample(string text, string newText)
        {
            StringBuilder print = new StringBuilder();
            string boderd = new string('-', 60);

            print.AppendLine("Problem 5. Parse tags \nYou are given a text. Write a program that changes the text in all regions surrounded by the tags `<upcase>` and `</upcase>` to upper-case. \nThe tags cannot be nested.\n");

            // print
            print.AppendLine("Example:")
                .AppendLine(boderd)
                .AppendFormat("{0}\n", text)
                .AppendLine(boderd)
                .AppendFormat("{0}\n", newText)
                .AppendLine(boderd);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter text: ");
            text = Console.ReadLine();

            newText = ChangeToUpper(text);

            // print
            print.Clear()
                .AppendLine(boderd)
                .AppendFormat("{0}\n", text)
                .AppendLine(boderd)
                .AppendFormat("{0}\n", newText)
                .AppendLine(boderd);

            Console.Write(print.ToString());
        }
    }
}
