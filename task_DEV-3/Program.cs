using System;
using System.Linq;

namespace task_DEV_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a non-negative integer number.");
            string inputValue = Console.ReadLine();

            //разбиение строки числа на элементы массива
            int inputNumberPartSize = int.MaxValue.ToString().Length - 1;
            int inputNumberPartsAmount = inputValue.Length / 
                (inputNumberPartSize) + 1;
            int[] inputNumberAsArray = new int[inputNumberPartsAmount];

            try
            {  
                for (int i = 0; i < inputNumberPartsAmount - 1; i++)
                {
                    inputNumberAsArray[i] = Convert.ToInt32(inputValue.Substring(
                        (inputNumberPartsAmount - 2 - i) * (inputNumberPartSize) +
                        inputValue.Length % (inputNumberPartSize),
                        inputNumberPartSize));
                }
                inputNumberAsArray[inputNumberPartsAmount - 1] = Convert.ToInt32(inputValue.Substring
                    (0, inputValue.Length % (inputNumberPartSize)));
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, the entered number is incorrect! Exiting process.");
                Environment.Exit(-1);
            }
            
            //Вычисление всякой херни
            int[,] previousRowMembers = new int[2, inputNumberPartsAmount];
            previousRowMembers[0, 0] = 0;
            previousRowMembers[1, 0] = 1;
            int[] currentRowMember = new int[inputNumberPartsAmount];
            currentRowMember[0] = 1;

            bool completeCalculation = false;
            while (true)
            {
                //сравнение чисел
                for (int i = inputNumberPartsAmount - 1; i >= 0; i--)
                {
                    if (inputNumberAsArray[i] != currentRowMember[i])
                    {
                        if (inputNumberAsArray[i] < currentRowMember[i])
                        {
                            completeCalculation = true;
                            break;
                        }
                        if (inputNumberAsArray[i] > currentRowMember[i])
                        {
                            break;
                        }
                    }
                }

                if (completeCalculation)
                {
                    break;
                }

                //сложение чисел
                int previousDigitNumber = 0;
                for (int i = 0; i < inputNumberPartsAmount; i++)
                {
                    if ((previousRowMembers[0, i] + previousRowMembers[1, i] + previousDigitNumber).
                       ToString().Length > inputNumberPartSize)
                    {
                        currentRowMember[i] = (previousRowMembers[0, i] + previousRowMembers[1, i] +
                            previousDigitNumber) %
                            Convert.ToInt32(Math.Pow(10, inputNumberPartSize));
                        previousDigitNumber = 1;
                    }
                    else
                    {
                        currentRowMember[i] = previousRowMembers[0, i] + previousRowMembers[1, i] +
                            previousDigitNumber;
                        previousDigitNumber = 0;
                    }

                    previousRowMembers[0, i] = previousRowMembers[1, i];
                    previousRowMembers[1, i] = currentRowMember[i];
                }    
            }

            for (int i = 0; i < inputNumberPartsAmount; i++)
            {
                currentRowMember[i] = previousRowMembers[0, i];
            }
            //Вывод итогового сообщения
            string outputMessage = currentRowMember.SequenceEqual(inputNumberAsArray)
                ? "The entered number is a member of the Fibonacci sequence."
                : "The entered number isn't a member of the Fibonacci sequence.";

            Console.WriteLine(outputMessage);
        }
    }
}
