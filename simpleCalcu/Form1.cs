using System;
using System.Windows.Forms;

namespace simpleCalcu
{
    public partial class Form1 : Form
    {
        string input = "";
        double result = 0;
        string operation = "";
        bool operationSelected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void DigitButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Prevent multiple decimals
            if (button.Text == "." && input.Contains("."))
                return;

            input += button.Text;
            textBox1.Text = input;
        }

        private void SetOperation(string op)
        {
            if (input != "")
            {
                if (double.TryParse(input, out double current))
                {
                    if (operationSelected)
                        CalculateResult(current);
                    else
                        result = current;
                }
                else
                {
                    MessageBox.Show("Invalid input.");
                    input = "";
                    return;
                }

                input = "";
                operationSelected = false;
            }

            operation = op;
            operationSelected = true;
        }

        private void CalculateResult(double currentInput)
        {
            switch (operation)
            {
                case "+":
                    result += currentInput;
                    break;
                case "-":
                    result -= currentInput;
                    break;
                case "*":
                    result *= currentInput;
                    break;
                case "/":
                    if (currentInput != 0)
                        result /= currentInput;
                    else
                    {
                        MessageBox.Show("Cannot divide by zero.");
                        return;
                    }
                    break;
                default:
                    MessageBox.Show("No operation selected.");
                    return;
            }
            textBox1.Text = result.ToString();
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            if (input != "")
            {
                if (double.TryParse(input, out double current))
                {
                    CalculateResult(current);
                    input = "";
                    operationSelected = false;
                    operation = "";
                }
                else
                {
                    MessageBox.Show("Invalid input.");
                    input = "";
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            input = "";
            result = 0;
            operation = "";
            operationSelected = false;
            textBox1.Text = "";
        }

        // Operation Buttons
        private void AddButton_Click(object sender, EventArgs e) => SetOperation("+");
        private void SubtractButton_Click(object sender, EventArgs e) => SetOperation("-");
        private void MultiplyButton_Click(object sender, EventArgs e) => SetOperation("*");
        private void DivideButton_Click(object sender, EventArgs e) => SetOperation("/");

        // Optional: Recalculate without changing operation
        private void RecalculateButton_Click(object sender, EventArgs e)
        {
            if (input != "" && double.TryParse(input, out double current))
            {
                CalculateResult(current);
                input = "";
                operationSelected = false;
            }

            textBox1.Text = result.ToString();
        }

    }
}
