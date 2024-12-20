// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This class handles the functionality of viewing the user's tickets in the application.
// It connects to the database to fetch the user's ticket information and displays it in a DataGridView.
// 
// Methods:
// - InitializeDataGridView: Sets up the DataGridView columns to display concert details.
// - LoadUserTickets: Loads the tickets for the logged-in user from the database.
// - btnBack_Click: Handles the back button click event, navigating the user to the main menu.
// ----------------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace UI
{
    public partial class ViewTickets : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewTickets"/> class.
        /// Sets up the button event handlers and loads the user's tickets.
        /// </summary>
        public ViewTickets()
        {
            InitializeComponent();
            btnBack.Click += btnBack_Click;
            LoadUserTickets();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the form load event.
        /// Initializes the DataGridView and loads the user's tickets.
        /// </summary>
        private void ViewTickets_Load()
        {
            // Setup columns before loading data
            InitializeDataGridView();

            // Load user's tickets
            LoadUserTickets();
        }

        /// <summary>
        /// Initializes the columns of the DataGridView to display concert information.
        /// </summary>
        private void InitializeDataGridView()
        {
            dgvTickets.Columns.Clear(); // Clear existing columns if any

            // Add columns for the concert information
            dgvTickets.Columns.Add("ConcertName", "Concert Name");
            dgvTickets.Columns.Add("ConcertDate", "Concert Date");
            dgvTickets.Columns.Add("Price", "Price");
            dgvTickets.Columns.Add("BandName", "Band Name");

            // Format columns for better display
            dgvTickets.Columns["ConcertDate"].DefaultCellStyle.Format = "MMMM dd, yyyy";
            dgvTickets.Columns["Price"].DefaultCellStyle.Format = "C"; // Format as currency
        }

        /// <summary>
        /// Loads the tickets for the logged-in user from the database.
        /// Displays the data in the DataGridView.
        /// </summary>
        private void LoadUserTickets()
        {
            // Assuming LoginVariables.email has the current logged-in user's email
            string email = LoginVariables.email;

            // Create the connection string
            SqlConnection con = SqlConnectionHelper.GetConnection();

            // SQL query to fetch tickets for the logged-in user
            string query = "SELECT c.ConcertName, c.ConcertDate, c.Price, c.BandName from Tickets t " +
                           "JOIN Concerts c ON t.ConcertId = c.ConcertId " +
                           "JOIN Clients cl ON t.ClientId = cl.Client_Id " +
                           "WHERE cl.Email = @Email";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@Email", email);
            DataTable dt = new DataTable();

            try
            {
                // Fill the DataTable with the result of the query
                da.Fill(dt);

                // Bind the DataTable to the DataGridView
                dgvTickets.DataSource = dt;
                Controls.Add(dgvTickets);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tickets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Handles the back button click event. Navigates the user to the main menu.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Create an instance of the main menu form (assuming it's called MainMenuForm)
            MainMenu mainMenuForm = new MainMenu();
            mainMenuForm.StartPosition = FormStartPosition.CenterScreen;

            // Close the current form
            this.Close();          // Close the current form
            mainMenuForm.Show();   // Show the Main Menu form
        }

        /// <summary>
        /// Optional: Handles when a user clicks on a ticket row in the DataGridView.
        /// You can implement logic to show more ticket details or navigate to another form.
        /// </summary>
        private void dgvTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implement actions when a user clicks on a ticket cell
            // For example: Show more ticket details or navigate to another form with additional information
        }

        #endregion
    }
}