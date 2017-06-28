using System;
using System.Numerics;

namespace task_DEV_4
{
    // Class describing the sequence of integers in the form of the BigInteger array.
    public class IntegerNumberSequence
    {
        // Array specifying the sequence to be examined.
        private BigInteger[] numberSequence;
        // A sequence property that determines whether it is non-decreasing.

        public IntegerNumberSequence(BigInteger[] sequence)
        {
            numberSequence = sequence;
        }

        // Set the value of the sequence.
        public BigInteger[] SequenceValues
        {
            set
            {
                numberSequence = value;
            }
            get 
            {
                return numberSequence;
            }
        }

        // A method to determine whether a sequence is non-decreasing.
        public bool CheckSequenceForNonDecreasing()
        {
            bool isNonDecreasing = true;
            BigInteger previousMember = SequenceValues[0];
            foreach (BigInteger member in SequenceValues)
            {
                if (member < previousMember)
                {
                    isNonDecreasing = false;
                    break;
                }
                previousMember = member;
            }
            return isNonDecreasing;
        }
    }
}
