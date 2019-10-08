using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MathCalculator.Tests
{
    [TestClass]
    public class ConvertToPostfixNotationTests
    {
        [TestMethod]
        public void Convert_String_ListStringReturned()
        {
            List<string> str = new List<string> {"(","~","~","2","/","(","8","+","2","*",
                                                "5",")","/","(","1","+","3","*","2","-",
                                                "4",")",")","+","2,5"};

            ConvertToPostfixNotation convert = new ConvertToPostfixNotation(str);
            List<string> result = convert.Convert();

            List<string> postfixNotationString = new List<string> { "2","~","~","8","2","5","*","+","/",
                                                                    "1","3","2","*","+","4","-","/","2,5","+"};
            Assert.AreEqual(postfixNotationString.ToString(),result.ToString());
        }

        [TestMethod]
        public void Convert_String_ListStringErrorBrackets()
        {
            string error = "";
            List<string> result;
            List<string> str = new List<string> { "(", "", "2", "+", "8", "" };
            try 
            {
                ConvertToPostfixNotation convert = new ConvertToPostfixNotation(str);
                result = convert.Convert();
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }

            Assert.AreEqual(error, "Close bracket not found!");
        }

        [TestMethod]
        public void Convert_String_ListStringWithSpaces()
        { 
            List<string> result = new List<string>();
            List<string> str = new List<string> { "(", "", "2", "+", "8", "", ")" };

            ConvertToPostfixNotation convert = new ConvertToPostfixNotation(str);
            result = convert.Convert();

            str = new List<string> { "2", "8", "+" };

            Assert.AreEqual(result.ToString(), str.ToString());
        }
    }
}