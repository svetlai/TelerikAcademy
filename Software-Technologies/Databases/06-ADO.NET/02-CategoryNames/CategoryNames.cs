namespace ADO.CategoryNames
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// 2. Write a program that retrieves the name and description of all categories in the Northwind DB.
    /// </summary>
    public class CategoryNames
    {
        public static void Main()
        {
            string sqlConnectionString = "Server=.\\; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(sqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                Console.WriteLine("Category names: ");

                string queryCategories = "SELECT CategoryName, Description FROM Categories";
                SqlCommand cmdCategories = new SqlCommand(queryCategories, dbCon);
                SqlDataReader reader = cmdCategories.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0}: {1}", categoryName.ToUpper(), description);
                    }
                }
            }

            dbCon.Close();
        }
    }
}
