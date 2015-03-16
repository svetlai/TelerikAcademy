namespace MobileDevice.Models
{
    using System;
    using System.Text;

    public abstract class Phone
    {
        private const string ModelNullExceptionMessage = "Model cannot be empty.";
        private const string ManufacturerNullExceptionMessage = "Manufacturer cannot be empty.";
        private const string OwnerNullExceptionMessage = "Owner cannot be empty.";
        private const string PriceNegativeExceptionMessage = "Price cannot be less than 0.";

        private string model;
        private Manufacturer manufacturer;
        private Owner owner;
        private decimal? price;

        protected Phone(string model, Manufacturer manufacturer)
            : this(model, manufacturer, null, null)
        {
        }

        protected Phone(string model, Manufacturer manufacturer, decimal? price, Owner owner)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
        }

        public string Model 
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ModelNullExceptionMessage);
                }

                this.model = value;
            }
        }

        public Manufacturer Manufacturer 
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ManufacturerNullExceptionMessage);
                }

                this.manufacturer = value;
            }
        }

        public Owner Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                this.owner = value;
            }
        }

        public decimal? Price 
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(PriceNegativeExceptionMessage);
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Model: {0}", this.Model);
            sb.AppendLine();
            sb.AppendFormat("Manufacturer: {0}", this.Manufacturer.Name);
            sb.AppendLine();

            if (this.price != null)
            {
                sb.AppendFormat("Price: {0}", this.Price);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
