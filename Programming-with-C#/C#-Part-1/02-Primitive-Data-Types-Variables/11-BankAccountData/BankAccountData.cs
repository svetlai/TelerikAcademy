namespace BankAccountData
{
    using System;

    /// <summary>
    /// Problem 11. Bank Account Data
    /// A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
    /// Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.
    /// </summary>
    public class BankAccountData
    {
        public static void Main()
        {
            string firstName = "Fred";
            string middleName = "J.";
            string lastName = "Flinstone";
            decimal balance = 1254.12M;
            string bankName = "DSK Bank";
            string iban = "BG22STSA12121212121212";
            string bic = "BGSFSTSA";
            ulong[] creditCardNumbers = 
            {
                123456,
                456789,
                789123
            };

            Console.WriteLine("Name: {0} {1} {2}", firstName, middleName, lastName);
            Console.WriteLine("Balance: {0}", balance);
            Console.WriteLine("Bank: {0}", bankName);
            Console.WriteLine("IBAN: {0}", iban);
            Console.WriteLine("BIC: {0}", bic);

            for (int i = 0; i < creditCardNumbers.Length; i++)
            {
                Console.WriteLine("Credit card number: {0}", creditCardNumbers[i]);
            }

            Console.WriteLine();
        }
    }
}
