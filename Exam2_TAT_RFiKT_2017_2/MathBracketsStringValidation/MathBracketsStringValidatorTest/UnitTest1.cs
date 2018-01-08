using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathBracketsStringValidation;

namespace MathBracketsStringValidationTest
{
    [TestClass]
    public class CheckerForBracketsTest
    {
        [TestMethod]
        public void TestCheckEmptyString()
        {
            Assert.AreEqual(true, new CheckerForBrackets().Check(""));
        }

        [TestMethod]
        public void TestCheckSinglePairOfBrackets()
        {
            Assert.AreEqual(true, new CheckerForBrackets().Check("{}"));
        }

        [TestMethod]
        public void TestCheckTwoPairsOfBrackets()
        {
            Assert.AreEqual(true, new CheckerForBrackets().Check("{}[]"));
        }

        [TestMethod]
        public void TestCheckThreePairsOfBrackets()
        {
            Assert.AreEqual(true, new CheckerForBrackets().Check("{}[]()"));
        }

        [TestMethod]
        public void TestCheckFewSimilarBracketsOneInsideAnother()
        {
            Assert.AreEqual(true, new CheckerForBrackets().Check("{some_operations{some_operations{some_operations}some_operations}some_operations}"));
        }

        [TestMethod]
        public void TestCheckComplexBracketsExpression()
        {
            Assert.AreEqual(true, new CheckerForBrackets().Check("{[()()][{}]}"));
        }

        [TestMethod]
        public void TestCheckIncorrectSingleBracket()
        {
            Assert.AreEqual(false, new CheckerForBrackets().Check("["));
        }

        [TestMethod]
        public void TestCheckIncorrectSinglePairOfBrackets()
        {
            Assert.AreEqual(false, new CheckerForBrackets().Check("}{"));
        }

        [TestMethod]
        public void TestCheckIncorrectTwoPairsOfBrackets()
        {
            Assert.AreEqual(false, new CheckerForBrackets().Check("{[}]"));
        }

        [TestMethod]
        public void TestCheckIncorrectThreePairsOfBrackets()
        {
            Assert.AreEqual(false, new CheckerForBrackets().Check("{(}[)]"));
        }

        [TestMethod]
        public void TestCheckIncorrectFewSimilarBracketsOneInsideAnother()
        {
            Assert.AreEqual(false, new CheckerForBrackets().Check("}}}{{{"));
        }

        [TestMethod]
        public void TestCheckIncorrectComplexBracketsExpression()
        {
            Assert.AreEqual(false, new CheckerForBrackets().Check("{(}[()]{()}"));
        }
    }
}