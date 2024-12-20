// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This form allows the user to create a new account by entering their email
// and password. It checks if the passwords match, and if the email is 
// already registered, it prevents account creation.
// 
// Features:
// - Validates if passwords match
// - Checks if the email already exists in the database
// - Creates a new account by inserting the user's details into the database
// 
// Regions:
// - Constructor: Initializes the form and binds events
// - Event Handlers: Contains events for form loading, button clicks, and checkbox changes
// - Helper Methods: Handles password validation, password visibility toggling, and account creation
// ----------------------------------------------------------------------

using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class CreateACC : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateACC"/> class.
        /// </summary>
        public CreateACC()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the event when the first label is clicked.
        /// </summary>
        private void label1_Click(object sender, EventArgs e)
        {
            // No implementation needed currently
        }

        /// <summary>
        /// Handles the event when the account creation button is clicked.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidatePasswords())
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if passwords do not match
            }

            CreateAccount();
        }

        /// <summary>
        /// Handles the event when the checkbox for showing passwords is toggled.
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }

        /// <summary>
        /// Handles changes in the third textbox (confirm password field).
        /// </summary>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // No implementation needed currently
        }

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        private void CreateACC_Load(object sender, EventArgs e)
        {
            // Initialization on form load can be added here
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Validates if the two password fields match.
        /// </summary>
        /// <returns>True if passwords match; otherwise, false.</returns>
        private bool ValidatePasswords()
        {
            return textBox2.Text == textBox3.Text;
        }

        /// <summary>
        /// Toggles the visibility of the password fields based on the checkbox state.
        /// </summary>
        private void TogglePasswordVisibility()
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
            textBox3.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        /// <summary>
        /// Attempts to create a new user account by inserting data into the database.
        /// </summary>
        private void CreateAccount()
        {
            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                try
                {
                    if (CheckIfUserExists(con, textBox1.Text))
                    {
                        MessageBox.Show("Email already registered. Please try a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (InsertNewUser(con, textBox1.Text, textBox2.Text))
                    {
                        MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Account creation failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Checks if a user with the provided email already exists in the database.
        /// </summary>
        /// <param name="connection">The SQL connection object.</param>
        /// <param name="email">The email to check.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        private bool CheckIfUserExists(SqlConnection connection, string email)
        {
            string query = "SELECT COUNT(*) FROM Clients WHERE email=@Email";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                int userExists = Convert.ToInt32(cmd.ExecuteScalar());
                return userExists > 0;
            }
        }

        /// <summary>
        /// Inserts a new user into the Clients table.
        /// </summary>
        /// <param name="connection">The SQL connection object.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if the insertion was successful; otherwise, false.</returns>
        private bool InsertNewUser(SqlConnection connection, string email, string password)
        {
            string query = "INSERT INTO Clients (email, password) VALUES (@Email, @Password)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        #endregion
    }
}