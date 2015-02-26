namespace DownloadFile
{
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Problem 4. Download file
    /// Write a program that downloads a file from Internet (e.g. [Ninja image](http://telerikacademy.com/Content/Images/news-img01.png)) and stores it the current directory.
    /// Find in Google how to download files in C#.
    /// Be sure to catch all exceptions and to free any used resources in the finally block.
    /// </summary>
    public class DownloadFile
    {
        public static void Main()
        {
            Console.WriteLine("Problem 4. Download file \nWrite a program that downloads a file from Internet (e.g. [Ninja image](http://telerikacademy.com/Content/Images/news-img01.png)) and stores it the current directory. \nFind in Google how to download files in C#. \nBe sure to catch all exceptions and to free any used resources in the finally block.\n");
            string sourcePath = "http://telerikacademy.com/Content/Images/news-img01.png";
            string downloadDir = "news-img01.png";

            try
            {
                DownloadFileFromWeb(sourcePath, downloadDir);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e.Message);
            }

            // or if all are handled the same way simply:
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            //     return;
            // }
        }

        public static void DownloadFileFromWeb(string sourcePath, string downloadDir)
        {
            // 'using' will free the resource; no need for .Dispose();
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(sourcePath, downloadDir);
                Console.WriteLine("File was downloaded successfully at {0}", Directory.GetCurrentDirectory());
            }
        }

        // alternative
        // public static void DownloadFile(string sourcePath, string downloadDir)
        // {             
        //      WebClient client = new WebClient();  
        //      try
        //      {                          
        //          client.DownloadFile(sourcePath, downloadDir);
        //      }
        //      catch (Exception e)
        //      {
        //          Console.WriteLine(e.Message);
        //          return;
        //      }
        //      finally
        //      {
        //          client.Dispose();
        //      }
        // }
    }
}
