namespace BMICalculator;

public partial class BMIForm : Form
{
    public BMIForm()
    {
        InitializeComponent();
    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
        // Validate height
        if (string.IsNullOrWhiteSpace(txtHeight.Text))
        {
            lblSuggestion.Text = "Please enter a height.";
            txtHeight.Focus();
            return;
        }

        if (!double.TryParse(txtHeight.Text, out double heightCm) || heightCm <= 0)
        {
            lblSuggestion.Text = "Please enter a valid height greater than zero.";
            txtHeight.Focus();
            return;
        }

        // Validate weight
        if (string.IsNullOrWhiteSpace(txtWeight.Text))
        {
            lblSuggestion.Text = "Please enter a weight.";
            txtWeight.Focus();
            return;
        }

        if (!double.TryParse(txtWeight.Text, out double weightKg) || weightKg <= 0)
        {
            lblSuggestion.Text = "Please enter a valid weight greater than zero.";
            txtWeight.Focus();
            return;
        }

        // Convert height from cm to meters and calculate BMI
        double heightMeters = heightCm / 100.0;
        double bmi = weightKg / (heightMeters * heightMeters);

        // Determine category
        string category;
        if (bmi < 18.5)
        {
            category = "Underweight";
        }
        else if (bmi < 25.0)
        {
            category = "Normal weight";
        }
        else if (bmi < 30.0)
        {
            category = "Overweight";
        }
        else
        {
            category = "Obese";
        }

        // Display result to two decimal places
        lblSuggestion.Text = $"BMI: {bmi:F2} - {category}";
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        txtHeight.Clear();
        txtWeight.Clear();
        lblSuggestion.Text = string.Empty;
        txtHeight.Focus();
    }
}
