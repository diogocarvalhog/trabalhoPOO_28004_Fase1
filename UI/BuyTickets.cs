using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConcertManager;
using Microsoft.Data.SqlClient;

namespace UI
{
    public partial class BuyTickets : Form
    {
        private ListBands listBands = new ListBands();

        public BuyTickets()
        {
            InitializeComponent();
            this.Load += Form3_Load;

            // Associating the SelectedIndexChanged event to comboBox1
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        // Form Load event to initialize data
        private void Form3_Load(object sender, EventArgs e)
        {
            // Clear existing items in comboBox1
            comboBox1.Items.Clear();

            // Fetch concert data from the database
            string query = "SELECT ConcertID, BandName FROM Concerts";
            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Assuming ConcertID is an integer and BandName is a string
                    string concertName = reader["BandName"].ToString();
                    comboBox1.Items.Add(concertName);  // Add the concert names to comboBox1
                }
            }
        }

        // Event when user selects a band from comboBox1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear items in comboBox2
            comboBox2.Items.Clear();

            if (comboBox1.SelectedItem != null)
            {
                string selectedBandName = comboBox1.SelectedItem.ToString();

                // Query to get concerts for the selected band
                string query = "SELECT ConcertName, ConcertDate, Price FROM Concerts WHERE BandName = @BandName";
                using (SqlConnection con = SqlConnectionHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@BandName", selectedBandName); // Correctly passing the BandName parameter

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string concertDate = Convert.ToDateTime(reader["ConcertDate"]).ToString("dd/MM/yyyy");
                        string concertInfo = $"{concertDate} - {reader["Price"]:C2}";
                        comboBox2.Items.Add(concertInfo);
                    }
                }
            }
        }

        // Method to get the current client ID from email
        private int GetCurrentClientID(string userEmail)
        {
            int clientID = -1; // Default value if not found

            string query = "SELECT Client_Id FROM Clients WHERE email = @Email";

            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", userEmail);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    clientID = Convert.ToInt32(result);
                }
            }

            return clientID;
        }

        // Method to get selected concert ID
        private int GetSelectedConcertID()
        {
            string selectedConcertInfo = comboBox2.SelectedItem.ToString();
            string concertDate = selectedConcertInfo.Split(" - ")[0]; // Extract date
            string concertName = selectedConcertInfo.Split(" - ")[1]; // Extract concert name

            int concertID = -1;

            // Query to get ConcertID based on ConcertName (which should be unique)
            string query = "SELECT ConcertID FROM Concerts WHERE ConcertName = @ConcertName AND ConcertDate = @ConcertDate";
            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ConcertDate", DateTime.Parse(concertDate));
                cmd.Parameters.AddWithValue("@ConcertName", concertName);
                concertID = (int)cmd.ExecuteScalar();
            }

            return concertID;
        }

        // Event handler for confirming the booking
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Confirm button clicked!");
            string email = LoginVariables.email;
            int clientID = GetCurrentClientID(email); // Retrieve logged-in user's ID
            List<int> selectedTickets = new List<int>();

            // Array of checkboxes representing seats
            CheckBox[] seats = new CheckBox[]
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9
            };

            int seatCounter = 0;
            foreach (var seat in seats)
            {
                if (seat.Enabled && seat.Checked)  // Check if the seat is available and selected
                {
                    // Assuming TicketID is mapped to the checkbox position (or you can use a separate array for TicketID)
                    selectedTickets.Add(seatCounter + 1);  // Add the corresponding TicketID (seatCounter + 1)
                }
                seatCounter++;
            }

            if (selectedTickets.Count > 0)
            {
                // Update the database to mark tickets as booked
                using (SqlConnection con = SqlConnectionHelper.GetConnection())
                {
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        foreach (int ticketID in selectedTickets)
                        {
                            string query = "UPDATE Tickets SET IsAvailable = 0, ClientID = @ClientID WHERE TicketID = @TicketID AND IsAvailable = 1";
                            SqlCommand cmd = new SqlCommand(query, con, transaction);
                            cmd.Parameters.AddWithValue("@ClientID", clientID);
                            cmd.Parameters.AddWithValue("@TicketID", ticketID);

                            int affectedRows = cmd.ExecuteNonQuery();
                            if (affectedRows == 0)
                            {
                                // This means the ticket is already booked, so you can handle the situation here
                                throw new Exception("One or more tickets were already booked.");
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Tickets booked successfully!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Booking failed: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select tickets!");
            }
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            // This method seems unused. You can remove it.
        }

        // Event handler for CheckBox change (unused in the code now)
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            // This method seems unused. You can remove it as well.
        }
    }
}