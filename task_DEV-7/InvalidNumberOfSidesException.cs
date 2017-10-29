using System;

namespace task_DEV_7
{
    class InvalidNumberOfSidesException : FormatException
    {
        public InvalidNumberOfSidesException(string message) : base(message) { }
    }
}
