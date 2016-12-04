namespace ADO.ProductCategories
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// 3. Write a program that retrieves from the Northwind database all product categories and the names of the 
    /// products in each category. Can you do this with a single SQL query (with table join)?
    /// </summary>
    public class ProductCategories
    {
        public static void Main()
        {
            string sqlConnection = "Server=.\\; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(sqlConnection);
            dbCon.Open();

            using (dbCon)
            {
                Console.WriteLine("Products in category: ");
                Console.WriteLine();
                string queryJoin = "SELECT c.CategoryName, p.ProductName FROM Categories c INNER JOIN Products p ON c.CategoryID = p.CategoryID";
                SqlCommand cmdJoin = new SqlCommand(queryJoin, dbCon);
                SqlDataReader reader = cmdJoin.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string product = (string)reader["ProductName"];
                        Console.WriteLine("{0}: {1}", categoryName.ToUpper(), product);
                    }
                }
            }

            dbCon.Close();
        }
    }
}
