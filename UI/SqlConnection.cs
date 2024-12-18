using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace UI
    {
    public static class SqlConnectionHelper
    {
        // Function to get SQL connection
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=192.168.1.105; Initial Catalog=logindata; Persist Security Info=True; User ID=teste; Password=123321; TrustServerCertificate=True");

            con.Open(); // Open the connection
            return con;
        }
    }
}