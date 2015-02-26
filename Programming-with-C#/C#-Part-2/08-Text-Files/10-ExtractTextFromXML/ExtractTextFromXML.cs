namespace ExtractTextFromXML
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Problem 10. Extract text from XML
    /// Write a program that extracts from given XML file all the text without the tags.
    /// </summary>
    public class ExtractTextFromXML
    {
        public static void Main()
        {
            Console.WriteLine("Problem 10. Extract text from XML \nWrite a program that extracts from given XML file all the text without the tags.\n");

            string path = "../../xml.xml";

            var text = ExtractTextFromXMLFile(path);
            Console.WriteLine(text);
        }

        public static string ExtractTextFromXMLFile(string path)
        {
            StringBuilder sbText = new StringBuilder();

            var contents = File.ReadAllText(path);

            bool inTag = false;
            char currentSymbol;

            for (int i = 0; i < contents.Length; i++)
            {
                currentSymbol = contents[i];

                if (currentSymbol == '<')
                {
                    inTag = true;
                }
                else if (currentSymbol == '>')
                {
                    inTag = false;
                }

                if (!inTag && currentSymbol != '>')
                {
                    sbText.Append(currentSymbol);
                }
            }

            return sbText.ToString();
        }
    }
}
