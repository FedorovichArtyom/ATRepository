using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task_DEV_7;

namespace task_DEV_12
{
  [TestClass]
  public class SimpleTriangleTests
  {
    [TestMethod]
    public void TestConstructorForNumericValidSides()
    {
      // Arrange.
      var sides = new TriangleSides()
      {
        First = 3.2,
        Second = 4.62,
        Third = 5.11
      };

      // Act.
      SimpleTriangle triangle = new SimpleTriangle(sides);
      // Assert.
    }

    [TestMethod]
    public void TestConstructorForExpanentialValidSides()
    {
      // Arrange.
      var sides = new TriangleSides()
      {
        First = 3.2e+2,
        Second = 4.62e+2,
        Third = 5.11E+2
      };

      try
      {
        // Act.
        SimpleTriangle triangle = new SimpleTriangle(sides);
      }
      catch (WrongSidesException ex)
      {
        // Assert.
        Assert.Fail();
      }
    }

    [TestMethod]
    public void TestConstructorForNegativeSidesValues()
    {
      // Arrange.
      var sides = new TriangleSides()
      {
        First = -3.2e+2,
        Second = -4.62e+2,
        Third = -5.11E+2
      };

      try
      {
        // Act.
        SimpleTriangle triangle = new SimpleTriangle(sides);
        // Assert.
        Assert.Fail();
      }
      catch (WrongSidesException ex)
      {

      }
    }

    [TestMethod]
    public void TestConstructorForZeroSidesValues()
    {
      // Arrange.
      var sides = new TriangleSides()
      {
        First = 0,
        Second = 0,
        Third = 0
      };

      try
      {
        // Act.
        SimpleTriangle triangle = new SimpleTriangle(sides);
        // Assert.
        Assert.Fail();
      }
      catch (WrongSidesException ex)
      {

      }
    }
  }
}
