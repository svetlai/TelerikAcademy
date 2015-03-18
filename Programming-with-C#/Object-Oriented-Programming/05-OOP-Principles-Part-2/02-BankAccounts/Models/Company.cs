namespace BankAccounts.Models
{
    public class Company : Customer
    {
        private string contactPersonName;

        public Company(string name)
            : this(name, string.Empty, string.Empty, string.Empty, string.Empty)
        {           
        }

        public Company(string name, string address)
            : this(name, address, string.Empty, string.Empty, string.Empty)
        {
        }

        public Company(string name, string address, string email)
            : this(name, address, email, string.Empty, string.Empty)
        {
        }

        public Company(string name, string address, string email, string phoneNumber, string contactPersonName)
            : base(name, address, email, phoneNumber)
        {
            this.ContactPersonName = contactPersonName;
            this.CustomerType = CustomerType.Company;
        }

        public string ContactPersonName
        {
            get
            {
                return this.contactPersonName;
            }

            set
            {
                this.contactPersonName = value;
            }
        }
    }
}
