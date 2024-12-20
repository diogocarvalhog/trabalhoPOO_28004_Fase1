// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This form represents the main menu of the application after the user has logged in.
// It provides options to view tickets, buy tickets, or quit the application. 
// The main menu interacts with the database to retrieve user-specific information,
// such as fetching the current user's details based on the logged-in email.
// 
// Features:
// - Allows the user to view tickets and navigate to the ViewTickets form
// - Provides the option to buy tickets and navigate to the BuyTickets form
// - Displays a confirmation dialog when quitting the application
// - Retrieves current user information from the database based on the logged-in email
// 
// Regions:
// - Constructor: Initializes the form and attaches the event handlers
// - Event Handlers: Contains event handlers for button clicks (view, buy tickets, quit)
// - Helper Methods: Retrieves current user information from the database using their email
// ----------------------------------------------------------------------

using ConcertManager;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// Represents the main menu form of the application.
    /// </summary>
    public partial class MainMenu : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
            btnQuit.Click += btnQuit_Click; // Attach Quit button event handler
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the "View Tickets" button click.
        /// Opens the ViewTickets form.
        /// </summary>
        private void btnViewTickets_Click(object sender, EventArgs e)
        {
            ViewTickets viewTicketsForm = new ViewTickets
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            viewTicketsForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Event handler for the "Buy Tickets" button click.
        /// Navigates to the BuyTickets form with the current user's information.
        /// </summary>
        private void btnBuyTickets_Click(object sender, EventArgs e)
        {
            string email = LoginVariables.email; // Retrieve logged-in user's email

            Users currentUser = GetCurrentClient(email); // Fetch user object
            if (currentUser == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BuyTickets buyTicketsForm = new BuyTickets(currentUser)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            buyTicketsForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Event handler for the Quit button click.
        /// Displays a confirmation dialog and exits the application if confirmed.
        /// </summary>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to quit?", "Exit Application",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Exit the entire application
            }
        }

        /// <summary>
        /// Event handler for the form load event.
        /// </summary>
        private void MainMenu_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Retrieves the current user object from the database based on their email.
        /// </summary>
        /// <param name="userEmail">The email of the user to retrieve.</param>
        /// <returns>A <see cref="Users"/> object representing the current user, or null if not found.</returns>
        private Users GetCurrentClient(string userEmail)
        {
            Users currentUser = null;

            string query = "SELECT Client_Id, email, password FROM Clients WHERE email = @Email";

            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", userEmail);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int clientId = Convert.ToInt32(reader["Client_Id"]);
                    string email = reader["email"].ToString();
                    string password = reader["password"].ToString();

                    // Create a new Users object with fetched data
                    currentUser = new Users(email, clientId, email, password);
                }
            }

            return currentUser;
        }

        #endregion
    }
}