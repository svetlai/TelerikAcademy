namespace ADO.AddNewProduct
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// 4. Write a method that adds a new product in the products table in the Northwind database. 
    /// Use a parameterized SQL command.
    /// </summary>
    public class AddNewProduct
    {
        public static void Main()
        {
            const string SqlConnection = "Server=.\\; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(SqlConnection);
            dbCon.Open();

            Product product = new Product("Carling", 1, 1, "6 pack", 3.50m, 1, 1, 1, false);

            AddProduct(dbCon, product);

            dbCon.Close();
        }

        public static void AddProduct(SqlConnection dbCon, Product product)
        {
            using (dbCon)
            {
                string queryInsert = "INSERT INTO Products ([ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], " +
                                    "[UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) " +
                                    "VALUES (@productName, @supplierId, @categoryID, @quantityPerUnit, " +
		                            "@unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)";
                SqlCommand cmdAddNewProduct = new SqlCommand(queryInsert, dbCon);

                cmdAddNewProduct.Parameters.AddWithValue("@productName", product.ProductName);
                cmdAddNewProduct.Parameters.AddWithValue("@supplierId", product.SuplierId);
                cmdAddNewProduct.Parameters.AddWithValue("@categoryID", product.CategoryId);
                cmdAddNewProduct.Parameters.AddWithValue("@quantityPerUnit", product.QuantityPerUnit);
                cmdAddNewProduct.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
                cmdAddNewProduct.Parameters.AddWithValue("@unitsInStock", product.UnitsInStock);
                cmdAddNewProduct.Parameters.AddWithValue("@unitsOnOrder", product.UnitsOnOrder);
                cmdAddNewProduct.Parameters.AddWithValue("@reorderLevel", product.ReorderLevel);
                cmdAddNewProduct.Parameters.AddWithValue("@discontinued", product.Discontinued);

                cmdAddNewProduct.ExecuteNonQuery();
            }
        }
    }
}
