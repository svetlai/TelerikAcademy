namespace BankAccounts.Models
{
    public class MortgageAccount : Account
    {
        private const int DifferentInterestIndividualMonths = 6;
        private const int DifferentInterestCompanyMonths = 12;

        public MortgageAccount(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
            this.AccountType = AccountType.Mortgage;
        }

        public override void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer.CustomerType == CustomerType.Company)
            {
                if (months <= DifferentInterestCompanyMonths)
                {
                    return (this.MonthlyInterestRate * months) / 2;
                }

                return base.CalculateInterest(months - DifferentInterestCompanyMonths);
            }
            else if (this.Customer.CustomerType == CustomerType.Individual)
            {
                if (months <= DifferentInterestIndividualMonths)
                {
                    return 0;
                }

                return base.CalculateInterest(months - DifferentInterestIndividualMonths);
            }

            return base.CalculateInterest(months);
        }
    }
}
