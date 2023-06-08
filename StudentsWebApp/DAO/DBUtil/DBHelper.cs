using System.Data.SqlClient;

namespace StudentsWebApp.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;

        /// <summary>
        /// No instances of this class should be available
        /// </summary>
        private DBHelper() { }

        public static SqlConnection? GetConnection()
        {
            conn = null;
            try
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.AddJsonFile("appsettings.json");

                //string url = @"Data Source=localhost\sqlexpress;Initial Catalog=Students4DB;Integrated Security=True";

                string url = configurationManager.GetConnectionString("DefaultConnection");
                conn = new SqlConnection(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return conn;
        }

        public static void CloseConnection()
        {
            conn?.Close();
        }
    }
}
