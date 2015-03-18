namespace BankAccounts
{
    using System;
    using System.Text;

    using BankAccounts.Models;
    using Helper;

    public class BankAccountsTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestBank();
        }

        private static void TestBank()
        {
            var sb = new StringBuilder();

            var bank = new Bank("Tilirik Bank");

            var peshoCompany = new Company("Pesho Company");
            var peshoIndividual = new IndividualCustomer("Pesho");

            var accounts = new Account[] 
            {
                new DepositAccount(peshoIndividual, 500m, 6.5m),
                new LoanAccount(peshoCompany, 20000m, 7.8m),
                new MortgageAccount(peshoIndividual, 50000m, 2.8m)
            };

            sb.AppendLine("Initial state: \n");

            foreach (var account in accounts)
            {
                bank.AddAccount(account);
            }

            sb.Append(bank.ToString());

            sb.AppendLine("Withdraw 600 from the deposit account:");

            var depositAccount = (DepositAccount)accounts[0];

            try
            {
                depositAccount.Withdraw(600);
            }
            catch (Exception e)
            {
                sb.AppendLine(e.Message);
            }

            sb.AppendLine("\nWithdraw 300 from the deposit account.");

            depositAccount.Withdraw(300);
            accounts[0] = depositAccount;

            sb.AppendLine("Deposit 200 in each account: \n");

            foreach (var account in accounts)
            {
                account.Deposit(200);
            }

            sb.Append(bank.ToString());

            sb.AppendLine("Calculate interest for 12 months: ");
            var interest = accounts[2].CalculateInterest(12);

            sb.AppendFormat("Individual mortgage account yearly interest: {0}", interest)
                .AppendLine();

            Console.WriteLine(sb.ToString());
        }
    }
}
