namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Chair : Furniture, IChair
    {
        private const string NoLegsExcMsg = "Chair must have at least one leg or you'd be sitting on the floor.";

        private int numberOfLegs;

        public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(NoLegsExcMsg);
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Legs: {1}", base.ToString(), this.NumberOfLegs);
        }
    }
}
