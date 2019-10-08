using System.Collections.Generic;

namespace MathCalculator
{
    public class FormatterString
    {
        private string _inputString;
        public FormatterString()
        {

        }
        public FormatterString(string inputString)
        {
            _inputString = inputString;
        }
        
        public string FormattingString()
        { 
            string resultString;

            resultString = _inputString.Replace(" ", "").Replace(".", ",");

            return resultString;
        }

        public List<string> FormatUnaryMinus(List<string> listStr)
        {
            for (int i = 0; i < listStr.Count; i++)
            {
                if (i + 1 < listStr.Count && listStr[i].Equals(MathOperations.BinaryMinus))
                {
                    if (i - 1 >= 0)
                    {
                        if (MathOperations.BasicOperators.ContainsKey(listStr[i - 1]) &&
                            listStr[i - 1] != MathOperations.CloseBracket)
                        {
                            listStr[i] = MathOperations.UnaryMinus;
                        }
                    }
                    else
                    {
                        listStr[i] = MathOperations.UnaryMinus;
                    }
                }
            }
            return listStr;
        }

    }
}
