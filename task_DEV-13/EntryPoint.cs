using System;

namespace task_DEV_13
{
  // Defines an appropriate group of developers for the custom client.
  // Input: from args format - "'price' 'efficiency' 'criterion'".
  public class EntryPoint
  {
    static void Main(string[] args)
    {
      // Get program parameters.
      ConsoleArgsValidator validator = new ConsoleArgsValidator(args);
      decimal price;
      int efficiency;
      DevGroupCreationCriterion criterion;
      try
      {
        price = validator.GetValidPrice();
        efficiency = validator.GetValidEfficiency();
        criterion = validator.GetValidCriterion();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      //
    }
  }
}
