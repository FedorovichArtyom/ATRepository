using System;
using System.Collections.Generic;

namespace task_DEV_13
{
  public class DevGroup
  {
    public Dictionary<DeveloperQualification, int> DevGroupInstance { get; private set; }
    public DevGroupConstituents Constituents { get; private set; }

    public DevGroup()
    {
      Constituents = new DevGroupConstituents(0, 0, 0, 0);
      DevGroupInstance = new Dictionary<DeveloperQualification, int>();
      DevGroupInstance.Add(new DeveloperQualification(QualificationName.Junior), 0);
      DevGroupInstance.Add(new DeveloperQualification(QualificationName.Middle), 0);
      DevGroupInstance.Add(new DeveloperQualification(QualificationName.Senior), 0);
      DevGroupInstance.Add(new DeveloperQualification(QualificationName.Lead), 0);
    }
    public DevGroup(DevGroupConstituents constituents)
    {
      this.Constituents = constituents;
      DevGroupInstance = new Dictionary<DeveloperQualification, int>();
      DevGroupInstance.Add(new DeveloperQualification(QualificationName.Junior), constituents.JuniorAmount);
      DevGroupInstance.Add(new DeveloperQualification(QualificationName.Middle), constituents.MiddleAmount);
      DevGroupInstance.Add(new DeveloperQualification(QualificationName.Senior), constituents.SeniorAmount);
      DevGroupInstance.Add(new DeveloperQualification(QualificationName.Lead), constituents.LeadAmount);
    }
    public void Add(DeveloperQualification qualification, int amount)
    {
      DevGroupInstance.Add(qualification, amount);
    }
    public bool IsEmpty()
    {
      bool result = true;
      foreach (var devQualification in DevGroupInstance)
      {
        if (devQualification.Value != 0)
        {
          result = false;
          break;
        }
      }

      return result;
    }
  }
}
