namespace Helper
{
    using System;
    using System.IO;

    public static class HelperMethods
    {
        public static void DisplayTaskDescription(string path)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(ReadTaskDescription(path));
            Console.WriteLine(Constants.TaskDescriptionEndBorder);
            Console.ResetColor();
        }

        private static string ReadTaskDescription(string path)
        {
            string taskDescription = string.Empty;
            try
            {
                taskDescription = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return taskDescription;
        }
    }
}
