// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This class provides helper methods for establishing and managing SQL database connections.
// It includes a method to open a connection to the SQL Server database, handle exceptions,
// and return an open connection object for further use.
// 
// Methods:
// - GetConnection: Establishes and opens a connection to the SQL Server database.
// ----------------------------------------------------------------------

using System;
using Microsoft.Data.SqlClient;

namespace UI
{
    /// <summary>
    /// Provides helper methods for managing SQL database connections.
    /// </summary>
    public static class SqlConnectionHelper
    {
        #region Methods

        /// <summary>
        /// Establishes and opens a connection to the SQL Server database.
        /// </summary>
        /// <returns>
        /// An open <see cref="SqlConnection"/> object to the database.
        /// </returns>
        /// <exception cref="SqlException">
        /// Thrown if there is an issue opening the connection to the database.
        /// </exception>
        public static SqlConnection GetConnection()
        {
            // Connection string for connecting to the database
            string connectionString = "Data Source=192.168.1.105; " +
                                      "Initial Catalog=logindata; " +
                                      "Persist Security Info=True; " +
                                      "User ID=teste; " +
                                      "Password=123321; " +
                                      "TrustServerCertificate=True";

            // Initialize the connection
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open(); // Open the connection
            }
            catch (SqlException ex)
            {
                // Optionally log the error (can integrate a logger here)
                throw new Exception("Failed to open the SQL connection.", ex);
            }

            return con; // Return the open connection
        }

        #endregion
    }
}