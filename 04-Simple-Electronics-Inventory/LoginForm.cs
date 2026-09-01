using ElectronicsInventory.Database;

namespace ElectronicsInventory;

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
            if (DatabaseConnection.ValidateLogin(username, password))
            {
                // Hide login, open inventory as modal, then exit when inventory closes
                Hide();

                using (var mainForm = new MainForm())
                {
                    mainForm.ShowDialog();
                }

                // When MainForm closes, end the app
                Close();
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
                "Could not connect to the database.\n\n" +
                "Check PostgreSQL is running, database exists, and PG_PASSWORD is set.\n\n" +
                "Error: " + ex.Message,
                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        Hide();

        using (var registerForm = new RegisterForm())
        {
            registerForm.ShowDialog();
        }

        // After register form closes, show login again (unless they already signed in elsewhere)
        if (!IsDisposed)
        {
            Show();
        }
    }
}
