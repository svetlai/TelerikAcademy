namespace ReadLargeCollection
{
    using System;

    public class Product : IComparable<Product>
    {
        private decimal price;

        public Product()
        {
        }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price 
        { 
            get
            {
                return this.price;
            }
            
            set
            {
                this.price = value;
            }
        }

        public int CompareTo(Product other)
        {
            return this.price.CompareTo(other.price);
        }
    }
}
