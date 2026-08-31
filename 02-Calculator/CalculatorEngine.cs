namespace Calculator;

/// <summary>
/// Simple expression evaluator that supports +, -, ×, ÷ with correct operator precedence.
/// Multiplies and divides before adding and subtracting.
/// </summary>
public static class CalculatorEngine
{
    public static string Evaluate(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            return "0";

        // Tokenize into numbers and operators
        var tokens = Tokenize(expression);
        if (tokens.Count == 0)
            return "0";

        // First pass: handle × and ÷ (left to right)
        var afterMulDiv = new List<object>();
        int i = 0;
        while (i < tokens.Count)
        {
            if (tokens[i] is double)
            {
                afterMulDiv.Add(tokens[i]);
                i++;
            }
            else if (tokens[i] is string op && (op == "×" || op == "÷"))
            {
                if (afterMulDiv.Count == 0 || i + 1 >= tokens.Count || tokens[i + 1] is not double)
                    throw new InvalidOperationException("Invalid expression");

                double left = (double)afterMulDiv[^1];
                double right = (double)tokens[i + 1];

                if (op == "÷" && right == 0)
                    throw new DivideByZeroException();

                double result = op == "×" ? left * right : left / right;
                afterMulDiv[^1] = result;
                i += 2;
            }
            else
            {
                afterMulDiv.Add(tokens[i]);
                i++;
            }
        }

        // Second pass: handle + and - (left to right)
        if (afterMulDiv.Count == 0)
            return "0";

        double total = afterMulDiv[0] is double d ? d : throw new InvalidOperationException("Invalid expression");

        for (int j = 1; j < afterMulDiv.Count; j += 2)
        {
            if (j + 1 >= afterMulDiv.Count)
                break;

            string op = afterMulDiv[j] as string ?? throw new InvalidOperationException("Invalid expression");
            double right = afterMulDiv[j + 1] is double r ? r : throw new InvalidOperationException("Invalid expression");

            if (op == "+")
                total += right;
            else if (op == "-")
                total -= right;
            else
                throw new InvalidOperationException("Invalid operator");
        }

        return FormatResult(total);
    }

    private static List<object> Tokenize(string expression)
    {
        var tokens = new List<object>();
        int i = 0;

        while (i < expression.Length)
        {
            char c = expression[i];

            if (char.IsWhiteSpace(c))
            {
                i++;
                continue;
            }

            if (c == '+' || c == '-' || c == '×' || c == '÷')
            {
                // Handle unary minus at the start of a number (e.g. after an operator or at beginning)
                if (c == '-' && (tokens.Count == 0 || tokens[^1] is string))
                {
                    // Parse negative number
                    i++;
                    if (i >= expression.Length || (!char.IsDigit(expression[i]) && expression[i] != '.'))
                        throw new InvalidOperationException("Invalid expression");

                    int start = i;
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                        i++;

                    string numStr = expression[start..i];
                    if (!double.TryParse(numStr, out double negNum))
                        throw new InvalidOperationException("Invalid number");
                    tokens.Add(-negNum);
                }
                else
                {
                    tokens.Add(c.ToString());
                    i++;
                }
            }
            else if (char.IsDigit(c) || c == '.')
            {
                int start = i;
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    i++;

                string numStr = expression[start..i];
                if (!double.TryParse(numStr, out double num))
                    throw new InvalidOperationException("Invalid number");
                tokens.Add(num);
            }
            else
            {
                throw new InvalidOperationException("Invalid character in expression");
            }
        }

        return tokens;
    }

    private static string FormatResult(double value)
    {
        // Avoid unnecessary trailing zeros (e.g. 25 instead of 25.000000)
        if (value == Math.Floor(value) && !double.IsInfinity(value))
            return ((long)value).ToString();

        // Round to a reasonable number of decimal places to avoid floating-point noise
        string formatted = value.ToString("G10");
        return formatted;
    }
}
