namespace UI
{
    partial class CreateACC
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            checkBox1 = new CheckBox();
            textBox3 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.SandyBrown;
            button1.Font = new Font("Segoe UI", 11F);
            button1.Location = new Point(263, 702);
            button1.Name = "button1";
            button1.Size = new Size(206, 78);
            button1.TabIndex = 0;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(45, 179);
            label1.Name = "label1";
            label1.Size = new Size(98, 47);
            label1.TabIndex = 1;
            label1.Text = "Email";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(45, 319);
            label2.Name = "label2";
            label2.Size = new Size(155, 47);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(400, 179);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(303, 39);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(400, 319);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(303, 39);
            textBox2.TabIndex = 4;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(400, 582);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(218, 36);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Show Passwords";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(400, 462);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(303, 39);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(45, 462);
            label3.Name = "label3";
            label3.Size = new Size(278, 47);
            label3.TabIndex = 7;
            label3.Text = "Confirm Password";
            // 
            // Form2
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(776, 877);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(checkBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Create Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private CheckBox checkBox1;
        private TextBox textBox3;
        private Label label3;
    }
}