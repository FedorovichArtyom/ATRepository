using System;

namespace task_DEV_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a non-negative integer number.");
            string inputValue = Console.ReadLine();

            //try catch
            int inputNumber = Convert.ToInt32(inputValue);

            int[] previousRowMembers = new int[2];
            previousRowMembers[0] = 0;
            previousRowMembers[1] = 1;
            int currentRowMember = 1;

            while (currentRowMember < inputNumber)
            {
                currentRowMember = previousRowMembers[0] + previousRowMembers[1];
                previousRowMembers[0] = previousRowMembers[1];
                previousRowMembers[1] = currentRowMember;
            }

            string outputMessage = (currentRowMember == inputNumber) || (inputNumber == 0)
                ? "The entered number is a member of the Fibonacci sequence."
                : "The entered number isn't a member of the Fibonacci sequence.";

            Console.WriteLine(outputMessage);
        }
    }
}
