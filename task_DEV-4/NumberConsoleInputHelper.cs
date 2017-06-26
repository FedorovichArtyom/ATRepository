using System;
using System.Numerics;

namespace task_DEV_4
{
    // Class that implements the input of a sequence of integers 
    // from the console and converts them to an array.
    public class NumberConsoleInputHelper
    {
        public BigInteger[] GetInputNumberSequence()
        {
            // Input sequence of integers, conversion to BigInteger, return sequence.
            bool exitInputing = false;
            BigInteger[] inputSequence = null;
            while (!exitInputing)
            {
                Console.WriteLine("Enter the sequence of integer numbers (separate numbers with spaces): \n");
                char delimiter = ' ';
                string[] inputSequenceString = Console.ReadLine().Split(delimiter);
                inputSequence = new BigInteger[inputSequenceString.Length];

                try
                {
                    for (int i = 0; i < inputSequenceString.Length; i++)
                    {
                        inputSequence[i] = BigInteger.Parse(inputSequenceString[i]);
                    }
                    exitInputing = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry, the entered sequence is incorrect! Try again.");
                }
            }
            return inputSequence;
        }
    }
}
