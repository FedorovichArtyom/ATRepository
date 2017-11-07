using System;
using System.Globalization;

namespace task_DEV_7
{
  public class InputHandler
  {
    public TriangleSides GetSidesFromConsole()
    {
      bool parsed = false;
      double[] inputSidesValues = new double[AssemblyInfo.triangleSidesNumber];
      do
      {
        Console.WriteLine(AssemblyInfo.enterTriangleSides);
        string inputString = Console.ReadLine();
        char[] delimiters = { ' ' };
        string[] inputStringArray = inputString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        try
        {
          //CheckForCorrectInputValuesNumber
          if (inputStringArray.Length != AssemblyInfo.triangleSidesNumber)
          {
            throw new InvalidNumberOfSidesException(AssemblyInfo.invalidNumberOfInputValues);
          }
          inputSidesValues = ParseInputArray(inputStringArray);
          parsed = true;
        }
        catch (InvalidNumberOfSidesException ex)
        {
          parsed = false;
          Console.WriteLine(AssemblyInfo.invalidNumberOfInputValues);
        }
        catch (FormatException ex)
        {
          parsed = false;
          Console.WriteLine(AssemblyInfo.unparsedInputValues);
        }
        catch (OverflowException ex)
        {
          parsed = false;
          Console.WriteLine(AssemblyInfo.overflowSidesValues);
        }
      } while (!parsed);

      return new TriangleSides()
      {
        First = inputSidesValues[0],
        Second = inputSidesValues[1],
        Third = inputSidesValues[2]
      };
    }

    private double[] ParseInputArray(string[] inputArray)
    {
      double[] parsedArray = new double[inputArray.Length];
      for (int i = 0; i < inputArray.Length; i++)
      {
        CultureInfo cultureInfo = new CultureInfo(AssemblyInfo.inputDataCultureFormat);
        parsedArray[i] = Convert.ToDouble(inputArray[i], cultureInfo);
      }
      return parsedArray;
    }
  }
}
