using System;

namespace task_DEV_13
{
  public class CompanyDevelopmentStaff
  {
    public int JuniorDevsAmount { get; private set; }
    public int MiddleDevsAmount { get; private set; }
    public int SeniorDevsAmount { get; private set; }
    public int LeadDevsAmount { get; private set; }

    public CompanyDevelopmentStaff()
    {
      JuniorDevsAmount = AssemblyInfo.JUNIOR_DEVS_AMOUNT;
      MiddleDevsAmount = AssemblyInfo.MIDDLE_DEVS_AMOUNT;
      SeniorDevsAmount = AssemblyInfo.SENIOR_DEVS_AMOUNT;
      LeadDevsAmount = AssemblyInfo.LEAD_DEVS_AMOUNT;
    }
  }
}
