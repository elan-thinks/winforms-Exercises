using System.Security.Cryptography;
using System.Text;
using Npgsql;
using RegisterLogin.Models;

namespace RegisterLogin.Database;

/// <summary>
/// Handles all PostgreSQL database operations using ADO.NET (Npgsql).
/// Connection string is configured in one place here.
/// </summary>
public static class DatabaseConnection
{
    // ============================================================
    // CONFIGURE YOUR POSTGRESQL PASSWORD HERE
    // Replace YOUR_PASSWORD with your actual postgres password.
    // ============================================================
    private const string ConnectionString =
        "Host=localhost;Port=5432;Database=winforms_exercises;Username=postgres;Password=YOUR_PASSWORD;";

    /// <summary>
    /// Creates a new open NpgsqlConnection.
    /// Caller is responsible for disposing it (use 'using').
    /// </summary>
    public static NpgsqlConnection GetConnection()
    {
        var connection = new NpgsqlConnection(ConnectionString);
        connection.Open();
        return connection;
    }

    /// <summary>
    /// Hashes a password using PBKDF2 (beginner-friendly, built into .NET).
    /// </summary>
    public static string HashPassword(string password)
    {
        // Generate a random salt
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        // Derive a 32-byte key using PBKDF2 with 100,000 iterations
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        // Store salt + hash together (base64)
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
            if (combined.Length != 48) // 16 salt + 32 hash
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
