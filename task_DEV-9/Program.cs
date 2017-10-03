using System.IO;
using System.Collections.Generic;
using System;

namespace task_DEV_9
{
  // Current program reads two strings from file and change random char sequence
  // from one string to another random char sequence from the second string.
  class Program
  {
    static void Main(string[] args)
    {
      string[] dataFromFile = null;
      try
      {
        dataFromFile = new FileReader().GetStringsFromCustomFile();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return;
      }

      // If the data contain less or more than 2 strings.
      if ((dataFromFile.Length != 2) && (dataFromFile != null))
      {
        Console.WriteLine(AssemblyInfo.notValidDataAmountMessage);
        return;
      }
      
      string changedStr = dataFromFile[0];
      string changingStr = dataFromFile[1];
      string swapResult = new StringContentChanger().SwapRandomCharSequence(changedStr, changingStr);

      Console.WriteLine(AssemblyInfo.beforeSwapOperationMessage, changedStr, changingStr);
      Console.WriteLine(AssemblyInfo.afterSwapOperationMessage, swapResult);
    } 
  }
}
