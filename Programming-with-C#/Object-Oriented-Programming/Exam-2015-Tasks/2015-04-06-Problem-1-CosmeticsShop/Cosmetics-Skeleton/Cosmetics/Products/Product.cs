namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 10;
        private const int MinBrandLength = 2;
        private const int MaxBrandLength = 10;

        private const string BrandProperty = "Product brand";
        private const string NameProperty = "Product name";
        private const string PriceProperty = "Price";
        private const string GenderProperty = "Gender";

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, NameProperty));
                Validator.CheckIfStringLengthIsValid(value, MaxNameLength, MinNameLength, string.Format(GlobalErrorMessages.InvalidStringLength, NameProperty, MinNameLength, MaxNameLength));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, BrandProperty));
                Validator.CheckIfStringLengthIsValid(value, MaxBrandLength, MinBrandLength, string.Format(GlobalErrorMessages.InvalidStringLength, BrandProperty, MinBrandLength, MaxBrandLength));                
                this.brand = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, PriceProperty));
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, GenderProperty));
                this.gender = value;
            }
        }

        public virtual string Print()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("- {0} - {1}:", this.Brand, this.Name)
                .AppendLine()
                .AppendFormat("  * Price: ${0}", this.Price)
                .AppendLine()
                .AppendFormat("  * For gender: {0}", this.Gender)
                .AppendLine();
            
            return sb.ToString();
        }
    }
}
