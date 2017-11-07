using System;

namespace task_DEV_13
{
  public struct DevGroupConstituents
  {
    public int JuniorAmount;
    public int MiddleAmount;
    public int SeniorAmount;
    public int LeadAmount; 

    public DevGroupConstituents(int juniorAmount,int middleAmount,int seniorAmount,int leadAmount)
    {
      JuniorAmount = juniorAmount;
      MiddleAmount = middleAmount;
      SeniorAmount = seniorAmount;
      LeadAmount = leadAmount;
    }
  }
}
