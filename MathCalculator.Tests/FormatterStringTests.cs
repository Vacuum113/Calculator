using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MathCalculator.Tests
{
    [TestClass]
    public class FormatterStringTests
    {
        [TestMethod]
        public void FormatUnaryMinus_ExpressionString_FormattedStringReturned()
        {
            List<string> str = new List<string> { "-", "-", "-", "4", 
                                                  "-", "-", "-", "4" };
            FormatterString formatter = new FormatterString();
            str = formatter.FormatUnaryMinus(str);

            List<string> expected = new List<string> {"~","~","~","4",
                                                      "-","~","~","4"};

            Assert.AreEqual(expected.ToString(), str.ToString());
        }

        [TestMethod]
        public void FormatUnaryMinus_ExpressionString2_FormattedStringReturned()
        {
            List<string> str = new List<string> { "-", "(", " ", "4",
                                                  "-", "2", ")" };
            FormatterString formatter = new FormatterString();
            str = formatter.FormatUnaryMinus(str);

            List<string> expected = new List<string> {"~","("," ","4",
                                                      "-","2",")"};

            Assert.AreEqual(expected.ToString(), str.ToString());
        }
    }
}