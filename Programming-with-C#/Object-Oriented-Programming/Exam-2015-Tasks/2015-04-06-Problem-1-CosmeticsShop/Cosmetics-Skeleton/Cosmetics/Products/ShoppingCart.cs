namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private const string ShoppingCartProduct = "Product";

        private ICollection<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, ShoppingCartProduct));
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, ShoppingCartProduct));
            this.products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            if (this.products.Contains(product))
            {
                return true;
            }

            return false;
        }

        public decimal TotalPrice()
        {
            return this.products
                .Select(p => p.Price)
                .Sum();
        }
    }
}
