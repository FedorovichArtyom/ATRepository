using System.IO;
using System.Collections.Generic;

namespace task_DEV_9
{
  // Current program reads two strings from file and change random char sequence
  // from one string to another random char sequence from the second string.
  class Program
  {
    static void Main(string[] args)
    {
      string[] dataFromFile = new FileReader().GetStringsFromCustomFile();
      ConsoleHandler consoleHandler = new ConsoleHandler();

      // If the data contain less or more than 2 strings.
      if (dataFromFile.Length != 2)
      {
        consoleHandler.PrintNotValidDataMessage();
        return;
      }
      
      string changedStr = dataFromFile[0];
      string changingStr = dataFromFile[1];
      string swapResult = new StringContentChanger().SwapRandomCharSequence(changedStr, changingStr);

      consoleHandler.PrintSwapResult(changedStr, changingStr, swapResult);
    } 
  }
}
