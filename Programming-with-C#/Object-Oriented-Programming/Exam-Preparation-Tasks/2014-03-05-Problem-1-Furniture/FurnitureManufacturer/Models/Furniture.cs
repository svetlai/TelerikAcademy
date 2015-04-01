namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private const string EmptyModelExcMsg = "Model cannot be null or empty.";
        private const string ModelLengthExcMsg = "Model cannot be less than 3 characters.";
        private const string NegativePriceExcMsg = "Price must be a positve number.";
        private const string NegativeHeightExcMsg = "Height must be a positve number.";

        private string model;
        private MaterialType materialType;
        private decimal price;
        private decimal height;

        protected Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.MaterialType = materialType;
            this.Price = price;
            this.Height = height;
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
                    throw new ArgumentNullException(EmptyModelExcMsg);
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException(ModelLengthExcMsg);
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.materialType.ToString();
            }
        }

        public MaterialType MaterialType
        {
            get
            {
                return this.materialType;
            }

            private set
            {
                this.materialType = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NegativePriceExcMsg);
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NegativeHeightExcMsg);
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
