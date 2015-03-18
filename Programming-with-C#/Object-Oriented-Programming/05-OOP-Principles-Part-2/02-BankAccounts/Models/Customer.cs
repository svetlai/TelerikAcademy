namespace BankAccounts.Models
{
    using System;
    using System.Collections.Generic;

    public abstract class Customer
    {
        private const string NameNullExceptionMsg = "A name must be specified.";
        private const string NameLengthExceptionMsg = "Name must be between 2 and 50 characters long.";

        private CustomerType customerType;
        private string name;
        private string address;
        private string email;
        private string phoneNumber;
        private ICollection<Account> accounts;

        protected Customer(string name, string address, string email, string phoneNumber)
        {
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Accounts = new List<Account>();
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

        public CustomerType CustomerType
        {
            get
            {
                return this.customerType;
            }

            protected set
            {
                this.customerType = value;
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

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                this.phoneNumber = value;
            }
        }

        public ICollection<Account> Accounts
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

        public override string ToString()
        {
            return this.Name + " - " + this.CustomerType;
        }
    }
}
