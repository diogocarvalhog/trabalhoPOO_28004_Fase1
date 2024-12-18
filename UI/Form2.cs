﻿using Microsoft.Data.SqlClient;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
           
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if passwords do not match
            }

            using (SqlConnection con = new SqlConnection("Data Source = 192.168.1.193; Initial Catalog = logindata; Persist Security Info = True; User ID = teste; Password = 123321; TrustServerCertificate = True"))
            {
                try
                {
                    con.Open();

                    // Check if email already exists
                    string checkUserQuery = "SELECT COUNT(*) FROM loginapp WHERE email=@Email";
                    SqlCommand checkCmd = new SqlCommand(checkUserQuery, con);
                    checkCmd.Parameters.AddWithValue("@Email", textBox1.Text);
                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Email already registered. Please try a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Insert new user
                    string insertQuery = "INSERT INTO loginapp (email, password) VALUES (@Email, @Password)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@Email", textBox1.Text);
                    insertCmd.Parameters.AddWithValue("@Password", textBox2.Text);

                    int result = insertCmd.ExecuteNonQuery();

                    if (result > 0)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
            textBox3.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

