namespace UI
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnViewTickets = new Button();
            btnBuyTickets = new Button();
            SuspendLayout();
            // 
            // btnViewTickets
            // 
            btnViewTickets.Location = new Point(175, 178);
            btnViewTickets.Margin = new Padding(5, 6, 5, 6);
            btnViewTickets.Name = "btnViewTickets";
            btnViewTickets.Size = new Size(244, 100);
            btnViewTickets.TabIndex = 0;
            btnViewTickets.Text = "View Tickets";
            btnViewTickets.UseVisualStyleBackColor = true;
            btnViewTickets.Click += btnViewTickets_Click;
            // 
            // btnBuyTickets
            // 
            btnBuyTickets.Location = new Point(175, 407);
            btnBuyTickets.Margin = new Padding(5, 6, 5, 6);
            btnBuyTickets.Name = "btnBuyTickets";
            btnBuyTickets.Size = new Size(244, 100);
            btnBuyTickets.TabIndex = 1;
            btnBuyTickets.Text = "Buy Tickets";
            btnBuyTickets.UseVisualStyleBackColor = true;
            btnBuyTickets.Click += btnBuyTickets_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(607, 668);
            Controls.Add(btnBuyTickets);
            Controls.Add(btnViewTickets);
            Margin = new Padding(5, 6, 5, 6);
            Name = "MainMenu";
            Text = "Main Menu";
            Load += MainMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnViewTickets;
        private System.Windows.Forms.Button btnBuyTickets;
    }
}