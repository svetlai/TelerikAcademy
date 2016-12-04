namespace ADO.ReadExcel
{
    using System;
    using System.Data.OleDb;

    /// <summary>
    /// 6. Create an Excel file with 2 columns: name and score: 
    /// Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score 
    /// row by row.
    /// </summary>
    public class ReadFromExcel
    {
        public static void Main()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=../../Scores.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""";

            OleDbConnection excelConn = new OleDbConnection(connectionString);

            excelConn.Open();

            using (excelConn)
            {
                string querySelect = "Select * FROM [Sheet1$]";
                OleDbCommand cmd = new OleDbCommand(querySelect, excelConn);

                OleDbDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double score = (double)reader["Score"];
                        Console.WriteLine("{0}: {1}", name, score);
                    }
                }
            }

            excelConn.Close();
        }
    }
}
