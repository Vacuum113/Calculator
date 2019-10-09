using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathCalculator.Test
{
    [TestClass]
    public class RunnerTest
    {
        [TestMethod]
        public void Run_2Plus3_5Returned()
        {
            double result;
            Runner Runner = new Runner("2 + 3");
            result = Runner.Run();
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Run_4BinaryMinus3_1Returned()
        {
            double result;
            Runner Runner = new Runner("4 - 3");
            result = Runner.Run();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Run_2PlusUnaryMinus3_UnaryMinus1Returned()
        {
            double result;
            Runner Runner = new Runner("2 + (-3)");
            result = Runner.Run();
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Run_4Multiplication10_40Returned()
        {
            double result;
            Runner Runner = new Runner("4 * 10");
            result = Runner.Run();
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void Run_10Division2_5Returned()
        {
            double result;
            Runner Runner = new Runner("10 / 2");
            result = Runner.Run();
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Run_3dot5Division3comma5_1Returned()
        {
            double result;
            Runner Runner = new Runner("3.5/3,5");
            result = Runner.Run();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Run_20DivisionUnaryMinus5_UnaryMinus4Returned()
        {
            double result;
            Runner Runner = new Runner("20 /(-5)");
            result = Runner.Run();
            Assert.AreEqual(-4, result);
        }

        [TestMethod]
        public void Run_0dot5Plus2dot5_3Returned()
        {
            double result;
            Runner Runner = new Runner("0.5+2.5");
            result = Runner.Run();
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Run_10000000Division1000_1Returned()
        {
            double result;
            Runner Runner = new Runner("10000000 / 1000");
            result = Runner.Run();
            Assert.AreEqual(10000, result);
        }

        [TestMethod]
        public void Run_Expression_UnaryMinus1dot2Returned()
        {
            double result;
            Runner Runner = new Runner("-2*3/5");
            result = Runner.Run();
            Assert.AreEqual(-1.2, result);
        }

        [TestMethod]
        public void Run_0Multiplication10_0Returned()
        {
            double result;
            Runner Runner = new Runner("0*10");
            result = Runner.Run();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Run_Expression_UnaryMinus0dot1Returned()
        {
            double result;
            Runner Runner = new Runner("(2*5) / (10 -(-10))");
            result = Runner.Run();
            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void Run_Expression_0Returned()
        {
            double result;
            Runner Runner = new Runner("2+-2");
            result = Runner.Run();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Run_Expression_4dot8Returned()
        {
            double result;
            Runner Runner = new Runner("--2*((8+2*5)/(1+3*2-4))/2.5");
            result = Runner.Run();
            Assert.AreEqual(4.8, result);
        }

        [TestMethod]
        public void Run_2Division0_ReturnError()
        {
            string error = "";
            double result;
            try
            {
                Runner Runner = new Runner("2/0");
                result = Runner.Run();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("Cannot be divided by zero", error);

        }

        [TestMethod]
        public void Run_2comma2comma2comma2Division3_ReturnError()
        {
            string error = "";
            double result;
            try
            {
                Runner Runner = new Runner("2,2,2/3");
                result = Runner.Run();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("Invalid operator!", error);
        }

        [TestMethod]
        public void Run_2Division2CloseBracket_ReturnError()
        {
            string error = "";
            double result;
            try
            {
                Runner Runner = new Runner("2/2)");
                result = Runner.Run();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("Open bracket not found!", error);
        }

        [TestMethod]
        public void Run_OpenBracket2Division2_ReturnError()
        {
            string error = "";
            double result;
            try
            {
                Runner Runner = new Runner("(2/2");
                result = Runner.Run();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("Close bracket not found!", error);
        }

        [TestMethod]
        public void Run_2StraightLine2_ReturnError()
        {
            string error = "";
            double result;
            try
            {
                Runner Runner = new Runner("2|2");
                result = Runner.Run();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("Invalid operator!", error);
        }

        [TestMethod]
        public void Run_2BinaryPlusBinaryPlus2_ReturnError()
        {
            string error = "";
            double result;
            try
            {
                Runner Runner = new Runner("2++2");
                result = Runner.Run();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("Expression is not valid!", error);
        }

        [TestMethod]
        public void Run_Expression_NotValidErrorReturned()
        {
            string error = "";
            double result;
            try
            {
                Runner Runner = new Runner("--2((8+2*5)/(1+3*2-4))/2.5");
                result = Runner.Run();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("Expression is not valid!", error);
        }
    }
}
