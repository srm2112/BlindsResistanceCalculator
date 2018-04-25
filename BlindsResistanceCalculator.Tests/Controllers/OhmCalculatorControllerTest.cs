using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlindsResistanceCalculator;
using BlindsResistanceCalculator.Controllers;
using Moq;
using BlindsResistanceCalculator.Data;
using BlindsResistanceCalculator.Calculator;
using BlindsResistanceCalculator.ViewModels;

namespace BlindsResistanceCalculator.Tests.Controllers
{
    [TestClass]
    public class OhmCalculatorControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var colorCodeData = new Mock<IColorCodeData>();
            var calculator = new Mock<IOhmValueCalculator>();

            OhmCalculatorController controller = new OhmCalculatorController(colorCodeData.Object, calculator.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CalculateCalledWithValidInput()
        {
            // Arrange
            var colorCodeData = new Mock<IColorCodeData>();
            var calculator = new Mock<IOhmValueCalculator>();

            OhmCalculatorController controller = new OhmCalculatorController(colorCodeData.Object, calculator.Object);

            var colorCodeInput = new ColorCodeInput() {
                                        BandAColor = "Yellow",
                                        BandBColor = "Violet",
                                        BandCColor = "Red",
                                        BandDColor = "Gold" };

            // Act
            ViewResult result = controller.Calculate(colorCodeInput) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CalculateCalledWithInvalidInput()
        {
            // Arrange
            var colorCodeData = new Mock<IColorCodeData>();
            var calculator = new Mock<IOhmValueCalculator>();

            OhmCalculatorController controller = new OhmCalculatorController(colorCodeData.Object, calculator.Object);

            var colorCodeInput = new ColorCodeInput() {
                                        BandAColor = null,
                                        BandBColor = null,
                                        BandCColor = null,
                                        BandDColor = null };

            // Act
            ViewResult result = controller.Calculate(colorCodeInput) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
