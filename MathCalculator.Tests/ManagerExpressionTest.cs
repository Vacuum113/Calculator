using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MathCalculator.Test
{
    [TestClass]
    public class ManagerExpressionTest
    {
        [TestMethod]
        public void Control_2Plus5_7Returned()
        {
            string str = "+";
            Stack<double> stack = new Stack<double>();
            stack.Push(2);
            stack.Push(5);

            double result = ManagerExpression.Control(str, stack);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Control_10BinariMinus5_5Returned()
        {
            string str = "-";
            Stack<double> stack = new Stack<double>();
            stack.Push(10);
            stack.Push(5);

            double result = ManagerExpression.Control(str, stack);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Control_2Dot5Multiplication6_15Returned()
        {
            string str = "*";
            Stack<double> stack = new Stack<double>();
            stack.Push(2.5);
            stack.Push(6);

            double result = ManagerExpression.Control(str, stack);

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Control_15Division6_2Dot5Returned()
        {
            string str = "/";
            Stack<double> stack = new Stack<double>();
            stack.Push(15);
            stack.Push(6);

            double result = ManagerExpression.Control(str, stack);

            Assert.AreEqual(2.5, result);
        }

        [TestMethod]
        public void Control_2Divisionn0_ErrorReturned()
        {
            string result = "";
            string str = "/";
            Stack<double> stack = new Stack<double>();
            stack.Push(2);
            stack.Push(0);
            try
            {
                double value = ManagerExpression.Control(str, stack);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            Assert.AreEqual("Cannot be divided by zero", result);
        }

        public void Control_15UnaryMinus_UnaryMinus_15Returned()
        {
            string str = "~";
            Stack<double> stack = new Stack<double>();
            stack.Push(15);

            double result = ManagerExpression.Control(str, stack);

            Assert.AreEqual(-15, result);
        }

        public void Control_InvalidOperator_ErrorReturned()
        {
            string error = "";
            string str = "|";
            Stack<double> stack = new Stack<double>();
            stack.Push(15);
            stack.Push(10);
            try
            {
                double result = ManagerExpression.Control(str, stack);
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("Invalid Operator", error);
        }

    }
}
