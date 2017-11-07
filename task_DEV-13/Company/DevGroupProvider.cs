using System;
using System.Collections.Generic;

namespace task_DEV_13
{
  public class DevGroupProvider
  {
    private decimal customerPrice;
    private int customerEfficiency;

    private Dictionary<QualificationName,int> maxDevsAmount;

    private DeveloperQualification junior = new DeveloperQualification(QualificationName.Junior);
    private DeveloperQualification middle = new DeveloperQualification(QualificationName.Middle);
    private DeveloperQualification senior = new DeveloperQualification(QualificationName.Senior);
    private DeveloperQualification lead = new DeveloperQualification(QualificationName.Lead);

    //
    public DevGroupProvider(decimal customerPrice, int customerEfficiency)
    {
      this.customerPrice = customerPrice;
      this.customerEfficiency = customerEfficiency;

      maxDevsAmount = new Dictionary<QualificationName, int>();
      maxDevsAmount.Add(QualificationName.Junior, (int)Math.Floor(customerPrice / junior.Price));
      maxDevsAmount.Add(QualificationName.Middle, (int)Math.Floor(customerPrice / middle.Price));
      maxDevsAmount.Add(QualificationName.Senior, (int)Math.Floor(customerPrice / senior.Price));
      maxDevsAmount.Add(QualificationName.Lead, (int)Math.Floor(customerPrice / lead.Price));
    }

    // Provide group methods.
    // Get custom devs group with max efficiency for price.
    public DevGroup GetDevGroupWithMaxEfficiencyForPrice()
    {
      // Characteristics of custom dev group.
      DevGroup customGroup = new DevGroup();
      decimal totalPrice = 0m;
      int totalEfficiency = 0;

      // Check all possible variants of devs group combinations and get the one with valid price and greatest efficiency.
      List<DevGroupConstituents> allGroupConfigurations = GetAllPossibleGroupConfigurations();
      foreach (var groupConfiguration in allGroupConfigurations)
      {
        // Get the price of new custom devs group and compare with customerPrice.
        totalPrice = groupConfiguration.JuniorAmount * junior.Price +
            groupConfiguration.MiddleAmount * middle.Price +
            groupConfiguration.SeniorAmount * senior.Price +
            groupConfiguration.LeadAmount * lead.Price;

        // If the group total price is valid get the efficiency of the group.
        if (totalPrice - customerPrice < 0m)
        {
          int newTotalEfficiency = groupConfiguration.JuniorAmount * junior.Efficiency +
            groupConfiguration.MiddleAmount * middle.Efficiency +
            groupConfiguration.SeniorAmount * senior.Efficiency +
            groupConfiguration.LeadAmount * lead.Efficiency;

          // If the new group's efficiency is higher than previous group's, create a new custom devs group. 
          if (newTotalEfficiency > totalEfficiency)
          {
            customGroup = new DevGroup(groupConfiguration);
            totalEfficiency = newTotalEfficiency;
          }
        }
      }

      // If after all checked combinations the custom dev group is empty, return exception, cause there is no option 
      // to create appropriate devs group.
      if (customGroup.IsEmpty())
      {
        throw new WrongConditionsToCreateGroupException();
      }

      return customGroup;
    }

    // Get custom devs group with min price for custom efficiency.
    public DevGroup GetDevGroupWithMinPriceForCustomEfficiency()
    {
      // Characteristics of custom dev group.
      DevGroup customGroup = new DevGroup();
      decimal totalPrice = 0m;
      int totalEfficiency = 0;

      // Check all possible variants of devs group combinations and get the one with valid efficiency and lowest price.
      List<DevGroupConstituents> allGroupConfigurations = GetAllPossibleGroupConfigurations();
      foreach (var groupConfiguration in allGroupConfigurations)
      {
        // Get the efficiency of new custom devs group and compare with customerEfficiency.
        totalEfficiency = groupConfiguration.JuniorAmount * junior.Efficiency + 
          groupConfiguration.MiddleAmount * middle.Efficiency +
          groupConfiguration.SeniorAmount * senior.Efficiency +
          groupConfiguration.LeadAmount * lead.Efficiency;

        // If group's total efficiency is valid get the price of the group.
        if (totalEfficiency == customerEfficiency)
        {
          decimal newTotalPrice = groupConfiguration.JuniorAmount * junior.Price + 
            groupConfiguration.MiddleAmount * middle.Price +
            groupConfiguration.SeniorAmount * senior.Price +
            groupConfiguration.LeadAmount * lead.Price;

          // If the new group's price is lower than previous group's, create a new custom devs group. 
          if (newTotalPrice - totalPrice < 0m)
          {
            customGroup = new DevGroup(groupConfiguration);
            totalPrice = newTotalPrice;
          }
        }
      }

      // If after all checked combinations the custom dev group is empty, return exception, cause there is no option 
      // to create appropriate devs group.
      if (customGroup.IsEmpty())
      {
        throw new WrongConditionsToCreateGroupException();
      }

      return customGroup;
    }

    //
    public DevGroup GetDevGroupWithMinNonJuniorsForEfficiency()
    {

    }

    // Get all posible group configurations of devs.
    private List<DevGroupConstituents> GetAllPossibleGroupConfigurations()
    {
      var allGroupsConfigurations = new List<DevGroupConstituents>();
      for (int juniorAmount = 0; juniorAmount <= maxDevsAmount[QualificationName.Junior]; juniorAmount++)
      {
        for (int middleAmount = 0; middleAmount <= maxDevsAmount[QualificationName.Middle]; middleAmount++)
        {
          for (int seniorAmount = 0; seniorAmount <= maxDevsAmount[QualificationName.Senior]; seniorAmount++)
          {
            for (int leadAmount = 0; leadAmount <= maxDevsAmount[QualificationName.Lead]; leadAmount++)
            {
              allGroupsConfigurations.Add(new DevGroupConstituents(juniorAmount, middleAmount, seniorAmount, leadAmount));
            }
          }
        }
      }

      return allGroupsConfigurations;
    }
  }
}