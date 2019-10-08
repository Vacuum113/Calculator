using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathCalculator.Tests
{
    [TestClass]
    public class PatternGeneratorTests
    {
        [TestMethod]
        public void Generate_Empty_StringPatternReturn()
        {
            var str = PatternGenerator.Generate();

            Assert.AreEqual(str, @"(\()|(\))|(-)|(\+)|(/)|(\*)|(~)");

        }
    }
}