// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This form allows the user to log into the system using their email and
// password. It checks the credentials against the database and, if valid, 
// grants access to the main menu.
// 
// Features:
// - Validates user credentials against the database
// - Allows the user to toggle password visibility
// - Navigates to the main menu upon successful login
// 
// Regions:
// - Constructor: Initializes the form and binds events
// - Event Handlers: Contains events for form loading, login button click, and password visibility toggle
// - Helper Methods: Handles user credential verification and password visibility toggling
// ----------------------------------------------------------------------

using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class Login : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the form load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialization logic on form load can be added here
        }

        /// <summary>
        /// Event handler for text changes in the password text box.
        /// </summary>
        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            // Logic for handling text changes in the password field can be added here
        }

        /// <summary>
        /// Event handler for the login button click event. 
        /// Verifies user credentials and navigates to the MainMenu on success.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">Event arguments.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            LoginVariables.email = txtEmail.Text; // Save email to global login variables
            string query = "SELECT COUNT(*) FROM clients WHERE email=@Email AND password=@Password";

            using (SqlConnection con = SqlConnectionHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (count > 0)
                {
                    MessageBox.Show("Login Successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Show MainMenu and hide the login form
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.StartPosition = FormStartPosition.CenterScreen;
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Event handler for the password visibility toggle checkbox.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">Event arguments.</param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        /// <summary>
        /// Event handler for the email text box text changed event.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">Event arguments.</param>
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            // Logic for handling text changes in the email field can be added here
        }

        /// <summary>
        /// Event handler for the link label click to open the account creation form.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">Event arguments.</param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateACC signup = new CreateACC();
            signup.StartPosition = FormStartPosition.CenterScreen;
            signup.Show();
        }

        #endregion
    }
}