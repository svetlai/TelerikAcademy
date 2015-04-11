namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Category : ICategory
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 15;

        private const string CategoryName = "Category name";
        private const string CategoryProduct = "Product";
        private const string ProductDoesNotexistExcMsg = "Product {0} does not exist in category {1}!";

        private string name;
        private ICollection<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, CategoryName));
                Validator.CheckIfStringLengthIsValid(value, MaxNameLength, MinNameLength, string.Format(GlobalErrorMessages.InvalidStringLength, CategoryName, MinNameLength, MaxNameLength));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, CategoryProduct));
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(ProductDoesNotexistExcMsg, cosmetics.Name, this.Name));
            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            var sb = new StringBuilder();
            var productString = this.products.Count == 1 ? "product" : "products";

            sb.AppendFormat("{0} category - {1} {2} in total", this.Name, this.products.Count, productString)
                .AppendLine();

            var sortedProducts = this.products
                .OrderBy(p => p.Brand)
                .ThenByDescending(p => p.Price);

            foreach (var product in sortedProducts)
            {
                sb.AppendLine(product.Print());
            }

            return sb.ToString().Trim();
        }
    }
}
