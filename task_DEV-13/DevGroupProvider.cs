using System;

namespace task_DEV_13
{
  public class DevGroupProvider
  {
    private decimal customerPrice;
    private int customerEfficiency;

    public CompanyDevelopmentStaff GetDevGroupByMaxEfficiency()
    {
      decimal efficiencyPerPriceJunior = AssemblyInfo.JUNIOR_DEVS_EFFICIENCY / AssemblyInfo.JUNIOR_DEVS_PRICE;
      return new CompanyDevelopmentStaff();
    }
  }
}
