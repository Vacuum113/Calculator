using System;
using System.Collections.Generic;

namespace MathCalculator
{
    public class Calculator
    {
        private string _inputString;
        public Calculator(string inputString)
        {
            _inputString = inputString;
        }

        public double Calculation()
        {
            FormatterString formatter = new FormatterString(_inputString);

            // Format the line, remove the spaces and replace the dots with commas.
            string formatString = formatter.FormattingString();

            // The string is split into individual characters.
            // The unary minus symbol is replaced by a tilde.
            List<string> splitString = formatter.FormatUnaryMinus(Splitter.SplitString(formatString));

            // Translation of a string from infix notation to reverse Polish notation.
            List<string> postfixNotationStrin = new ConvertToPostfixNotation(splitString).Convert();

            // The result is calculated using the stack.
            double resutlt = CalculateExpression(postfixNotationStrin); 

            return resutlt;
        }

        private double CalculateExpression(List<string> listStringToCalculate)
        { 
            Stack<double> stackResult = new Stack<double>();

            foreach (string value in listStringToCalculate)
            {
                double outParse;

                stackResult.Push(double.TryParse(value, out outParse) ? outParse : ManagerExpression.Control(value, stackResult));
            }

            if (stackResult.Count == 1)
            {
                return stackResult.Pop();
            }
            else
            {
                throw new Exception("Expression is not valid!");
            }
        }

    }
}
