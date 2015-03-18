namespace BankAccounts.Contracts
{
    using BankAccounts.Models;

    public interface IAccount
    {
        Customer Customer { get; }

        decimal Balance { get; }

        decimal MonthlyInterestRate { get; }
    }
}
