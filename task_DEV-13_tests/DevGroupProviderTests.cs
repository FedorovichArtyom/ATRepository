using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task_DEV_13;

namespace task_DEV_13_tests
{
  [TestClass]
  public class DevGroupProviderTests
  {
    // GetDevGroupWithMaxEfficiencyForPrice tests. First criterion.
    [TestMethod]
    public void TestGetDevGroupWithMaxEfficiencyForPriceWithValidInputs()
    {
      // Arrange.
      decimal customerPrice = 5600m;
      int customerEfficiency = 200;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMaxEfficiencyForPrice();

      // Assert.
      // Total price should be 5500 not 5600, but it gains most efficiency(325).
      // For prices: 500, 1000, 2000, 2300. From Junior to Lead.
      // For efficiences: 25, 60, 75, 100. From Junior to Lead.
      int juniors = 1;
      int middles = 5;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongConditionsToCreateGroupException))]
    public void TestGetDevGroupWithMaxEfficiencyForPriceWithNegativePrice()
    {
      // Arrange.
      decimal customerPrice = -5600m;
      int customerEfficiency = 200;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMaxEfficiencyForPrice();

      // Assert.
      int juniors = 0;
      int middles = 0;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongConditionsToCreateGroupException))]
    public void TestGetDevGroupWithMaxEfficiencyForPriceWithNegativeEfficiency()
    {
      // Arrange.
      decimal customerPrice = -5600m;
      int customerEfficiency = 200;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMaxEfficiencyForPrice();

      // Assert.
      int juniors = 0;
      int middles = 0;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }

    // GetDevGroupWithMinPriceForCustomEfficiency tests. Second criterion.
    [TestMethod]
    public void TestGetDevGroupWithMinPriceForCustomEfficiencyWithCustomerPriceEqualValidResultTotalValue()
    {
      // Arrange.
      decimal customerPrice = 5000m;
      int customerEfficiency = 300;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMinPriceForCustomEfficiency();

      // Assert.
      int juniors = 0;
      int middles = 5;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }

    [TestMethod]
    public void TestGetDevGroupWithMinPriceForCustomEfficiencyWithValidValues()
    {
      // Arrange.
      decimal customerPrice = 7000m;
      int customerEfficiency = 300;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMinPriceForCustomEfficiency();

      // Assert.
      int juniors = 0;
      int middles = 5;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongConditionsToCreateGroupException))]
    public void TestGetDevGroupWithMinPriceForCustomEfficiencyWithNegativePrice()
    {
      // Arrange.
      decimal customerPrice = -7000m;
      int customerEfficiency = 300;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMinPriceForCustomEfficiency();

      // Assert.
      int juniors = 0;
      int middles = 0;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongConditionsToCreateGroupException))]
    public void TestGetDevGroupWithMinPriceForCustomEfficiencyWithNegativeEfficiency()
    {
      // Arrange.
      decimal customerPrice = 7000m;
      int customerEfficiency = -300;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMinPriceForCustomEfficiency();

      // Assert.
      int juniors = 0;
      int middles = 0;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }

    // GetDevGroupWithMinNonJuniorsForEfficiency tests. Third criterion.
    [TestMethod]
    public void TestGetDevGroupWithMinNonJuniorsForEfficiencyForValidValues()
    {
      // Arrange.
      decimal customerPrice = 7000m;
      int customerEfficiency = 300;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMinNonJuniorsForEfficiency();

      // Assert.
      int juniors = 12;
      int middles = 0;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongConditionsToCreateGroupException))]
    public void TestGetDevGroupWithMinNonJuniorsForEfficiencyForNegativePrice()
    {
      // Arrange.
      decimal customerPrice = -7000m;
      int customerEfficiency = 300;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMinNonJuniorsForEfficiency();

      // Assert.
      int juniors = 0;
      int middles = 0;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongConditionsToCreateGroupException))]
    public void TestGetDevGroupWithMinNonJuniorsForEfficiencyForNegativeEfficiency()
    {
      // Arrange.
      decimal customerPrice = 7000m;
      int customerEfficiency = -300;
      var groupProvider = new DevGroupProvider(customerPrice, customerEfficiency);

      // Act.
      DevGroup group = groupProvider.GetDevGroupWithMinNonJuniorsForEfficiency();

      // Assert.
      int juniors = 0;
      int middles = 0;
      int seniors = 0;
      int leads = 0;
      DevGroupConstituents expected = new DevGroupConstituents(juniors, middles, seniors, leads);
      Assert.AreEqual(group.Constituents, expected);
    }
  }
}
