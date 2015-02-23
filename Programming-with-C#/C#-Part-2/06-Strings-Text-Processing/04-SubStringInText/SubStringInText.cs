namespace SubStringInText
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 4. Sub-string in text
    /// Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
    /// Example:
    /// The target sub-string is `in`
    /// The text is as follows:
    /// We are liv**in**g **in** an yellow submar**in**e. We don't have anyth**in**g else. **In**side the submar**in**e is very tight. So we are dr**in**k**in**g all the day. We will move out of it **in** 5 days.
    /// The result is: `9`
    /// </summary>
    public class SubStringInText
    {
        public static void Main()
        {
            string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string subString = "in";

            int count = CountSubstringInText(subString, text);

            DisplayExample(text, subString, count);
        }

        public static int CountSubstringInText(string sub, string text)
        {
            int startIndex = 0;
            int count = 0;

            while (startIndex < text.Length - 1)
            {
                int foundIndex = text.ToLower().IndexOf(sub.ToLower(), startIndex);

                if (foundIndex > -1)
                {
                    count++;
                }
                else
                {
                    break;
                }

                startIndex = foundIndex + 1;
            }

            return count;
        }

        private static void DisplayExample(string text, string subString, int count)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 4. Sub-string in text \nWrite a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).\n");

            // print
            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendFormat("{0}\n", text)
                .AppendLine()
                .AppendFormat("{0,10} | {1,10}\n", "substring", "count")
                .AppendFormat("{0,10} | {1,10}\n", subString, count)
                .AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter text: ");
            text = Console.ReadLine();

            Console.Write("Enter substring: ");
            subString = Console.ReadLine();

            count = CountSubstringInText(subString, text);

            // print
            print.Clear()
                .AppendLine(border)
                .AppendFormat("{0}\n", text)
                .AppendLine()
                .AppendFormat("{0,10} | {1,10}\n", subString, count)
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
