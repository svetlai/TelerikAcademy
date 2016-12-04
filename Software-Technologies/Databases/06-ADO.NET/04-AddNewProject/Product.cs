using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.AddNewProduct
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string productName, int suplierId, int CategoryId, string quantityPerUnit, 
            decimal unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            this.ProductName = productName;
            this.SuplierId = suplierId;
            this.CategoryId = CategoryId;
            this.QuantityPerUnit = quantityPerUnit;
            this.UnitPrice = unitPrice;
            this.UnitsInStock = unitsInStock;
            this.UnitsOnOrder = unitsOnOrder;
            this.ReorderLevel = reorderLevel;
            this.Discontinued = discontinued;
        }

        public string ProductName { get; set; }

        public int SuplierId { get; set; }

        public int CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
