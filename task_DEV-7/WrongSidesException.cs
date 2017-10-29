using System;

namespace task_DEV_7
{
    class WrongSidesException : FormatException
    {
        public WrongSidesException(string message) : base(message) { }
    }
}
