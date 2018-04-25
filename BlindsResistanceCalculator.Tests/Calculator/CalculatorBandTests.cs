using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BlindsResistanceCalculator.Models;
using BlindsResistanceCalculator.Data;
using Moq;
using BlindsResistanceCalculator.Calculator;

namespace BlindsResistanceCalculator.Tests.Calculator
{
    [TestClass]
    public class CalculatorBandTests
    {
        private Mock<IColorCodeData> _colorCodeData;
        private List<ColorCode> _colorCodes;

        [TestInitialize]
        public void InitializeTests()
        {
            _colorCodes = new List<ColorCode>();
            _colorCodes.Add(new ColorCode() { Name = "Brown", SignificantFigure = 1, Multiplier = 10f, Tolerance = 1f });
            _colorCodes.Add(new ColorCode() { Name = "Red", SignificantFigure = 2, Multiplier = 100f, Tolerance = 2f });
            _colorCodes.Add(new ColorCode() { Name = "Orange", SignificantFigure = 3, Multiplier = 10001f, Tolerance = -1 });

            _colorCodeData = new Mock<IColorCodeData>();
        }

        [TestCleanup]
        public void CleanupTests()
        {
            _colorCodeData = null;
            _colorCodes = null;
        }

        [TestMethod]
        public void MultiplierShouldShouldReturnValidValueWithValidInputData()
        {
            // Arrange
            var multiplier = new Multiplier(_colorCodeData.Object);

            _colorCodeData.Setup(x => x.GetMultipliers()).Returns(() => _colorCodes);

            // Act
            var result = multiplier.GetValue("Red");

            // Assert
            _colorCodeData.Verify(x => x.GetMultipliers(), Times.Once);
            Assert.AreEqual(100f, result);
        }

        [TestMethod]
        public void MultiplierShouldShouldReturnZeroWithInvalidInputData()
        {
            // Arrange
            var multiplier = new Multiplier(_colorCodeData.Object);

            _colorCodeData.Setup(x => x.GetMultipliers()).Returns(() => _colorCodes);

            // Act
            var result = multiplier.GetValue(null);

            // Assert
            _colorCodeData.Verify(x => x.GetMultipliers(), Times.Once);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SignificantFigureShouldShouldReturnValidValueWithValidInputData()
        {
            // Arrange
           var significantFigure = new SignificantFigure(_colorCodeData.Object);

            _colorCodeData.Setup(x => x.GetSignificantFigures()).Returns(() => _colorCodes);

            // Act
            var result = significantFigure.GetValue("Red");

            // Assert
            _colorCodeData.Verify(x => x.GetSignificantFigures(), Times.Once);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void SignificantFigureShouldShouldReturnZeroWithInvalidInputData()
        {
            // Arrange
            var significantFigure = new SignificantFigure(_colorCodeData.Object);

            _colorCodeData.Setup(x => x.GetSignificantFigures()).Returns(() => _colorCodes);

            // Act
            var result = significantFigure.GetValue(null);

            // Assert
            _colorCodeData.Verify(x => x.GetSignificantFigures(), Times.Once);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ToleranceShouldShouldReturnValidValueWithValidInputData()
        {
            // Arrange
            var tolerance = new Tolerance(_colorCodeData.Object);

            _colorCodeData.Setup(x => x.GetTolerances()).Returns(() => _colorCodes);

            // Act
            var result = tolerance.GetValue("Red");

            // Assert
            _colorCodeData.Verify(x => x.GetTolerances(), Times.Once);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ToleranceShouldShouldReturnZeroWithInvalidInputData()
        {
            // Arrange
            var tolerance = new Tolerance(_colorCodeData.Object);

            _colorCodeData.Setup(x => x.GetTolerances()).Returns(() => _colorCodes);

            // Act
            var result = tolerance.GetValue(null);

            // Assert
            _colorCodeData.Verify(x => x.GetTolerances(), Times.Once);
            Assert.AreEqual(0, result);
        }
    }
}
