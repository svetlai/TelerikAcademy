namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, ITable
    {
        private const string NegativeLengthExcMsg = "Length must be a positve number.";
        private const string NegativeWidthExcMsg = "Width must be a positve number.";

        private decimal length;
        private decimal width;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Width = width;
            this.Length = length;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NegativeLengthExcMsg);
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NegativeWidthExcMsg);
                }

                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.Width * this.Length;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Length: {1}, Width: {2}, Area: {3}", base.ToString(), this.Length, this.Width, this.Area);
        }
    }
}
