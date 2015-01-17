namespace EmployeeData
{
    using System;

    /// <summary>
    /// Problem 10. Employee Data
    /// A marketing company wants to keep record of its employees. Each record would have the following characteristics:
    /// First name
    /// Last name
    /// Age (0...100)
    /// Gender (m or f)
    /// Personal ID number (e.g. 8306112507)
    /// Unique employee number (27560000…27569999)
    /// Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names. Print the data at the console.
    /// </summary>
    public class EmployeeData
    {
        public static void Main()
        {
            string firstName = "Bob";
            string familyName = "Bobson";
            byte age = 12;
            char gender = 'm';
            long idNumber = 123456;
            uint employeeNumber = 27560000;

            Console.WriteLine("Name: {0} {1}", firstName, familyName);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("Gender: {0}", gender);
            Console.WriteLine("ID Number: {0}", idNumber);
            Console.WriteLine("Employee Number: {0}", employeeNumber);
            Console.WriteLine();
        }
    }
}
