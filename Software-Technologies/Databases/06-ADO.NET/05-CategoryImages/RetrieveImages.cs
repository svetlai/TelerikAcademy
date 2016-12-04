namespace ADO.RetrieveImages
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    /// <summary>
    /// 5. Write a program that retrieves the images for all categories in the Northwind database and stores them as 
    /// JPG files in the file system.
    /// </summary>
    public class RetrieveImages
    {
        public static void Main()
        {
            const string SqlConnectionString = "Server=.\\; Database=Northwind; Integrated Security=true";
            const string FileExtension = ".jpg";
            const string DestinationImageFile = @"..\";

            SqlConnection dbCon = new SqlConnection(SqlConnectionString);
            dbCon.Open();

            ExtractImageFromDB(SqlConnectionString, DestinationImageFile, FileExtension);

            dbCon.Close();
        }

        private static void ExtractImageFromDB(string SqlConnectionString, string DestinationImageFile, string FileExtension)
        {
            SqlConnection dbConn = new SqlConnection(SqlConnectionString);
            dbConn.Open();

            using (dbConn)
            {
                string querySelectImage = "SELECT CategoryID, Picture FROM Categories";
                SqlCommand cmd = new SqlCommand(querySelectImage, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    byte[] image;
                    int categoryId;

                    while (reader.Read())
                    {
                        categoryId = (int)reader["CategoryID"];
                        image = (byte[])reader["Picture"];

                        WriteBinaryFile(image, DestinationImageFile + categoryId + FileExtension);
                        image = null;
                    }

                }
            }
        }

        public static void WriteBinaryFile(byte[] fileContents, string fileLocation)
        {
            FileStream stream = new FileStream(fileLocation, FileMode.Create);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }
    }
}
