using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
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
            SqlConnection con = new SqlConnection("Data Source = 172.16.15.173; Initial Catalog = logindata; Persist Security Info = True; User ID = teste; Password = 123321; TrustServerCertificate = True");
            con.Open();
            string query = "SELECT COUNT(*) from loginapp WHERE email=@email AND password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@password", txtPass.Text);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (count > 0)
            {
                MessageBox.Show("Login Successful", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3 concerts = new Form3();
                concerts.Show();
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
            Form2 signup = new Form2();
            signup.Show();

        }
    }
}
