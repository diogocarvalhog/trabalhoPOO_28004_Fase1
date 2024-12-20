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
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            SuspendLayout();
            // 
            // dgvTickets
            // 
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Location = new Point(107, 98);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.RowHeadersWidth = 82;
            dgvTickets.Size = new Size(884, 817);
            dgvTickets.TabIndex = 0;
            dgvTickets.CellContentClick += dgvTickets_CellContentClick;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(690, 996);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(171, 46);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click_1;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // ViewTickets
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(1086, 1089);
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
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}