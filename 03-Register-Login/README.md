# 03 — Register & Login with PostgreSQL

A beginner-friendly WinForms exercise that teaches:

- Visual Studio WinForms Designer
- Form navigation
- PostgreSQL + ADO.NET (Npgsql)
- Parameterized queries
- Simple password hashing (PBKDF2)

## Setup steps

### 1. Create the database

Run the SQL in `sql/create_database.sql` (or manually):

```sql
CREATE DATABASE winforms_exercises;

-- Then connect to winforms_exercises and run:
CREATE TABLE IF NOT EXISTS users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(100) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

### 2. Set your PostgreSQL password (environment variable)

The app reads the password from a **User environment variable** named `PG_PASSWORD`.

**Create the variable:**

1. Windows Search → type **Environment Variables** → Open **Edit the system environment variables**
2. Click **Environment Variables...**
3. Under **User variables** click **New...**
4. Variable name: `PG_PASSWORD`
5. Variable value: your real postgres password (the actual password, not another variable name)
6. Click OK on all dialogs

**Important:** Restart Visual Studio (or close and reopen the terminal) so it picks up the new variable.

If your environment variable already has a different name, open:

`Database/DatabaseConnection.cs`

and change this line to match your variable name:

```csharp
private const string PasswordEnvironmentVariableName = "PG_PASSWORD";
```

### 3. Restore NuGet packages

The project uses the **Npgsql** package. Visual Studio will restore it automatically,
or run:

```bash
cd 03-Register-Login
dotnet restore
```

### 4. Run the project

In Visual Studio:

1. Open `WinFormsExercises.sln`
2. Right-click **RegisterLogin** → Set as Startup Project
3. Press F5

Or from the command line:

```bash
cd 03-Register-Login
dotnet run
```

The app starts on the **Login** form. Use the button at the bottom to go to Register.

## Color theme

- **Register form**: soft pastel lavender / soft pink
- **Login form**: soft baby blue / cream

All colors are set in the Designer files so you can see and edit them in Visual Studio Designer.
