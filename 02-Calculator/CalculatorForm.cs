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
    }

    private void btnDecimal_Click(object sender, EventArgs e)
    {
        if (_justCalculated)
        {
            _expression = string.Empty;
            txtDisplay.Text = "0.";
            _justCalculated = false;
            _lastWasOperator = false;
            return;
        }

        if (_lastWasOperator || txtDisplay.Text == "Cannot divide by zero")
        {
            txtDisplay.Text = "0.";
            _lastWasOperator = false;
            return;
        }

        // Only allow one decimal point in the current number
        if (!txtDisplay.Text.Contains('.'))
        {
            txtDisplay.Text += ".";
        }
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
            return;
        }

        if (_lastWasOperator)
        {
            // Replace the previous operator
            if (_expression.Length >= 3)
            {
                _expression = _expression[..^3] + op + " ";
            }
            return;
        }

        // Append current number and the operator to the expression
        _expression += txtDisplay.Text + " " + op + " ";
        _lastWasOperator = true;
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
                return;
            }

            string result = CalculatorEngine.Evaluate(fullExpression);
            txtDisplay.Text = result;
            _expression = string.Empty;
            _justCalculated = true;
            _lastWasOperator = false;
        }
        catch (DivideByZeroException)
        {
            txtDisplay.Text = "Cannot divide by zero";
            _expression = string.Empty;
            _justCalculated = true;
            _lastWasOperator = false;
        }
        catch
        {
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
    }
}
