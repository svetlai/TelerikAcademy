namespace ADO.AppendNewRowExcel
{
    using System;
    using System.Data.OleDb;

    /// <summary>
    /// 7. Implement appending new rows to the Excel file.
    /// </summary>
    public class AppendRowToExcel
    {
        public static void Main()
        {
            string pathToFile = @"../../Scores.xlsx";

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=" + pathToFile + @";Extended Properties=""Excel 12.0 XML;HDR=Yes""";

            OleDbConnection excelConn = new OleDbConnection(connectionString);

            excelConn.Open();

            using (excelConn)
            {
                string queryInsert = @"INSERT INTO [Sheet1$] ([Name], [Score]) VALUES (@Name, @Score)";

                OleDbCommand cmd = new OleDbCommand(queryInsert, excelConn);

                string name = "Georgi Georgiev";
                double score = 20;

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@score", score);

                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Row inserted successfully.");
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error occured: " + exception);
                }
            }

            excelConn.Close();
        }
    }
}
