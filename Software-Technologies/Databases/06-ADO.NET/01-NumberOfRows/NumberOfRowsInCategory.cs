namespace ADO.NumberOfRows
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// 1. Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the 
    /// Categories table.
    /// </summary>
    public class NumberOfRowsInCategory
    {
        public static void Main()
        {
            string sqlConnectionString = "Server=.\\; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(sqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                string queryCount = "SELECT COUNT(*) FROM Categories";
                SqlCommand cmdCount = new SqlCommand(queryCount, dbCon);

                int categoriesCount = (int)cmdCount.ExecuteScalar();

                Console.WriteLine("Categories row count: {0} ", categoriesCount);
            }

            dbCon.Close();
        }
    }
}
