namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10M;
        private readonly decimal initialHeight;

        private bool isConverted;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this.initialHeight = this.Height;
        }

        public bool IsConverted
        {
            get 
            {
                return this.isConverted;
            }

            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.IsConverted = false;
                this.Height = this.InitialHeight;
            }
            else
            {
                this.IsConverted = true;
                this.Height = this.ConvertedHeight;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, State: {1}", base.ToString(), this.IsConverted ? "Converted" : "Normal");
        }
    }
}
