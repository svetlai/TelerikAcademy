namespace BankAccounts.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bank
    {
        private const string NameNullExceptionMsg = "A name must be specified.";
        private const string NameLengthExceptionMsg = "Name must be between 2 and 50 characters long.";

        private string name;
        private string address;
        private ICollection<Account> accounts;

        public Bank(string name)
            : this(name, string.Empty)
        {
        }

        public Bank(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.Accounts = new HashSet<Account>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameNullExceptionMsg);
                }

                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentException(NameLengthExceptionMsg);
                }

                this.name = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        public virtual ICollection<Account> Accounts
        {
            get
            {
                return this.accounts;
            }

            private set
            {
                this.accounts = value;
            }
        }

        public void AddAccount(Account account)
        {
            this.Accounts.Add(account);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Name);

            foreach (var account in this.Accounts)
            {
                sb.AppendLine(account.ToString())
                    .AppendLine();
            }

            return sb.ToString();
        }
    }
}
