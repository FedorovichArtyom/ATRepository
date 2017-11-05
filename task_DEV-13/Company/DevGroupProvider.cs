using System;
using System.Collections.Generic;

namespace task_DEV_13
{
  public class DevGroupProvider
  {
    private decimal customerPrice;
    private int customerEfficiency;

    public DevGroupProvider(decimal customerPrice, int customerEfficiency)
    {
      this.customerPrice = customerPrice;
      this.customerEfficiency = customerEfficiency;
    }

    public DevGroup GetDevGroupWithMaxEfficiency()
    {
      DevGroup group = new DevGroup();
      List<DeveloperQualification> efficiencyHierarchy = new List<DeveloperQualification>
      {
        new DeveloperQualification(QualificationName.Junior),
        new DeveloperQualification(QualificationName.Middle),
        new DeveloperQualification(QualificationName.Senior),
        new DeveloperQualification(QualificationName.Lead)
      };
      efficiencyHierarchy.Sort();

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
  }
}