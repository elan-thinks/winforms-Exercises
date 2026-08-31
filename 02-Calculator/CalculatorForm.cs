namespace Calculator;

public partial class CalculatorForm : Form
{
    // Holds the full expression being built (e.g. "10 + 20 + 30")
    private string _expression = string.Empty;

    // True after equals was pressed — next number starts a new calculation
    private bool _justCalculated = false;

    // True when the last action was an operator
    private bool _lastWasOperator = false;

    public CalculatorForm()
    {
        InitializeComponent();
        txtDisplay.Text = "0";
        lblExpression.Text = string.Empty;
    }

    /// <summary>
    /// Updates the expression preview label so the user can see what they typed.
    /// </summary>
    private void UpdateExpressionDisplay()
    {
        if (_justCalculated)
        {
            // After equals we already set the label in btnEquals_Click
            return;
        }

        if (string.IsNullOrEmpty(_expression))
        {
            lblExpression.Text = string.Empty;
        }
        else if (_lastWasOperator)
        {
            // Show expression so far (ends with operator), e.g. "8 + "
            lblExpression.Text = _expression.TrimEnd();
        }
        else
        {
            // Show full expression including current number, e.g. "8 + 5"
            lblExpression.Text = (_expression + txtDisplay.Text).Trim();
        }
    }

    private void btnNumber_Click(object sender, EventArgs e)
    {
        if (sender is not Button btn)
            return;

        string digit = btn.Text;

        if (_justCalculated)
        {
            // Start a fresh calculation after equals
            _expression = string.Empty;
            txtDisplay.Text = digit;
            _justCalculated = false;
            _lastWasOperator = false;
            UpdateExpressionDisplay();
            return;
        }

        if (_lastWasOperator || txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
        {
            txtDisplay.Text = digit;
            _lastWasOperator = false;
        }
        else
        {
            txtDisplay.Text += digit;
        }

        UpdateExpressionDisplay();
    }

    private void btnDecimal_Click(object sender, EventArgs e)
    {
        if (_justCalculated)
        {
            _expression = string.Empty;
            txtDisplay.Text = "0.";
            _justCalculated = false;
            _lastWasOperator = false;
            UpdateExpressionDisplay();
            return;
        }

        if (_lastWasOperator || txtDisplay.Text == "Cannot divide by zero")
        {
            txtDisplay.Text = "0.";
            _lastWasOperator = false;
            UpdateExpressionDisplay();
            return;
        }

        // Only allow one decimal point in the current number
        if (!txtDisplay.Text.Contains('.'))
        {
            txtDisplay.Text += ".";
        }

        UpdateExpressionDisplay();
    }

    private void btnOperator_Click(object sender, EventArgs e)
    {
        if (sender is not Button btn)
            return;

        string op = btn.Text; // "+", "-", "×", "÷"

        if (txtDisplay.Text == "Cannot divide by zero")
        {
            // Reset after error
            _expression = string.Empty;
            txtDisplay.Text = "0";
            lblExpression.Text = string.Empty;
            _lastWasOperator = false;
            _justCalculated = false;
            return;
        }

        if (_justCalculated)
        {
            // Continue from the previous result
            _expression = txtDisplay.Text + " " + op + " ";
            _justCalculated = false;
            _lastWasOperator = true;
            UpdateExpressionDisplay();
            return;
        }

        if (_lastWasOperator)
        {
            // Replace the previous operator
            if (_expression.Length >= 3)
            {
                _expression = _expression[..^3] + op + " ";
            }
            UpdateExpressionDisplay();
            return;
        }

        // Append current number and the operator to the expression
        _expression += txtDisplay.Text + " " + op + " ";
        _lastWasOperator = true;
        UpdateExpressionDisplay();
    }

    private void btnEquals_Click(object sender, EventArgs e)
    {
        if (txtDisplay.Text == "Cannot divide by zero")
            return;

        if (_justCalculated)
            return;

        try
        {
            string fullExpression = _expression + txtDisplay.Text;

            // If there is no operator yet, just keep the current number
            if (string.IsNullOrWhiteSpace(_expression))
            {
                _justCalculated = true;
                lblExpression.Text = string.Empty;
                return;
            }

            // Show the full expression with "=" before showing the result
            lblExpression.Text = fullExpression.Trim() + " =";

            string result = CalculatorEngine.Evaluate(fullExpression);
            txtDisplay.Text = result;
            _expression = string.Empty;
            _justCalculated = true;
            _lastWasOperator = false;
        }
        catch (DivideByZeroException)
        {
            lblExpression.Text = string.Empty;
            txtDisplay.Text = "Cannot divide by zero";
            _expression = string.Empty;
            _justCalculated = true;
            _lastWasOperator = false;
        }
        catch
        {
            lblExpression.Text = string.Empty;
            txtDisplay.Text = "Error";
            _expression = string.Empty;
            _justCalculated = true;
            _lastWasOperator = false;
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        _expression = string.Empty;
        txtDisplay.Text = "0";
        lblExpression.Text = string.Empty;
        _justCalculated = false;
        _lastWasOperator = false;
    }

    private void btnBackspace_Click(object sender, EventArgs e)
    {
        if (_justCalculated || _lastWasOperator || txtDisplay.Text == "Cannot divide by zero")
            return;

        if (txtDisplay.Text.Length > 1)
        {
            txtDisplay.Text = txtDisplay.Text[..^1];
        }
        else
        {
            txtDisplay.Text = "0";
        }

        UpdateExpressionDisplay();
    }
}
