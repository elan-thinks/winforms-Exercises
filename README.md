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

Alternatively, from the command line (with .NET 8 SDK):

```bash
cd 01-BMI-Calculator
dotnet run
```

#### Features

- Enter height (cm) and weight (kg)
- Calculate BMI and see category (Underweight / Normal weight / Overweight / Obese)
- Clear button resets the form
- Full Visual Studio Designer support — open `BMIForm.cs` → View Designer to see and edit the UI visually
