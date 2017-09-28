using System;

namespace task_DEV_9
{
  public class ConsoleHandler
  {
    // Output into the console the result of random char sequences swap operation.
    public void PrintSwapResult(string changed, string changing, string swapResult)
    {
      Console.WriteLine("Changed string: {0}, changing string: {1}", changed, changing);
      Console.WriteLine("String after swap operation:: {0}", swapResult);
    }

    public void PrintNotValidDataMessage()
    {
      Console.WriteLine("The amount of inputed strings is incorrect. There should be 2 strings.");
    }
  }
}
