# WinForms Exercises

A collection of independent C# Windows Forms exercises.

Each exercise is a complete, self-contained project that can be opened and run on its own.

## Projects

### 01-BMI-Calculator

A simple beginner-friendly BMI (Body Mass Index) calculator.

- **Project path:** `01-BMI-Calculator/`
- **Project name:** BMICalculator
- **Form name:** BMIForm

#### How to run

1. Open `WinFormsExercises.sln` in Visual Studio.
2. Set **BMICalculator** as the startup project (right-click → Set as Startup Project).
3. Press F5 or click Start.

Alternatively:

```bash
cd 01-BMI-Calculator
dotnet run
```

### 02-Calculator

A complete arithmetic calculator supporting +, -, ×, ÷ with correct operator precedence.

- **Project path:** `02-Calculator/`
- **Project name:** Calculator
- **Form name:** CalculatorForm

#### Features

- Addition, subtraction, multiplication, division
- Multiple numbers and operators in one expression
- Operator precedence (× and ÷ before + and -)
- Decimal numbers, division by zero handling, Clear & Backspace
- Expression preview while typing
- Full Visual Studio Designer support

#### How to run

1. Open `WinFormsExercises.sln` in Visual Studio.
2. Set **Calculator** as the startup project.
3. Press F5.

Alternatively:

```bash
cd 02-Calculator
dotnet run
```

### 03-Register-Login

Register & Login with PostgreSQL using ADO.NET (Npgsql).

- **Project path:** `03-Register-Login/`
- **Project name:** RegisterLogin
- **Forms:** LoginForm, RegisterForm

#### Features

- Cute pastel UI (lavender register, soft blue login)
- Full Visual Studio Designer support for both forms
- PostgreSQL + ADO.NET with parameterized queries
- PBKDF2 password hashing (no plain-text passwords)
- Form navigation between Login and Register
- Duplicate username handling, validation, friendly error messages

#### Setup

1. Create the database (see `03-Register-Login/sql/create_database.sql`)
2. Set your PostgreSQL password in `Database/DatabaseConnection.cs`
3. Restore NuGet packages (Npgsql)
4. Run the project

See `03-Register-Login/README.md` for detailed steps.

#### How to run

1. Open `WinFormsExercises.sln` in Visual Studio.
2. Set **RegisterLogin** as the startup project.
3. Press F5.

Alternatively:

```bash
cd 03-Register-Login
dotnet run
```
