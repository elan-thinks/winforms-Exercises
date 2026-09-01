using ElectronicsInventory.Database;

namespace ElectronicsInventory;

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
        string confirm = txtConfirmPassword.Text;

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

        if (string.IsNullOrWhiteSpace(confirm))
        {
            MessageBox.Show("Please confirm your password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmPassword.Focus();
            return;
        }

        if (password != confirm)
        {
            MessageBox.Show("Passwords do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmPassword.Focus();
            return;
        }

        try
        {
            DatabaseConnection.RegisterUser(username, password);
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                "Could not connect to the database.\n\n" +
                "Check PostgreSQL is running, database exists, and PG_PASSWORD is set.\n\n" +
                "Error: " + ex.Message,
                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnBackToLogin_Click(object sender, EventArgs e)
    {
        var loginForm = new LoginForm();
        loginForm.Show();
        this.Hide();
    }
}
