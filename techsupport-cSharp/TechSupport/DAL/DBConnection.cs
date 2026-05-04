using System.Data.SqlClient;

namespace TechSupport.DAL
{
    /// <summary>
    ///  Method for creating a connection between C# and DB
    /// </summary>
    class DBConnection
    {

        public static SqlConnection GetConnection()
        {
            string connectionString =
                "Data Source=localhost;Initial Catalog=TechSupport;" +
                "Integrated Security=True";


            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
