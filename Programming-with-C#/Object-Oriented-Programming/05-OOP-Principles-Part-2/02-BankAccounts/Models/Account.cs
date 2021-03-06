﻿namespace BankAccounts.Models
{
    using System;
    using System.Text;

    using BankAccounts.Contracts;

    public abstract class Account : IAccount, ICalculateInterest, IDeposit
    {
        private const string NegativeRateExceptionMsg = "Montly interest rate cannot be negative.";

        private Customer customer;
        private decimal balance;
        private decimal monthlyInterestRate;

        protected Account(Customer customer, decimal balance, decimal monthlyInterestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            private set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                this.balance = value;
            }
        }

        public decimal MonthlyInterestRate
        {
            get
            {
                return this.monthlyInterestRate;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeRateExceptionMsg);
                }

                this.monthlyInterestRate = value;
            }
        }

        public AccountType AccountType { get; protected set; }

        public abstract void Deposit(decimal sum);

        public virtual decimal CalculateInterest(int months)
        {
            return this.MonthlyInterestRate * months;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Account: " + this.AccountType)
                .AppendLine("Balance: " + this.Balance)
                .AppendLine("Monthly interest rate: " + this.MonthlyInterestRate)
                .Append("Customer: " + Customer.ToString());

            return sb.ToString();
        }
    }
}
