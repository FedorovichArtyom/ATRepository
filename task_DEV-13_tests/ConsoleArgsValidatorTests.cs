using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task_DEV_13;

namespace task_DEV_13_tests
{
  [TestClass]
  public class ConsoleArgsValidatorTests
  {
    // GetValidPrice tests.
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

    // GetValidEfficiency tests.
    [TestMethod]
    public void TestGetValidEfficiencyForPositiveIntegerValue()
    {
      // Arrange.
      string[] args = new string[3] { "500", "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      int result = consoleArgsValidator.GetValidEfficiency();

      // Assert.
      Assert.AreEqual(16237, result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void TestGetValidEfficiencyForIntegerValuesWithCommas()
    {
      // Arrange.
      string[] args = new string[3] { "500,213", "16,237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      int result = consoleArgsValidator.GetValidEfficiency();

      // Assert.
      Assert.AreEqual(16237, result);
    }

    [TestMethod]
    public void TestGetValidForNonIntegerValue()
    {
      // Arrange.
      string[] args = new string[3] { "500.213", "100.0", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      int result = consoleArgsValidator.GetValidEfficiency();

      // Assert.
      Assert.AreEqual(100, result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void TestGetValidForNonIntegerValueWithSomeZerosAfterDot()
    {
      // Arrange.
      string[] args = new string[3] { "500.213", "100.00", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      int result = consoleArgsValidator.GetValidEfficiency();

      // Assert.
      Assert.AreEqual(100, result);
    }

    [TestMethod]
    public void TestGetValidEfficiencyForZeroIntegerValue()
    {
      // Arrange.
      string[] args = new string[3] { "1232", "0", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      int result = consoleArgsValidator.GetValidEfficiency();

      // Assert.
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    [ExpectedException(typeof(OverflowException))]
    public void TestGetValidEfficiencyForValueHigherThenInt32MaxValue()
    {
      // Arrange.
      string[] args = new string[3] { "2324",
        "2147483649", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      int result = consoleArgsValidator.GetValidEfficiency();

      // Assert.
      Assert.AreEqual("2147483649", result.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(OverflowException))]
    public void TestGetValidEfficiencyForValueLowerThenInt32MinValue()
    {
      // Arrange.
      string[] args = new string[3] { "2324",
        "-2147483649", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      int result = consoleArgsValidator.GetValidEfficiency();

      // Assert.
      Assert.AreEqual("-2147483649", result.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestGetValidEfficiencyForNegativeValues()
    {
      // Arrange.
      string[] args = new string[3] { "312.6",
        "-16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      int result = consoleArgsValidator.GetValidEfficiency();

      // Assert.
      Assert.AreEqual(-16237, result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void TestGetValidEfficiencyForString()
    {
      // Arrange.
      string[] args = new string[3] { "31",
        "162ds37", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      int result = consoleArgsValidator.GetValidEfficiency();

      // Assert.
    }

    // GetValidCriterion tests.
    [TestMethod]
    public void TestGetValidCriterionForValidInput()
    {
      string[] args = new string[3] { "31",
        "16237", "maxefficiency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      DevGroupCreationCriterion result = consoleArgsValidator.GetValidCriterion();

      // Assert.
      Assert.AreEqual(DevGroupCreationCriterion.MaxEfficiency, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestGetValidCriterionForNotValidInput()
    {
      string[] args = new string[3] { "31",
        "16237", "maxefficieq123$%#2ency" };
      var consoleArgsValidator = new ConsoleArgsValidator(args);

      // Act.
      DevGroupCreationCriterion result = consoleArgsValidator.GetValidCriterion();

      // Assert.
      Assert.AreEqual(DevGroupCreationCriterion.MaxEfficiency, result);
    }
  }
}
