using System;
using System.Collections.Generic;

namespace task_DEV_13
{
  // Provides a dictionary for cantaining a group of devs of all devs qualification. 
  public class DevGroup
  {
    public Dictionary<DeveloperQualification, int> DevGroupInstance { get; private set; }
    // The current group setup.
    public DevGroupConstituents Constituents { get; private set; }

    // For constructor without params initialize all qualifications with zero amount of devs.
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
    
    // Add dev qualification to a dictionary.
    public void Add(DeveloperQualification qualification, int amount)
    {
      DevGroupInstance.Add(qualification, amount);
    }

    // Return true if all of there is no devs for each dev qualification in the dictionary.
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
