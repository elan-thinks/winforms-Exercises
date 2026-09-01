# WinForms Exercises

Independent C# Windows Forms exercises. Each project has its own `.csproj` and runs alone.

## Projects

| # | Folder | Project | Description |
|---|--------|---------|-------------|
| 01 | `01-BMI-Calculator` | BMICalculator | BMI calculator |
| 02 | `02-Calculator` | Calculator | Arithmetic calculator with precedence |
| 03 | `03-Register-Login` | RegisterLogin | Register/Login with PostgreSQL |
| 04 | `04-Simple-Electronics-Inventory` | ElectronicsInventory | Inventory CRUD + auth + search |

Open `WinFormsExercises.sln` in Visual Studio, set the desired project as Startup Project, press F5.

### 04 — Electronics Inventory (setup)

1. Ensure database `winforms_exercises` exists and tables `users` + `products` (see `04-Simple-Electronics-Inventory/sql/create_tables.sql`).
2. Set User env var `PG_PASSWORD` to your postgres password; restart Visual Studio.
3. Run project **ElectronicsInventory**.
