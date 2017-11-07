using System;
using System.Collections.Generic;

namespace task_DEV_13
{
  public class DevGroupProvider
  {
    private decimal customerPrice;
    private int customerEfficiency;

    private List<DeveloperQualification> efficiencyHierarchy = new List<DeveloperQualification>
    {
      new DeveloperQualification(QualificationName.Junior),
      new DeveloperQualification(QualificationName.Middle),
      new DeveloperQualification(QualificationName.Senior),
      new DeveloperQualification(QualificationName.Lead)
    };

    public DevGroupProvider(decimal customerPrice, int customerEfficiency)
    {
      this.customerPrice = customerPrice;
      this.customerEfficiency = customerEfficiency;
    }

    // Provide group methods.
    public DevGroup GetDevGroupWithMaxEfficiencyPerPrice()
    {
      efficiencyHierarchy.Sort(this.CompareQualificationsByEfficiencyPerPrice);

      return BuildGroup();
    }
    public DevGroup GetDevGroupWithMinPricePerEfficiency()
    {
      efficiencyHierarchy.Sort(this.CompareQualificationsByPricePerEfficiency);

      return BuildGroup();
    }
    public DevGroup GetDevGroupWithMinNonJuniorsPerEfficiency()
    {
      efficiencyHierarchy.Sort(this.CompareQualificationsByMinNonJuniorsPerEfficiency);

      return BuildGroup();
    }

    // Build group helper.
    private DevGroup BuildGroup()
    {
      DevGroup group = new DevGroup();
      decimal restCustomerPrice = customerPrice;
      foreach (var devQualification in efficiencyHierarchy)
      {
        int devsAmount = (int)Math.Ceiling((double)customerEfficiency / devQualification.Efficiency);
        decimal price = devsAmount * devQualification.Price;
        decimal priceResidual = restCustomerPrice - price;

        if (priceResidual > 0m)
        {
          group.Add(devQualification, devsAmount);
          restCustomerPrice = priceResidual;
        }
        else
        {
          break;
        }
      }
      return group;
    }

    // Comparers.
    public int CompareQualificationsByEfficiencyPerPrice(DeveloperQualification firstQualification,
      DeveloperQualification secondQualification)
    {
      int result = 0;
      if (firstQualification.EfficiencyPerPrice > secondQualification.EfficiencyPerPrice)
      {
        result = -1;
      }
      if (firstQualification.EfficiencyPerPrice < secondQualification.EfficiencyPerPrice)
      {
        result = 1;
      }
      if (firstQualification.EfficiencyPerPrice == secondQualification.EfficiencyPerPrice)
      {
        if (firstQualification.Price > secondQualification.Price)
        {
          result = -1;
        }
        if (firstQualification.Price < secondQualification.Price)
        {
          result = 1;
        }
        if (firstQualification.Price == secondQualification.Price)
        {
          result = 0;
        }
      }

      return result;
    }
    public int CompareQualificationsByPricePerEfficiency(DeveloperQualification firstQualification,
      DeveloperQualification secondQualification)
    {
      int result = 0;
      if (firstQualification.PricePerEfficiency > secondQualification.PricePerEfficiency)
      {
        result = 1;
      }
      if (firstQualification.PricePerEfficiency < secondQualification.PricePerEfficiency)
      {
        result = -1;
      }
      if (firstQualification.PricePerEfficiency == secondQualification.PricePerEfficiency)
      {
        if (firstQualification.Price > secondQualification.Price)
        {
          result = 1;
        }
        if (firstQualification.Price < secondQualification.Price)
        {
          result = -1;
        }
        if (firstQualification.Price == secondQualification.Price)
        {
          result = 0;
        }
      }

      return result;
    }
    public int CompareQualificationsByMinNonJuniorsPerEfficiency(DeveloperQualification firstQualification,
      DeveloperQualification secondQualification)
    {
      int result = 0;
      if (firstQualification.Qualification == QualificationName.Junior &&
        secondQualification.Qualification != QualificationName.Junior)
      {
        result = -1;
      }
      if (firstQualification.Qualification != QualificationName.Junior &&
        secondQualification.Qualification == QualificationName.Junior)
      {
        result = 1;
      }
      if (firstQualification.Qualification != QualificationName.Junior &&
        secondQualification.Qualification != QualificationName.Junior)
      {
        result = CompareQualificationsByPricePerEfficiency(firstQualification, secondQualification);
      }

      return result;
    }
  }
}