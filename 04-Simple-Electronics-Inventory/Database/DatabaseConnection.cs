using System.Security.Cryptography;
using ElectronicsInventory.Models;
using Npgsql;

namespace ElectronicsInventory.Database;

/// <summary>
/// All PostgreSQL access via ADO.NET (Npgsql).
/// Password is read from environment variable PG_PASSWORD.
/// </summary>
public static class DatabaseConnection
{
    // Change this if your env variable has a different name
    private const string PasswordEnvironmentVariableName = "PG_PASSWORD";

    private static string GetConnectionString()
    {
        string? password = Environment.GetEnvironmentVariable(PasswordEnvironmentVariableName, EnvironmentVariableTarget.User)
            ?? Environment.GetEnvironmentVariable(PasswordEnvironmentVariableName, EnvironmentVariableTarget.Process)
            ?? Environment.GetEnvironmentVariable(PasswordEnvironmentVariableName, EnvironmentVariableTarget.Machine);

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidOperationException(
                $"PostgreSQL password not found.\n\n" +
                $"Set a User environment variable named '{PasswordEnvironmentVariableName}' " +
                "to your real postgres password, then restart Visual Studio.");
        }

        return $"Host=localhost;Port=5432;Database=winforms_exercises;Username=postgres;Password={password};";
    }

    public static NpgsqlConnection GetConnection()
    {
        var connection = new NpgsqlConnection(GetConnectionString());
        connection.Open();
        return connection;
    }

    // ---------- Password hashing (PBKDF2) ----------

    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        byte[] combined = new byte[48];
        Buffer.BlockCopy(salt, 0, combined, 0, 16);
        Buffer.BlockCopy(hash, 0, combined, 16, 32);
        return Convert.ToBase64String(combined);
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        try
        {
            byte[] combined = Convert.FromBase64String(storedHash);
            if (combined.Length != 48) return false;

            byte[] salt = new byte[16];
            byte[] hash = new byte[32];
            Buffer.BlockCopy(combined, 0, salt, 0, 16);
            Buffer.BlockCopy(combined, 16, hash, 0, 32);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] computed = pbkdf2.GetBytes(32);
            return CryptographicOperations.FixedTimeEquals(computed, hash);
        }
        catch
        {
            return false;
        }
    }

    // ---------- Users ----------

    public static bool UsernameExists(string username)
    {
        using var conn = GetConnection();
        using var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE username = @username", conn);
        cmd.Parameters.AddWithValue("username", username);
        return (long)(cmd.ExecuteScalar() ?? 0L) > 0;
    }

    public static bool RegisterUser(string username, string password)
    {
        if (UsernameExists(username))
            throw new InvalidOperationException("Username already exists.");

        string hash = HashPassword(password);
        using var conn = GetConnection();
        using var cmd = new NpgsqlCommand(
            "INSERT INTO users (username, password_hash) VALUES (@username, @password_hash)", conn);
        cmd.Parameters.AddWithValue("username", username);
        cmd.Parameters.AddWithValue("password_hash", hash);
        return cmd.ExecuteNonQuery() > 0;
    }

    public static bool ValidateLogin(string username, string password)
    {
        using var conn = GetConnection();
        using var cmd = new NpgsqlCommand(
            "SELECT password_hash FROM users WHERE username = @username", conn);
        cmd.Parameters.AddWithValue("username", username);
        object? result = cmd.ExecuteScalar();
        if (result is null or DBNull) return false;
        return VerifyPassword(password, (string)result);
    }

    // ---------- Products ----------

    public static List<Product> GetAllProducts()
    {
        var list = new List<Product>();
        using var conn = GetConnection();
        using var cmd = new NpgsqlCommand(
            "SELECT id, name, category, price, quantity FROM products ORDER BY id", conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Product
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Category = reader.GetString(2),
                Price = reader.GetDecimal(3),
                Quantity = reader.GetInt32(4)
            });
        }
        return list;
    }

    public static List<Product> SearchProducts(string searchText)
    {
        var list = new List<Product>();
        using var conn = GetConnection();
        using var cmd = new NpgsqlCommand(
            @"SELECT id, name, category, price, quantity
              FROM products
              WHERE name ILIKE @search OR category ILIKE @search
              ORDER BY id", conn);
        cmd.Parameters.AddWithValue("search", "%" + searchText + "%");
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Product
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Category = reader.GetString(2),
                Price = reader.GetDecimal(3),
                Quantity = reader.GetInt32(4)
            });
        }
        return list;
    }

    public static bool InsertProduct(string name, string category, decimal price, int quantity)
    {
        using var conn = GetConnection();
        using var cmd = new NpgsqlCommand(
            "INSERT INTO products (name, category, price, quantity) VALUES (@name, @category, @price, @quantity)", conn);
        cmd.Parameters.AddWithValue("name", name);
        cmd.Parameters.AddWithValue("category", category);
        cmd.Parameters.AddWithValue("price", price);
        cmd.Parameters.AddWithValue("quantity", quantity);
        return cmd.ExecuteNonQuery() > 0;
    }

    public static bool UpdateProduct(int id, string name, string category, decimal price, int quantity)
    {
        using var conn = GetConnection();
        using var cmd = new NpgsqlCommand(
            @"UPDATE products
              SET name = @name, category = @category, price = @price, quantity = @quantity
              WHERE id = @id", conn);
        cmd.Parameters.AddWithValue("id", id);
        cmd.Parameters.AddWithValue("name", name);
        cmd.Parameters.AddWithValue("category", category);
        cmd.Parameters.AddWithValue("price", price);
        cmd.Parameters.AddWithValue("quantity", quantity);
        return cmd.ExecuteNonQuery() > 0;
    }

    public static bool DeleteProduct(int id)
    {
        using var conn = GetConnection();
        using var cmd = new NpgsqlCommand("DELETE FROM products WHERE id = @id", conn);
        cmd.Parameters.AddWithValue("id", id);
        return cmd.ExecuteNonQuery() > 0;
    }
}
