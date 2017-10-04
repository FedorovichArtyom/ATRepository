﻿using System;
using System.Collections.Generic;

namespace task_DEV_10
{
  class Program
  {
    static void Main(string[] args)
    {
      // Get the list of arrays from the text file.
      List<double[]> arrays = null;
      try
      {
        arrays = new FileReader().GetArraysOfDoubleFromCustomFile();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return;
      }

      // Output the original arrays.
      Console.WriteLine("Original arrays:");
      foreach (var array in arrays)
      {
        Console.Write("[ ");
        foreach (var element in array)
        {
          Console.Write(element + " ");
        }
        Console.WriteLine(']');
      }

      // Output the resulting array of equal elements.
      var equalElementsArray = new EqualElementsSearcher().GetEqualElementsFromArrays(arrays, 
        AssemblyInfo.comparisonAccuracy);

      Console.Write("\nResult:\n[ ");
      foreach (var element in equalElementsArray)
      {
        Console.Write(element + " ");
      }
      Console.WriteLine(']');
    }
  }
}
