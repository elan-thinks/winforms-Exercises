using RegisterLogin.Database;

namespace RegisterLogin;

public partial class RegisterForm : Form
{
    public RegisterForm()
    {
        InitializeComponent();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;
        string confirmPassword = txtConfirmPassword.Text;

        // Validation
        if (string.IsNullOrWhiteSpace(username))
        {
            MessageBox.Show("Please enter a username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Please enter a password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(confirmPassword))
        {
            MessageBox.Show("Please confirm your password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmPassword.Focus();
            return;
        }

        if (password != confirmPassword)
        {
            MessageBox.Show("Passwords do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmPassword.Focus();
            return;
        }

        try
        {
            DatabaseConnection.RegisterUser(username, password);

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Open Login form and close this one
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
        catch (InvalidOperationException ex) when (ex.Message == "Username already exists.")
        {
            MessageBox.Show("Username already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Could not connect to the database.\n\nPlease check:\n" +
                "1. PostgreSQL is running\n" +
                "2. Database 'winforms_exercises' exists\n" +
                "3. Password is set correctly in DatabaseConnection.cs\n\n" +
                "Error: " + ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnGoToLogin_Click(object sender, EventArgs e)
    {
        var loginForm = new LoginForm();
        loginForm.Show();
        this.Hide();
    }
}
