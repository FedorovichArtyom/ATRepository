using System;

namespace task_DEV_13
{
  // Console arguments validator.
  public class ConsoleArgsValidator
  {
    // User parameteres input.
    public string StrPrice { get; set; }
    public string StrEfficiency { get; set; }
    public string StrCriterion { get; set; }

    public ConsoleArgsValidator(string[] args)
    {
      StrPrice = args[0];
      StrEfficiency = args[1];
      StrCriterion = args[2];
    }

    // Return max price, inputted by customer, if it is valid.
    // Throw FormatException if price is in non-valid format.
    // Throw ArgumentOutOfRangeException if price value isn't valid.
    public decimal GetValidPrice()
    {
      decimal price = Convert.ToDecimal(StrPrice, AssemblyInfo.culture);
      if (price < AssemblyInfo.MIN_PRICE)
      {
        throw new ArgumentOutOfRangeException();
      }
      return price;
    }

    // Return min required efficiency, inputted by customer, if it is valid.
    // Throw FormatException if efficiency is in non-valid format. 
    // Throw ArgumentOutOfRangeException if efficiency value isn't valid.
    public int GetValidEfficiency()
    {
      // If the string number contains .0 at the end remove this because it still 
      // an integer number. This rule is not spread for greater amount of zeros after
      // dot, cause it means that input is incorrect.
      int minPossibleNumberLength = 2;
      int dotPosition = StrEfficiency.Length - 2;
      int zeroAfterDotPosition = StrEfficiency.Length - 1;
      if (StrEfficiency.Length > minPossibleNumberLength)
      {
        if ((StrEfficiency[dotPosition] == '.') &&
          (StrEfficiency[zeroAfterDotPosition] == '0'))
        {
          StrEfficiency = StrEfficiency.Remove(StrEfficiency.Length - 2);
        }
      }

      int efficiency = Convert.ToInt32(StrEfficiency, AssemblyInfo.culture);
      if (efficiency < AssemblyInfo.MIN_EFFICIENCY)
      {
        throw new ArgumentOutOfRangeException();
      }
      return efficiency;
    }

    // Return criterion of dev group creation if it is valid.
    // Throw ArgumentException if criterion isn't valid.
    public DevGroupCreationCriterion GetValidCriterion()
    {
      DevGroupCreationCriterion criterion;
      if (StrCriterion == AssemblyInfo.VALID_MAX_EFFICIENCY_CRITERION)
      {
        criterion = DevGroupCreationCriterion.MaxEfficiency;
      }
      else if (StrCriterion == AssemblyInfo.VALID_MIN_COST_CRITERION)
      {
        criterion = DevGroupCreationCriterion.MinCost;
      }
      else if (StrCriterion == AssemblyInfo.VALID_MIN_NON_JUNIOR_DEVS_AMOUNT_CRITERION)
      {
        criterion = DevGroupCreationCriterion.MinJuniorDevsAmount;
      }
      else 
      {
        throw new ArgumentException();
      }
      return criterion;
    }
  }
}
