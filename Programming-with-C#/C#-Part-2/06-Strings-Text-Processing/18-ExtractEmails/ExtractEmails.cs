namespace ExtractEmails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using System.Text;

    /// <summary>
    /// Problem 18. Extract e-mails
    /// Write a program for extracting all email addresses from given text.
    /// All sub-strings that match the format `<identifier>@<host>…<domain>` should be recognized as emails.
    /// </summary>
    public class ExtractEmails
    {
        private static readonly char[] Separators = new char[] { ' ', ',', '!', '?', ':', ';', '(', ')', '[', ']' };

        public static void Main()
        {
            string text = "Some random text meme@abv.bg with @ random emails will_bo@yahoo.com.";

            var emails = ExtractEmailsFromText(text);

            DisplayExample(text, emails);
        }

        public static List<string> ExtractEmailsFromText(string text)
        {
            var emails = new List<string>();
            var words = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim(new char[] { '.', '-', '_' }))
                .ToList();

            foreach (var word in words)
            {
                if (IsValidEmail(word))
                {
                    emails.Add(word);
                }

                // split
                // int atIndex = word.IndexOf('@');
                // int dotIndex = word.IndexOf('.', atIndex);
                // string identifier = word.Substring(0, atIndex);
                // string host = word.Substring(atIndex + 1, dotIndex - (atIndex + 1));
                // string domain = word.Substring(dotIndex + 1, word.Length - (dotIndex + 1));
                // }
            }

            return emails;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static void DisplayExample(string text, List<string> emails)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 18. Extract e-mails \nWrite a program for extracting all email addresses from given text. \nAll sub-strings that match the format `<identifier>@<host>…<domain>` should be recognized as emails.\n")
                .AppendLine("Example: ")
                .AppendLine(text)
                .AppendLine(border);

            foreach (var email in emails)
            {
                print.AppendLine(email);
            }

            print.AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
