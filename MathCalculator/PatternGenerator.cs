using System.Text;
using System.Text.RegularExpressions;

namespace MathCalculator
{
    public static class PatternGenerator
    {
        //  A class for creating a pattern for 
        //  regular expressions to split an expression into parts.

        public static string Generate()
        {
            string format = "|({0})";

            var str = new StringBuilder();

            foreach (string key in MathOperations.BasicOperators.Keys)
            {
                str.Append(string.Format(format, Regex.Escape(key)));
            }

            return str.Remove(0, 1).ToString();
        }
    }
}

