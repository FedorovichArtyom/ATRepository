using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task_DEV_13;

namespace task_DEV_13_tests
{
  [TestClass]
  public class ConsoleArgsValidatorTests
  {
    [TestMethod]
    public void TestGetValidPriceForPositiveIntegerValue()
    {
      // Arrange.
      string[] args = new string[3] { "500", "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
      Assert.AreEqual(500m, result);
    }

    [TestMethod]
    public void TestGetValidPriceForIntegerValuesWithCommas()
    {
      // Arrange.
      string[] args = new string[3] { "500,213", "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
      Assert.AreEqual(500213m, result);
    }

    [TestMethod]
    public void TestGetValidPriceForNonIntegerValue()
    {
      // Arrange.
      string[] args = new string[3] { "500.213", "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
      Assert.AreEqual(500.213m, result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void TestGetValidPriceForNonIntegerValueWithDollarSign()
    {
      // Arrange.
      string[] args = new string[3] { "$500.213", "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
      Assert.AreEqual(500.213m, result);
    }

    [TestMethod]
    public void TestGetValidPriceForZeroIntegerValue()
    {
      // Arrange.
      string[] args = new string[3] { "0", "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
      Assert.AreEqual(0m, result);
    }

    [TestMethod]
    public void TestGetValidPriceForZeroNonIntegerValue()
    {
      // Arrange.
      string[] args = new string[3] { "0.0", "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
      Assert.AreEqual(0.0m, result);
    }

    [TestMethod]
    [ExpectedException(typeof(OverflowException))]
    public void TestGetValidPriceForValueHigherThenDecimalMaxValue()
    {
      // Arrange.
      string[] args = new string[3] { "79,228,162,514,264,337,593,543,950,336", 
        "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
      Assert.AreEqual("79228162514264337593543950336", result.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(OverflowException))]
    public void TestGetValidPriceForValueLowerThenDecimalMinValue()
    {
      // Arrange.
      string[] args = new string[3] { "-79,228,162,514,264,337,593,543,950,336", 
        "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
      Assert.AreEqual("-79228162514264337593543950336", result.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestGetValidPriceForNegativeValues()
    {
      // Arrange.
      string[] args = new string[3] { "-312.6", 
        "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
      Assert.AreEqual(-312.6m, result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void TestGetValidPriceForString()
    {
      // Arrange.
      string[] args = new string[3] { "31fsd.6", 
        "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      decimal result = consoleArgsValidator.GetValidPrice();

      // Assert.
    }
  }
}
