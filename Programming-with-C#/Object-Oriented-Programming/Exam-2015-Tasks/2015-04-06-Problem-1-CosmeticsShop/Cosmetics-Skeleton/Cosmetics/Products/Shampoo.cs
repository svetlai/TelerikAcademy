namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IShampoo, IProduct
    {
        private const string UsageProperty = "Shampoo usage";
        private const string MillilitersProperty = "Shampoo milliliters";

        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public override decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, MillilitersProperty));
                this.milliliters = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, UsageProperty));
                this.usage = value;
            }
        }

        public override string Print()
        {
            var sb = new StringBuilder();
            sb.Append(base.Print())
                .AppendFormat("  * Quantity: {0} ml", this.Milliliters)
                .AppendLine()
                .AppendFormat("  * Usage: {0}", this.Usage);

            return sb.ToString();
        }
    }
}
