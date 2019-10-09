using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MathCalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Calculation_Plus_Test()
        {
            double result = new Calculator().Calculation(new List<string> { "2", "3", "+" });

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Calculation_BinaryMinus_Test()
        {
            double result = new Calculator().Calculation(new List<string> { "2", "3", "-" });

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Calculation_Division_Test()
        {
            double result = new Calculator().Calculation(new List<string> { "10", "2", "/" });

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Calculation_Multiplication_Test()
        {
            double result = new Calculator().Calculation(new List<string> { "2,5", "2", "*" });

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Calculation_UnaryMinus_Test()
        {
            double result = new Calculator().Calculation(new List<string> { "2", "~" });

            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void Calculation_Error_Test()
        {
            string error = "";
            try
            {
                double result = new Calculator().Calculation(new List<string> { "2", "3", "3", "+" });
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("Expression is not valid!", error);
        }
    }
}