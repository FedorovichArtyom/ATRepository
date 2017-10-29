using System;

namespace task_DEV_7
{
    class InputHandler
    {
        public Sides GetSidesFromConsole()
        {
            bool parsed = false;
            double[] inputSidesValues = new double[AssemblyInfo.triangleSidesNumber];
            do
            {
                Console.WriteLine(AssemblyInfo.enterTriangleSides);
                string inputString = Console.ReadLine();
                string[] inputStringArray = SplitInputString(inputString);

                try
                {
                    CheckForCorrectInputValuesNumber(inputStringArray);
                    inputSidesValues = ParseInputArray(inputStringArray);
                    parsed = true;
                }
                catch (InvalidNumberOfSidesException)
                {
                    parsed = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine(AssemblyInfo.unparsedInputValues);
                    parsed = false;
                }
            } while (!parsed);

            return new Sides() { First = inputSidesValues[0], Second = inputSidesValues[1],
                Third = inputSidesValues[2] };
        }

        private string[] SplitInputString(string inputString)
        {
            char[] delimiters = { ' ' }; 
            return inputString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
        private void CheckForCorrectInputValuesNumber(string[] inputStringArray)
        {
            if (inputStringArray.Length != AssemblyInfo.triangleSidesNumber)
            {
                throw new InvalidNumberOfSidesException(AssemblyInfo.invalidNumberOfInputValues);
            }
        }
        private double[] ParseInputArray(string[] inputArray)
        {
            double[] parsedArray = new double[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                parsedArray[i] = Double.Parse(inputArray[i], System.Globalization.NumberStyles.AllowDecimalPoint);
            }
            return parsedArray;
        }
    }
}
