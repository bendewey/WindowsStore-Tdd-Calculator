using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestLibrary1
{
    [TestClass]
    public class EquationParserTests
    {
        [TestMethod]
        public void WhenParsingSimpleAdd_ThenShouldGetThreeTokens()
        {
            // Arrange
            var parser = new EquationParser();
            // Act
            var result = parser.Parse("1+2");

            // Assert
            Assert.AreEqual(3, result.Tokens.Count);
        }

        [TestMethod]
        public void WhenParsingSimpleAdd_ThenSecondTokenShouldBeAnAddOperator()
        {
            // Arrange
            var parser = new EquationParser();
        
            // Act
            var result = parser.Parse("1+2");

            // Assert
            Assert.AreEqual(TokenType.Operator, result.Tokens[1].Type);
        }

        [TestMethod]
        public void WhenParsingSimpleAdd_ThenFirstTokenShouldBeAValueOf1()
        {
            // Arrange
            var parser = new EquationParser();

            // Act
            var result = parser.Parse("1+2");

            // Assert
            Assert.AreEqual(TokenType.Value, result.Tokens[0].Type);
            Assert.AreEqual(1m, result.Tokens[0].Value);
        }

        [TestMethod]
        public void WhenParsingNull_ThenShouldReturnZeroTokens()
        {
            // Arrange
            var parser = new EquationParser();

            // Act
            var result = parser.Parse(null);

            // Assert
            Assert.AreEqual(0, result.Tokens.Count);
        }
    }
}
