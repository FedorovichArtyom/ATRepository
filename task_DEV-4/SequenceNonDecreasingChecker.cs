using System;
using System.Numerics;

namespace task_DEV_4
{
    // Class describing the method of checking integer number sequence for non-decreasing.
    public class SequenceNonDecreasingChecker
    {
        // A method examines whether a sequence entered in console is non-decreasing.
        public void CheckForNonDecreasingArg(string arg)
        {
            char delimiter = ' ';
            string[] inputSequenceString = arg.Split(delimiter);
            BigInteger[] inputSequence = new BigInteger[inputSequenceString.Length];

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
                CheckForNonDecreasingConsole();
            }

            bool isNonDecreasing = true;
            BigInteger previousMember = inputSequence[0];
            foreach (BigInteger member in inputSequence)
            {
                if (member < previousMember)
                {
                    isNonDecreasing = false;
                    break;
                }
                previousMember = member;
            }
            string outputMessage = isNonDecreasing
                ? "The entered sequence is non-decreasing."
                : "The entered sequence isn't non-decreasing.";
            Console.WriteLine(outputMessage);
        }

        // A method examines whether a sequence entered in console is non-decreasing.
        public void CheckForNonDecreasingConsole()
        {
            BigInteger prevMember = 0;
            bool exitInputing = false;
            while (!exitInputing)
            {
                Console.WriteLine("Enter next member of the sequence:");
                try
                {
                    BigInteger currentMember = BigInteger.Parse(Console.ReadLine());
                    if (currentMember < prevMember)
                    {
                        Console.WriteLine("The entered sequence isn't non-decreasing.");
                        exitInputing = true;
                    }
                    else
                    {
                        Console.WriteLine("The entered sequence is non-decreasing.");
                    }
                    prevMember = currentMember;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry, the entered number is incorrect! Try again.");
                }
            }
        }
    }
}
