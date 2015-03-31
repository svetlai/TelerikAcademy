namespace BankAccounts.Models
{
    public class LoanAccount : Account
    {
        private const int NoInterestIndiviualMonths = 3;
        private const int NoInterestCompanyMonths = 2;

        public LoanAccount(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
            this.AccountType = AccountType.Loan;
        }

        public override void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer.CustomerType == CustomerType.Company)
            {
                if (months <= NoInterestCompanyMonths)
                {
                    return 0;
                }

                return base.CalculateInterest(months - NoInterestCompanyMonths);
            }
            else if (this.Customer.CustomerType == CustomerType.Individual)
            {
                if (months <= NoInterestIndiviualMonths)
                {
                    return 0;
                }

                return base.CalculateInterest(months - NoInterestIndiviualMonths);
            }

            return base.CalculateInterest(months);
        }
    }
}
