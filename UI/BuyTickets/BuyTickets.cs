// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This form allows the user to buy tickets for concerts. It loads the available 
// bands and concerts, and allows users to select seats and book tickets. 
// The functionality includes dynamic loading of concert data from a database, 
// seat management (disabled for booked seats), and ticket booking.
// 
// Features:
// - Displays a list of bands and concerts
// - Allows the user to select seats and book tickets
// - Updates seat availability in real-time
// - Handles database transactions for booking tickets
// 
// Regions:
// - Fields: Holds references to the data and current user
// - Constructor: Initializes the form and binds events
// - Event Handlers: Contains events for form loading, band/concert selection, seat updates, etc.
// - Data Loading: Handles loading of band and concert data from the database
// - Seat Management: Manages seat availability for each concert
// - Booking Management: Handles the booking of selected tickets for the user
// - Utility Methods: Helper methods for getting selected concert ID
// ----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConcertManager;
using Microsoft.Data.SqlClient;

namespace UI
{
    public partial class BuyTickets : Form
    {
        #region Fields

        private ListBands listBands = new ListBands(); // Holds all bands and concerts in memory
        private Users currentUser; // Logged-in user

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes the BuyTickets form.
        /// </summary>
        /// <param name="user">The current logged-in user.</param>
        public BuyTickets(Users user)
        {
            InitializeComponent();
            this.Load += BuyTickets_Load;

            currentUser = user; // Assign the current user
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            btnReturnToMainMenu.Click += btnReturnToMainMenu_Click;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event triggered on form load. Loads bands and concerts into memory.
        /// </summary>
        private void BuyTickets_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            LoadBandsAndConcerts(); // Load data into memory

            // Populate comboBox1 with band names
            foreach (var band in listBands.BandsList)
            {
                comboBox1.Items.Add(band.bandName);
            }
        }

