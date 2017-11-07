using System;

namespace task_DEV_13
{ 
  public class WrongConditionsToCreateGroupException : Exception
  {
    public WrongConditionsToCreateGroupException() : base(AssemblyInfo.WRONG_CONDITIONS_EXCEPTION_MESSAGE)
    {

    }
  }
}
