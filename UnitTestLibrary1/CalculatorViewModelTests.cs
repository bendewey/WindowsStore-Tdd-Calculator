using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App1;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestLibrary1
{
    [TestClass]
    public class CalculatorViewModelTests
    {
        [TestMethod]
        public void WhenExecutingEmptyEquation_ThenResultShouldSayNothing()
        {
            // Arrange
            var vm = new CalculatorViewModel(new EquationParser(), new Calculator());
            vm.Equation = "";

            // Act
            vm.Execute();

            // Assert
            Assert.AreEqual("Nothing", vm.Result);
        }

        [TestMethod]
        public void WhenExecutingAnAddEquation_ThenResultShouldAddTheTwoNumbers()
        {
            // Arrange
            var vm = new CalculatorViewModel(new EquationParser(), new Calculator());
            vm.Equation = "1+2";

            // Act
            vm.Execute();

            // Assert
            Assert.AreEqual("3", vm.Result);
        }
    }
}
