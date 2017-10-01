using System;
using System.Collections.Generic;

namespace task_DEV_10
{
  // Represents the method to get equal elements from arrays.
  public class EqualElementsSearcher
  {
    // Returns the array of equal elements in the list of arrays of doubles.
    public double[] GetEqualElementsFromArrays(List<double[]> arrays, double comparisonAccuracy)
    {
      // Merge arrays in one.
      double[] mergedArray = MergeArrays(arrays);

      // Sort arrays.
      Array.Sort(mergedArray);

      // Find equal accurate to comparisonAccuracy elements and place them in the list.
      List<double> equalElementsList = new List<double>();
      for (int i = 1; i < mergedArray.Length; i++)
      {
        if (Math.Abs(mergedArray[i] - mergedArray[i - 1]) < Math.Abs(comparisonAccuracy))
        {
          if (!equalElementsList.Contains(mergedArray[i]))
          {
            equalElementsList.Add(mergedArray[i]);
          }
        }
      }

      return equalElementsList.ToArray();
    }

    // Merge arrays of doubles in one array.
    private double[] MergeArrays(List<double[]> arrays)
    {
      // Count the length of new merged array and create it.
      int mergedArrayLength = 0;
      foreach (var array in arrays)
      {
        mergedArrayLength += array.Length;
      }
      double[] mergedArray = new double[mergedArrayLength];

      // Merge all arrays.
      int mergedArrayLastIndex = 0;
      foreach (var array in arrays)
      {
        for (int i = 0; i < array.Length; i++)
        {
          mergedArray[i + mergedArrayLastIndex] = array[i];
        }
        mergedArrayLastIndex += array.Length;
      }

      return mergedArray;
    }
  }
}
