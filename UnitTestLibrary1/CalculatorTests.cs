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
    public class CalculatorTests
    {
        [TestMethod]
        public void WhenExecutingAndAddEquation_ThenResultShouldEqualThree()
        {
            // Arrange
            var calculator = new Calculator();
            var equation = new Equation()
                {
                    Tokens = new List<Token>()
                        {
                            new Token() {Value = 1m, Type = TokenType.Value},
                            new Token() {Value = "+", Type = TokenType.Operator},
                            new Token() {Value = 2m, Type = TokenType.Value},
                        }
                };

            // Act
            var result = calculator.Solve(equation);

            // Assert
            Assert.AreEqual(3m, result);
        }

        [TestMethod]
        public void WhenExecutingAndAddEquation_ThenResultShouldEqualFive()
        {
            // Arrange
            var calculator = new Calculator();
            var equation = new Equation()
            {
                Tokens = new List<Token>()
                        {
                            new Token() {Value = 3m, Type = TokenType.Value},
                            new Token() {Value = "+", Type = TokenType.Operator},
                            new Token() {Value = 2m, Type = TokenType.Value},
                        }
            };

            // Act
            var result = calculator.Solve(equation);

            // Assert
            Assert.AreEqual(5m, result);
        }
    }
}
