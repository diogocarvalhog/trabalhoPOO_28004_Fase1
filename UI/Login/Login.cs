using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;




namespace UI
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginVariables.email = txtEmail.Text;
            SqlConnection con = SqlConnectionHelper.GetConnection();
            string query = "SELECT COUNT(*) from clients WHERE email=@email AND password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@password", txtPass.Text);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (count > 0)
            {
                MessageBox.Show("Login Successful", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Instead of BuyTickets, show the MainMenuForm
                MainMenu mainMenu = new MainMenu();
                mainMenu.StartPosition = FormStartPosition.CenterScreen;
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed", "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateACC signup = new CreateACC();
            signup.Show();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
          // URL to open
          string url = "https://www.youtube.com/watch?v=xm3YgoEiEDc&t=1s";

          // Open the URL in the default web browser
          Process.Start(new ProcessStartInfo
          {
              FileName = url,
              UseShellExecute = true // Important for opening URLs
          });
         
        }
    }
}
