namespace TelerikAcademyRSS
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Using JSON.NET and the Telerik Academy Forums RSS feed implement the following:
    /// </summary>
    public class RSSParser
    {
        public static void Main()
        {
            //1. The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss 
            //2. Download the content of the feed programmatically
            //You can use WebClient.DownloadFile()

            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://forums.academy.telerik.com/feed/qa.rss", "telerik-academy-rss.xml");

            //3. Parse the XML from the feed to JSON
            var xmlDoc = XDocument.Load("telerik-academy-rss.xml");
            string json = JsonConvert.SerializeXNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);

            //4. Using LINQ-to-JSON select all the question titles and print them to the console
            var jsonObj = JObject.Parse(json);
            var titles = jsonObj["rss"]["channel"]["item"].Select(i => i["title"]).ToList();

            foreach (var title in titles)
            {
                Console.WriteLine(title.ToString());
            }

            //5. Parse the JSON string to POCO
            //var template = new
            //{
            //    Title = "",
            //    Link = "",
            //    Description = "",
            //    Category = "",
            //    Date = ""
            //};

            //var items = JsonConvert.DeserializeAnonymousType(json, template);
            
            var items = JsonConvert.DeserializeObject<List<Item>>(jsonObj["rss"]["channel"]["item"].ToString());
            
            //6. Using the parsed objects create a HTML page that lists all questions from the RSS their categories 
            //and a link to the question's page
            StringBuilder result = new StringBuilder();
            result.Append("<!DOCTYPE html><html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta charset=\"utf-8\" /><title>Telerik RSS</title></head><body>");

            foreach (var item in items)
            {
                result.Append("<section>");
                result.Append("<h1>" + item.Title + "</h1>");
                result.Append("<h3>Category: " + item.Category + "</h3>");
                result.Append(item.Description);
                result.Append("<a href=\"" + item.Link + "\">Link</a>");
                result.Append("</section>");
            }

            result.Append("</body></html>");
            var htmlContent = result.ToString();

            StreamWriter writer = new StreamWriter("telerik-academy-rss.html");

            using (writer)
            {
                writer.Write(htmlContent);
            }
        }
    }
}
