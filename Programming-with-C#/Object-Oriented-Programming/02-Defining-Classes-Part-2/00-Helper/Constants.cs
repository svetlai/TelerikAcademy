namespace Helper
{
    using System;

    public class Constants
    {
        public const string PathToTaskDescription = "../../tasks.md";

        public static readonly string Border = new string('-', Console.WindowWidth - 1);
        public static readonly string TaskDescriptionEndBorder = new string('=', Console.WindowWidth);
    }
}
