namespace StringsInCSharp
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 1. Strings in C#
    /// Describe the strings in C#.
    /// What is typical for the string data type?
    /// Describe the most important methods of the String class.
    /// </summary>
    public class StringsInCSharp
    {
        public static void Main()
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            string description = "A string is an object of type String whose value is text. Internally, the text is stored as a sequential read-only collection of Char objects.\n";
            string characteristics = "Typical: immutable; reference type;\n";
            string methods = @"1. Contains - Returns a value indicating whether a specified substring occurs within this string.
2. IndexOf()/LastIndexOf() - Reports the zero-based index of the first/last occurrence of the specified string/char in this instance.
3. Join() - Concatenates the elements of an object array, using the specified separator between each element.
4. PadLeft()/PadRight() - Returns a new string that right-aligns the characters in this instance by padding them with spaces on the left/right, for a specified total length.
5. Split() - Returns a string array that contains the substrings in this instance that are delimited by elements of a specified Unicode character array.
6. Replace() - Returns a new string in which all occurrences of a specified string/char in the current instance are replaced with another specified string/char.
7. StartsWith()/EndsWith() - Determines whether the beginning/end of this string instance matches the specified string.
8. ToLower()/ToUpper() - Returns a copy of this string converted to lowercase/uppercase.
9. Trim() - Removes all leading and trailing white-space characters from the current String object.
10. Substring() - Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.

More at: https://msdn.microsoft.com/en-us/library/system.string_methods%28v=vs.110%29.aspx
";
            print.AppendLine("Problem 1. Strings in C# \nDescribe the strings in C#. \nWhat is typical for the string data type? \nDescribe the most important methods of the String class.\n")
                .AppendLine(description)
                .AppendLine(characteristics)
                .AppendLine(methods);

            Console.Write(print.ToString());
        }
    }
}
