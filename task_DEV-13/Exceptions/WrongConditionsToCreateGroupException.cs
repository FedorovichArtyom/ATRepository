using System;

namespace task_DEV_13
{ 
  // An exception for not valid parameters or non-appropriate conditions to create a DevGroup.
  public class WrongConditionsToCreateGroupException : Exception
  {
    public WrongConditionsToCreateGroupException() : base(AssemblyInfo.WRONG_CONDITIONS_EXCEPTION_MESSAGE)
    {

    }
  }
}