        /// <summary>
        /// Event triggered when the band selection changes.
        /// Populates the concert list based on the selected band.
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            if (comboBox1.SelectedItem != null)
            {
                string selectedBandName = comboBox1.SelectedItem.ToString();
                Bands selectedBand = listBands.BandsList.Find(b => b.bandName == selectedBandName);

                if (selectedBand != null)
                {
                    foreach (var concert in selectedBand.concerts)
                    {
                        string concertInfo = $"{concert.date} - {concert.price:C2}";
                        comboBox2.Items.Add(concertInfo);
                    }
                }
            }

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0; // Default to the first concert
            }
        }

        /// <summary>
        /// Event triggered when the concert selection changes.
        /// Updates seat availability for the selected concert.
        /// </summary>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int concertID = GetSelectedConcertID();
                UpdateSeatAvailability(concertID); // Disable booked seats
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Event triggered when the "Confirm" button is clicked.
        /// Books the selected tickets for the current user.
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                int clientID = currentUser.IdUser; // User ID
                int concertID = GetSelectedConcertID();
                List<int> selectedTickets = new List<int>();

                CheckBox[] seats = new CheckBox[]
                {
                    checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9
                };

                int baseTicketID = (concertID - 1) * 9;

                for (int i = 0; i < seats.Length; i++)
                {
                    if (seats[i].Enabled && seats[i].Checked)
                    {
                        int ticketID = baseTicketID + (i + 1);
                        selectedTickets.Add(ticketID);
                    }
                }

                if (selectedTickets.Count > 0)
                {
                    BookTickets(clientID, concertID, selectedTickets);
                }
                else
                {
                    MessageBox.Show("Please select at least one ticket!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Event triggered when the "Return to Main Menu" button is clicked.
        /// Closes the current form and shows the main menu.
        /// </summary>
        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenuForm = new MainMenu();
            mainMenuForm.StartPosition = FormStartPosition.CenterScreen;
            this.Close();
            mainMenuForm.Show();
        }

        #endregion

        #region Data Loading

        /// <summary>
        /// Loads all bands and their concerts into memory.
        /// </summary>
        private void LoadBandsAndConcerts()
        {
            string queryBands = "SELECT BandName FROM Concerts GROUP BY BandName";

            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(queryBands, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string bandName = reader["BandName"].ToString();
                    Bands band = new Bands(bandName, "", "");
                    listBands.AddBand(band);

                    LoadConcertsForBand(band); // Load concerts for each band
                }
            }
        }

        /// <summary>
        /// Loads concerts for a specific band.
        /// </summary>
        /// <param name="band">The band whose concerts are to be loaded.</param>
        private void LoadConcertsForBand(Bands band)
        {
            string queryConcerts = "SELECT ConcertID, ConcertName, ConcertDate, Price FROM Concerts WHERE BandName = @BandName";

            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(queryConcerts, con);
                cmd.Parameters.AddWithValue("@BandName", band.bandName);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int concertID = (int)reader["ConcertID"];
                    string concertName = reader["ConcertName"].ToString();
                    string concertDate = Convert.ToDateTime(reader["ConcertDate"]).ToString("dd/MM/yyyy");
                    double price = Convert.ToDouble(reader["Price"]);

                    Concerts concert = new Concerts("", 0, concertName, concertID, concertDate, price, band.bandName);
                    band.AddConcert(concert);
                }
            }
        }

        #endregion

        #region Seat Management

        /// <summary>
        /// Updates seat availability for the specified concert.
        /// </summary>
        /// <param name="concertID">The ID of the selected concert.</param>
        private void UpdateSeatAvailability(int concertID)
        {
            CheckBox[] seats = new CheckBox[]
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9
            };

            // Reset checkboxes
            foreach (var seat in seats)
            {
                seat.Enabled = true;
                seat.Checked = false;
            }

            string query = "SELECT TicketID FROM Tickets WHERE ConcertID = @ConcertID AND IsAvailable = 0";

            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ConcertID", concertID);

                SqlDataReader reader = cmd.ExecuteReader();
                List<int> bookedTickets = new List<int>();

                while (reader.Read())
                {
                    bookedTickets.Add((int)reader["TicketID"]);
                }

                int baseTicketID = (concertID - 1) * 9;

                foreach (int bookedTicketID in bookedTickets)
                {
                    int seatIndex = (bookedTicketID - baseTicketID) - 1;
                    if (seatIndex >= 0 && seatIndex < seats.Length)
                    {
                        seats[seatIndex].Enabled = false; // Disable booked seats
                        seats[seatIndex].Checked = true;
                    }
                }
            }
        }

        #endregion

        #region Booking Management

        /// <summary>
        /// Books the selected tickets for the user.
        /// </summary>
        private void BookTickets(int clientID, int concertID, List<int> tickets)
        {
            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    foreach (int ticketID in tickets)
                    {
                        string query = "UPDATE Tickets SET IsAvailable = 0, ClientID = @ClientID " +
                                       "WHERE TicketID = @TicketID AND ConcertID = @ConcertID AND IsAvailable = 1";

                        SqlCommand cmd = new SqlCommand(query, con, transaction);
                        cmd.Parameters.AddWithValue("@ClientID", clientID);
                        cmd.Parameters.AddWithValue("@TicketID", ticketID);
                        cmd.Parameters.AddWithValue("@ConcertID", concertID);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Tickets booked successfully!");
                    UpdateSeatAvailability(concertID);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Booking failed: {ex.Message}");
                }
            }
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Retrieves the selected concert's ID based on the user's selection in the combo boxes.
        /// </summary>
        /// <returns>The concert ID of the selected concert.</returns>
        /// <exception cref="Exception">Thrown if no band or concert is selected.</exception>
        private int GetSelectedConcertID()
        {
            if (comboBox2.SelectedItem == null || comboBox1.SelectedItem == null)
                throw new Exception("Please select both a band and a concert!");

            string selectedBandName = comboBox1.SelectedItem.ToString();
            string selectedConcertInfo = comboBox2.SelectedItem.ToString();
            string[] concertParts = selectedConcertInfo.Split(" - ");

            string concertDate = concertParts[0];
            decimal price = Convert.ToDecimal(concertParts[1].Replace("€", "").Trim());

            Bands selectedBand = listBands.BandsList.Find(b => b.bandName == selectedBandName);
            if (selectedBand != null)
            {
                Concerts selectedConcert = selectedBand.concerts.Find(c => c.date == concertDate && c.price == (double)price);

                if (selectedConcert != null)
                {
                    return selectedConcert.concertID; // Return ConcertID from memory
                }
            }

            throw new Exception("Concert not found in memory!");
        }

        #endregion

        private void BuyTickets_Load_1(object sender, EventArgs e)
        {

        }
    }
}