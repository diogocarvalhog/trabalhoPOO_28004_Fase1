namespace UI
{
    partial class ViewTickets
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvTickets = new DataGridView();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            SuspendLayout();
            // 
            // dgvTickets
            // 
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Location = new Point(302, 71);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.RowHeadersWidth = 82;
            dgvTickets.Size = new Size(1650, 799);
            dgvTickets.TabIndex = 0;
            dgvTickets.CellContentClick += dgvTickets_CellContentClick;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(41, 872);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(171, 46);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // ViewTickets
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(2220, 1360);
            Controls.Add(btnBack);
            Controls.Add(dgvTickets);
            Name = "ViewTickets";
            Text = "Form1";
            Load += ViewTickets_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTickets;
        private Button btnBack;
    }
}