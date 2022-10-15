using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FutureValueCalculator.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FutureValueCalculator.Tests.Models
{
    [TestClass]
    public class FutureValueModelTests
    {
        [TestMethod]
        public void T01_CalculateFV_ValidInput()
        {
            // Arrange 
            FutureValueModel model = new FutureValueModel();
            model.Investment = 500;
            model.Rate = 5;
            model.Years = 2;

            // Act 
            decimal output = model.CalculateFV();

            // Assert 
            Assert.AreEqual(12645.43m, output);
        }

        [TestMethod]
        public void T02_CalculateFV_InvalidInvestment_01()
        {
            // Arrange 
            FutureValueModel model = new FutureValueModel();
            model.Investment = 99;
            model.Rate = 5;
            model.Years = 2;

            // Act 
            decimal output = model.CalculateFV();

            // Assert 
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void T03_CalculateFV_InvalidInvestment_02()
        {
            // Arrange 
            FutureValueModel model = new FutureValueModel();
            model.Investment = 5001;
            model.Rate = 5;
            model.Years = 2;

            // Act 
            decimal output = model.CalculateFV();

            // Assert 
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void T04_CalculateFV_InvalidInvestment_02()
        {
            // Arrange 
            FutureValueModel model = new FutureValueModel();
            model.Investment = 5001;
            model.Rate = 5;
            model.Years = 2;

            // Act 
            decimal output = model.CalculateFV();

            // Assert 
            //Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void T05_IsWithInRange_Valid()
        {
            // Arrange 
            FutureValueModel model = new FutureValueModel();
            
            // Act 
            bool result = model.IsWithInRange(100, 1000, 500);

            // Assert 
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void T06_CalculateFV_InvalidInvestment()
        {
            // Arrange 
            FutureValueModel model = new FutureValueModel();
            model.Investment = 5001;
            model.Rate = 5;
            model.Years = 2;

            // Act 
            decimal output = model.CalculateFV();
            var results = new List<ValidationResult>();
            var testContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, testContext, results, true);

            // Assert 
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The field Monthly Investment: must be between 100 and 5000.", results[0].ErrorMessage);
        }

    }
}
