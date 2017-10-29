using System;

namespace task_DEV_7
{
  //trouble is it really needed here.
  class WrongSidesException : FormatException
  {
    public WrongSidesException(string message) : base(message) { }
  }
}
