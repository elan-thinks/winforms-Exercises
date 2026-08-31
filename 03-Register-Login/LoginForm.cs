using RegisterLogin.Database;

namespace RegisterLogin;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

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

        try
        {
            bool isValid = DatabaseConnection.ValidateLogin(username, password);

            if (isValid)
            {
                MessageBox.Show("Login successful! Welcome!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
            }
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

    private void btnGoToRegister_Click(object sender, EventArgs e)
    {
        var registerForm = new RegisterForm();
        registerForm.Show();
        this.Hide();
    }
}
