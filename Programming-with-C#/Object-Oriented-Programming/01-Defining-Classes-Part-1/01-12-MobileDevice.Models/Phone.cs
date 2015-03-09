namespace MobileDevice.Models
{
    using System;
    using System.Text;

    public class Phone
    {
        private const string ModelNullExceptionMessage = "Model cannot be empty.";
        private const string ManufacturerNullExceptionMessage = "Manufacturer cannot be empty.";
        private const string PriceNegativeExceptionMessage = "Price cannot be less than 0.";

        private string model;
        private Manufacturer manufacturer;
        private decimal? price;

        public Phone(string model, Manufacturer manufacturer)
            : this(model, manufacturer, null)
        {
        }

        public Phone(string model, Manufacturer manufacturer, decimal? price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
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

            sb.AppendFormat("Model: {0}", this.model);
            sb.AppendLine();
            sb.AppendFormat("Manufacturer: {0}", this.manufacturer.Name);
            sb.AppendLine();

            if (this.price != null)
            {
                sb.AppendFormat("Price: {0}", this.price);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
