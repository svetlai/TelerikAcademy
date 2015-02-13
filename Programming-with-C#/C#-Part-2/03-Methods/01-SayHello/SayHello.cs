namespace SayHello
{
    using System;

    /// <summary>
    /// Problem 1. Say Hello
    /// Write a method that asks the user for his name and prints `�Hello, <name>�`
    /// Write a program to test this method.
    /// </summary>
    public class Hello
    {
        public static void Main()
        {
            Console.WriteLine("Problem 1. Say Hello \nWrite a method that asks the user for his name and prints `Hello, <name>` \nWrite a program to test this method.\n");

            SayHello();
        }

        public static void SayHello()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
