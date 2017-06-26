using System;
using System.Numerics;

namespace task_DEV_3
{
    // A program that determines whether the introduced nonnegative integer 
    // is a member of the Fibonacci sequence. 
    // Entered number size is limited to 254.
    class EntryPoint
    {
        static void Main(string[] args)
        {
            ConsoleInputHelper inputHelper = new ConsoleInputHelper();
            BigInteger enteredNumber = inputHelper.GetInputNumber();
            FibonacciNumberChecker numberChecker = new FibonacciNumberChecker();

            string outputMessage = numberChecker.Check(enteredNumber)
                ? "The entered number is the member of Fibonacci row."
                : "The entered number isn't the member of Fibonacci row.";

            Console.WriteLine(outputMessage);
        }
    }
}
