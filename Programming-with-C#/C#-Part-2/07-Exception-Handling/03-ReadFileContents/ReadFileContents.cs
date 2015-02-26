namespace ReadFileContents
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Problem 3. Read file contents
    /// Write a program that enters file name along with its full file path (e.g. `C:\WINDOWS\win.ini`), reads its contents and prints it on the console.
    /// Find in MSDN how to use `System.IO.File.ReadAllText(�)`.Be sure to catch all possible exceptions and print user-friendly error messages.
    /// </summary>
    public class ReadFileContents
    {
        public static void Main()
        {
            Console.WriteLine("Problem 3. Read file contents \nWrite a program that enters file name along with its full file path (e.g. `C:\\WINDOWS\\win.ini`), reads its contents and prints it on the console. \nFind in MSDN how to use `System.IO.File.ReadAllText(�)`.Be sure to catch all possible exceptions and print user-friendly error messages.\n");
            Console.Write("Please enter path to file: ");

            // path to test with: ../../joke.txt
            string path = Console.ReadLine();
            string contents = string.Empty;

            contents = ReadFile(path);
           
            Console.WriteLine(contents);
        }

        public static string ReadFile(string path)
        {
            StringBuilder contents = new StringBuilder();
            try
            {
                contents.Append(File.ReadAllText(path));  
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
            catch (PathTooLongException e)
            {
                return e.Message;
            }
            catch (DirectoryNotFoundException e)
            {
                return e.Message;
            }
            catch (IOException e)
            {
                return e.Message;
            }
            catch (UnauthorizedAccessException e)
            {
                return e.Message;
            }
            catch (NotSupportedException e)
            {
                return e.Message;
            }

            // or if all are handled the same way simply:
            // catch (Exception e)
            // {
            //     return e.Message);
            //     return;
            // }
                     
            return contents.ToString();
        }
    }
}
