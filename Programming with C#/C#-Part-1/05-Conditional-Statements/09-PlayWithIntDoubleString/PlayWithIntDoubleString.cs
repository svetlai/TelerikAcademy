namespace PlayWithIntDoubleString
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 9. Play with Int, Double and String
    /// Write a program that, depending on the userâ€™s choice, inputs an `int`, `double` or `string` variable.
    /// If the variable is `int` or `double`, the program increases it by one.
    /// If the variable is a `string`, the program appends `*` at the end.
    /// Print the result at the console. Use switch statement.
    /// Example 1:
    /// | program                | user  |
    /// |------------------------|-------|
    /// | Please choose a type:  |       |
    /// | 1 --> int              |       |
    /// | 2 --> double           | 3     |
    /// | 3 --> string           |       |
    /// |                        |       |
    /// | Please enter a string: | hello |
    /// |                        |       |
    /// | hello*                 |       |
    /// Example 2:
    /// | program                | user |
    /// |------------------------|------|
    /// | Please choose a type:  |      |
    /// | 1 --> int              |      |
    /// | 2 --> double           | 2    |
    /// | 3 --> string           |      |
    /// |                        |      |
    /// | Please enter a double: | 1.5  |
    /// |                        |      |
    /// | 2.5                    |      |
    /// </summary>
    public class PlayWithIntDoubleString
    {
        public static void Main()
        {
            Console.WriteLine("Problem 9. Play with Int, Double and String \nWrite a program that, depending on the userâ€™s choice, inputs an `int`, `double` or `string` variable. If the variable is `int` or `double`, the program increases it by one. If the variable is a `string`, the program appends `*` at the end. Print the result at the console. Use switch statement.\n");

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Please choose a type: \n1 --> int \n2 --> double \n3 --> string");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.Write("Please enter an integer: ");
                    int intNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("New value: {0}", intNumber + 1);
                    break;
                case "2":
                    Console.Write("Please enter an double: ");
                    double doubleNumber = double.Parse(Console.ReadLine());
                    Console.WriteLine("New value: {0}", doubleNumber + 1);
                    break;
                case "3":
                    Console.Write("Please enter an string: ");
                    string stringLine = Console.ReadLine();
                    Console.WriteLine("New value: {0}", stringLine + "*");
                    break;
            }
        }
    }
}
