using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace UI
{
    public partial class ViewTickets : Form
    {
        public ViewTickets()
        {
            InitializeComponent();
            btnBack.Click += btnBack_Click;
        }

        private void ViewTickets_Load(object sender, EventArgs e)
        {
            // Setup columns before loading data
            InitializeDataGridView();

            // Load user's tickets
            LoadUserTickets();

        }

        // Method to initialize DataGridView columns
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

        // Method to load the user's tickets from the database
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
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Create an instance of the main menu form (assuming it's called MainMenuForm)
            MainMenu mainMenuForm = new MainMenu();
            mainMenuForm.StartPosition = FormStartPosition.CenterScreen;

            // Close the current form
            this.Close();          // Close the current form
            mainMenuForm.Show();   // Show the Main Menu form
        }
        // Optional: You can add logic here to handle when a user clicks on a ticket row
        private void dgvTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can implement actions when a user clicks on a ticket cell, for example:
            // Show more ticket details or navigate to another form with additional information
        }

        private void ViewTickets_Load_1(object sender, EventArgs e)
        {

        }
    }
}