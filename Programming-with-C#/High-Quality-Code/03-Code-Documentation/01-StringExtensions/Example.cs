﻿// <copyright file="Example.cs" company="Telerik Academy">
// Generated by Telerik Academy
// </copyright>
namespace CodeDocumentation
{
    using System;

    using Telerik.ILS.Common;

    /// <summary>
    /// Examples of StringExtensions class
    /// </summary>
    public class Example
    {
        /// <summary>
        /// Method to show examples
        /// </summary>
        public static void Main()
        {
            string academy = "Telerik Academy";
            Console.WriteLine(academy.ToMd5Hash());

            Console.WriteLine("ok".ToBoolean());

            Console.WriteLine("1".ToShort());

            Console.WriteLine("1".ToInteger());

            Console.WriteLine("1".ToLong());

            Console.WriteLine("someString".ToDateTime());

            Console.WriteLine("hello".CapitalizeFirstLetter());

            Console.WriteLine("good morning world.".GetStringBetween("good", "world", 0));

            Console.WriteLine("здрасти".ConvertCyrillicToLatinLetters());

            Console.WriteLine("zdrasti".ConvertLatinToCyrillicKeyboard());

            Console.WriteLine("pesho&$%123".ToValidUsername());

            Console.WriteLine("Some invaliд **£$file name.cs".ToValidLatinFileName());

            Console.WriteLine("someString".GetFirstCharacters(4));

            Console.WriteLine("file-name.js".GetFileExtension());

            Console.WriteLine("jpg".ToContentType());

            var arr = "hi".ToByteArray();
            Console.WriteLine(string.Join(" ", arr));  
        }
    }
}
