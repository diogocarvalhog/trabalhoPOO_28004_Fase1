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
            this.btnViewTickets = new System.Windows.Forms.Button();
            this.btnBuyTickets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewTickets
            // 
            this.btnViewTickets.Location = new System.Drawing.Point(100, 100);
            this.btnViewTickets.Name = "btnViewTickets";
            this.btnViewTickets.Size = new System.Drawing.Size(150, 50);
            this.btnViewTickets.TabIndex = 0;
            this.btnViewTickets.Text = "View Tickets";
            this.btnViewTickets.UseVisualStyleBackColor = true;
            this.btnViewTickets.Click += new System.EventHandler(this.btnViewTickets_Click);
            // 
            // btnBuyTickets
            // 
            this.btnBuyTickets.Location = new System.Drawing.Point(100, 200);
            this.btnBuyTickets.Name = "btnBuyTickets";
            this.btnBuyTickets.Size = new System.Drawing.Size(150, 50);
            this.btnBuyTickets.TabIndex = 1;
            this.btnBuyTickets.Text = "Buy Tickets";
            this.btnBuyTickets.UseVisualStyleBackColor = true;
            this.btnBuyTickets.Click += new System.EventHandler(this.btnBuyTickets_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuyTickets);
            this.Controls.Add(this.btnViewTickets);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnViewTickets;
        private System.Windows.Forms.Button btnBuyTickets;
    }
}