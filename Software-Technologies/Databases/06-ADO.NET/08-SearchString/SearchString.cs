namespace ADO.SearchString
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// 8. Write a program that reads a string from the console and finds all products that contain this string. 
    /// Ensure you handle correctly characters like ', %, ", \ and _.
    /// </summary>
    class SearchString
    {
        static void Main()
        {
            Console.WriteLine("Type a string to search for: ");
            string toSearch = EscapeCharacters(Console.ReadLine());

            string sqlConnectionString = "Server=.\\; Database=Northwind; Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(sqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                string queryProducts = "SELECT ProductName FROM Products WHERE ProductName LIKE @toSearch";
                SqlCommand cmdProducts = new SqlCommand(queryProducts, dbCon);

                cmdProducts.Parameters.AddWithValue("@toSearch", "%" + toSearch + "%");

                Console.WriteLine("Products found: ");
                Console.WriteLine();

                SqlDataReader reader = cmdProducts.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine(productName);
                    }
                }
            }

            dbCon.Close();
        }
            
            private static string EscapeCharacters(string input)
            {
                input = input.Replace(@"\", @"[\]");
                input = input.Replace(@"%", @"[%]");
                input = input.Replace(@"_", @"[_]");
                input = input.Replace(@"'", @"[']");
                return input;
            }

    }
}
