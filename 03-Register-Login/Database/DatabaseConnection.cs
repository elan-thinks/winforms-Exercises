using System.Security.Cryptography;
using Npgsql;

namespace RegisterLogin.Database;

/// <summary>
/// Handles all PostgreSQL database operations using ADO.NET (Npgsql).
/// Connection string is configured in one place here.
/// </summary>
public static class DatabaseConnection
{
    // ============================================================
    // PASSWORD IS READ FROM AN ENVIRONMENT VARIABLE
    //
    // Option A (recommended): set env var PG_PASSWORD to your real password
    // Option B: set env var to whatever name you already use on your PC
    //
    // Change "PG_PASSWORD" below to match the name of YOUR user variable.
    // ============================================================
    private const string PasswordEnvironmentVariableName = "PG_PASSWORD";

    private static string GetConnectionString()
    {
        // Read the password from the Windows User environment variable
        string? password = Environment.GetEnvironmentVariable(
            PasswordEnvironmentVariableName,
            EnvironmentVariableTarget.User);

        // Also try Process scope (in case it was set only for the current session)
        if (string.IsNullOrWhiteSpace(password))
        {
            password = Environment.GetEnvironmentVariable(
                PasswordEnvironmentVariableName,
                EnvironmentVariableTarget.Process);
        }

        // Fallback: Machine (system) scope
        if (string.IsNullOrWhiteSpace(password))
        {
            password = Environment.GetEnvironmentVariable(
                PasswordEnvironmentVariableName,
                EnvironmentVariableTarget.Machine);
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidOperationException(
                $"PostgreSQL password not found.\n\n" +
                $"Create a User environment variable named '{PasswordEnvironmentVariableName}' " +
                $"and set its value to your real postgres password.\n\n" +
                "Steps:\n" +
                "1. Windows Search → 'Environment Variables'\n" +
                "2. Under 'User variables' click New\n" +
                $"3. Name: {PasswordEnvironmentVariableName}\n" +
                "4. Value: your actual postgres password\n" +
                "5. OK, then RESTART Visual Studio (or the terminal) so it picks up the new variable.");
        }

        return $"Host=localhost;Port=5432;Database=winforms_exercises;Username=postgres;Password={password};";
    }

    /// <summary>
    /// Creates a new open NpgsqlConnection.
    /// Caller is responsible for disposing it (use 'using').
    /// </summary>
    public static NpgsqlConnection GetConnection()
    {
        var connection = new NpgsqlConnection(GetConnectionString());
        connection.Open();
        return connection;
    }

    /// <summary>
    /// Hashes a password using PBKDF2 (beginner-friendly, built into .NET).
    /// </summary>
    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        byte[] combined = new byte[salt.Length + hash.Length];
        Buffer.BlockCopy(salt, 0, combined, 0, salt.Length);
        Buffer.BlockCopy(hash, 0, combined, salt.Length, hash.Length);

        return Convert.ToBase64String(combined);
    }

    /// <summary>
    /// Verifies a password against a stored hash.
    /// </summary>
    public static bool VerifyPassword(string password, string storedHash)
    {
        try
        {
            byte[] combined = Convert.FromBase64String(storedHash);
            if (combined.Length != 48)
                return false;

            byte[] salt = new byte[16];
            byte[] storedHashBytes = new byte[32];
            Buffer.BlockCopy(combined, 0, salt, 0, 16);
            Buffer.BlockCopy(combined, 16, storedHashBytes, 0, 32);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] computedHash = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(computedHash, storedHashBytes);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks if a username already exists in the database.
    /// </summary>
    public static bool UsernameExists(string username)
    {
        using var connection = GetConnection();
        using var command = new NpgsqlCommand(
            "SELECT COUNT(*) FROM users WHERE username = @username",
            connection);

        command.Parameters.AddWithValue("username", username);

        long count = (long)(command.ExecuteScalar() ?? 0L);
        return count > 0;
    }

    /// <summary>
    /// Registers a new user. Returns true on success.
    /// Throws if username already exists or database error occurs.
    /// </summary>
    public static bool RegisterUser(string username, string password)
    {
        if (UsernameExists(username))
            throw new InvalidOperationException("Username already exists.");

        string passwordHash = HashPassword(password);

        using var connection = GetConnection();
        using var command = new NpgsqlCommand(
            "INSERT INTO users (username, password_hash) VALUES (@username, @password_hash)",
            connection);

        command.Parameters.AddWithValue("username", username);
        command.Parameters.AddWithValue("password_hash", passwordHash);

        int rowsAffected = command.ExecuteNonQuery();
        return rowsAffected > 0;
    }

    /// <summary>
    /// Validates login credentials. Returns true if username and password match.
    /// </summary>
    public static bool ValidateLogin(string username, string password)
    {
        using var connection = GetConnection();
        using var command = new NpgsqlCommand(
            "SELECT password_hash FROM users WHERE username = @username",
            connection);

        command.Parameters.AddWithValue("username", username);

        object? result = command.ExecuteScalar();
        if (result is null || result is DBNull)
            return false;

        string storedHash = (string)result;
        return VerifyPassword(password, storedHash);
    }
}
