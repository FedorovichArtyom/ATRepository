using System;
using System.Numerics;

namespace task_DEV_3
{
    // Class describing some numbers of the Fibonacci row.
    public class FibonacciNumberChecker
    {
        // Method that determines whether the introduced nonnegative integer 
        // is a member of the Fibonacci sequence.
        public bool Check(BigInteger number)
        { 
            BigInteger[] previousNumbers = new BigInteger[2];
            previousNumbers[1] = 1;
            while (previousNumbers[1] < number)
            {
                previousNumbers[1] = BigInteger.Add(previousNumbers[0], previousNumbers[1]);
                previousNumbers[0] = BigInteger.Subtract(previousNumbers[1], previousNumbers[0]);
            }

            if (number.Equals(previousNumbers[1]))
                return true;
            else
                return false;
        }
    }
}
