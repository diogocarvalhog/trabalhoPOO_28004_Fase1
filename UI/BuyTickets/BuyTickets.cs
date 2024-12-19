using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConcertManager;
using Microsoft.Data.SqlClient;

namespace UI
{
    public partial class BuyTickets : Form
    {
        private ListBands listBands = new ListBands(); // Holds all bands and concerts in memory
        private Users currentUser; // Logged-in user

        public BuyTickets(Users user)
        {
            InitializeComponent();
            this.Load += BuyTickets_Load;

            currentUser = user; // Assign the current user
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            btnReturnToMainMenu.Click += btnReturnToMainMenu_Click;
        }

        // Load all bands and concerts into memory on form load
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

        // Load bands and their concerts into memory
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

        // Load concerts for a specific band
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

        // Event: When band selection changes, update concerts in comboBox2
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

        // Event: When concert selection changes, update seat availability
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

        // Find the selected ConcertID from the in-memory data
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

        // Update the checkboxes to reflect seat availability
        private void UpdateSeatAvailability(int concertID)
        {
            CheckBox[] seats = new CheckBox[]
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9
            };

            // Reset checkboxes: enable and uncheck them
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

                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows == 0)
                        {
                            throw new Exception($"Ticket {ticketID} was already booked!");
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Tickets booked successfully!");
                    UpdateSeatAvailability(concertID); // Refresh seats
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Booking failed: {ex.Message}");
                }
            }
        }

        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenuForm = new MainMenu();
            mainMenuForm.StartPosition = FormStartPosition.CenterScreen;
            this.Close();
            mainMenuForm.Show();
        }
        private void BuyTickets_Load_1(object sender, EventArgs e)
        {

        }
    }
}