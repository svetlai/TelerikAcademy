namespace MobileDevice.Models
{
    using System;

    public class Manufacturer
    {
        private const string NameNullExceptionMessage = "Manufacturer's name cannot be empty.";
        private const string CountryNullExceptionMessage = "Manufacturer's country cannot be empty.";

        private string name;
        private string country;
        private string address;
        private string phoneNumber;

        public Manufacturer(string name, string country)
            : this(name, country, null, null)
        {
        }

        public Manufacturer(string name, string country, string address, string phoneNumber)
        {
            this.Name = name;
            this.Country = country;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameNullExceptionMessage);
                }

                this.name = value;
            }
        }

        public string Country 
        {
            get
            {
                return this.country;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(CountryNullExceptionMessage);
                }

                this.country = value;
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
    }
}
