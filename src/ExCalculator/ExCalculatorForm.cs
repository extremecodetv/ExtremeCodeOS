using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        bool isOperator { get; set; } = true;
        string _input { get; set; }

        public void AddNum(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (output.Text != "")
                ClearAll();

            _input += button.Text;

            input.Text = _input;
        }

        public void AddOperator(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (output.Text != "")
                return;

            _input += isOperator ? $" {button.Text} " : "";

            input.Text = _input;

            isOperator = false;
        }

        public void ClearAll(object sender, EventArgs e)
        {
            input.Text = "";
            output.Text = "";
            isOperator = true;
            _input = "";
        }

        public void ClearAll()
        {
            input.Text = "";
            output.Text = "";
            isOperator = true;
            _input = "";
        }

        public void Delete(object sender, EventArgs e)
        {
            if (_input == "")
            {
                return;
            }

            if (_input[_input.Length - 1] == '+' ||
                _input[_input.Length - 1] == '-' ||
                _input[_input.Length - 1] == 'x' ||
                _input[_input.Length - 1] == '%' ||
                _input[_input.Length - 1] == '^')
            {
                isOperator = true;
            }

            _input = _input.Remove(_input.Length - 1);

            input.Text = _input;
        }

        public void Answer(object sender, EventArgs e)
        {
            string[] operation = _input.Split(' ');

            if (operation.Length < 3 || operation[operation.Length - 1] == "")
                return;

            double num1 = Convert.ToDouble(operation[0]);
            double num2 = Convert.ToDouble(operation[2]);

            double answer = 0;

            switch (operation[1])
            {
                case "+":
                    answer = num1 + num2;

                    ClearAll();
                    break;

                case "-":
                    answer = num1 - num2;

                    ClearAll();
                    break;

                case "x":
                    answer = num1 * num2;

                    ClearAll();
                    break;

                case "%":
                    answer = num1 / num2;

                    ClearAll();
                    break;

                case "^":
                    answer = Math.Pow(num1, num2);

                    ClearAll();
                    break;
            }

            output.Text = answer.ToString();
        }

        public void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}