using System;

namespace task_DEV_7
{
  public class WrongSidesException : FormatException
  {
    public WrongSidesException(string message) : base(message) { }
    public WrongSidesException() { }
  }
}
