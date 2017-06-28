using System;
using System.Numerics;

namespace task_DEV_4
{
    // Class that implements the input of a sequence of integers 
    // from the console and converts them to an array.
    public class NumberConsoleInputHelper
    {
        // Input sequence of integers, conversion to BigInteger, return sequence.
        private BigInteger[] GetSequenceFromConsole()
        {
            BigInteger[] inputSequence = null;
            bool exitInputing = false;
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

        private BigInteger[] GetSequenceFromArg(string arg)
        {
            char delimiter = ' ';
            string[] inputSequenceString = arg.Split(delimiter);
            BigInteger[] inputSequence = null;
            try
            {
                for (int i = 0; i < inputSequenceString.Length; i++)
                {
                    inputSequence[i] = BigInteger.Parse(inputSequenceString[i]);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, the entered sequence is incorrect! Try to type it in the console.");
                inputSequence = GetSequenceFromConsole(); 
            }
            return inputSequence;
        }

        // 
        public BigInteger[] GetInputNumberSequence(string arg)
        {
            BigInteger[] sequence = null;
            if (arg != null)
            {
                sequence = GetSequenceFromArg(arg);
            }
            else
            {
                sequence = GetSequenceFromConsole();
            }
            return sequence;
        }
    }
}
