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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnViewTickets_Click(object sender, EventArgs e)
        {
            // Navigate to ViewTicketsForm (create this form if it doesn't exist yet)
            ViewTickets viewTicketsForm = new ViewTickets();
            viewTicketsForm.Show();
            this.Hide();
        }

        private void btnBuyTickets_Click(object sender, EventArgs e)
        {
            // Navigate to BuyTicketsForm
            BuyTickets buyTicketsForm = new BuyTickets();
            buyTicketsForm.Show();
            this.Hide();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
