# 04 — Simple Electronics Inventory Management System

Beginner WinForms exercise: Register/Login + product CRUD + search with PostgreSQL (ADO.NET / Npgsql).

## Setup

### 1. Database

```sql
CREATE DATABASE winforms_exercises;  -- if not already created

-- Then connect to winforms_exercises and run:
CREATE TABLE IF NOT EXISTS users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(100) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(150) NOT NULL,
    category VARCHAR(100) NOT NULL,
    price NUMERIC(10,2) NOT NULL,
    quantity INT NOT NULL
);
```

Or use `sql/create_tables.sql`.

### 2. PostgreSQL password

Uses the same environment variable as project 03:

**User variable name:** `PG_PASSWORD`  
**Value:** your real postgres password

Restart Visual Studio after setting it.

If your variable has another name, edit `Database/DatabaseConnection.cs`:

```csharp
private const string PasswordEnvironmentVariableName = "PG_PASSWORD";
```

### 3. Run

```bash
cd 04-Simple-Electronics-Inventory
dotnet restore
dotnet run
```

Or in Visual Studio: set **ElectronicsInventory** as Startup Project → F5.

App starts on Login. Create an account, sign in, then manage products.
