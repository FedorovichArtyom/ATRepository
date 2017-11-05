using System;

namespace task_DEV_13
{
  public class DeveloperQualification
  {
    public QualificationName Qualification { get; set; }
    public int Efficiency { get; private set; }
    public decimal Price { get; private set; }
    public decimal PricePerEfficiency { get; private set; }

    public DeveloperQualification(QualificationName qualification)
    {
      this.Qualification = qualification;
      switch (qualification)
      { 
        case QualificationName.Junior:
          Efficiency = AssemblyInfo.JUNIOR_DEVS_EFFICIENCY;
          Price = AssemblyInfo.JUNIOR_DEVS_PRICE;
          break;
        case QualificationName.Middle:
          Efficiency = AssemblyInfo.MIDDLE_DEVS_EFFICIENCY;
          Price = AssemblyInfo.MIDDLE_DEVS_PRICE;
          break;
        case QualificationName.Senior:
          Efficiency = AssemblyInfo.SENIOR_DEVS_EFFICIENCY;
          Price = AssemblyInfo.SENIOR_DEVS_PRICE;
          break;
        case QualificationName.Lead:
          Efficiency = AssemblyInfo.LEAD_DEVS_EFFICIENCY;
          Price = AssemblyInfo.LEAD_DEVS_PRICE;
          break;
      }
      PricePerEfficiency = Price / Efficiency;
    }
  }
}
