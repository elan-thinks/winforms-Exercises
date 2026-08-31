namespace RegisterLogin
{
    partial class LoginForm
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
            btnLogin = new Button();
            btnGoToRegister = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(80, 130, 180);
            lblTitle.Location = new Point(95, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Welcome Back";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(70, 100, 140);
            lblUsername.Location = new Point(50, 95);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(71, 19);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(245, 250, 255);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(50, 118);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 27);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(70, 100, 140);
            lblPassword.Location = new Point(50, 165);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 19);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(245, 250, 255);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(50, 188);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(130, 180, 230);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 245);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(280, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnGoToRegister
            // 
            btnGoToRegister.BackColor = Color.FromArgb(230, 245, 255);
            btnGoToRegister.FlatAppearance.BorderColor = Color.FromArgb(180, 210, 240);
            btnGoToRegister.FlatStyle = FlatStyle.Flat;
            btnGoToRegister.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnGoToRegister.ForeColor = Color.FromArgb(70, 120, 170);
            btnGoToRegister.Location = new Point(50, 300);
            btnGoToRegister.Name = "btnGoToRegister";
            btnGoToRegister.Size = new Size(280, 35);
            btnGoToRegister.TabIndex = 6;
            btnGoToRegister.Text = "Don't have an account? Register";
            btnGoToRegister.UseVisualStyleBackColor = false;
            btnGoToRegister.Click += btnGoToRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(380, 370);
            Controls.Add(btnGoToRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnGoToRegister;
    }
}
