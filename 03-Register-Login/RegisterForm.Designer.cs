namespace RegisterLogin
{
    partial class RegisterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            btnGoToLogin = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(120, 80, 160);
            lblTitle.Location = new Point(95, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(190, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Account";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(90, 70, 120);
            lblUsername.Location = new Point(50, 85);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(71, 19);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(255, 250, 255);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(50, 108);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 27);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(90, 70, 120);
            lblPassword.Location = new Point(50, 150);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 19);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(255, 250, 255);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(50, 173);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblConfirmPassword.ForeColor = Color.FromArgb(90, 70, 120);
            lblConfirmPassword.Location = new Point(50, 215);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(121, 19);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(255, 250, 255);
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtConfirmPassword.Location = new Point(50, 238);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(280, 27);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(180, 140, 220);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(50, 290);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(280, 40);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnGoToLogin
            // 
            btnGoToLogin.BackColor = Color.FromArgb(255, 230, 240);
            btnGoToLogin.FlatAppearance.BorderColor = Color.FromArgb(220, 180, 200);
            btnGoToLogin.FlatStyle = FlatStyle.Flat;
            btnGoToLogin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnGoToLogin.ForeColor = Color.FromArgb(140, 90, 140);
            btnGoToLogin.Location = new Point(50, 345);
            btnGoToLogin.Name = "btnGoToLogin";
            btnGoToLogin.Size = new Size(280, 35);
            btnGoToLogin.TabIndex = 8;
            btnGoToLogin.Text = "Already have an account? Login";
            btnGoToLogin.UseVisualStyleBackColor = false;
            btnGoToLogin.Click += btnGoToLogin_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 245, 255);
            ClientSize = new Size(380, 410);
            Controls.Add(btnGoToLogin);
            Controls.Add(btnRegister);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Button btnGoToLogin;
    }
}
