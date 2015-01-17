namespace PrintCompanyInformation
{
    using System;

    /// <summary>
    /// Problem 2. Print Company Information
    /// A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number
    /// Write a program that reads the information about a company and its manager and prints it back on the console.
    /// Example input:
    /// program	user
    /// Company name:	Telerik Academy
    /// Company address:	31 Al. Malinov, Sofia
    /// Phone number:	+359 888 55 55 555
    /// Fax number:	2
    /// Web site:	http://telerikacademy.com/
    /// Manager first name:	Nikolay
    /// Manager last name:	Kostov
    /// Manager age:	25
    /// Manager phone:	+359 2 981 981
    /// 
    /// Example output:
    /// Telerik Academy
    /// Address: 231 Al. Malinov, Sofia
    /// Tel. +359 888 55 55 555
    /// Fax: (no fax)
    /// Web site: http://telerikacademy.com/
    /// Manager: Nikolay Kostov (age: 25, tel. +359 2 981 981)  
    /// </summary>
    public class PrintCompanyInformation
    {
        public static void Main()
        {
            Console.WriteLine("Problem 2. Print Company Information \nA company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints it back on the console.");
            Console.WriteLine();

            // Read all the info from the console
            Console.Write("Company name: ");
            string companyName = Console.ReadLine();

            Console.Write("Company address: ");
            string companyAddress = Console.ReadLine();

            Console.Write("Phone number: ");
            string companyPhone = Console.ReadLine();

            Console.Write("Fax number: ");
            string companyFax = Console.ReadLine();

            Console.Write("Web site: ");
            string companyWebSite = Console.ReadLine();

            Console.Write("Manager first name: ");
            string managerFirstName = Console.ReadLine();

            Console.Write("Manager last name: ");
            string managerLastName = Console.ReadLine();

            Console.Write("Manager age: ");
            string managerAgeLine = Console.ReadLine();

            int managerAge;

            if (!int.TryParse(managerAgeLine, out managerAge)
                || managerAge < 0 || managerAge > 150)
            {
                throw new FormatException("Age must be a valid integer number.");
            }

            Console.Write("Manager phone: ");
            string managerPhone = Console.ReadLine();

            Console.WriteLine();

            // Print all the entered info on the console
            Console.WriteLine("{0}", companyName);
            Console.WriteLine("Address: {0}", companyAddress);
            Console.WriteLine("Tel.: {0}", companyPhone);
            Console.WriteLine("Fax: {0}", companyFax != string.Empty ? companyFax : "(no fax)");
            Console.WriteLine("Web site: {0}", companyWebSite);
            Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", managerFirstName, managerLastName, managerAge, managerPhone);
        }
    }
}
