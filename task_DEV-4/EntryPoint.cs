using System;
using System.Numerics;

namespace task_DEV_4
{
    // A program that determines whether the entered into the console 
    // sequence of integers is nondecreasing.
    class EntryPoint
    {
        static void Main(string[] args)
        {
            SequenceNonDecreasingChecker enteredSequence = new SequenceNonDecreasingChecker();
            if (args.Length != 0)
            {
                enteredSequence.CheckForNonDecreasingArg(args[0]);
            }
            else
            {
                enteredSequence.CheckForNonDecreasingConsole();
            }
        }
    }
}
