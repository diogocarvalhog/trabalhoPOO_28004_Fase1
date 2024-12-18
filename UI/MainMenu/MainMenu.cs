using ConcertManager;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnViewTickets_Click(object sender, EventArgs e)
        {
            // Navigate to ViewTicketsForm (create this form if it doesn't exist yet)
            ViewTickets viewTicketsForm = new ViewTickets();
            viewTicketsForm.StartPosition = FormStartPosition.CenterScreen; 
            viewTicketsForm.Show();
            this.Hide();
        }

        private void btnBuyTickets_Click(object sender, EventArgs e)
        {
            // Assuming you have the current user's email stored
            string email = LoginVariables.email;

            // Fetch the current user object (You will need to implement GetCurrentClient method)
            Users currentUser = GetCurrentClient(email);

            if (currentUser == null)
            {
                MessageBox.Show("User not found.");
                return;
            }

            // Now pass the user object to the BuyTickets form
            BuyTickets buyTicketsForm = new BuyTickets(currentUser);
            buyTicketsForm.StartPosition = FormStartPosition.CenterScreen;
            buyTicketsForm.Show();
            this.Hide();
        }
        private Users GetCurrentClient(string userEmail)
        {
            Users currentUser = null;  // Default value if not found

            string query = "SELECT Client_Id, email, password FROM Clients WHERE email = @Email";

            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", userEmail);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Assuming the table contains Client_Id, email, and password
                    int clientId = Convert.ToInt32(reader["Client_Id"]);
                    string email = reader["email"].ToString();
                    string password = reader["password"].ToString();

                    // Create a new Users object and populate it with the fetched data
                    currentUser = new Users(email, clientId, email, password);
                }
            }

            return currentUser;
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
