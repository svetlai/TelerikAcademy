namespace Northwind.DBContext
{
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;

    /// <summary>
    /// 6. Create a database called NorthwindTwin with the same structure as Northwind using the features from 
    /// DbContext. Find for the API for schema generation in MSDN or in Google.
    /// </summary>
    public class NortwindTwin
    {
        static void Main()
        {
            IObjectContextAdapter context = new NorthwindDBContext();
            string cloneNorthwind = context.ObjectContext.CreateDatabaseScript();

            string createDbQuery = "CREATE DATABASE NorthwindTwin";
            string connStringMaster = "Server=.; Database=master; Integrated Security=true";

            SqlConnection dbMasterConn = new SqlConnection(connStringMaster);

            dbMasterConn.Open();

            using (dbMasterConn)
            {
                SqlCommand createDB = new SqlCommand(createDbQuery, dbMasterConn);
                createDB.ExecuteNonQuery();
            }

            dbMasterConn.Close();

            string connStringNorthwindTwin = "Server=.; Database=NorthwindTwin; Integrated Security=true";
            SqlConnection dbNorthwindTwinConn = new SqlConnection(connStringNorthwindTwin);

            dbNorthwindTwinConn.Open();

            using (dbNorthwindTwinConn)
            {
                SqlCommand cloneDB = new SqlCommand(cloneNorthwind, dbNorthwindTwinConn);
                cloneDB.ExecuteNonQuery();
            }
        }
    }
}
