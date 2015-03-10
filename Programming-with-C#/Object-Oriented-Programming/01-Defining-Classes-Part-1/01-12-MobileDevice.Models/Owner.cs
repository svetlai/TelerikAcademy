namespace MobileDevice.Models
{
    using System;

    public class Owner
    {
        private const string NameNullExceptionMessage = "Name cannot be empty.";

        private string firstName;
        private string lastName;
        private string address;

        public Owner(string firstName, string lastName)
            : this(firstName, lastName, null)
        {
        }

        public Owner(string firstName, string lastName, string address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameNullExceptionMessage);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameNullExceptionMessage);
                }

                this.lastName = value;
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
    }
}
