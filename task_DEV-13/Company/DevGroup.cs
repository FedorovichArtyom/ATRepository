using System;
using System.Collections.Generic;

namespace task_DEV_13
{
  public class DevGroup
  {
    public Dictionary<DeveloperQualification, int> devGroup = new Dictionary<DeveloperQualification,int>();

    public void Add(DeveloperQualification qualification, int amount)
    {
      devGroup.Add(qualification, amount);
    }
    public bool IsEmpty()
    {
      return devGroup.Count == 0;
    }
  }
}
