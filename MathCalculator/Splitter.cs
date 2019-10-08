using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MathCalculator
{
    public static class Splitter
    {
        public static List<string> SplitString(string inpStr)
        {
            string pattern = PatternGenerator.Generate();

            List<string> str = Regex.Split(inpStr, pattern).Where(x => x != string.Empty).ToList();

            return str;
        }
    }
}
