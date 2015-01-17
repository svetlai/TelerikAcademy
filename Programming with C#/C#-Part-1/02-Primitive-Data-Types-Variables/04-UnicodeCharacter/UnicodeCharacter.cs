namespace UnicodeCharacter
{
    using System;

    /// <summary>
    /// Problem 4. Unicode Character
    /// Declare a character variable and assign it with the symbol that has Unicode code 42 (decimal) using the \u00XX syntax, and then print it.
    /// Hint: first, use the Windows Calculator to find the hexadecimal representation of 42. The output should be *.
    /// </summary>
    public class UnicodeCharacter
    {
        public static void Main()
        {
            char unicodeChar42 = '\u002A';

            Console.WriteLine("Character with Unicode code 42: {0}", unicodeChar42);
        }
    }
}
