using System.Collections.Generic;

namespace MathCalculator
{
    public class Runner
    {
        private string _inputString;
        public Runner(string inputString)
        {
            _inputString = inputString;
        }

        public double Run()
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
            double resutlt = new Calculator().Calculation(postfixNotationStrin);

            return resutlt;
        }
    }
}
