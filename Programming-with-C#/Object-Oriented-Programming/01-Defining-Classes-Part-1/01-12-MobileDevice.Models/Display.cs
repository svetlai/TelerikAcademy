namespace MobileDevice.Models
{
    using System;

    public class Display
    {
        private const string SizeNegativeExceptionMessage = "Display size cannot be negative.";
        private const string NumberOfColorsNegativeExceptionMessage = "Number of colors cannot be negative.";

        private double size;
        private uint numberOfColors;

        public Display()
        {
        }

        public Display(double size, uint numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public double Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(SizeNegativeExceptionMessage);
                }

                this.size = value;
            }
        }

        public uint NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NumberOfColorsNegativeExceptionMessage);
                }

                this.numberOfColors = value;
            }
        }
    }
}
