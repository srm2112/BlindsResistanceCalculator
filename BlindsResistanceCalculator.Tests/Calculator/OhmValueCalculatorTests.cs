using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BlindsResistanceCalculator.Calculator;
using BlindsResistanceCalculator.Data;
using System.Collections.Generic;
using BlindsResistanceCalculator.Models;

namespace BlindsResistanceCalculator.Tests.Calculator
{
    [TestClass]
    public class OhmValueCalculatorTests
    {
        private Mock<IBandValue> _significantFigure;
        private Mock<IBandValue> _multiplier;
        private Mock<IBandValue> _tolerance;
        private IOhmValueCalculator _calculator;

        [TestInitialize]
        public void InitializeTests()
        {
            _significantFigure = new Mock<IBandValue>();
            _multiplier = new Mock<IBandValue>();
            _tolerance = new Mock<IBandValue>();
            _calculator = new OhmValueCalculator(_significantFigure.Object, _multiplier.Object, _tolerance.Object);
        }

        [TestCleanup]
        public void CleanupTests()
        {
            _significantFigure = null;
            _multiplier = null;
            _tolerance = null;
            _calculator = null;
        }

        [TestMethod]
        public void CalculatorShouldMakeAllValueCallsAndReturnZero()
        {
            // Arrange
            
            // Act
            var result = _calculator.CalculateOhmValue(
                                        It.IsAny<string>(), 
                                        It.IsAny<string>(), 
                                        It.IsAny<string>(), 
                                        It.IsAny<string>());

            // Assert
            _significantFigure.Verify(x => x.GetValue(It.IsAny<string>()), Times.AtLeast(2));
            _multiplier.Verify(x => x.GetValue(It.IsAny<string>()), Times.Once);
            _tolerance.Verify(x => x.GetValue(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(0d, result.CalculatedOhms);
        }

        [TestMethod]
        public void CalculatorShouldMakeAllValueCallsAndReturnsValidCalculation()
        {
            // Arrange
            _significantFigure.Setup(x => x.GetValue("Yellow")).Returns(() => 4);
            _significantFigure.Setup(x => x.GetValue("Violet")).Returns(() => 7);
            _multiplier.Setup(x => x.GetValue("Red")).Returns(() => 100);
            _tolerance.Setup(x => x.GetValue("Gold")).Returns(() => 5);

            // Act
            var result = _calculator.CalculateOhmValue(
                                        "Yellow",
                                        "Violet",
                                        "Red",
                                        "Gold");

            // Assert
            _significantFigure.Verify(x => x.GetValue(It.IsAny<string>()), Times.AtLeast(2));
            _multiplier.Verify(x => x.GetValue(It.IsAny<string>()), Times.Once);
            _tolerance.Verify(x => x.GetValue(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(4700d, result.CalculatedOhms);
            Assert.AreEqual(4465d, result.LowTolerance);
            Assert.AreEqual(4935d, result.HighTolerance);
        }
    }
}
